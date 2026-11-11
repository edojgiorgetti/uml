using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML
{
    public class Utente : Persona
    {
        public Utente(string nome, string cognome, string username, string password)
            : base(nome, cognome, username, password) { }
    }
}
