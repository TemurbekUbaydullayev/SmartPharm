using System;
using ConsoleTables;
using SmartPharm.Models;
using SmartPharm.IRepository;
using SmartPharm.Service;
using SmartPharm.Extension;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace SmartPharm.Repository
{
    public class AdminRepository : IAdminRepository
    {
        public void AddAdmin(Adminstration admin)
        {
            string json = File.ReadAllText(Constants.AdminJsonPath);
            IList<Adminstration> AdminList = JsonConvert.DeserializeObject<List<Adminstration>>(json);

            int count = 0;

            bool result = SimilarityCheck(Constants.AdminJsonPath, admin);

            if (!result)
            {
                AdminList.Add(new Adminstration()
                {
                    FirstName = admin.FirstName,
                    LastName = admin.LastName,
                    Age = admin.Age,
                    Login = admin.Login,
                    Password = admin.Password,
                    Contact = admin.Contact
                });

                string res = JsonConvert.SerializeObject(AdminList);
                File.WriteAllText(Constants.AdminJsonPath, res);
                //count++;

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
                    Console.WriteLine("\nAdd admin successfully\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nThis user is available\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void DeleteAdmin()
        {
            Console.Write("Enter the admin phone number: ");
            string Contact = Console.ReadLine();

            string json = File.ReadAllText(Constants.AdminJsonPath);
            IList<Adminstration> AdminList = JsonConvert.DeserializeObject<IList<Adminstration>>(json);
            var admins = AdminList.Where(x => x.Contact == Contact).ToList();

            bool result = false;
            foreach (var admin1 in admins)
            {
                if (admin1.Contact == Contact) result = true;
            }

            if (result)
            {
                foreach (var admin in admins)
                {
                    AdminList.Remove(admin);
                }

                string res = JsonConvert.SerializeObject(AdminList);
                File.WriteAllText(Constants.AdminJsonPath, res);

                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nDelete admin successfuly\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            { 
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nAdmin not found\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public bool IsAdmin(Adminstration admin)
        {
            bool result = false;

            string json = File.ReadAllText(Constants.AdminJsonPath);
            IList<Adminstration> AdminstList = JsonConvert.DeserializeObject<List<Adminstration>>(json);

            foreach (var iteam in AdminstList)
            {
                if (iteam.FirstName != "" || iteam.FirstName != null)
                {
                    if (iteam.Login == admin.Login)
                    {

                        if (iteam.Password == admin.Password) result = true;
                    }
                }
            }
            return result;
        }

        public string ReadPassword()
        {
            string password = "";
            while (true)
            {
            place:
                try
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.Escape:
                            return null;
                        case ConsoleKey.Enter:
                            return password;
                        case ConsoleKey.Backspace:
                            password = password.Substring(0, (password.Length - 1));
                            Console.Write("\b \b");
                            break;
                        default:
                            password += key.KeyChar;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("*");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                }
                catch
                {
                    goto place;
                }
            }
        }

        public void ShowAdmin()
        {
            string json = File.ReadAllText(Constants.AdminJsonPath);
            IList<Adminstration> AdminList = JsonConvert.DeserializeObject<List<Adminstration>>(json);

            var adminTable = new ConsoleTable("Admin", "Age", "Phone number", "Login");
            foreach (var admin in AdminList)
            {
                if (admin.FirstName != "" && admin.LastName != null)
                {
                    adminTable.AddRow(admin.FirstName + " " + admin.LastName,
                        admin.Age,
                        admin.Contact,
                        admin.Login
                        );
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            adminTable.Write();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public bool SimilarityCheck(string path, Adminstration admin)
        {
            string json = File.ReadAllText(Constants.AdminJsonPath);
            IList<Adminstration> AdminList = JsonConvert.DeserializeObject<List<Adminstration>>(json);
            foreach (var iteam in AdminList)
            {
                if (iteam.FirstName != null && iteam.FirstName != "")
                {
                    if (iteam.Contact == admin.Contact) return true;
                }
            }
            return false;
        }
    }

}
