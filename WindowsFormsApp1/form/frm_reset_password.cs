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
    public partial class frm_reset_password : Form
    {
        Account account_change = new Account();
        String fullname_change = "";
        public frm_reset_password(String fullname, Account account)
        {
            InitializeComponent();
            account_change = account;
            fullname_change = fullname;
            label1.Text = label1.Text + "\n" + fullname_change;
        }

        private void Clear()
        {
            txt_newpassword.Text = "";
            txt_reenter_password.Text = "";
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            if (txt_reenter_password.PasswordChar == '*')
            {
                ClickShowPass.Instance.ChangeShowPass(panel1, txt_newpassword);
            }
            else
            {
                ClickShowPass.Instance.ChangeClosedPass(panel1, txt_newpassword);
            }
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            if (txt_reenter_password.PasswordChar == '*')
            {
                ClickShowPass.Instance.ChangeShowPass(panel2, txt_reenter_password);
            }
            else
            {
                ClickShowPass.Instance.ChangeClosedPass(panel2, txt_reenter_password);
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Clear();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            bool check = CheckRe_EnterPass(txt_newpassword.Text, txt_reenter_password.Text);
            if (!check)
            {
                lb_err_re_enter_pass.Text = "Mật khẩu nhập lại không trùng khớp với mật khẩu mới";
                lb_err_re_enter_pass.Visible = true;
            }
            else
            {
                string query = "exec UpdatePasswordByID @AccountID, @NewPassword";
                int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { account_change.Id, BCrypt.Net.BCrypt.HashString(txt_newpassword.Text) });

                if (result > 0)
                {
                    MessageBox.Show("Đặt lại mật khẩu thành công");
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Đặt lại mật khẩu thất bại");
                    return;
                }
            }
        }

        private bool CheckRe_EnterPass(string newpassword, string reenter_password)
        {
            if (newpassword == reenter_password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
