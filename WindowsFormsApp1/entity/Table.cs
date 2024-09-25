using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.entity
{
    class Table
    {
        int id, status;
        string name;

        public Table() { }

        public Table(DataRow row)
        {
            this.Id = int.Parse(row["id"].ToString());
            this.Name = row["name"].ToString();
            this.Status = int.Parse(row["status"].ToString());
        }

        public int Id { get => id; set => id = value; }
        public int Status { get => status; set => status = value; }
        public string Name { get => name; set => name = value; }
    }
}
