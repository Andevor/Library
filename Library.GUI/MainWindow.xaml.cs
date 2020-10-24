using Library.Data.Model;
using Library.Logic;
using System.Windows;

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
            ItemEditor editor = new ItemEditor();
            if(editor.ShowDialog() == true)
            {
                logic.Create(editor.item);
            }
        }

        private void Update_item(object sender, RoutedEventArgs e)
        {
            ItemEditor editor = new ItemEditor(lbTest.SelectedItem as Konyvtarak);
            if(editor.ShowDialog() == true)
            {
                logic.Update(editor.item);
            }
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
