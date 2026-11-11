using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML
{
    public class Persona
    {
        public string Nome { get; private set; }
        public string Cognome { get; private set; }
        public string Username { get; private set; }
        private string _password;

        public Persona(string nome, string cognome, string username, string password)
        {
            Nome = nome;
            Cognome = cognome;
            Username = username;
            _password = password;
        }

        public bool ModificaPassword(string psw)
        {
            if (string.IsNullOrWhiteSpace(psw)) return false;
            _password = psw;
            return true;
        }

        // Aggiunto io: serve per il login del diagramma di sequenza
        public bool VerificaPassword(string psw) => _password == psw;
    }
}
