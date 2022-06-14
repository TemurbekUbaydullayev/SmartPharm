using SmartPharm.Models;

namespace SmartPharm.IRepository
{
    internal interface IAdminRepository
    {
        public void AddAdmin(Adminstration admin);
        public string ReadPassword();
        public bool IsAdmin(Adminstration admin);
        public bool SimilarityCheck(string path, Adminstration admin);
        public void DeleteAdmin();

        public void ShowAdmin();
    }
}
