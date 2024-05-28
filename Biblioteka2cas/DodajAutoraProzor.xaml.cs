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
    /// Interaction logic for DodajAutoraProzor.xaml
    /// </summary>
    public partial class DodajAutoraProzor : Window
    {
        public Autor Autor { get; private set; }

        public DodajAutoraProzor()
        {
            InitializeComponent();
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var ime = txtIme.Text;
            var prezime = txtPrezime.Text;

            if (!string.IsNullOrEmpty(ime) && !string.IsNullOrEmpty(prezime))
            {
                Autor = new Autor(ime, prezime);
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Popunite sva polja.");
            }
        }
    }
}
