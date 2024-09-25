using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.entity
{
    class BillItem
    {
        int id, quantity, billid, foodid;
        float price;


        public int Id { get => id; set => id = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int Billid { get => billid; set => billid = value; }
        public int Foodid { get => foodid; set => foodid = value; }
        public float Price { get => price; set => price = value; }
    }
}
