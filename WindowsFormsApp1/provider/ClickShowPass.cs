using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.provider
{
    class ClickShowPass
    {
        private static ClickShowPass instance;

        internal static ClickShowPass Instance
        {
            get { if (instance == null) instance = new ClickShowPass(); return ClickShowPass.instance; }
            private set { ClickShowPass.instance = value; }
        }

        public void ChangeShowPass(Panel panel, TextBox textBox)
        {
            panel.BackgroundImage = Image.FromFile(@"D:\new do an .net\DoAnCS464\WindowsFormsApp1\images\icon-open-eye.png");

            panel.BackgroundImageLayout = ImageLayout.Stretch;

            textBox.PasswordChar = '\0';
        }

        public void ChangeClosedPass(Panel panel, TextBox textBox)
        {
            panel.BackgroundImage = Image.FromFile(@"D:\new do an .net\DoAnCS464\WindowsFormsApp1\images\icon-closed-eye.png");

            panel.BackgroundImageLayout = ImageLayout.Stretch;

            textBox.PasswordChar = '*';
        }
    }
}
