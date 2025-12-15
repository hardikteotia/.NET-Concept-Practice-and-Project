using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCrud.Model
{
    internal class ProductModel
    {
        //here we create a model which is literally like a table so that we can use it to hold the value with table
        public int pID { get; set; }

        public string pName { get; set; }

        public double pPrice { get; set; }

        public bool isProductAvailable { get; set; } = true;
        public override string ToString()
        {
            return string.Format("pId = {0}, pName = {1}, pPrice = {2}, isProductAvailable = {4}",pID,pName,pPrice, isProductAvailable);
        }
    }
}
