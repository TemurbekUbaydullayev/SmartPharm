using System;
using System.IO;
using SmartPharm.Service;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SmartPharm.Models;
using SmartPharm.IRepository;
using ConsoleTables;

namespace SmartPharm.Repository
{
    internal class ProductRepository : Product, IProductRepository
    {
        public static void AddProduct(ProductRepository product)
        {
            string json = File.ReadAllText(Constants.ProductJsonPath);
            IList<ProductRepository> ProductList = JsonConvert.DeserializeObject<IList<ProductRepository>>(json);

            int count = 0;
            bool result = product.SimilarityCheckk(Constants.ProductJsonPath, product);
            if (result == false)
            {
                ProductList.Add(new ProductRepository()
                {
                    Name = product.Name,
                    Enterprise = product.Enterprise,
                    State = product.State,
                    Cost = product.Cost,
                    Residue = product.Residue,
                    Trim = product.Trim,
                    Barcode = product.Barcode
                });
                if (product.Barcode.Length == 13)
                {
                    string res = JsonConvert.SerializeObject(ProductList);
                    File.WriteAllText(Constants.ProductJsonPath, res);
                    count++;
                }
                if (count == 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nError\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nAdd medicine successfully\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThis medicine is available\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public static void DeleteProduct()
        {
            Console.Write("Enter product barcode: ");
            string Barcode = Console.ReadLine();

            string json = File.ReadAllText(Constants.ProductJsonPath);
            IList<ProductRepository> ProductList = JsonConvert.DeserializeObject<IList<ProductRepository>>(json);
            var products = ProductList.Where(x => x.Barcode == Barcode).ToList();

            bool result = false;
            foreach (var product in products)
            {
                if (product.Barcode == Barcode) result = true;
            }

            if(result == true)
            {
                foreach(var product in products)
                {
                    ProductList.Remove(product);
                }

                string res = JsonConvert.SerializeObject(ProductList);
                File.WriteAllText(Constants.ProductJsonPath, res);

                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nDelete medicine successfuly\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nMedicine not found\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public static void ShowProduct()
        {
            string json = File.ReadAllText(Constants.ProductJsonPath);
            IList<ProductRepository> ProductList = JsonConvert.DeserializeObject<List<ProductRepository>>(json);

            var productTable = new ConsoleTable("Medicine", "Enterprise", "State", "Cost", "Residue", "Trim", "Barcode");
            foreach (var product in ProductList)
            {
                if (product.Name != "" && product.Name != null)
                {
                    productTable.AddRow(
                        product.Name,
                        product.Enterprise,
                        product.State,
                        product.Cost,
                        product.Residue,
                        product.Trim,
                        product.Barcode
                        );
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            productTable.Write();
            Console.ForegroundColor = ConsoleColor.White;
        }

        internal bool SimilarityCheckk(string path, ProductRepository product)
        {
            string json = File.ReadAllText(Constants.ProductJsonPath);
            IList<ProductRepository> ProductList = JsonConvert.DeserializeObject<List<ProductRepository>>(json);
            foreach (var iteam in ProductList)
            {
                if (iteam.Name != null && iteam.Name != "")
                {
                    if (iteam.Barcode == product.Barcode) return true;
                }
            }
            return false;
        }

    }
}
