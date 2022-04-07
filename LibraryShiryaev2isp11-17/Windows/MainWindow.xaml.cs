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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibraryShiryaev2isp11_17.Windows;

namespace LibraryShiryaev2isp11_17
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void blwbtn_Click(object sender, RoutedEventArgs e)
        {
            BookListWindow bookListWindow = new BookListWindow();
            bookListWindow.Show();
            this.Close();

        }

        private void CustList_Click(object sender, RoutedEventArgs e)
        {
            UserListWindow userListWindow = new UserListWindow();
            userListWindow.Show();
            this.Close();
        }

        private void btnGive_Click(object sender, RoutedEventArgs e)
        {
            GiveBookWindow giveBookWindow = new GiveBookWindow();
            giveBookWindow.Show();
            this.Close();
                
        }

        

        private void btdExit_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Close();
        }
    }
}
