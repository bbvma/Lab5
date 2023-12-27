using Lab5.Other_Windows;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab5
{
    public partial class MainWindow : Window
    {
        static Lab5Context db = new Lab5Context();
        private Catalog catalog = new Catalog(db);
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            RefreshListView();
        }

        // при загрузке окна
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // гарантируем, что база данных создана
            db.Database.EnsureCreated();
            // загружаем данные из БД
            db.Books.Load();
            // и устанавливаем данные в качестве контекста
            DataContext = db.Books.Local.ToObservableCollection();
        }


        //действие при нажатии пункта меню "Добавить"
        private void menuItemAdd_Click(object sender, RoutedEventArgs e)
        {
            var addBookWindow = new AddBookWindow(catalog);
            addBookWindow.ShowDialog();
            RefreshListView();
        }

        private void menuItemFindByTitle_Click(object sender, RoutedEventArgs e)
        {
            new FindBookByTitleWindow(catalog).ShowDialog();
        }
        private void menuItemFindByAuthor_Click(object sender, RoutedEventArgs e)
        {
            new FindBookByAuthorWindow(catalog).ShowDialog();
        }
        private void menuItemFindByKeywords_Click(object sender, RoutedEventArgs e)
        {
            new FindBookByKeyWordsWindow(catalog).ShowDialog();
        }
        private void menuItemFindByISBN_Click(object sender, RoutedEventArgs e)
        {
            new FindBookByISBNWindow(catalog).ShowDialog();
        }
        private void menuItemExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Выйти", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
        private void RefreshListView()
        {
            // Привязка списка книг к ListView
            bookListView.ItemsSource = catalog.GetAllBooks;
        }
    }
}
