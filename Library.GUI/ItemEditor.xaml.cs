﻿using Library.Data.Model;
using Library.Logic;
using System.Windows;

namespace Library.GUI
{
    /// <summary>
    /// Interaction logic for ItemEditor.xaml
    /// </summary>
    public partial class ItemEditor : Window
    {
        public Konyvtarak item = new Konyvtarak();
        KonyvtarLogic logic = new KonyvtarLogic();

        public ItemEditor(Konyvtarak item) : this()
        {
            this.item = item;
            txbNev.Text = item.KonyvtarNev;
            txbCim.Text = item.Cim;
            cmbZip.SelectedItem = item.Irsz;
        }

        public ItemEditor()
        {
            InitializeComponent();
            cmbZip.ItemsSource = logic.GetIrsz();
        }

        private void SaveItem(object sender, RoutedEventArgs e)
        {
            item.KonyvtarNev = txbNev.Text;
            item.Cim = txbCim.Text;
            item.Irsz = cmbZip.SelectedItem.ToString();
            DialogResult = true;
        }

        private void CancelItem(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
