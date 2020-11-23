using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfLoginScreen
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
            txtUsername.Focus();
        }

        private void btnSumbit_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"data source=LAPTOP-NSUOOFBL\SQLEXPRESS; initial catalog=LoginDB; integrated security=True;");

            try
            {
                if(sqlCon.State == System.Data.ConnectionState.Closed)
                {
                    sqlCon.Open();
                }
                String query = "select count(1) from tblUser where Username=@Username and Password=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.CommandType = System.Data.CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username",txtUsername.Text);
                sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Password);

                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if(count == 1)
                {
                    MainWindow dashboard = new MainWindow();
                    dashboard.Show();
                    this.Close();
                }
                else
                {
                    //MessageBox.Show("Username or Password is incorrect.");
                    MessageBox.Show(".שם משתמש וסיסמא לא תקינים");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
