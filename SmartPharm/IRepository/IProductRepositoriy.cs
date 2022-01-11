using SmartPharm.Models;
using SmartPharm.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPharm.IRepository
{
    public interface IProductRepositoriy
    {
        public void AddProduct(Product product);
        public void DeleteProduct();
        public void ShowProduct();
        internal bool SimilarityCheckk(string path, Product product);
    }
}
