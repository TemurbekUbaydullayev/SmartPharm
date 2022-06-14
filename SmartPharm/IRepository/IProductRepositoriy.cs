using SmartPharm.Models;

namespace SmartPharm.IRepository
{
    internal interface IProductRepositoriy
    {
        void AddProduct(Product product);
        void DeleteProduct();
        void ShowProduct();
    }
}
