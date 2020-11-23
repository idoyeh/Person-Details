using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfLoginScreen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            #region Select
            //DataTable dt = UserDetailsClass.Select();
            //displayDetails.ItemsSource = dt.DefaultView;
            #endregion
            UserDetailsClass searchUser = new UserDetailsClass();
            searchUser.UserID = -1;
            searchUser.FirstName = "";
            searchUser.LastName = "";

            DataTable dt = UserDetailsClass.Search(searchUser);
            displayDetails.ItemsSource = dt.DefaultView;
            
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            UserDetailsClass searchUser = new UserDetailsClass();
            if (String.IsNullOrEmpty(txtID.Text))
            {
                searchUser.UserID = -1;
            }
            else
            {
                searchUser.UserID = int.Parse(txtID.Text);
            }

            if (String.IsNullOrEmpty(txtName.Text)) // FirstName and LastName empty.
            {
                searchUser.FirstName = "";
                searchUser.LastName = "";
            }
            else
            {
                if(txtName.Text.Split(' ').Length == 2) // FirstName and LastName uses.
                {
                    searchUser.FirstName = txtName.Text.Split(' ')[0];
                    searchUser.LastName = txtName.Text.Split(' ')[1];   
                }
                else if (txtName.Text.Split(' ').Length == 1) // FirstName use, LastName empty.
                {
                    searchUser.FirstName = txtName.Text.Split(' ')[0];
                    searchUser.LastName = "";
                }
                else
                {
                    searchUser.FirstName = "-1";
                    searchUser.LastName = "-1";
                }
            }
            
            DataTable dt = UserDetailsClass.Search(searchUser);
            displayDetails.ItemsSource = dt.DefaultView;

        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            btn.Height = 50;
            btn.Width = 100;
            btn.FontSize = 20;
            btn.Content = "OK!";
            btn.Background = new SolidColorBrush(Colors.Green);
            btn.Foreground = new SolidColorBrush(Colors.Yellow);

        }

        private void DisplayDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dg = sender as DataGrid;
            DataRowView dr = dg.SelectedItem as DataRowView;
            Console.WriteLine("-----");Console.WriteLine("-----");Console.WriteLine("-----");
            if (dr != null)
            {
                UserDetailsClass displayUser = new UserDetailsClass()
                {
                    UserID = Convert.ToInt32(dr["UserID"]),
                    FirstName = dr["FirstName"].ToString(),
                    LastName = dr["LastName"].ToString(),
                    PhoneNumber = dr["PhoneNumber"].ToString(),
                    Address = dr["Address"].ToString(),
                    Gender = dr["Gender"].ToString(),
                    Description = dr["Description"].ToString()
                };
                MoveDisplayDetails_Window(displayUser);
            }

                Console.WriteLine(dr["FirstName"].ToString() + " " + dr["LastName"].ToString());
            }

        private void MoveDisplayDetails_Window(UserDetailsClass displayUser)
        {
            DisplayPersonWindow dashboardDetails = new DisplayPersonWindow();
            dashboardDetails.FillDetails(displayUser);
            dashboardDetails.Show();
            this.Close();
        }
    }

}
