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
    /// Логика взаимодействия для GiveBookWindow.xaml
    /// </summary>
    public partial class GiveBookWindow : Window
    {
        List<GiveBook> giveBookList = new List<GiveBook>();
        List<string> listSort = new List<string>()
        {
            "По умолчанию",
            "По фамилии читателя",
            "По имени читателя",
            "По названию книги"
        };
        public GiveBookWindow()
        {
            InitializeComponent();
            cmbSort.ItemsSource = listSort;
            cmbSort.SelectedIndex = 0;

            Filter();
        }
        private void Filter()
        {
            giveBookList = AppData.Context.GiveBook.ToList();
            giveBookList = giveBookList.
                            Where(i => i.Customer.LastName.ToLower().Contains(txtSearch.Text.ToLower()) ||
                            i.Customer.FirstName.ToLower().Contains(txtSearch.Text.ToLower()) ||
                            i.Book.Title.ToLower().Contains(txtSearch.Text.ToLower()) ||
                            i.DateStart.Date >= dpDateStart.SelectedDate ||
                            i.DateStart.Date <= dpDateEnd.SelectedDate).ToList();

            switch (cmbSort.SelectedIndex)
            {
                case 0:
                    giveBookList = giveBookList.OrderBy(i => i.CustomerID).ToList();
                    break;
                case 1:
                    giveBookList = giveBookList.OrderBy(i => i.Customer.LastName).ToList();
                    break;
                case 2:
                    giveBookList = giveBookList.OrderBy(i => i.Customer.FirstName).ToList();
                    break;
                case 3:
                    giveBookList = giveBookList.OrderBy(i => i.Book.Title).ToList();
                    break;
                default:
                    giveBookList = giveBookList.OrderBy(i => i.CustomerID).ToList();
                    break;
            }

            GiveList.ItemsSource = giveBookList;
        }
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void listRentBook_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                if (GiveList.SelectedItem is EF.Book)
                {
                    try
                    {
                        var item = GiveList.SelectedItem as EF.Book;
                        var resultClick = MessageBox.Show("Вы уверены?", "Подтвердите удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (resultClick == MessageBoxResult.Yes)
                        {
                            AppData.Context.Book.Remove(item);
                            AppData.Context.SaveChanges();
                            MessageBox.Show("Запись успешно удалена!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                            Filter();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }

        private void btnAddRentBook_Click(object sender, RoutedEventArgs e)
        {
            AddEditGiveBook addEditGiveBook = new AddEditGiveBook();
            this.Opacity = 0.2;
            addEditGiveBook.ShowDialog();
            this.Opacity = 1;
            Filter();
        }

        private void dpDateStart_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void dpDateEnd_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void listRentBook_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var bookgive = new EF.GiveBook();

            if (GiveList.SelectedItem is EF.GiveBook)
            {
                bookgive = GiveList.SelectedItem as EF.GiveBook;
            }
            AddEditGiveBook addEditGiveBook = new AddEditGiveBook(bookgive);
            this.Opacity = 0.2;
            addEditGiveBook.ShowDialog();
            this.Opacity = 1;
            Filter();
        }
    }
}
