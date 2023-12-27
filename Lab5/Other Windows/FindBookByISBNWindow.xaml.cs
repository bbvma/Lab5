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
    /// Interaction logic for FindBookByISBNWindow.xaml
    /// </summary>
    public partial class FindBookByISBNWindow : Window
    {
        private readonly Catalog catalog;
        public FindBookByISBNWindow(Catalog catalog)
        {
            InitializeComponent();
            this.catalog = catalog;
        }
        private void btnFindByISBN_Click(object sender, RoutedEventArgs e)
        {
            string find = FindISBN.Text;
            var result = catalog.SearchByISBN(find);
            new ResultWindow(result).ShowDialog();
            Close();
        }
    }
}
