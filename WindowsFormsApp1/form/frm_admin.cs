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
        private frm_main mainForm;
        public frm_admin(frm_main mainForm)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.dtgvfood.CellClick += new DataGridViewCellEventHandler(this.dtgvfood_CellClick);
            this.FormClosed += new FormClosedEventHandler(this.frm_admin_FormClosed);

            this.mainForm = mainForm;
        }

        //Page danh mục
        private void frm_admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (mainForm != null && !mainForm.IsDisposed)
            {
                mainForm.RefreshMainForm();  // Gọi phương thức để refresh dữ liệu
                mainForm.Show();  // Hiển thị lại form main
                mainForm.BringToFront();  // Đưa form main lên trước
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
            GetDataAccount();
        }

        private void ClearPageStatistical()
        {
            dtgvBill.Columns.Clear();
            dtfromdate.Value = DateTime.Now;
            dttodate.Value = DateTime.Now;
        }

        //Page đồ uống

        List<Food> foods = new List<Food>();
        Food food = new Food();
        bool isViewFoodClick = false;

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

        private void dtgvfood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!isViewFoodClick)
                return;

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

            isViewFoodClick = false;
        }

        private void btn_viewfood_Click(object sender, EventArgs e)
        {
            isViewFoodClick = true;

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
            ReloadPage();
        }

        private void ReloadPage()
        {
            ClearPageStatistical();

            ClearPageFood();

            ClearPageCategory();

            ClearPageTable();

            ClearPageAccount();
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
            if (string.IsNullOrWhiteSpace(namefood))
            {
                MessageBox.Show("Vui lòng nhập tên món", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            float pricefood = (float)nb_giafood.Value;
            if (string.IsNullOrWhiteSpace(pricefood.ToString()))
            {
                MessageBox.Show("Vui lòng nhập giá đồ uống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { food.Id, namefood, categoryID, pricefood });

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thành công");
                    ClearPageFood();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");
                    ClearPageFood();
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
            if (string.IsNullOrWhiteSpace(pricefood.ToString()))
            {
                MessageBox.Show("Vui lòng nhập giá đồ uống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "exec InsertFood @Name, @Price, @CategoryId";
            try
            {
                int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { namefood, pricefood, categoryID });


                if (result > 0)
                {
                    MessageBox.Show($"Thêm thành công");
                    ClearPageFood();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                    ClearPageFood();
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

            int isBlock = Convert.ToInt32(btn_blockfood.Tag);
            isBlock = (isBlock == 0) ? 1 : 0;

            string query = "UPDATE Food " +
                "SET isBlock = @IsBlock " +
                "WHERE id = @FoodId AND " +
                "EXISTS(SELECT 1 FROM Category WHERE Category.id = Food.category_id AND Category.isBlock = 0)";

            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { isBlock, food.Id });

            if (result > 0 && isBlock == 1)
            {
                MessageBox.Show("Khoá thành công");
                ClearPageFood();
            }
            else if (result > 0 && isBlock == 0)
            {
                MessageBox.Show("Mở khoá thành công");
                ClearPageFood();
            }
            else
            {
                MessageBox.Show("Thất bại. Danh mục của món này đang bị khoá, không thể mở khoá món.");
                ClearPageFood();
            }
        }

        private void btn_findfood_Click(object sender, EventArgs e)
        {
            string keyfood = txt_findfood.Text;
            string query = "SELECT * FROM Food WHERE Name LIKE '%' + @FoodName + '%'";

            DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { keyfood });

            AddDataFoods(data);
        }

        private void ClearPageFood()
        {
            txt_findfood.Clear();
            txt_idfood.Clear();
            txt_namefood.Clear();
            btn_blockfood.Text = "Khoá";
            nb_giafood.Value = 10000;
            cb_category.SelectedValue = 0;
            food = new Food();
            GetDataFood();
        }

        //Page danh mục

        List<Category> categories = new List<Category>();
        Category category = new Category();
        bool isViewCategoryClick = false;

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

            dtgvcategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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

        private void btn_viewcategory_Click(object sender, EventArgs e)
        {
            isViewCategoryClick = true;

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
            if (!isViewCategoryClick)
                return;

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

            isViewCategoryClick = false;
        }

        private void btn_editcategory_Click(object sender, EventArgs e)
        {
            if (category.Id == 0 || category == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục và nhấn xem", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = txt_namecategory.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Vui lòng nhập tên danh mục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "update Category set name = @NameCategory where id = @CategoryId";

            try
            {
                int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { name, category.Id });

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thành công");
                    ClearPageCategory();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");
                    ClearPageCategory();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("Tên danh mục đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"SQL Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_addcategory_Click(object sender, EventArgs e)
        {
            string name = txt_namecategory.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Vui lòng nhập tên danh mục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "exec InsertCategory @NameCategory";

            try
            {
                int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { name });

                if (result > 0)
                {
                    MessageBox.Show("Thêm thành công");
                    ClearPageCategory();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                    ClearPageCategory();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("Tên danh mục đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"SQL Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_blockcategory_Click(object sender, EventArgs e)
        {
            if (category.Id == 0 || category == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục và nhấn xem", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //string query = "exec UpdateBlockCategoryById @CategoryID, @IsBlock";
            int isBlock = Convert.ToInt32(btn_blockcategory.Tag);
            isBlock = (isBlock == 0) ? 1 : 0;

            string action = isBlock == 1 ? "khoá" : "mở khoá";
            string message = $"Bạn có chắc chắn muốn {action} danh mục và các món trong danh mục không?";

            DialogResult result = MessageBox.Show(message, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ExecuteCategoryBlockAction(category.Id, isBlock);
            }
        }

        private void ExecuteCategoryBlockAction(int categoryId, int isBlock)
        {
            string query = "exec UpdateBlockCategoryById @CategoryID, @IsBlock";
            int affectedRows = DataProvider.Instance.ExcuteNonQuery(query, new object[] { categoryId, isBlock });
            string action = isBlock == 1 ? "Khoá" : "Mở khoá";

            if (affectedRows > 0)
            {
                MessageBox.Show($"{action} thành công");
                ClearPageCategory();
            }
            else
            {
                MessageBox.Show($"{action} thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearPageCategory()
        {
            txt_idcategory.Clear();
            txt_namecategory.Clear();
            btn_blockcategory.Text = "Khoá";
            GetDataCategory();
            category = new Category();
        }

        //Page bàn ăn

        List<Table> tables = new List<Table>();
        Table table = new Table();
        bool isViewTableClick = false;

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

            dtgvtable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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

        private void dtgvtable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!isViewTableClick)
                return;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvtable.Rows[e.RowIndex];

                string tableid = row.Cells["TableId"].Value.ToString();
                string name = row.Cells["Name"].Value.ToString();
                string status = row.Cells["Status"].Value.ToString();
                string isBlock = row.Cells["isBlock"].Value.ToString();

                table = new Table
                {
                    Id = int.Parse(tableid),
                    Name = name,
                    Status = int.Parse(status),
                    IsBlock = int.Parse(isBlock)
                };
            }

            isViewTableClick = false;
        }

        private void btnviewtable_Click(object sender, EventArgs e)
        {
            isViewTableClick = true;

            if (table != null)
            {
                txt_idtable.Text = table.Id.ToString();
                txt_nametable.Text = table.Name;
                txt_statustable.Text = table.Status == 0 ? "Trống" : "Bận";

                if (table.IsBlock == 1)
                {
                    btn_blocktable.Text = "Mở khoá";
                    btn_blocktable.Tag = 1;
                }
                else
                {
                    btn_blocktable.Text = "Khoá";
                    btn_blocktable.Tag = 0;
                }
            }
        }

        private void btn_edittable_Click(object sender, EventArgs e)
        {
            if (table.Id == 0 || table == null)
            {
                MessageBox.Show("Vui lòng chọn bàn trước và nhấn xem", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE TableFood SET name = @Name WHERE id = @TableID and status = 0";

            string name = txt_nametable.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Vui lòng nhập tên bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { name, table.Id });

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thành công");
                    ClearPageTable();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại, đang có khách ngồi bàn này");
                    ClearPageTable();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("Tên bàn đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"SQL Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_addtable_Click(object sender, EventArgs e)
        {
            string nameTable = txt_nametable.Text;

            if (string.IsNullOrWhiteSpace(nameTable))
            {
                MessageBox.Show("Vui lòng nhập tên bàn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "exec InsertTable @NameTable";

            try
            {
                int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { nameTable });

                if (result > 0)
                {
                    MessageBox.Show("Thêm thành công");
                    ClearPageTable();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                    ClearPageTable();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("Tên bàn đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"SQL Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_blocktable_Click(object sender, EventArgs e)
        {
            if (table.Id == 0 || table == null)
            {
                MessageBox.Show("Vui lòng chọn bàn trước và nhấn xem", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE TableFood SET isBlock = @IsBlock WHERE id = @TableID and status = 0";
            int isBlock = Convert.ToInt32(btn_blocktable.Tag);
            isBlock = (isBlock == 0) ? 1 : 0;

            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { isBlock, table.Id });

            if (result > 0 && isBlock == 1)
            {
                MessageBox.Show($"Khoá thành công");
                ClearPageTable();
            }
            else if (result > 0 && isBlock == 0)
            {
                MessageBox.Show("Mở khoá thành công");
                ClearPageTable();
            }
            else
            {
                MessageBox.Show("Thất bại, vì đang có khách ngồi bàn này");
                ClearPageTable();
            }
        }

        private void ClearPageTable()
        {
            txt_idtable.Clear();
            txt_nametable.Clear();
            txt_statustable.Clear();
            btn_blocktable.Text = "Khoá";
            table = new Table();
            GetDataTable();
        }

        //Page tài khoản
        List<Account> accounts = new List<Account>();
        Account account = new Account();
        bool isViewAccountClick = false;

        private void GetDataAccount()
        {
            string query = "select acc.id, acc.fullname, acc.username, acc.role, acc.isBlock from Account acc";
            DataTable data = DataProvider.Instance.ExcuteQuery(query);

            AddDataAccounts(data);
        }

        private void AddDataAccounts(DataTable data)
        {
            dtgvemployee.Columns.Clear();
            accounts.Clear();

            dtgvemployee.Columns.Add("AccountId", "Account ID");
            dtgvemployee.Columns.Add("Fullname", "Họ tên");
            dtgvemployee.Columns.Add("Username", "Username");
            dtgvemployee.Columns.Add("Role", "Quyền");
            dtgvemployee.Columns.Add("IsBlock", "Is Block");

            dtgvemployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataRow row in data.Rows)
            {
                Account account = new Account(row);

                accounts.Add(account);
            }

            foreach (var item in accounts)
            {
                int index = dtgvemployee.Rows.Add();
                dtgvemployee.Rows[index].Cells["AccountId"].Value = item.Id;
                dtgvemployee.Rows[index].Cells["Fullname"].Value = item.Fullname;
                dtgvemployee.Rows[index].Cells["Username"].Value = item.Username;
                dtgvemployee.Rows[index].Cells["Role"].Value = item.Role;
                dtgvemployee.Rows[index].Cells["IsBlock"].Value = item.IsBlock;
            }
        }

        private void dtgvemployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!isViewAccountClick)
                return;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgvemployee.Rows[e.RowIndex];

                string accountid = row.Cells["AccountId"].Value.ToString();
                string fullname = row.Cells["Fullname"].Value.ToString();
                string username = row.Cells["Username"].Value.ToString();
                string role = row.Cells["Role"].Value.ToString();
                string isBlock = row.Cells["isBlock"].Value.ToString();

                account = new Account
                {
                    Id = int.Parse(accountid),
                    Fullname = fullname,
                    Username = username,
                    Role = role,
                    IsBlock = int.Parse(isBlock)
                };
            }

            isViewAccountClick = false;
        }

        private void btn_viewemployee_Click(object sender, EventArgs e)
        {
            isViewAccountClick = true;

            if (account != null)
            {
                txt_username.Text = account.Username;
                txt_fullname.Text = account.Fullname;

                if (account.Role == "ADMIN")
                {
                    rd_roleadmin.Checked = true;
                }
                else
                {
                    rd_roleuser.Checked = true;
                }

                if (account.IsBlock == 0)
                {
                    rd_action.Checked = true;
                }
                else
                {
                    rd_block.Checked = true;
                }

                if (account.IsBlock == 1)
                {
                    btn_blockemployee.Text = "Mở khoá";
                    btn_blockemployee.Tag = 1;
                }
                else
                {
                    btn_blockemployee.Text = "Khoá";
                    btn_blockemployee.Tag = 0;
                }
            }
        }

        private void btn_editemployee_Click(object sender, EventArgs e)
        {
            if (account.Id == 0 || account == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản và nhấn xem", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "update Account set username = @Username, fullname = @Fullname, role = @Role where id = @AccountId";
            string username = txt_username.Text;
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fullname = txt_fullname.Text;
            if (string.IsNullOrWhiteSpace(fullname))
            {
                MessageBox.Show("Vui lòng nhập họ và tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string role = rd_roleadmin.Checked ? "ADMIN" : "USER";
            if (string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Vui lòng chọn quyền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { username, fullname, role, account.Id });

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật thành công");
                    ClearPageAccount();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại");
                    ClearPageAccount();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("Username đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"SQL Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearPageAccount()
        {
            txt_username.Clear();
            txt_password.Clear();
            txt_fullname.Clear();
            rd_action.Checked = false;
            rd_block.Checked = false;
            rd_roleadmin.Checked = false;
            rd_roleuser.Checked = false;
            btn_blockemployee.Text = "Khoá";
            account = new Account();
            GetDataAccount();
        }

        private void btn_cleartoaddempl_Click(object sender, EventArgs e)
        {
            ClearPageAccount();
            txt_password.Enabled = true;
        }

        private void btn_addemployee_Click(object sender, EventArgs e)
        {
            string username = txt_username.Text;
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fullname = txt_fullname.Text;
            if (string.IsNullOrWhiteSpace(fullname))
            {
                MessageBox.Show("Vui lòng nhập họ và tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string password = txt_password.Text;
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string role = rd_roleadmin.Checked ? "ADMIN" : "USER";
            if (string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Vui lòng chọn quyền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "exec InsertAccount @Fullname, @Username, @Password , @Role";

            try
            {
                int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { fullname, username, password, role });

                if (result > 0)
                {
                    MessageBox.Show("Thêm nhân viên thành công");
                    ClearPageAccount();
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại");
                    ClearPageAccount();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show("Username đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show($"SQL Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_blockemployee_Click(object sender, EventArgs e)
        {
            if (account.Id == 0 || account == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản và nhấn xem", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "update Account set isBlock = @IsBlock WHERE id = @AccountId";
            int isBlock = Convert.ToInt32(btn_blockemployee.Tag);
            isBlock = (isBlock == 0) ? 1 : 0;

            int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { isBlock, account.Id });

            if (result > 0 && isBlock == 1)
            {
                MessageBox.Show($"Khoá thành công");
                ClearPageAccount();
            }
            else if (result > 0 && isBlock == 0)
            {
                MessageBox.Show("Mở khoá thành công");
                ClearPageAccount();
            }
            else
            {
                MessageBox.Show("Thất bại");
                ClearPageAccount();
            }
        }

        private void btn_resetpass_Click(object sender, EventArgs e)
        {
            if (account.Id == 0 || account == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản và nhấn xem", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            frm_reset_password _Reset_Password = new frm_reset_password(account.Fullname, account);
            _Reset_Password.Show();
        }
    }
}