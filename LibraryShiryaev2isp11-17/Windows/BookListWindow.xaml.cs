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
using LibraryShiryaev2isp11_17.EF;
using LibraryShiryaev2isp11_17.Windows;


namespace LibraryShiryaev2isp11_17.Windows
{
    /// <summary>
    /// Логика взаимодействия для BookListWindow.xaml
    /// </summary>
    public partial class BookListWindow : Window
    {

        List<Book> BookList = new List<Book>();
        List<string> listSort = new List<string>() { "По умолчанию", "По Названию", "По Изданию", "По Используемости" };
        public BookListWindow()
        {
            InitializeComponent();
            cmbSort.ItemsSource = listSort;
            cmbSort.SelectedItem = 0;
            ListBook.ItemsSource = AppData.Context.Book.ToList();
            Filter();
        }


        private void Filter()
        {

           BookList = AppData.Context.Book.ToList();
           BookList = BookList.Where(i => i.Title.ToLower().Contains(txtSearch.Text.ToLower()) || i.Publisher.ToLower().Contains(txtSearch.Text.ToLower())).ToList();

            switch (cmbSort.SelectedIndex)
            {
                case 0:
                    BookList = BookList.OrderBy(i => i.BookID).ToList();
                    break;
                case 1:
                    BookList = BookList.OrderBy(i => i.Title).ToList();
                    break;
                case 2:
                    BookList = BookList.OrderBy(i => i.Publisher).ToList();
                    break;
                case 3:
                    BookList = BookList.OrderBy(i => i.Info).ToList();
                    break;
                default:
                    BookList = BookList.OrderBy(i => i.BookID).ToList();
                    break;
            }

            ListBook.ItemsSource = BookList;

        }


        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void btdAddBook_Click(object sender, RoutedEventArgs e)
        {
            AddBookWindow addbookListWindow = new AddBookWindow();
            addbookListWindow.Show();
        }

        private void ListBook_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Delete || e.Key == System.Windows.Input.Key.Back)
            {
                var item = ListBook.SelectedItem as EF.Book;

                try
                {
                    var resultClick = MessageBox.Show("Вы уверены?", "Подтвердите удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (resultClick == MessageBoxResult.Yes)
                    {
                        AppData.Context.Book.Remove(item);
                        AppData.Context.SaveChanges();
                        MessageBox.Show("Успех", "Книга успешно удалена", MessageBoxButton.OK, MessageBoxImage.Information);

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
