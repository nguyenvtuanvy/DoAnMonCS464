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

        //Page danh mục

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
            GetDataCategory();
            GetDataTable();
        }

        //Page đồ uống

        List<Food> foods = new List<Food>();

        private void GetDataFood()
        {
            string query = "select f.* from Food f";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            AddDataFoods(data);
        }

        private void AddDataFoods(DataTable data)
        {
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
            GetDataFood();
            food = new Food();
            txt_idcategory.Clear();
            txt_namecategory.Clear();
            GetDataCategory();
            category = new Category();
        }

        private void ReloadPage()
        {
            ClearFoodDetails();
            GetDataFood();
            GetDataCategory();
            GetDataTable();
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

        private void btn_findfood_Click(object sender, EventArgs e)
        {
            string keyfood = txt_findfood.Text;
            string query = "SELECT * FROM Food WHERE Name LIKE '%' + @FoodName + '%'";

            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { keyfood });

            AddDataFoods(data);
        }


        //Page danh mục

        List<Category> categories = new List<Category>();

        private void GetDataCategory()
        {
            string query = "exec GetDataCategory";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            AddDataCategorys(data);
        }

        private void AddDataCategorys(DataTable data)
        {
            dtgvcategory.Columns.Clear();
            categories.Clear();

            dtgvcategory.Columns.Add("CategoryId", "Category ID");
            dtgvcategory.Columns.Add("Name", "Tên");
            dtgvcategory.Columns.Add("IsBlock", "Is Block");

            foreach (DataRow row in data.Rows)
            {
                Category category = new Category(row);

                categories.Add(category);
            }

            foreach (var item in categories)
            {
                int index = dtgvcategory.Rows.Add();
                dtgvcategory.Rows[index].Cells["CategoryId"].Value = item.Id;
                dtgvcategory.Rows[index].Cells["Name"].Value = item.Name;
                dtgvcategory.Rows[index].Cells["IsBlock"].Value = item.IsBlock;
            }
        }

        Category category = new Category();

        private void btn_viewcategory_Click(object sender, EventArgs e)
        {
            if (category != null)
            {
                txt_idcategory.Text = category.Id.ToString();
                txt_namecategory.Text = category.Name;

                if (category.IsBlock == 1)
                {
                    btn_blockcategory.Text = "Mở khoá";
                    btn_blockcategory.Tag = 1;
                }
                else
                {
                    btn_blockcategory.Text = "Khoá";
                    btn_blockcategory.Tag = 0;
                }
            }
        }

        private void dtgvcategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvcategory.Rows[e.RowIndex];

                string categoryid = row.Cells["CategoryId"].Value.ToString();
                string name = row.Cells["Name"].Value.ToString();
                string isBlock = row.Cells["isBlock"].Value.ToString();

                category = new Category
                {
                    Id = int.Parse(categoryid),
                    Name = name,
                    IsBlock = int.Parse(isBlock)
                };
            }
        }

        //Page bàn ăn

        List<Table> tables = new List<Table>();

        private void GetDataTable()
        {
            string query = "select tf.* from TableFood tf";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            AddDataTables(data);
        }

        private void AddDataTables(DataTable data)
        {
            dtgvtable.Columns.Clear();
            tables.Clear();

            dtgvtable.Columns.Add("TableId", "Table ID");
            dtgvtable.Columns.Add("Name", "Tên");
            dtgvtable.Columns.Add("Status", "Trạng thái");
            dtgvtable.Columns.Add("IsBlock", "Is Block");

            foreach (DataRow row in data.Rows)
            {
                Table table = new Table(row);

                tables.Add(table);
            }

            foreach (var item in tables)
            {
                int index = dtgvtable.Rows.Add();
                dtgvtable.Rows[index].Cells["TableId"].Value = item.Id;
                dtgvtable.Rows[index].Cells["Name"].Value = item.Name;
                dtgvtable.Rows[index].Cells["Status"].Value = item.Status;
                dtgvtable.Rows[index].Cells["IsBlock"].Value = item.IsBlock;
            }
        }
    }
}