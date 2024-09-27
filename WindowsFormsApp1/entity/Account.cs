using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.entity
{
    public class Account
    {
        int id;
        string username, fullname, password, role;
        int isBlock;

        public Account() { }

        public Account(DataRow row)
        {
            this.Id = int.Parse(row["id"].ToString());
            this.Fullname = row["fullname"].ToString();
            this.Username = row["username"].ToString();
            //this.Password = row["password"].ToString();
            this.Role = row["role"].ToString();
            this.isBlock = int.Parse(row["isBlock"].ToString());
        }

        public string Username { get => username; set => username = value; }
        public string Fullname { get => fullname; set => fullname = value; }
        public string Password { get => password; set => password = value; }
        public string Role { get => role; set => role = value; }
        public int Id { get => id; set => id = value; }
        public int IsBlock { get => isBlock; set => isBlock = value; }
    }
}
