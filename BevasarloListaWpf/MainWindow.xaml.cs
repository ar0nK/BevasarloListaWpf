using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BevasarloListaWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class ItemModel
    {
        public String Nev { get; set; }
        public int Mennyiseg { get; set; }
        public int Ar { get; set; }
        public string Kategoria { get; set; }
        public int Osszesen { get; set; }

        public ItemModel(string nev, int mennyiseg, int ar, string kategoria)
        {
            Nev = nev;
            Mennyiseg = mennyiseg;
            Ar = ar;
            Kategoria = kategoria;
            Osszesen = mennyiseg * ar;
        }
    }

    public partial class MainWindow : Window
    {
        List<ItemModel> termekek = new List<ItemModel>();
        public MainWindow()
        {
            InitializeComponent();
            termekek.Add(new ItemModel("Tej", 5, 450, "A"));
            termekek.Add(new ItemModel("Kenyer", 10, 350, "B"));
            termekek.Add(new ItemModel("Sajt", 2, 1200, "A"));
            termekek.Add(new ItemModel("Alma", 20, 200, "C"));
            termekek.Add(new ItemModel("Narancs", 15, 300, "C"));
            termekek.Add(new ItemModel("Hús", 3, 2500, "D"));
            termekek.Add(new ItemModel("Csokoládé", 7, 900, "B"));
            termekek.Add(new ItemModel("Kenyér", 1, 450, "B"));
            termekek.Add(new ItemModel("Tej", 12, 400, "A"));
            termekek.Add(new ItemModel("Sajt", 5, 1500, "D"));
            dataGrid.ItemsSource = termekek;
        }
    
    private void hozza_adas(object sender, RoutedEventArgs e)
        {
            var ujtermek = new Hozzaadas();
            if (ujtermek.ShowDialog() == true)
            {
                termekek.Add(ujtermek.ujtermek);
                dataGrid.ItemsSource = termekek;
                dataGrid.Items.Refresh();
            }
        }

        private void torles(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                termekek.Remove((ItemModel)dataGrid.SelectedItem);
                dataGrid.Items.Refresh();
            }
        }

        private void aTipus3Draga(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource=termekek.Where(t=>t.Kategoria=="A").OrderByDescending(t=>t.Osszesen).Take(3);
        }

        private void top5(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource=termekek.OrderByDescending(k=>k.Osszesen).Take(5);
        }

        private void betoltes(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource=termekek;
        }

        private void arSzerintCsokkeno(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = termekek.OrderByDescending(w => w.Ar);
        }

        private void dTipusNagyobb500(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = termekek.Where(t => t.Kategoria == "D" && t.Ar > 500);
        }

        private void tobbMint1(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = termekek.Where(k => k.Mennyiseg > 1).Select(s => new { Nev = s.Nev, Ar = s.Ar });
        }

        private void nevOsszAbc(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource=termekek.Select(d=>new {Név=d.Nev,Összesen=d.Osszesen}).OrderBy(a=>a.Név);
        }

        private void tipusDbOssz(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = termekek.OrderBy(x => x.Nev).GroupBy(d => d.Kategoria).Select(p => new { Típus = p.Key, Darab = p.Sum(s => s.Mennyiseg), Összesen = p.Sum(o => o.Osszesen) });
        }

        private void tipusAtlagar(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = termekek.GroupBy(t => t.Kategoria).Select(g => new { Kategória = g.Key, Átlagár = Math.Round(g.Average(q => q.Ar),2) });
        }

        
        private void highestTotalByCategoryBtn(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = termekek.GroupBy(t => t.Kategoria).Select(
            g => new
            {
                 Kategória = g.Key,
                 Összérték = g.Max(g => g.Osszesen)
            });
        }

        private void bMegC1000(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = termekek.Where(t => t.Kategoria == "B" || t.Kategoria == "C" && t.Ar < 1000);
        }
    } 
}