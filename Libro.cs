using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML
{
    public class Libro
    {
        public string Titolo { get; private set; }
        public int NumPagine { get; private set; }
        public int Disponibilità { get; private set; }
        public string ISBN { get; private set; }

        public Libro(string titolo, int numPagine, int disponibilità, string isbn)
        {
            Titolo = titolo;
            NumPagine = numPagine;
            Disponibilità = disponibilità;
            ISBN = isbn;
        }

        public int AumentaQuantità(int tot)
        {
            if (tot > 0) Disponibilità += tot;
            return Disponibilità;
        }

        public int DiminuisciQuantità(int tot)
        {
            if (tot > 0 && tot <= Disponibilità) Disponibilità -= tot;
            return Disponibilità;
        }

        public bool ControllaDisponibilità() => Disponibilità > 0;
    }
}
