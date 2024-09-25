using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.entity
{
    public class BillByTable
    {
        int billid, quantity;
        string name;
        float price, totalprice, totalbillprice;

        public BillByTable() { }

        public BillByTable(DataRow row)
        {
            this.Billid = int.Parse(row["bill_id"].ToString());
            this.Name = row["name"].ToString();
            this.Price = float.Parse(row["price"].ToString());
            this.Quantity = int.Parse(row["quantity"].ToString());
            this.Totalprice = float.Parse(row["totalprice"].ToString());
            this.Totalbillprice = float.Parse(row["totalbillprice"].ToString());
        }

        public int Billid { get => billid; set => billid = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public string Name { get => name; set => name = value; }
        public float Price { get => price; set => price = value; }
        public float Totalprice { get => totalprice; set => totalprice = value; }
        public float Totalbillprice { get => totalbillprice; set => totalbillprice = value; }
    }
}
