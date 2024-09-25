using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.entity
{
    class Bill
    {
        int id, status, tableid;
        DateTime datecheckin, datecheckout;
        float totalprice;

        public Bill() { }

        public Bill(DataRow row)
        {
            this.Id = int.Parse(row["id"].ToString());
            this.Datecheckin = DateTime.Parse(row["DateCheckIn"].ToString());
            this.Datecheckout = DateTime.Parse(row["DateCheckOut"].ToString());
            this.totalprice = float.Parse(row["total_price"].ToString());
            this.Status = int.Parse(row["status"].ToString());
            this.Tableid = int.Parse(row["table_id"].ToString());
        }

        public int Id { get => id; set => id = value; }
        public int Status { get => status; set => status = value; }
        public int Tableid { get => tableid; set => tableid = value; }
        public DateTime Datecheckin { get => datecheckin; set => datecheckin = value; }
        public DateTime Datecheckout { get => datecheckout; set => datecheckout = value; }
        public float Totalprice { get => totalprice; set => totalprice = value; }
    }
}
