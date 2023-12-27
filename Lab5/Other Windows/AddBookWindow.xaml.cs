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

namespace Lab5
{
    /// <summary>
    /// Interaction logic for AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        private readonly Catalog catalog;
        public AddBookWindow(Catalog catalog)
        {
            InitializeComponent();
            this.catalog = catalog;
        }

        //действие при нажатии на кнопку "Добавить" в пункте добавить книгу
        private void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var newBook = new Book
                {
                    Title = txtTitle.Text,
                    Author = txtAuthor.Text,
                    Genres = txtGenres.Text,
                    PublicationDate = datePicker1.SelectedDate.Value.Date.ToShortDateString(),
                    Annotation = txtAnnotation.Text,
                    ISBN = txtISBN.Text
                };

                catalog.AddBook(newBook);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении книги: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
