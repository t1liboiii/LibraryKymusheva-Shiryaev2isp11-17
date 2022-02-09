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
using LibraryShiryaev2isp11_17.ClassHelper;
using LibraryShiryaev2isp11_17.Windows;


namespace LibraryShiryaev2isp11_17.Windows
{
    /// <summary>
    /// Логика взаимодействия для UserListWindow.xaml
    /// </summary>
    public partial class UserListWindow : Window
    {
        List<User> userList = new List<User>();
        List<string> listSort = new List<string>() { "По умолчанию", "По Фамилии", "По Имени", "По адресу" };
        public UserListWindow()
        {
            InitializeComponent();
            cmbSort.ItemsSource = listSort;
            cmbSort.SelectedIndex = 0;
            ListCustomer.ItemsSource = AppData.Context.Customer.ToList();


            Filter();
        }


        private void Filter()
        {
            
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btdAddClient_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow adduserListWindow = new AddUserWindow();
            adduserListWindow.Show();
        }

        private void ListCustomer_KeyUp(object sender,System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Delete || e.Key == System.Windows.Input.Key.Back)
            {
                var item = ListCustomer.SelectedItem as EF.Customer;

                try
                {
                    var resultClick = MessageBox.Show("Вы уверены?", "Подтвердите удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (resultClick == MessageBoxResult.Yes)
                    {
                        AppData.Context.Customer.Remove(item);
                        AppData.Context.SaveChanges();
                        MessageBox.Show("Успех", "Пользователь успешно удалён", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    
                }
                
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
