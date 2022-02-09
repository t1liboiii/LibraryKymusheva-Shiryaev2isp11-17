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
        public AddBookWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var resultClick = MessageBox.Show("Вы уверены?", "Подтвердите добавление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resultClick == MessageBoxResult.Yes)
            {
                EF.Book newBook = new EF.Book();
                newBook.SubjectID = int.Parse(txtSubject.Text);
                newBook.Title = txtTitle.Text;
                newBook.Info = txtInfo.Text;
                newBook.DateOfPublication =DateTime.Parse(txtDate.Text);
                newBook.Publisher = txtPublisher.Text;
                newBook.BookInUse =bool.Parse (txtInuse.Text);
                AppData.Context.Book.Add(newBook);
                AppData.Context.SaveChanges();
                MessageBox.Show("ura", " user dobavlen", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();

            }
        }
    }
}
