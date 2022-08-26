using System;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que deseja fazer? ");
            Console.WriteLine("1 - Abrir arquivo");
            Console.WriteLine("2 - Criar novo arquivo");
            Console.WriteLine("0 - Sair");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0:
                    System.Environment.Exit(0); break;
                case 1: 
                    Abrir(); 
                    break;
                case 2: 
                    Editar();
                    break;
                default:
                    Menu();
                    break;
            }
        }

        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Digite o caminho do arquivo que deseja abrir:");
            var path = Console.ReadLine();

            using (var file = new StreamReader(path + ".txt"))
            {
               var arquivo =  file.ReadToEnd();
                Console.WriteLine(arquivo);
            }
            Console.WriteLine("");
            Console.ReadLine();
            Menu();
        }

        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
            Console.WriteLine("--------------------------------------");
            string text = "";

            do
            {
                text += Console.ReadLine(); //Juntando o que já tinha na variável com outras coisas
                text += Environment.NewLine; //Quebrando a linha no fim de cada leitura

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
            Salvar(text);
        }

        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho para salvar o arquivo?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path)) //Using já abre e fecha o arquivo, todo objeto que passarmos ele usa e fecha       
            {
                file.Write(text);
            }
            Console.WriteLine($"Arquivo salvo com sucesso! Caminho: {path}");
            Console.ReadLine();
            Menu();
        }

        static void Main(string[] args)
        {
            Menu();
        }
    }
}
