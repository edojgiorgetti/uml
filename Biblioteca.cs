using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML
{
    public class Biblioteca
    {
        private const int GiorniPrestito = 30;
        private int _prossimoId = 1;

        public string Indirizzo { get; private set; }
        public string Orario { get; private set; }
        public List<Libro> ListaLibri { get; } = new();
        public List<Persona> ListaUtente { get; } = new();
        public List<Prestito> ListaPrestiti { get; } = new();

        public Biblioteca(string indirizzo, string orario)
        {
            Indirizzo = indirizzo;
            Orario = orario;
        }

        public void ModificaOrario(string orario) => Orario = orario;

        public bool RegistraPrestito(Libro lib, string data, Utente user)
        {
            if (!lib.ControllaDisponibilità()) return false;
            if (!Prestito.TryParseData(data, out var inizio)) return false;

            var prestito = new Prestito(
                _prossimoId++,
                data,
                Prestito.FormattaData(inizio.AddDays(GiorniPrestito)),
                lib,
                user);

            lib.DiminuisciQuantità(1);
            ListaPrestiti.Add(prestito);
            return true;
        }

        public bool RegistraRestituzione(Libro lib, string data, Utente user)
        {
            var prestito = ListaPrestiti.FirstOrDefault(p =>
                p.Libro == lib && p.Utente == user && p.DataRestituzione == "");
            if (prestito == null || !Prestito.TryParseData(data, out _)) return false;

            prestito.DataRestituzione = data;
            lib.AumentaQuantità(1);
            return true;
        }
    }
}
