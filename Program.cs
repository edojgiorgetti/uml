namespace UML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var biblioteca = new Biblioteca("Via Roma 1", "9-18");
            var libro = new Libro("Il Nome della Rosa", 500, 1, "978-0156001311");
            var mario = new Utente("Mario", "Rossi", "mrossi", "pw123");
            var anna = new Utente("Anna", "Bianchi", "abianchi", "pw456");
            biblioteca.ListaLibri.Add(libro);
            biblioteca.ListaUtente.Add(mario);
            biblioteca.ListaUtente.Add(anna);

            Console.WriteLine($"Prestito a Mario: {biblioteca.RegistraPrestito(libro, "01/11/2026", mario)}");              // True
            Console.WriteLine($"Prestito ad Anna (nessuna copia): {biblioteca.RegistraPrestito(libro, "02/11/2026", anna)}"); // False
            Console.WriteLine($"Restituzione: {biblioteca.RegistraRestituzione(libro, "06/12/2026", mario)}");              // True
            Console.WriteLine($"Ritardo: {biblioteca.ListaPrestiti[0].CalcolaRitardo()} giorni");                           // 5
            Console.WriteLine($"Copie disponibili: {libro.Disponibilità}");                                                  // 1
        }
    }
}
