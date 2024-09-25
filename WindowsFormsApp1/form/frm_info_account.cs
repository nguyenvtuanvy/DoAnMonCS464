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
    public partial class frm_info_account : Form
    {
        Account info_acc = new Account();
        public frm_info_account()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public frm_info_account(Account account)
        {
            InitializeComponent();
            info_acc = account;
            InfoAccount();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void InfoAccount()
        {
            txt_username.Text = info_acc.Username;
            txt_fullname.Text = info_acc.Fullname;
            txt_password.Text = info_acc.Password;
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
            Clear();
        }

        private void Clear()
        {
            txt_username.Text = "";
            txt_fullname.Text = "";
            txt_password.Text = "";
            txt_newpassword.Text = "";
            txt_reenter_password.Text = "";
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            if (txt_password.PasswordChar == '*')
            {
                ClickShowPass.Instance.ChangeShowPass(panel2, txt_password);
            }
            else
            {
                ClickShowPass.Instance.ChangeClosedPass(panel2, txt_password);
            }
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            if (txt_newpassword.PasswordChar == '*')
            {
                ClickShowPass.Instance.ChangeShowPass(panel3, txt_newpassword);
            }
            else
            {
                ClickShowPass.Instance.ChangeClosedPass(panel3, txt_newpassword);
            }
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            if (txt_reenter_password.PasswordChar == '*')
            {
                ClickShowPass.Instance.ChangeShowPass(panel4, txt_reenter_password);
            }
            else
            {
                ClickShowPass.Instance.ChangeClosedPass(panel4, txt_reenter_password);
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
                int result = DataProvider.Instance.ExcuteNonQuery(query, new object[] { info_acc.Id, txt_newpassword.Text });

                if (result > 0)
                {
                    MessageBox.Show("Thay đổi mật khẩu thành công");
                    info_acc.Password = txt_newpassword.Text;
                    this.Hide();
                }
            }
        }
    }
}
