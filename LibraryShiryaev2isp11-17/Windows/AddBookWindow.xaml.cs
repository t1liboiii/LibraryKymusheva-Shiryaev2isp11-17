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
    /// Логика взаимодействия для AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        EF.Book editBook = new EF.Book();
        bool isEdit = true;
        public AddBookWindow()
        {
            InitializeComponent();
            isEdit = false;
        }


        public AddBookWindow(EF.Book book)
        {
            InitializeComponent();
            tbTitle2.Text = "Изменение данных книги";
            btnAdd.Content = "Изменить";
            editBook = book;
            txtTitle.Text = editBook.Title;
            txtPublisher.Text = editBook.Publisher;
            txtInfo.Text = editBook.Info;
            txtDate.Text = editBook.DateOfPublication.ToString();
            txtInuse.Text = editBook.BookInUse.ToString();
            txtSubject.Text = editBook.SubjectID.ToString();
            isEdit = true;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(txtSubject.Text))
            {
                MessageBox.Show("Поле SubjectID не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Поле Title не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtInfo.Text))
            {
                MessageBox.Show("Поле Info не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDate.Text))
            {
                MessageBox.Show("Поле Date не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPublisher.Text))
            {
                MessageBox.Show("Поле Publisher не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtInuse.Text))
            {
                MessageBox.Show("Поле InUse не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
           
            if (txtDate.Text.Length > 100)
            {
                MessageBox.Show("Недоступное кол-во символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtInfo.Text.Length > 1000)
            {
                MessageBox.Show("Недоступное кол-во символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtInuse.Text.Length > 5)
            {
                MessageBox.Show("Недоступное кол-во символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtPublisher.Text.Length > 30)
            {
                MessageBox.Show("Недоступное кол-во символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            if (txtTitle.Text.Length > 100)
            {
                MessageBox.Show("Недоступное кол-во символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (isEdit)
            {
                try
                {
                    editBook.SubjectID = int.Parse(txtSubject.Text);
                    editBook.Title = txtTitle.Text;
                    editBook.Info = txtInfo.Text;
                    editBook.DateOfPublication = DateTime.Parse(txtDate.Text);
                    editBook.Publisher = txtPublisher.Text;
                    editBook.BookInUse = bool.Parse(txtInuse.Text);
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
                        EF.Book newBook = new EF.Book();
                        newBook.SubjectID = int.Parse(txtSubject.Text);
                        newBook.Title = txtTitle.Text;
                        newBook.Info = txtInfo.Text;
                        newBook.DateOfPublication = DateTime.Parse(txtDate.Text);
                        newBook.Publisher = txtPublisher.Text;
                        newBook.BookInUse = bool.Parse(txtInuse.Text);
                        AppData.Context.Book.Add(newBook);
                        AppData.Context.SaveChanges();
                        MessageBox.Show("Книга добавлена ", " Успех", MessageBoxButton.OK, MessageBoxImage.Information);
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
