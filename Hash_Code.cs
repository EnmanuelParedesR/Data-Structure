using System;
using System.Collections.Generic;
using System.IO;

namespace TrabajoLab
{

    class Program
    {
        class Person
        {
           public string fname, lname;

            public Person(string fname, string lname)
            {
                this.fname = fname;
                this.lname = lname;
            }

            public override int GetHashCode()
            {
                return fname.GetHashCode() + lname.GetHashCode() * 31;
            }


        }


        static void Main(string[] args)
        {
            Dictionary<Person, double> indice = new Dictionary<Person, double>();

            Person Jesus = new Person("Jesus", "Cristo");
            Person Jesus1 = new Person("Jesus", "Cristo");
            Person Pedro = new Person("Pedro", "Cristo");

            indice.Add(Jesus, 4.0);

            Console.WriteLine(indice.ContainsKey(Jesus1));
            Console.WriteLine(indice.ContainsKey(Pedro));
            Console.WriteLine(Jesus.Equals(Pedro));

            Console.Read();

        }
    }
}


