using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPharm.Models
{
    public class Product
    {
        //internal static object product;

        public string Name { get; set; }
        public string Enterprise { get; set; }
        public string State { get; set; }
        public decimal Cost { get; set; }
        public int Residue { get; set; }
        public string Trim { get; set; }
        public string Barcode { get; set; }

    }
}
