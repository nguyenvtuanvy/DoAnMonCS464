using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.entity
{
    class Session
    {
        private static Session _instance;
        public Account CurrentAccount { get; set; }
        private Session() { }

        public static Session Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Session();
                }
                return _instance;
            }
        }

        public void ClearSession()
        {
            CurrentAccount = null;
        }
    }
}
