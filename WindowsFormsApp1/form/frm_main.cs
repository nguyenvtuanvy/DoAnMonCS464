using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.entity;
using WindowsFormsApp1.form;
using WindowsFormsApp1.provider;

namespace WindowsFormsApp1
{
    public partial class frm_main : Form
    {
        Account acc_login = new Account();
        public frm_main()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            acc_login = Session.Instance.CurrentAccount;

            if (acc_login.Role != "ADMIN")
            {
                adminToolStripMenuItem.Visible = false;
            }

            LoadDataTable();
        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_info_account _Info_Account = new frm_info_account(acc_login);
            _Info_Account.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Session.Instance.ClearSession();
            index_form.frm_Login.Show();
            this.Hide();
        }

        private frm_admin adminForm;

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (adminForm == null || adminForm.IsDisposed)
            {
                adminForm = new frm_admin(this);
                adminForm.Show();
            }
            else
            {
                adminForm.BringToFront();
            }
        }

        public void RefreshMainForm()
        {
            LoadDataTable();
            LoadDataCategory();
            if (categories.Count > 0)
            {
                categoryId = categories[0].Id;
                LoadFoodsByCategoryId(categoryId);
            }
        }

        private void frm_main_Load(object sender, EventArgs e)
        {
            LoadDataTable();
            LoadDataCategory();
            if (categories.Count > 0)
            {
                categoryId = categories[0].Id;
                LoadFoodsByCategoryId(categoryId);
            }
        }

        List<Category> categories = new List<Category>();
        int categoryId;

        private void LoadDataCategory()
        {
            categories.Clear();

            string query = "select c.* from Category c where c.isBlock = 0";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                Category category = new Category(row);

                categories.Add(category);
            }

            cb_category.DataSource = null;
            cb_category.DataSource = categories;
            cb_category.DisplayMember = "Name";
            cb_category.ValueMember = "Id";
        }

        private void cb_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_category.SelectedValue != null && int.TryParse(cb_category.SelectedValue.ToString(), out int selectedCategoryId))
            {
                categoryId = selectedCategoryId;
                LoadFoodsByCategoryId(categoryId);
            }
        }

        private void LoadFoodsByCategoryId(int categoryId)
        {
            string query = "exec GetDataFoodByCategoryId @id";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { categoryId });

            List<Food> foods = new List<Food>();

            foreach (DataRow row in data.Rows)
            {
                Food food = new Food(row);
                foods.Add(food);
            }

            cb_food.DataSource = foods;
            cb_food.DisplayMember = "Name";
            cb_food.ValueMember = "Id";
        }

        List<Table> tables = new List<Table>();

        private void LoadDataTable()
        {
            flp_table.Controls.Clear();
            tables.Clear();

            string query = "exec GetDataTable";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);


            foreach (DataRow row in data.Rows)
            {
                Table table = new Table(row);

                tables.Add(table);
            }

            cb_changtable.DataSource = tables;
            cb_changtable.DisplayMember = "Name";
            cb_changtable.ValueMember = "Id";

            foreach (var table in tables)
            {
                Button button = new Button() { Width = 80, Height = 80 };

                button.Text = table.Name + "\n" + (table.Status == 0 ? "Trống" : "Bận");
                button.Font = new Font("Times New Roman", 10F, FontStyle.Regular);
                button.Margin = new Padding(10);
                if (table.Status == 0)
                {
                    button.BackColor = Color.Green;
                }
                else
                {
                    button.BackColor = Color.Red;
                }

                button.Tag = table.Id;

                button.Click += Button_Click;

                flp_table.Controls.Add(button);
            }
        }

        private int tableid = -1;

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            tableid = (int)button.Tag;

            LoadBillItemByTableid();
        }

        private void btn_addfood_Click(object sender, EventArgs e)
        {
            if (tableid == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn trước.");
                return;
            }

            int foodId = (int)cb_food.SelectedValue;
            Food selectedFood = cb_food.SelectedItem as Food;
            float foodPrice = selectedFood.Price;

            int quantity = int.Parse(nb_foodcount.Text);

            int result = 0;
            int billId = 0;

            SqlParameter outputParam = new SqlParameter("@BillId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };
            if (lv_bill.Items.Count != 0)
            {
                string query_get_billid = "EXEC GetBillIDByTableId @TableId, @BillId OUTPUT";
                DataTable data = DataProvider.Instance.ExcuteQuery(query_get_billid, new object[] { tableid }, outputParam);

                billId = (int)outputParam.Value;
            }
            else
            {
                string query_insert_bill = "exec InsertBill @TableId, @BillId OUTPUT";

                billId = DataProvider.Instance.ExcuteNonQuery(query_insert_bill, new object[] { tableid }, outputParam);

            }

            if (billId != 0)
            {
                string query_insert_billitem = "exec InsertBillItem @BillId, @FoodId, @Quantity, @Price";
                result = DataProvider.Instance.ExcuteNonQuery(query_insert_billitem, new object[] { billId, foodId, quantity, foodPrice });
            }


            if (result > 0)
            {
                MessageBox.Show("Thêm món thành công");
                ReloadInterface();
            }
        }

        List<BillByTable> listBillByTables = new List<BillByTable>();

        private void LoadBillItemByTableid()
        {
            lv_bill.Items.Clear();
            listBillByTables.Clear();

            string query = "exec GetBillIemByTableId @TableId";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { tableid });


            foreach (DataRow row in data.Rows)
            {
                BillByTable billByTable = new BillByTable(row);

                listBillByTables.Add(billByTable);
            }

            foreach (var item in listBillByTables)
            {
                ListViewItem viewitem = new ListViewItem(item.Name.ToString());
                viewitem.SubItems.Add(item.Price.ToString());
                viewitem.SubItems.Add(item.Quantity.ToString());
                viewitem.SubItems.Add(item.Totalprice.ToString());

                lv_bill.Items.Add(viewitem);

                txt_totalprice.Text = item.Totalbillprice.ToString();
            }
        }

        private void ReloadInterface()
        {
            tableid = -1;
            LoadDataTable();
            LoadBillItemByTableid();
            nb_discount.Value = 0;
            nb_foodcount.Value = 1;
            txt_totalprice.Text = "";
        }

        private void btn_pay_Click(object sender, EventArgs e)
        {
            if (tableid == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn trước.");
                return;
            }

            if (listBillByTables.Count == 0)
            {
                MessageBox.Show("Hoá đơn trống.");
                return;
            }

            float total_price = listBillByTables[0].Totalbillprice;
            float discount = Convert.ToSingle(nb_discount.Value) / 100;
            float total_price_bill = total_price - (total_price * discount);

            string query = "exec UpdateStatusTableAndBillByTableId @TableId, @@TotalPrice";
            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { tableid, total_price_bill });

            if (result > 0)
            {
                frm_BillPay _BillPay = new frm_BillPay(listBillByTables, (total_price * discount), acc_login.Fullname);
                ReloadInterface();
                _BillPay.Show();
            }
        }

        private void btn_changtable_Click(object sender, EventArgs e)
        {
            int tableid_change = int.Parse(cb_changtable.SelectedValue.ToString());

            if (tableid == -1)
            {
                MessageBox.Show("Vui lòng chọn bàn hiện tại.");
                return;
            }

            Table currentTable = tables.FirstOrDefault(t => t.Id == tableid);
            Table destinationTable = tables.FirstOrDefault(t => t.Id == tableid_change);

            int merge = -1;

            if (currentTable.Status == 1 && destinationTable.Status == 0)
            {
                merge = 0;
            }
            else if (currentTable.Status == 1 && destinationTable.Status == 1)
            {
                merge = 1;
            }

            if (merge < 0)
            {
                MessageBox.Show("Không thể thực hiện");
                return;
            }
            else
            {
                string query = "exec ChangeTableIdInBillByTableId @TableId, @TableId_Change, @Merge";
                int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { tableid, tableid_change, merge });


                if (result > 0)
                {
                    MessageBox.Show("Chuyển Bàn Thành Công");
                    ReloadInterface();
                }
                else
                {
                    MessageBox.Show("Chuyển Bàn Thất Bại");
                    return;
                }
            }
        }
    }
}
