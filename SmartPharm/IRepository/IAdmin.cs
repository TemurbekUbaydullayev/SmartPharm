using SmartPharm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPharm.IRepository
{
    internal interface IAdmin
    {
        public  string ReadPassword();
        public bool IsAdmin(Adminstration admin);
        public bool SimilarityCheck(string path, Adminstration admin);
        public void DeleteAdmin();
        public void AddAdmin(Adminstration admin);
        public void ShowAdmin();
    }
}
