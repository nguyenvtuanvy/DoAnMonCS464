
namespace WindowsFormsApp1
{
    partial class frm_main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinTàiKhoảnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lv_bill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_totalprice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nb_discount = new System.Windows.Forms.NumericUpDown();
            this.cb_changtable = new System.Windows.Forms.ComboBox();
            this.tableFoodBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyBanCafeDataSet1 = new WindowsFormsApp1.QuanLyBanCafeDataSet1();
            this.btn_changtable = new System.Windows.Forms.Button();
            this.btn_pay = new System.Windows.Forms.Button();
            this.cb_category = new System.Windows.Forms.ComboBox();
            this.categoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyBanCafeDataSet = new WindowsFormsApp1.QuanLyBanCafeDataSet();
            this.cb_food = new System.Windows.Forms.ComboBox();
            this.btn_addfood = new System.Windows.Forms.Button();
            this.nb_foodcount = new System.Windows.Forms.NumericUpDown();
            this.flp_table = new System.Windows.Forms.FlowLayoutPanel();
            this.categoryTableAdapter = new WindowsFormsApp1.QuanLyBanCafeDataSetTableAdapters.CategoryTableAdapter();
            this.tableFoodTableAdapter = new WindowsFormsApp1.QuanLyBanCafeDataSet1TableAdapters.TableFoodTableAdapter();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nb_discount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableFoodBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanCafeDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanCafeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nb_foodcount)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thôngTinTàiKhoảnToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1230, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(79, 26);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // thôngTinTàiKhoảnToolStripMenuItem
            // 
            this.thôngTinTàiKhoảnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.thôngTinTàiKhoảnToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thôngTinTàiKhoảnToolStripMenuItem.Name = "thôngTinTàiKhoảnToolStripMenuItem";
            this.thôngTinTàiKhoảnToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(248, 34);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông tin cá nhân";
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinTàiKhoảnToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(248, 34);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lv_bill);
            this.panel2.Location = new System.Drawing.Point(624, 131);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(594, 421);
            this.panel2.TabIndex = 2;
            // 
            // lv_bill
            // 
            this.lv_bill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lv_bill.HideSelection = false;
            this.lv_bill.Location = new System.Drawing.Point(0, 0);
            this.lv_bill.Name = "lv_bill";
            this.lv_bill.Size = new System.Drawing.Size(594, 423);
            this.lv_bill.TabIndex = 0;
            this.lv_bill.UseCompatibleStateImageBehavior = false;
            this.lv_bill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Giá";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Số lượng";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.Width = 100;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txt_totalprice);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.nb_discount);
            this.panel3.Controls.Add(this.cb_changtable);
            this.panel3.Controls.Add(this.btn_changtable);
            this.panel3.Controls.Add(this.btn_pay);
            this.panel3.Location = new System.Drawing.Point(624, 560);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(594, 100);
            this.panel3.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(175, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "Giảm Giá (%)";
            // 
            // txt_totalprice
            // 
            this.txt_totalprice.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_totalprice.Location = new System.Drawing.Point(340, 62);
            this.txt_totalprice.Name = "txt_totalprice";
            this.txt_totalprice.ReadOnly = true;
            this.txt_totalprice.Size = new System.Drawing.Size(109, 30);
            this.txt_totalprice.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(344, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 23);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tổng Tiền";
            // 
            // nb_discount
            // 
            this.nb_discount.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nb_discount.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nb_discount.Location = new System.Drawing.Point(179, 64);
            this.nb_discount.Name = "nb_discount";
            this.nb_discount.Size = new System.Drawing.Size(125, 30);
            this.nb_discount.TabIndex = 11;
            this.nb_discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cb_changtable
            // 
            this.cb_changtable.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_changtable.FormattingEnabled = true;
            this.cb_changtable.Location = new System.Drawing.Point(6, 62);
            this.cb_changtable.Name = "cb_changtable";
            this.cb_changtable.Size = new System.Drawing.Size(133, 30);
            this.cb_changtable.TabIndex = 9;
            // 
            // tableFoodBindingSource
            // 
            this.tableFoodBindingSource.DataMember = "TableFood";
            this.tableFoodBindingSource.DataSource = this.quanLyBanCafeDataSet1;
            // 
            // quanLyBanCafeDataSet1
            // 
            this.quanLyBanCafeDataSet1.DataSetName = "QuanLyBanCafeDataSet1";
            this.quanLyBanCafeDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btn_changtable
            // 
            this.btn_changtable.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_changtable.Location = new System.Drawing.Point(6, 16);
            this.btn_changtable.Name = "btn_changtable";
            this.btn_changtable.Size = new System.Drawing.Size(133, 40);
            this.btn_changtable.TabIndex = 8;
            this.btn_changtable.Text = "Chuyển bàn";
            this.btn_changtable.UseVisualStyleBackColor = true;
            this.btn_changtable.Click += new System.EventHandler(this.btn_changtable_Click);
            // 
            // btn_pay
            // 
            this.btn_pay.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pay.Location = new System.Drawing.Point(472, 24);
            this.btn_pay.Name = "btn_pay";
            this.btn_pay.Size = new System.Drawing.Size(119, 70);
            this.btn_pay.TabIndex = 7;
            this.btn_pay.Text = "Thanh toán";
            this.btn_pay.UseVisualStyleBackColor = true;
            this.btn_pay.Click += new System.EventHandler(this.btn_pay_Click);
            // 
            // cb_category
            // 
            this.cb_category.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_category.FormattingEnabled = true;
            this.cb_category.Location = new System.Drawing.Point(624, 51);
            this.cb_category.Name = "cb_category";
            this.cb_category.Size = new System.Drawing.Size(378, 30);
            this.cb_category.TabIndex = 4;
            this.cb_category.SelectedIndexChanged += new System.EventHandler(this.cb_category_SelectedIndexChanged);
            // 
            // categoryBindingSource
            // 
            this.categoryBindingSource.DataMember = "Category";
            this.categoryBindingSource.DataSource = this.quanLyBanCafeDataSet;
            // 
            // quanLyBanCafeDataSet
            // 
            this.quanLyBanCafeDataSet.DataSetName = "QuanLyBanCafeDataSet";
            this.quanLyBanCafeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cb_food
            // 
            this.cb_food.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_food.FormattingEnabled = true;
            this.cb_food.Location = new System.Drawing.Point(624, 91);
            this.cb_food.Name = "cb_food";
            this.cb_food.Size = new System.Drawing.Size(378, 30);
            this.cb_food.TabIndex = 5;
            // 
            // btn_addfood
            // 
            this.btn_addfood.Location = new System.Drawing.Point(1019, 51);
            this.btn_addfood.Name = "btn_addfood";
            this.btn_addfood.Size = new System.Drawing.Size(119, 70);
            this.btn_addfood.TabIndex = 6;
            this.btn_addfood.Text = "Thêm món";
            this.btn_addfood.UseVisualStyleBackColor = true;
            this.btn_addfood.Click += new System.EventHandler(this.btn_addfood_Click);
            // 
            // nb_foodcount
            // 
            this.nb_foodcount.Location = new System.Drawing.Point(1154, 77);
            this.nb_foodcount.Name = "nb_foodcount";
            this.nb_foodcount.Size = new System.Drawing.Size(64, 26);
            this.nb_foodcount.TabIndex = 7;
            this.nb_foodcount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nb_foodcount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // flp_table
            // 
            this.flp_table.Location = new System.Drawing.Point(13, 51);
            this.flp_table.Name = "flp_table";
            this.flp_table.Size = new System.Drawing.Size(605, 609);
            this.flp_table.TabIndex = 8;
            // 
            // categoryTableAdapter
            // 
            this.categoryTableAdapter.ClearBeforeFill = true;
            // 
            // tableFoodTableAdapter
            // 
            this.tableFoodTableAdapter.ClearBeforeFill = true;
            // 
            // frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 672);
            this.Controls.Add(this.flp_table);
            this.Controls.Add(this.nb_foodcount);
            this.Controls.Add(this.btn_addfood);
            this.Controls.Add(this.cb_food);
            this.Controls.Add(this.cb_category);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm_main";
            this.Text = "Quản Lý Quán Cà Phê";
            this.Load += new System.EventHandler(this.frm_main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nb_discount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableFoodBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanCafeDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyBanCafeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nb_foodcount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinTàiKhoảnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cb_category;
        private System.Windows.Forms.ComboBox cb_food;
        private System.Windows.Forms.Button btn_addfood;
        private System.Windows.Forms.NumericUpDown nb_foodcount;
        private System.Windows.Forms.FlowLayoutPanel flp_table;
        private System.Windows.Forms.Button btn_pay;
        private System.Windows.Forms.Button btn_changtable;
        private System.Windows.Forms.ComboBox cb_changtable;
        private System.Windows.Forms.NumericUpDown nb_discount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_totalprice;
        private System.Windows.Forms.Label label2;
        private QuanLyBanCafeDataSet quanLyBanCafeDataSet;
        private System.Windows.Forms.BindingSource categoryBindingSource;
        private QuanLyBanCafeDataSetTableAdapters.CategoryTableAdapter categoryTableAdapter;
        private System.Windows.Forms.ListView lv_bill;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private QuanLyBanCafeDataSet1 quanLyBanCafeDataSet1;
        private System.Windows.Forms.BindingSource tableFoodBindingSource;
        private QuanLyBanCafeDataSet1TableAdapters.TableFoodTableAdapter tableFoodTableAdapter;
    }
}

