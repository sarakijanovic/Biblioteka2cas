using System;
using System.Collections.Generic;
using System.IO;
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

namespace Biblioteka2cas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string KnjigeFile = @"C:\Users\MAXX\Documents\knjige.txt";
        private const string AutoriFile = @"C:\Users\MAXX\Documents\autori.txt";

        private List<Knjiga> knjige = new List<Knjiga>();
        private List<Autor> autori = new List<Autor>();
        private bool prikazujemoKnjige = true;

        public MainWindow()
        {
            InitializeComponent();
            UcitajPodatke();
            PrikaziKnjige();
        }

        private void UcitajPodatke()
        {
            // Učitaj knjige
            if (File.Exists(KnjigeFile))
            {
                var lines = File.ReadAllLines(KnjigeFile);
                knjige = lines.Select(line =>
                {
                    var parts = line.Split(',');
                    return new Knjiga(parts[0], parts[1], DateTime.Parse(parts[2]));
                }).ToList();
            }

            // Učitaj autore
            if (File.Exists(AutoriFile))
            {
                var lines = File.ReadAllLines(AutoriFile);
                autori = lines.Select(line =>
                {
                    var parts = line.Split(',');
                    return new Autor(parts[0], parts[1]);
                }).ToList();
            }
        }

        private void SnimiPodatke()
        {
            // Snimi knjige
            var knjigeLines = knjige.Select(k => $"{k.Naziv},{k.Autor},{k.Datum:yyyy-MM-dd HH:mm:ss}");
            File.WriteAllLines(KnjigeFile, knjigeLines);

            // Snimi autore
            var autoriLines = autori.Select(a => $"{a.Ime},{a.Prezime}");
            File.WriteAllLines(AutoriFile, autoriLines);
        }

        private void PrikaziKnjige()
        {
            dataGridCentralni.ItemsSource = null;
            dataGridCentralni.ItemsSource = knjige;
            prikazujemoKnjige = true;
        }

        private void PrikaziAutore()
        {
            dataGridCentralni.ItemsSource = null;
            dataGridCentralni.ItemsSource = autori;
            prikazujemoKnjige = false;
        }

        private void btnPrikaziKnjige_Click(object sender, RoutedEventArgs e)
        {
            PrikaziKnjige();
        }

        private void btnPrikaziAutore_Click(object sender, RoutedEventArgs e)
        {
            PrikaziAutore();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            if (prikazujemoKnjige)
            {
                DodajKnjigu();
            }
            else
            {
                DodajAutora();
            }
            
        }

        private void DodajKnjigu()
        {
            var prozor = new DodajKnjiguProzor();
            if (prozor.ShowDialog() == true)
            {
                knjige.Add(prozor.Knjiga);
                SnimiPodatke();
                PrikaziKnjige();
            }
        }

        private void DodajAutora()
        {
            var prozor = new DodajAutoraProzor();
            if (prozor.ShowDialog() == true)
            {
                autori.Add(prozor.Autor);
                SnimiPodatke();
                PrikaziAutore();
            }
        }


    }
}

