using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.provider
{
    class DataProvider
    {
        private static DataProvider instance;

        string connectionstr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\new do an .net\DoAnCS464\WindowsFormsApp1\QLQuanCaPhe.mdf"";Integrated Security=True";

        internal static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        public DataTable ExcuteQuery(string query, object[] parameter = null, SqlParameter outputParam = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionstr))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listpara = query.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                    int i = 0;
                    for (int j = 0; j < listpara.Length; j++)
                    {
                        var item = listpara[j];

                        if (item.Contains('@'))
                        {
                            // Kiểm tra xem có OUTPUT hay không
                            if (j + 1 < listpara.Length && listpara[j + 1].Equals("OUTPUT", StringComparison.OrdinalIgnoreCase))
                            {
                                // Nếu gặp OUTPUT thì dừng
                                break;
                            }

                            if (i < parameter.Length)
                            {
                                cmd.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }
                }

                // Thêm tham số đầu ra nếu có
                if (outputParam != null)
                {
                    cmd.Parameters.Add(outputParam);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);

                // Nếu có outputParam thì set lại giá trị sau khi thực thi query
                if (outputParam != null)
                {
                    outputParam.Value = cmd.Parameters[outputParam.ParameterName].Value;
                }

                connection.Close();
            }

            return data;
        }

        public int ExcuteNonQuery(string query, object[] parameter = null, SqlParameter outputParam = null)
        {
            int check = 0;
            using (SqlConnection connection = new SqlConnection(connectionstr))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(query, connection);

                // Thêm tham số đầu vào
                if (parameter != null)
                {
                    string[] listpara = query.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                    int i = 0;
                    for (int j = 0; j < listpara.Length; j++)
                    {
                        var item = listpara[j];

                        if (item.Contains('@'))
                        {
                            // kiểm tra output
                            if (j + 1 < listpara.Length && listpara[j + 1].Equals("OUTPUT", StringComparison.OrdinalIgnoreCase))
                            {
                                break;
                            }

                            if (i < parameter.Length)
                            {
                                cmd.Parameters.AddWithValue(item, parameter[i]);
                                i++;
                            }
                        }
                    }

                    // Thêm tham số đầu ra nếu có
                    if (outputParam != null)
                    {
                        cmd.Parameters.Add(outputParam);
                    }

                    check = cmd.ExecuteNonQuery();

                    if (outputParam != null)
                    {
                        return Convert.ToInt32(outputParam.Value);
                    }
                }

                return check;
            }

        }
    }
}
