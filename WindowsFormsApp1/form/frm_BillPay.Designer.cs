
namespace WindowsFormsApp1.form
{
    partial class frm_BillPay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BillPay));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_name_eploy = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_datecheckin = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_datecheckout = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lv_bill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lb_totalbill = new System.Windows.Forms.Label();
            this.lb_discount = new System.Windows.Forms.Label();
            this.lb_pay = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(420, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hoá Đơn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(22, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nhân viên:";
            // 
            // lb_name_eploy
            // 
            this.lb_name_eploy.AutoSize = true;
            this.lb_name_eploy.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_name_eploy.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_name_eploy.Location = new System.Drawing.Point(121, 151);
            this.lb_name_eploy.Name = "lb_name_eploy";
            this.lb_name_eploy.Size = new System.Drawing.Size(93, 21);
            this.lb_name_eploy.TabIndex = 2;
            this.lb_name_eploy.Text = "Nhân viên:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(383, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ngày giờ đặt đơn:";
            // 
            // lb_datecheckin
            // 
            this.lb_datecheckin.AutoSize = true;
            this.lb_datecheckin.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_datecheckin.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_datecheckin.Location = new System.Drawing.Point(536, 151);
            this.lb_datecheckin.Name = "lb_datecheckin";
            this.lb_datecheckin.Size = new System.Drawing.Size(93, 21);
            this.lb_datecheckin.TabIndex = 4;
            this.lb_datecheckin.Text = "Nhân viên:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(354, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 21);
            this.label5.TabIndex = 5;
            this.label5.Text = "Ngày giờ thanh toán:";
            // 
            // lb_datecheckout
            // 
            this.lb_datecheckout.AutoSize = true;
            this.lb_datecheckout.Font = new System.Drawing.Font("Cambria", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_datecheckout.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_datecheckout.Location = new System.Drawing.Point(536, 214);
            this.lb_datecheckout.Name = "lb_datecheckout";
            this.lb_datecheckout.Size = new System.Drawing.Size(93, 21);
            this.lb_datecheckout.TabIndex = 6;
            this.lb_datecheckout.Text = "Nhân viên:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lv_bill);
            this.panel1.Location = new System.Drawing.Point(27, 274);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(670, 240);
            this.panel1.TabIndex = 7;
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
            this.lv_bill.Size = new System.Drawing.Size(670, 240);
            this.lv_bill.TabIndex = 0;
            this.lv_bill.UseCompatibleStateImageBehavior = false;
            this.lv_bill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên món:";
            this.columnHeader1.Width = 182;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Giá";
            this.columnHeader2.Width = 95;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Số lượng";
            this.columnHeader3.Width = 89;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành tiền";
            this.columnHeader4.Width = 101;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label7.Location = new System.Drawing.Point(382, 543);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(187, 26);
            this.label7.TabIndex = 8;
            this.label7.Text = "Tổng tiền hoá đơn:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(425, 592);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(144, 26);
            this.label8.TabIndex = 9;
            this.label8.Text = "Tiền giảm giá:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label9.Location = new System.Drawing.Point(341, 639);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(228, 26);
            this.label9.TabIndex = 10;
            this.label9.Text = "Tổng tiền thanh toán:";
            // 
            // lb_totalbill
            // 
            this.lb_totalbill.AutoSize = true;
            this.lb_totalbill.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_totalbill.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_totalbill.Location = new System.Drawing.Point(575, 543);
            this.lb_totalbill.Name = "lb_totalbill";
            this.lb_totalbill.Size = new System.Drawing.Size(63, 26);
            this.lb_totalbill.TabIndex = 11;
            this.lb_totalbill.Text = "Tổng ";
            // 
            // lb_discount
            // 
            this.lb_discount.AutoSize = true;
            this.lb_discount.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_discount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_discount.Location = new System.Drawing.Point(575, 592);
            this.lb_discount.Name = "lb_discount";
            this.lb_discount.Size = new System.Drawing.Size(63, 26);
            this.lb_discount.TabIndex = 12;
            this.lb_discount.Text = "Tổng ";
            // 
            // lb_pay
            // 
            this.lb_pay.AutoSize = true;
            this.lb_pay.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_pay.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_pay.Location = new System.Drawing.Point(575, 639);
            this.lb_pay.Name = "lb_pay";
            this.lb_pay.Size = new System.Drawing.Size(67, 26);
            this.lb_pay.TabIndex = 13;
            this.lb_pay.Text = "Tổng ";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel2.Location = new System.Drawing.Point(27, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(210, 123);
            this.panel2.TabIndex = 14;
            // 
            // frm_BillPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 692);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lb_pay);
            this.Controls.Add(this.lb_discount);
            this.Controls.Add(this.lb_totalbill);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lb_datecheckout);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lb_datecheckin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_name_eploy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frm_BillPay";
            this.Text = "Hoá đơn";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_name_eploy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_datecheckin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_datecheckout;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lv_bill;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lb_totalbill;
        private System.Windows.Forms.Label lb_discount;
        private System.Windows.Forms.Label lb_pay;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Panel panel2;
    }
}