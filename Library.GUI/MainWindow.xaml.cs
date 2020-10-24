using Library.Data.Model;
using Library.Logic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Library.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        KonyvtarLogic logic = new KonyvtarLogic();
        public MainWindow()
        {
            InitializeComponent();
            lbTest.ItemsSource = logic.elements;
        }

        private void New_item(object sender, RoutedEventArgs e)
        {

        }

        private void Update_item(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_item(object sender, RoutedEventArgs e)
        {
            if (lbTest.SelectedItem != null)
            {
                logic.Delete(lbTest.SelectedItem as Konyvtarak);
            }
            lbTest.Items.Refresh();
        }
    }
}
