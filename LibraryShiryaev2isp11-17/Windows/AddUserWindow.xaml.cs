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
        EF.Customer editCustomer = new EF.Customer();
        bool isEdit = true;
        public AddUserWindow()
        {
            InitializeComponent();
            isEdit = false;
            
        }

        public AddUserWindow(EF.Customer customer)
        {
            InitializeComponent();
            tbTitle.Text = "Изменение данных читателя";
            btnAdd.Content = "Изменить";
            editCustomer = customer;
            txtLastName.Text = editCustomer.LastName;
            txtFirstName.Text = editCustomer.FirstName;
            txtPhone.Text = editCustomer.Phone;
            txtAdress.Text = editCustomer.Adress;
            isEdit = true;
        }

        private void btnAdd_Click_1(object sender, RoutedEventArgs e)
        {
          

            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Поле Имя не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Поле Фамилия не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtAdress.Text))
            {
                MessageBox.Show("Поле Адрес не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Поле Телефон не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (txtFirstName.Text.Length > 100)
            {
                MessageBox.Show("Недоступное кол-во символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtAdress.Text.Length > 100)
            {
                MessageBox.Show("Недоступное кол-во символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtLastName.Text.Length > 100)
            {
                MessageBox.Show("Недоступное кол-во символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtPhone.Text.Length > 20)
            {
                MessageBox.Show("Недоступное кол-во символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if(isEdit)
            {
                try
                {
                    editCustomer.LastName = txtLastName.Text;
                    editCustomer.FirstName = txtFirstName.Text;
                    editCustomer.Phone = txtPhone.Text;
                    editCustomer.Adress = txtAdress.Text;
                    AppData.Context.SaveChanges();
                    MessageBox.Show("Успех", " Пользователь изменён", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString());

                  
                }
               
            }
            else
            {
                try
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
                        MessageBox.Show("Успех", " Пользователь добавлен", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
           
        }
    }
}
