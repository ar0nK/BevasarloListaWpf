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

namespace BevasarloListaWpf
{
    /// <summary>
    /// Interaction logic for Hozzaadas.xaml
    /// </summary>
    public partial class Hozzaadas : Window
    {
        public ItemModel ujtermek;
        public Hozzaadas()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ok(object sender, RoutedEventArgs e)
        {
            int mennyiseg_ = 0;
            int ar_ = 0;
            if(nev.Text==""|| !int.TryParse(mennyiseg.Text,out mennyiseg_)|| !int.TryParse(ar.Text,out ar_) || kategoria.SelectedItem == null)
            {
                MessageBox.Show("Nem megfelelő adatok a beviteli mezőkben!","Hiba",MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                ujtermek = new ItemModel(
                     nev.Text,
                     int.Parse(mennyiseg.Text),
                     int.Parse(ar.Text),
                     kategoria.Text
                );
                DialogResult = true;
            }
        }
    }
}
