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
using Microsoft.Win32;
using System.IO;


namespace LibraryShiryaev2isp11_17.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        EF.Book editBook = new EF.Book();
        bool isEdit = true;
        string pathPhoto2 = null;
        public AddBookWindow()
        {
            InitializeComponent();
            isEdit = false;
        }


        public AddBookWindow(EF.Book book)
        {

            InitializeComponent();
            if (book.Image != null)
            {
                using (MemoryStream stream = new MemoryStream(book.Image))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bitmapImage.StreamSource = stream;
                    bitmapImage.EndInit();
                    imgBook.Source = bitmapImage;
                }
            }

            tbTitle2.Text = "Изменение данных книги";
            btnAdd.Content = "Изменить";
            editBook = book;
            txtTitle.Text = editBook.Title;
            txtPublisher.Text = editBook.Publisher;
            txtInfo.Text = editBook.ShortInfo;
            txtDate.Text = editBook.DateOfPublication.ToString();
           

            isEdit = true;

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {


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
            

            if (txtDate.Text.Length > 100)
            {
                MessageBox.Show("Недоступное кол-во символов1", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (txtInfo.Text.Length > 1000)
            {
                MessageBox.Show("Недоступное кол-во символов2", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
           
            if (txtPublisher.Text.Length > 30)
            {
                MessageBox.Show("Недоступное кол-во символов4", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (txtTitle.Text.Length > 100)
            {
                MessageBox.Show("Недоступное кол-во символов5", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (isEdit)
            {
                try
                {

                    editBook.Title = txtTitle.Text;
                    editBook.ShortInfo = txtInfo.Text;
                    editBook.DateOfPublication = DateTime.Parse(txtDate.Text);
                    editBook.Publisher = txtPublisher.Text;
                   
                    AppData.Context.SaveChanges();
                    MessageBox.Show("Успех", " Книга изменена", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                    if (pathPhoto2 != null)
                    {
                        editBook.Image = File.ReadAllBytes(pathPhoto2);
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
                        EF.Book newBook = new EF.Book();

                        newBook.Title = txtTitle.Text;
                        newBook.ShortInfo = txtInfo.Text;
                        newBook.DateOfPublication = DateTime.Parse(txtDate.Text);
                        newBook.Publisher = txtPublisher.Text;
                        
                        if (pathPhoto2 != null)
                        {
                            newBook.Image = File.ReadAllBytes(pathPhoto2);
                        }
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


        private void btnChoosePhoto_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                imgBook.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                pathPhoto2 = openFileDialog.FileName;
            }

        }
    }
}