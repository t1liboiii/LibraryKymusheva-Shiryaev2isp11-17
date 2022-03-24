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
using LibraryShiryaev2isp11_17.EF;
using LibraryShiryaev2isp11_17.ClassHelper;
using LibraryShiryaev2isp11_17.Windows;



namespace LibraryShiryaev2isp11_17.Windows
{
    /// <summary>
    /// Логика взаимодействия для UserListWindow.xaml
    /// </summary>
    public partial class UserListWindow : Window
    {
        List<Customer> userList = new List<Customer>();
        List<string> listSort = new List<string>() { "По умолчанию", "По Фамилии", "По Имени", "По адресу" };

        public List<Issue> IssueList { get; private set; }

        public UserListWindow()
        {
            InitializeComponent();
            cmbSort.ItemsSource = listSort;
            cmbSort.SelectedItem = 0;
            ListCustomer.ItemsSource = AppData.Context.Customer.ToList();
            Filter();
        }


        private void Filter()
        {
            userList = AppData.Context.Customer.ToList();
            userList = userList.Where(i => i.LastName.ToLower().Contains(txtSearch.Text.ToLower()) || i.FirstName.ToLower().Contains(txtSearch.Text.ToLower())).ToList();

            switch (cmbSort.SelectedIndex)
            {
                case 0:
                    userList = userList.OrderBy(i => i.CustID).ToList();
                    break;
                case 1:
                    userList = userList.OrderBy(i => i.LastName).ToList();
                    break;
                case 2:
                    userList = userList.OrderBy(i => i.FirstName).ToList();
                    break;
                case 3:
                    userList = userList.OrderBy(i => i.Adress).ToList();
                    break;
                
                default:
                    userList = userList.OrderBy(i => i.CustID).ToList();
                    break;
            }


            ListCustomer.ItemsSource = userList;
        }
        private void IsPaidForCheack()
        {
            IssueList = AppData.Context.Issue.ToList();
            
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void btdAddClient_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow adduserListWindow = new AddUserWindow();
            adduserListWindow.Show();
            ListCustomer.ItemsSource = AppData.Context.Customer.ToString();
        }

        private void ListCustomer_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
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

        private void ListCustomer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var editCustomer = new EF.Customer();
            if (ListCustomer.SelectedItem is EF.Customer)
            {
                editCustomer = ListCustomer.SelectedItem as EF.Customer;
            }
            AddUserWindow adduserListWindow = new AddUserWindow(editCustomer);
            adduserListWindow.Show();
            ListCustomer.ItemsSource = AppData.Context.Customer.ToString();


        }

        
    }
}
