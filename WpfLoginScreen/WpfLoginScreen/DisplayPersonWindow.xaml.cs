using System;
using System.Collections.Generic;
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
using System.Xml.Serialization;
using System.IO;
using System.Drawing;

namespace WpfLoginScreen
{
    /// <summary>
    /// Interaction logic for DisplayPersonWindow.xaml
    /// </summary>
    public partial class DisplayPersonWindow : Window
    {
        public DisplayPersonWindow()
        {
            InitializeComponent();
        }

        public void FillDetails(UserDetailsClass displayUser)
        {
            txtName1.Text = displayUser.FirstName + " " + displayUser.LastName;
            txtWorkerNum.Text = "000" + displayUser.UserID.ToString();

            txtName2.Text = displayUser.FirstName + " " + displayUser.LastName;
            txtID.Text = displayUser.UserID.ToString();
            txtAddress.Text = displayUser.Address;
            txtPhoneNumber.Text = displayUser.PhoneNumber;
            txtGender.Text = displayUser.Gender;

            txtDescription.Text = displayUser.Description;

            #region another solution
            //txtName.Content = displayUser.FirstName + " " + displayUser.LastName;
            //txtID.Content = displayUser.UserID;
            //txtAddress.Content = displayUser.Address;
            //txtPhoneNumber.Content = displayUser.PhoneNumber;
            //txtGender.Content = displayUser.Gender;
            #endregion

        }

        private void BtnSaveTxt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;

                PrintDialog printDialog = new PrintDialog();
                if(printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "DetailsPerson");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
            }
            finally
            {
                this.Close();
            }
        }

        private void BtnReturnBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
            }
            finally
            {
                MainWindow dashboard = new MainWindow();
                dashboard.Show();
                this.Close();
            }
        } 

    }
}
