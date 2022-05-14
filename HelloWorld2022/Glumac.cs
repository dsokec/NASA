using System;
using System.Collections.Generic;
using System.Text;

namespace Glumci_i_filmovi.Models
{
    public class Glumac
    {
        public string Ime;
        public string Prezime;
        public static List<Glumac> Glumci = new List<Glumac>();
        public Glumac(string ime, string prezime)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            Glumci.Add(this);
        }
        public string Ispis()
        {
            return this.Ime + " " + this.Prezime;
        }
    }
}
