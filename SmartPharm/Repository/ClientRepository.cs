using SmartPharm.Models;
using SmartPharm.IRepository;
using System;
using System.IO;
using ConsoleTables;
using SmartPharm.Extension;
using SmartPharm.Service;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SmartPharm.Repository
{
    public class ClientRepository : IClientRepository
    {
        public static int count = 1;
        public static decimal total = 0;

        public void SearchMedicine()
        {
            Console.Write("Enter the medicine barcode: ");
            string inputMedicineBarcode = Console.ReadLine();

            string json = File.ReadAllText(Constants.ProductJsonPath);
            IList<Product> ProductList = JsonConvert.DeserializeObject<IList<Product>>(json);

            IEnumerable<Product> query = ProductList.Where(x => x.Barcode == inputMedicineBarcode);

            foreach (var product in query)
            {
                Console.WriteLine("\n  " +
                    $"{"Name: " + product.Name}\n  " +
                    $"{"Enterprice: " + product.Enterprise}\n  " +
                    $"{"State: " + product.State}\n  " +
                    $"{"Cost: " + product.Cost}\n  " +
                    $"{"Residue: " + product.Residue}\n  " +
                    $"{"Trim: " + product.Trim}\n  "
                    );
                Console.Write("\n");
            }
            if (query.Count() == 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error, please try again");
                Console.ForegroundColor = ConsoleColor.White;
                SearchMedicine();
            }
            else
            {
                while (true)
                {
                    try
                    {
                        Console.Write("Shopping(yes or not): ");
                        string selectShop = Console.ReadLine();
                        selectShop = selectShop.Capitalize();

                        if (selectShop == "Yes")
                        {
                            Console.Write("How many will you get: ");
                            int getCount = int.Parse(Console.ReadLine());
                            Shopping(getCount, inputMedicineBarcode);
                        }
                        else if (selectShop == "Not")
                        {
                            Console.Clear();
                            MedicineMenu();
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Nothing found");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Error");
                        MedicineMenu();
                    }
                }
            }
        }
        public void Shopping(int getCount, string inputMedicineBarcode)
        {
            Console.Clear();
            string json = File.ReadAllText(Constants.ProductJsonPath);
            IList<Product> ProductList = JsonConvert.DeserializeObject<IList<Product>>(json);

            foreach (Product product in ProductList)
            {
                decimal sum = 0;
                if (product.Barcode == inputMedicineBarcode)
                {
                    sum = (decimal)(getCount * product.Cost);
                    total += sum;
                    File.AppendAllText(Constants.ReceiptTextPath, count + ". " + getCount + " " + product.Name + "          " + getCount + " * " + product.Cost + " = " + sum + " \n");
                }
            }
            count++;

            Console.Write("Get more (yes or not): ");
            string inputGetMore = Console.ReadLine();
            inputGetMore = inputGetMore.Capitalize();

            if (inputGetMore == "Yes")
            {
                Console.Clear();
                SearchMedicine();
            }
            else if (inputGetMore == "Not")
            {
                Console.Clear();
                GetReceipt();
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nothing found");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void GetReceipt()
        {
            string result = File.ReadAllText(Constants.ReceiptTextPath);
            File.Delete(Constants.ReceiptTextPath);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nPlease take your receipt....\n\n");
            Console.ForegroundColor = ConsoleColor.White;

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("                                           ");
            Console.WriteLine("                 SmartPharm                ");
            Console.WriteLine("        (71)224-36-68 (88)333-84-80        ");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine(" Cashier: Adminstrator                     ");
            Console.WriteLine("                       " + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss "));
            Console.Write("-------------------------------------------\n");
            Console.Write(result);
            Console.Write("-------------------------------------------\n");
            Console.WriteLine(" Total:                      " + total + " so'm ");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("                                           ");
            Console.WriteLine("        Thank you for your purchase        ");
            Console.WriteLine("                                           ");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("\n\nMedicineMenu(1) | Exit(2) \n >>>");
            string input = Console.ReadLine();

            count /= count;
            total /= total;

            if (input == "1")
            {
                Console.Clear();
                MedicineMenu();
            }
            else if (input == "2")
            {
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nothing found");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public void MedicineMenu()
        {
            while (true)
            {
                Console.Write("Search medicine(1) | Medicines list(2) | Main Menu(3)\n");

                string inputClientSelect = Console.ReadLine();
                if (inputClientSelect == "1")
                {
                    Console.Clear();
                    SearchMedicine();
                }
                else if (inputClientSelect == "2")
                {
                    Console.Clear();
                    ProductRepository productRepository = new ProductRepository();
                    productRepository.ShowProduct();
                }
                else if (inputClientSelect == "3")
                {
                    Console.Clear();
                    MainMenu mainMenu = new MainMenu();
                    mainMenu.Menu();
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nothing found");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
