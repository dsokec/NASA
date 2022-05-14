using System;
using System.Collections.Generic;
using System.Text;

namespace nasljedivanje
{
    /* 
     * prema glavnom programu ovdje ulazim unutra i nasljedujem podatke
     * od klase Person
     */
    public class Student : Person
    {
        public string id = "ABC";
        // imamo nadjačavanje metode jer ulazimo u metodu bazne klase
        public override void GetInfo()
        {
            // ključna riječ base automatski se generira
            base.GetInfo();

            // ovo se normalno ispisuje u ovoj klasi
            Console.WriteLine("Student ID: {0}", id);
        }
    }
}
