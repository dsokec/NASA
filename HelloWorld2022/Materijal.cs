using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradjevniDijelovi
{
    public class Materijal
    {
        public int Id { get; set; }
        public string NazivMaterijala { get; set; }
        public float Ro { get; set; }
        public float Lambda { get; set; }

        public Materijal(int id, string naziv, float ro, float lambda)
        {
            Id = id;
            NazivMaterijala = naziv;
            Ro = ro;
            Lambda = lambda;
        }
    }
}
