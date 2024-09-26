using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.entity
{
    class Category
    {
        int id;
        string name;
        int isBlock;

        public Category() { }

        public Category(DataRow row)
        {
            this.Id = int.Parse(row["id"].ToString());
            this.Name = row["name"].ToString();
            this.IsBlock = int.Parse(row["isBlock"].ToString());
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int IsBlock { get => isBlock; set => isBlock = value; }
    }
}
