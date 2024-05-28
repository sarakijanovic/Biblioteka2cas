using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka2cas
{
    public class Autor
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public Autor(string ime, string prezime)
        {
            Ime = ime;
            Prezime = prezime;
        }
    }
}
