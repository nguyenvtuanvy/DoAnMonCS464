using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.entity;
using WindowsFormsApp1.provider;

namespace WindowsFormsApp1.form
{
    public partial class frm_BillPay : Form
    {
        private List<BillByTable> listBillByTables = new List<BillByTable>();
        private float discount_bill = 0;
        string name_employee = null;

        public frm_BillPay(List<BillByTable> bills, float discount, string name_emp)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            listBillByTables = bills;
            discount_bill = discount;
            name_employee = name_emp;
            LoadDataPage();
        }

        private void LoadDataPage()
        {
            Bill bill = new Bill();
            if (listBillByTables.Count > 0)
            {
                int billid = listBillByTables[0].Billid;
                string query = "exec GetBillByBillId @BillId";
                DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { billid });

                foreach (DataRow row in data.Rows)
                {
                    bill = new Bill(row);
                }
            }

            lb_name_eploy.Text = name_employee;
            lb_datecheckin.Text = bill.Datecheckin.ToString("dd/MM/yyyy HH:mm");
            lb_datecheckout.Text = bill.Datecheckout.ToString("dd/MM/yyyy HH:mm");

            foreach (var item in listBillByTables)
            {
                ListViewItem viewitem = new ListViewItem(item.Name.ToString());
                viewitem.SubItems.Add(item.Price.ToString());
                viewitem.SubItems.Add(item.Quantity.ToString());
                viewitem.SubItems.Add(item.Totalprice.ToString());

                lv_bill.Items.Add(viewitem);

                lb_totalbill.Text = item.Totalbillprice.ToString();
            }

            lb_discount.Text = discount_bill.ToString();
            lb_pay.Text = bill.Totalprice.ToString();
        }
    }
}
