using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.entity
{
    class Food
    {
        int id, categoryid;
        string name;
        float price;
        int isBlock;

        public Food() { }

        public Food(DataRow row)
        {
            this.Id = int.Parse(row["id"].ToString());
            this.Name = row["name"].ToString();
            this.Categoryid = int.Parse(row["category_id"].ToString());
            this.Price = float.Parse(row["price"].ToString());
            this.isBlock = int.Parse(row["isBlock"].ToString());
        }

        public int Id { get => id; set => id = value; }
        public int Categoryid { get => categoryid; set => categoryid = value; }
        public string Name { get => name; set => name = value; }
        public float Price { get => price; set => price = value; }
        public int IsBlock { get => isBlock; set => isBlock = value; }
    }
}
