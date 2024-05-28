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

namespace Biblioteka2cas
{
    /// <summary>
    /// Interaction logic for DodajKnjiguProzor.xaml
    /// </summary>
    public partial class DodajKnjiguProzor : Window
    {
        public Knjiga Knjiga { get; private set; }

        public DodajKnjiguProzor()
        {
            InitializeComponent();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var naziv = txtNaziv.Text;
            var autor = txtAutor.Text;
            var datum = DateTime.Now;

            if (!string.IsNullOrEmpty(naziv) && !string.IsNullOrEmpty(autor))
            {
                Knjiga = new Knjiga(naziv, autor, datum);
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Popunite sva polja.");
            }
        }
    }
}

