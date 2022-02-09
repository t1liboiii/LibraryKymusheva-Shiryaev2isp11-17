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
using LibraryShiryaev2isp11_17.Windows;
using LibraryShiryaev2isp11_17.ClassHelper;


namespace LibraryShiryaev2isp11_17.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
        {
            InitializeComponent();
            
            
        }

        private void btnAdd_Click_1(object sender, RoutedEventArgs e)
        {
            var resultClick = MessageBox.Show("Вы уверены?", "Подтвердите добавление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultClick == MessageBoxResult.Yes)
            {
                EF.Customer newCustomer = new EF.Customer();
                newCustomer.LastName = txtLastName.Text;
                newCustomer.FirstName = txtFirstName.Text;
                newCustomer.Phone = txtPhone.Text;
                newCustomer.Adress = txtAdress.Text;
                AppData.Context.Customer.Add(newCustomer);
                AppData.Context.SaveChanges();
                MessageBox.Show("ura"," user dobavlen", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();

            }    
        }
    }
}
