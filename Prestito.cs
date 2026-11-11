using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace UML
{
    

    public class Prestito
    {
        private const string Formato = "dd/MM/yyyy";

        public int IdPrestito { get; private set; }
        public string DataInizio { get; private set; }
        public string DataScadenza { get; private set; }
        public string DataRestituzione { get; set; } = "";

        // Non presenti nell'UML: servono a Biblioteca per ritrovare il prestito alla restituzione
        internal Libro Libro { get; }
        internal Utente Utente { get; }

        public Prestito(int idPrestito, string dataInizio, string dataScadenza, Libro libro, Utente utente)
        {
            IdPrestito = idPrestito;
            DataInizio = dataInizio;
            DataScadenza = dataScadenza;
            Libro = libro;
            Utente = utente;
        }

        public static string FormattaData(DateTime d) => d.ToString(Formato, CultureInfo.InvariantCulture);

        public static bool TryParseData(string s, out DateTime d) =>
            DateTime.TryParseExact(s, Formato, CultureInfo.InvariantCulture, DateTimeStyles.None, out d);

        public int CalcolaRitardo()
        {
            if (!TryParseData(DataScadenza, out var scadenza) ||
                !TryParseData(DataRestituzione, out var restituzione))
                return 0;

            return Math.Max(0, (restituzione - scadenza).Days);
        }
    }
}
