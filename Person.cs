using System;
using System.Collections.Generic;
using System.Text;

namespace nasljedivanje
{
    // vidim da ova klasa nista od nikoga drugog ne nasljeduje
    // ova klasa je polaznica za druge klase
    public class Person
    {
        protected string RNO = "44";
        protected string name = "ram";
        /* 
         * samo ovdje imam ključnu riječ virtual
         * jer se smatra da je ovo bazna klasa
         * koja daje nasljeđe preostalim klasama
         * klase su stud i student
         */
        public virtual void GetInfo() {
            //Console.WriteLine("Name: {0}", name);
            // prethodni redak mogao sam napisati i ovako
            Console.WriteLine($"Name: {name}");
            Console.WriteLine("RNO: {0}", RNO);
            Console.WriteLine();
        }
    }
}
