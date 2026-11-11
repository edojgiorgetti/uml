using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UML
{
    public class Bibliotecario : Persona
    {
        public Bibliotecario(string nome, string cognome, string username, string password)
            : base(nome, cognome, username, password) { }
    }
}
