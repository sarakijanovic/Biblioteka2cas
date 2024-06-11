using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka2cas
{
    public class Autor
    {
        //ako imate ID od obelezja u vasim projektima bilo bi dobro da dodate neku sekvencu
        /// <summary>
        /// /ili slicno tako da se ta vrednost automatski podesava a ne da korisnik bira ID
        /// </summary>
        public int id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public Autor(string ime, string prezime)
        {
            Ime = ime;
            Prezime = prezime;
        }
    }
}
