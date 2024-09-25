using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.entity;
using WindowsFormsApp1.form;
using WindowsFormsApp1.provider;

namespace WindowsFormsApp1
{
    public partial class frm_login : Form
    {
        private Account account = new Account();
        public frm_login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private bool IsValidUsername(string username)
        {
            string pattern = @"^[a-zA-Z][a-zA-Z0-9._]{2,19}$";
            return Regex.IsMatch(username, pattern);
        }

        //private bool IsValidPassword(string password)
        //{
        //    string pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
        //    return Regex.IsMatch(password, pattern);
        //}

        private bool CheckInput(bool isValid)
        {
            if (txt_username.Text == "")
            {
                lb_err_username.Text = "Username là bắt buộc";
                lb_err_username.Visible = true;
                isValid = false;
            }
            else
            {
                lb_err_username.Visible = false;
            }

            if (txt_password.Text == "")
            {
                lb_err_password.Text = "Mật khẩu là bắt buộc";
                lb_err_password.Visible = true;
                isValid = false;
            }
            else
            {
                lb_err_password.Visible = false;
            }

            return isValid;
        }

        private void CloseForm()
        {
            txt_username.Text = "";
            txt_password.Text = "";
            lb_err_username.Visible = false;
            lb_err_password.Visible = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            CloseForm();
            this.Hide();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            isValid = CheckInput(isValid);

            if (isValid)
            {
                string username = txt_username.Text;
                if (!IsValidUsername(username))
                {
                    lb_err_username.Text = "Email là không hợp lệ";
                    lb_err_username.Visible = true;
                    return;
                }
                else
                {
                    lb_err_username.Visible = false;
                }

                string input_password = txt_password.Text;
                //if (!IsValidPassword(password))
                //{
                //    lb_err_password.Text = "Mật khẩu là không hợp lệ";
                //    lb_err_password.Visible = true;
                //    return;
                //}
                //else
                //{
                //    lb_err_password.Visible = false;
                //}

                try
                {
                    string query = "EXEC GetAccountByUserName @username";
                    DataTable data = DataProvider.Instance.ExcuteQuery(query, new object[] { username });

                    foreach (DataRow row in data.Rows)
                    {
                        account.Id = int.Parse(row["id"].ToString());
                        account.Fullname = row["fullname"].ToString();
                        account.Username = row["username"].ToString();
                        account.Password = row["password"].ToString();
                        account.Role = row["role"].ToString();
                    }

                    bool check_login = false;
                    if (!string.IsNullOrEmpty(input_password))
                    {
                        //check_login = BCrypt.Net.BCrypt.Verify(password, store_password);
                        check_login = input_password == account.Password ? true : false;
                    }

                    if (check_login)
                    {
                        MessageBox.Show("Đăng Nhập Thành Công");

                        CloseForm();
                        frm_main _Main = new frm_main(account);
                        _Main.Show();
                        this.Hide();
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Username hoặc Mật Khẩu không chính xác");
                    Console.WriteLine(ex.Message);
                }
            }
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
    }
}
