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
using WindowsFormsApp1.provider;

namespace WindowsFormsApp1.form
{
    public partial class frm_admin : Form
    {
        public frm_admin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.dtgvfood.CellClick += new DataGridViewCellEventHandler(this.dtgvfood_CellClick);
            this.FormClosed += new FormClosedEventHandler(this.frm_admin_FormClosed);
        }

        private frm_main mainForm;

        private void frm_admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mainForm == null || mainForm.IsDisposed)
            {
                mainForm = new frm_main();
                mainForm.Show();
            }
            else
            {
                mainForm.BringToFront();
            }
        }

        private void btn_statistical_Click(object sender, EventArgs e)
        {
            GetDataToDTDVBill();
        }

        private void GetDataToDTDVBill()
        {
            DateTime datefrom = DateTime.Parse(dtfromdate.Value.ToString());
            DateTime dateto = DateTime.Parse(dttodate.Value.ToString());

            string query = "EXEC RevenueStatisticsByDate @DateFrom, @DateTo";
            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { datefrom, dateto });

            dtgvBill.Columns.Clear();

            dtgvBill.Columns.Add("TableName", "Tên Bàn");
            dtgvBill.Columns.Add("TotalPrice", "Tổng Doanh Thu");
            dtgvBill.Columns.Add("DateCheckIn", "Ngày đặt đơn");
            dtgvBill.Columns.Add("DateCheckOut", "Ngày thanh toán");

            dtgvBill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataRow row in data.Rows)
            {
                int index = dtgvBill.Rows.Add();
                dtgvBill.Rows[index].Cells["TableName"].Value = row["table_name"];
                dtgvBill.Rows[index].Cells["TotalPrice"].Value = row["total_price"];
                dtgvBill.Rows[index].Cells["DateCheckIn"].Value = row["first_checkin"];
                dtgvBill.Rows[index].Cells["DateCheckOut"].Value = row["last_checkout"];
            }
        }

        private void frm_admin_Load(object sender, EventArgs e)
        {
            this.categoryTableAdapter.Fill(this.quanLyBanCafeDataSet2.Category);
            GetDataFood();
        }

        List<Food> foods = new List<Food>();

        private void GetDataFood()
        {
            string query = "select f.* from Food f";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            dtgvfood.Columns.Clear();
            foods.Clear();

            dtgvfood.Columns.Add("CategoryId", "Category ID");
            dtgvfood.Columns.Add("Name", "Tên");
            dtgvfood.Columns.Add("Price", "Giá");
            dtgvfood.Columns.Add("FoodId", "Food ID");
            dtgvfood.Columns.Add("IsBlock", "Is Block");

            dtgvfood.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataRow row in data.Rows)
            {
                Food food = new Food(row);

                foods.Add(food);
            }

            foreach (var item in foods)
            {
                int index = dtgvfood.Rows.Add();
                dtgvfood.Rows[index].Cells["CategoryId"].Value = item.Categoryid;
                dtgvfood.Rows[index].Cells["Name"].Value = item.Name;
                dtgvfood.Rows[index].Cells["Price"].Value = item.Price;
                dtgvfood.Rows[index].Cells["FoodId"].Value = item.Id;
                dtgvfood.Rows[index].Cells["IsBlock"].Value = item.IsBlock;
            }
        }

        Food food = new Food();

        private void dtgvfood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvfood.Rows[e.RowIndex];

                string categoryid = row.Cells["CategoryId"].Value.ToString();
                string name = row.Cells["Name"].Value.ToString();
                string price = row.Cells["Price"].Value.ToString();
                string id = row.Cells["FoodId"].Value.ToString();
                string isBlock = row.Cells["isBlock"].Value.ToString();

                food = new Food
                {
                    Id = int.Parse(id),
                    Name = name,
                    Price = float.Parse(price),
                    Categoryid = int.Parse(categoryid),
                    IsBlock = int.Parse(isBlock)
                };
            }
        }


        private void btn_viewfood_Click(object sender, EventArgs e)
        {
            if (food != null)
            {
                txt_idfood.Text = food.Id.ToString();
                txt_namefood.Text = food.Name;
                nb_giafood.Value = (decimal)food.Price;
                cb_category.SelectedValue = food.Categoryid;

                if (food.IsBlock == 1)
                {
                    btn_blockfood.Text = "Mở khoá";
                    btn_blockfood.Tag = 1;
                }
                else
                {
                    btn_blockfood.Text = "Khoá";
                    btn_blockfood.Tag = 0;
                }
            }
        }

        private void tcAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearFoodDetails();
        }

        private void ClearFoodDetails()
        {
            dtgvBill.Columns.Clear();
            txt_findfood.Clear();
            txt_idfood.Clear();
            txt_namefood.Clear();
            nb_giafood.Value = 10000;
            cb_category.SelectedValue = 0;
            btn_blockfood.Enabled = true;
            food = new Food();
        }

        private void ReloadPage()
        {
            ClearFoodDetails();
            GetDataFood();
        }

        private void btn_editfood_Click(object sender, EventArgs e)
        {
            object selectedValue = cb_category.SelectedValue;
            if (food == null || food.Id == 0 || selectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đồ uống trước và nhấn xem", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "exec UpdateFood @FoodID, @Name, @CategoryID, @Price";
            int categoryID = (int)selectedValue;
            string namefood = txt_namefood.Text;
            float pricefood = (float)nb_giafood.Value;

            try
            {
                int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { food.Id, namefood, categoryID, pricefood });

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thành công");
                    ReloadPage();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");
                    ReloadPage();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("Đồ uống này đã có trong menu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"SQL Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btn_addfood_Click(object sender, EventArgs e)
        {
            string namefood = txt_namefood.Text;
            object selectedValue = cb_category.SelectedValue;

            if (string.IsNullOrWhiteSpace(namefood))
            {
                MessageBox.Show("Vui lòng nhập tên món", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục món ăn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int categoryID = (int)selectedValue;
            float pricefood = (float)nb_giafood.Value;

            string query = "exec InsertFood @Name, @Price, @CategoryId";
            try
            {
                int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { namefood, pricefood, categoryID });


                if (result > 0)
                {
                    MessageBox.Show($"Thêm thành công");
                    ReloadPage();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                    ReloadPage();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("Đồ uống này đã có trong menu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"SQL Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_blockfood_Click(object sender, EventArgs e)
        {
            object selectedValue = cb_category.SelectedValue;
            if (food == null || food.Id == 0 || selectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn đồ uống trước", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "update Food set isBlock = @IsBlock where id = @FoodId";
            int isBlock = Convert.ToInt32(btn_blockfood.Tag);

            isBlock = (isBlock == 0) ? 1 : 0;

            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { isBlock, food.Id });

            if (result > 0 && isBlock == 1)
            {
                MessageBox.Show($"Khoá thành công");
                ReloadPage();
            }
            else if (result > 0 && isBlock == 0)
            {
                MessageBox.Show("Mở khoá thành công");
                ReloadPage();
            }
            else
            {
                MessageBox.Show("Thất bại");
                ReloadPage();
            }
        }
    }
}