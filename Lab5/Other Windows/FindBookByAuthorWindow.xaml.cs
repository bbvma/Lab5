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

namespace Lab5.Other_Windows
{
    /// <summary>
    /// Interaction logic for FindBookByAuthorWindow.xaml
    /// </summary>
    public partial class FindBookByAuthorWindow : Window
    {
        private readonly Catalog catalog;
        public FindBookByAuthorWindow(Catalog catalog)
        {
            InitializeComponent();
            this.catalog = catalog;
        }
        private void btnFindByAuthor_Click(object sender, RoutedEventArgs e)
        {
            string find = FindAuthor.Text;
            var result = catalog.SearchByAuthor(find);
            new ResultWindow(result).ShowDialog();
            Close();
        }
    }
}
