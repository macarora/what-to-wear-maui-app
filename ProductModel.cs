using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTW.Models
{
    class ProductModel
    {
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public string ImageSource { get; set; }
        public static string[] ProductCategory = new string[] { "Top", "Bottom","Outerwear","Footwear", "Accessories", "Activewear"};
        public string Category { get; set; }
        public string Color { get; set; }
    }
}

