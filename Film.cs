using System;
using System.Collections.Generic;
using System.Text;

namespace Glumci_i_filmovi.Models
{
    public class Film
    {
        public string Naslov;
        public int Godina;

        public List<Glumac> Glumci = new List<Glumac>();
        public static List<Film> Filmovi = new List<Film>();
        public Film(string naslov, int godina)
        {
            this.Naslov = naslov;
            this.Godina = godina;
            Filmovi.Add(this);
        }
        public void DodajGlumca(Glumac glumac)
        {
            if (!Glumci.Contains(glumac))
            {
                Glumci.Add(glumac);
            }
        }
        public string Ispis()
        {
            string returnMe = "";
            returnMe = this.Naslov + " " + this.Godina.ToString() +
                "(";
            foreach (Glumac item in this.Glumci)
            {
                returnMe += item.Ispis() + ", ";
            }
            return returnMe + ")";
        }
    }
}
