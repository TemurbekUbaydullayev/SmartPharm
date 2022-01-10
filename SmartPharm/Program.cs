using System;

namespace SmartPharm
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("     <<<< Welcome to SmartPharm >>>>");
            Console.ForegroundColor = ConsoleColor.White;
            MainMenu.Menu();
        }
    }
}
