using System;
using System.Collections.Generic;
using SmartPharm.Models;
using SmartPharm.Repository;
using SmartPharm.Extension;
using SmartPharm.IRepository;

namespace SmartPharm
{
    internal class MainMenu
    {
        public static void Menu()
        {
            while (true)
            {
                Console.Write("\nAdminstratsiya(1) | Client(2) | Exit programm(3)\n >>> ");
                string input = Console.ReadLine();

                if(input == "1")
                {
                    Console.Clear();
                    Adminstration admin = new Adminstration();
                    Admin admin1 = new Admin();

                    #region input login and password
                    Console.Write("\nEnter login: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    admin.Login = Console.ReadLine();

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Enter password: ");
                    admin.Password = admin1.ReadPassword();
                    #endregion

                    bool result = admin1.IsAdmin(admin);
                    if (result == true)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\tLogin and password confirmed\n");
                        Console.ForegroundColor = ConsoleColor.White;
                        MissionAdmin();
                    }
                    else
                    {
                        Console.Clear();

                        //changing color of console text
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\tLogin and password error\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }


                }
                else if(input == "2")
                {
                    Console.Clear();
                    ClientRepository client = new ClientRepository();

                    Console.Write("Enter firstname: ");
                    client.FirstName = Console.ReadLine();
                    client.FirstName = client.FirstName.Capitalize();

                    Console.Write("Enter lastname: ");
                    client.LastName = Console.ReadLine();
                    client.LastName = client.LastName.Capitalize();

                    Console.Clear();
                    ClientRepository.MedicineMenu();
                    
                        
                    
                }

            }
        }
        public static void AdminMenu()
        {
            Adminstration admin = new Adminstration();
            Admin Adminstration = new Admin();

            
            while (true)
            {
                Console.Write("Add Admin(1) | Delete Admin(2) | Admin lists(3) | Go back(4)\n >>> ");
                string inputAdminSelect = Console.ReadLine();
                if (inputAdminSelect == "1")
                {
                    Console.Clear();

                    #region add input admin
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green; 
                        Console.Write("    Enter the details of the new admin:\n");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.Write("Enter FirstName: ");
                        admin.FirstName = Console.ReadLine();
                        admin.FirstName = admin.FirstName.Capitalize();

                        Console.Write("Enter LastName: ");
                        admin.LastName = Console.ReadLine();
                        admin.LastName = admin.LastName.Capitalize();

                        Console.Write("Enter Age: ");
                        admin.Age = int.Parse(Console.ReadLine());

                        Console.Write("Enter phone number: ");
                        admin.Contact = Console.ReadLine();

                        Console.Write("Enter Login: ");
                        admin.Login = Console.ReadLine();

                        Console.Write("Enter password: ");
                        admin.Password = Console.ReadLine();

                        Adminstration.AddAdmin(admin);

                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nError, please try again\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    #endregion

                }
                else if(inputAdminSelect == "2")
                {
                    Console.Clear();
                    Adminstration.DeleteAdmin();
                }
                else if(inputAdminSelect == "3")
                {
                    Console.Clear();
                    Adminstration.ShowAdmin();
                }
                else if(inputAdminSelect == "4")
                {
                    Console.Clear();
                    MissionAdmin();
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nNothing Found\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        public static void MissionAdmin()
        {
            Admin admin = new Admin();
            while (true)
            {
                Console.Write("\nProduct(1) | Adminstrator settings(2) | Main Menu(3)\n >>> ");
                string input = Console.ReadLine();
                if(input == "1")
                {
                    Console.Clear();
                    ProductMenu();
                }
                else if(input == "2")
                {
                    Console.Clear();
                    AdminMenu();
                }
                else if(input == "3")
                {
                    Console.Clear();
                    Menu();
                }

            }
        }
        public static void ProductMenu()
        {
            ProductRepository product = new ProductRepository();

            while (true)
            {
                Console.Write("\nAdd medicine(1) | Delete medicine(2) | Medicines list(3) | Go back(4)\n >>> ");
                string inputCommandSelect = Console.ReadLine();

                if(inputCommandSelect == "1")
                {
                    Console.Clear();
                    #region input data medicine
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("   Enter product informatsion:\n");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.Write("Enter medicine name: ");
                        product.Name = Console.ReadLine();
                        product.Name = product.Name.Capitalize();

                        Console.Write("Enter enterprise: ");
                        product.Enterprise = Console.ReadLine();
                        product.Enterprise = product.Enterprise.Capitalize();

                        Console.Write("Enter state: ");
                        product.State = Console.ReadLine();
                        product.State = product.State.Capitalize();

                        Console.Write("Enter cost: ");
                        product.Cost = decimal.Parse(Console.ReadLine());

                        Console.Write("Enter Residue: ");
                        product.Residue = int.Parse(Console.ReadLine());

                        Console.Write("Enter trim: ");
                        product.Trim = Console.ReadLine();

                        Console.Write("Enter barcode: ");
                        product.Barcode = Console.ReadLine();

                        ProductRepository.AddProduct(product);
                    }
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nError, please try again\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    #endregion
                }
                else if(inputCommandSelect == "2")
                {
                    Console.Clear();
                    ProductRepository.DeleteProduct();
                }
                else if(inputCommandSelect == "3")
                {
                    Console.Clear();
                    ProductRepository.ShowProduct();
                }
                else if(inputCommandSelect == "4")
                {
                    Console.Clear();
                    MissionAdmin();
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nNothing Found\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
        }
        

    }
}
