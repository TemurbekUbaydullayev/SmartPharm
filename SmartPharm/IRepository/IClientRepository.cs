using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
