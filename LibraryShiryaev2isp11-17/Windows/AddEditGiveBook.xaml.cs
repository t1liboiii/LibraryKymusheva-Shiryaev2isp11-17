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

namespace LibraryShiryaev2isp11_17.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditGiveBook.xaml
    /// </summary>
    public partial class AddEditGiveBook : Window
    {
        EF.GiveBook editBook = new EF.GiveBook();
        bool isEdit = true;

        public AddEditGiveBook()
        {
            InitializeComponent();

            cmbBook.ItemsSource = AppData.Context.Book.ToList();
            cmbBook.DisplayMemberPath = "Title";
            cmbBook.SelectedIndex = 0;

            cmbReader.ItemsSource = AppData.Context.Customer.ToList();
            cmbReader.DisplayMemberPath = "LastName";
            cmbReader.SelectedIndex = 0;

            cmbEmployer.ItemsSource = AppData.Context.Employe.ToList();
            cmbEmployer.DisplayMemberPath = "LastName";
            cmbEmployer.SelectedIndex = 0;

        }

        public AddEditGiveBook(EF.GiveBook bookgive)
        {
            InitializeComponent();

            cmbBook.ItemsSource = AppData.Context.Book.ToList();
            cmbBook.DisplayMemberPath = "Title";

            cmbReader.ItemsSource = AppData.Context.Customer.ToList();
            cmbReader.DisplayMemberPath = "LastName";

            cmbEmployer.ItemsSource = AppData.Context.Employe.ToList();
            cmbEmployer.DisplayMemberPath = "LastName";


            tbTitle.Text = "Поставить дату возврата";
            btnAddRentBook.Content = "Добавить дату";


            editBook = bookgive;

            cmbBook.SelectedIndex = bookgive.BookID - 1;
            cmbReader.SelectedIndex = bookgive.CustomerID - 1;
            dtDateStart.SelectedDate = bookgive.DateStart;
            dtDateEnd.SelectedDate = bookgive.DateEnd;
            if (cmbEmployer.SelectedIndex == (int)bookgive.EmployeID)
            {
                cmbEmployer.SelectedIndex = (int)bookgive.EmployeID - 1;
            }


            isEdit = true;
        }

        private void btnAddRentBook_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit)
            {
                try
                {
                    var resultClick = MessageBox.Show("Вы уверены?", "Подтвердите добавление даты", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (resultClick == MessageBoxResult.Yes)
                    {
                        EF.GiveBook bookgive = new EF.GiveBook();
                        bookgive.DateEnd = dtDateEnd.DisplayDate;

                        AppData.Context.SaveChanges();
                        MessageBox.Show("Дата сдачи успешно добавлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
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
                        EF.GiveBook bookgive = new EF.GiveBook();
                        bookgive.BookID = cmbBook.SelectedIndex + 1;
                        bookgive.CustomerID = cmbReader.SelectedIndex + 1;
                        bookgive.EmployeID = cmbEmployer.SelectedIndex + 1;
                        bookgive.DateStart = dtDateStart.DisplayDate;
                        bookgive.DateEnd = dtDateEnd.DisplayDate;

                        AppData.Context.GiveBook.Add(bookgive);
                        AppData.Context.SaveChanges();
                        MessageBox.Show("Запись успешно добавлена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
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
