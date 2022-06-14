namespace SmartPharm.IRepository
{
    internal interface IClientRepository
    {
        public void SearchMedicine();
        public void Shopping(int getCount, string inputMedicineBarcode);
        public void GetReceipt();
        public void MedicineMenu();
    }
}
