using System;
using SmartPharm.Extension;
using SmartPharm.IRepository;
using SmartPharm.Models;
using SmartPharm.Repository;

namespace SmartPharm
{
    internal class Program
    {
        
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("     <<<< Welcome to SmartPharm >>>>");
            Console.ForegroundColor = ConsoleColor.White;
            MainMenu mainMenu = new MainMenu();
            mainMenu.Menu();
        }   
    }
}
