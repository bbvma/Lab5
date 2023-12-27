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
    /// Interaction logic for FindBookByKeyWordsWindow.xaml
    /// </summary>
    public partial class FindBookByKeyWordsWindow : Window
    {
        private readonly Catalog catalog;
        public FindBookByKeyWordsWindow(Catalog catalog)
        {
            InitializeComponent();
            this.catalog = catalog;
        }
        private void btnFindByKeywords_Click(object sender, RoutedEventArgs e)
        {
            string find = FindKeywords.Text;
            List<string> find_List = find.Split(",").ToList();
            var result = catalog.SearchByKeywords(find_List);
            new ResultWindow(result).ShowDialog();
            Close();
        }
    }
}
