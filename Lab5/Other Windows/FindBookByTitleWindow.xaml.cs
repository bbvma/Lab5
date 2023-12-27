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
    /// Interaction logic for FindBookByTitleWindow.xaml
    /// </summary>
    public partial class FindBookByTitleWindow : Window
    {
        private readonly Catalog catalog;
        public FindBookByTitleWindow(Catalog catalog)
        {
            InitializeComponent();
            this.catalog = catalog;
        }
        private void btnFindByTitle_Click(object sender, RoutedEventArgs e)
        {
            string find = FindTitle.Text;
            var result = catalog.SearchByTitle(find);
            new ResultWindow(result).ShowDialog();
            Close();
        }
    }
}
