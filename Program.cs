using System;

namespace WhatsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Agenda agenda = new Agenda();
            Contato c1    = new Contato("hitoxxy", "+55 11989877709");
            Contato c2    = new Contato("hideiki", "+55 11281928728");
            Contato c3    = new Contato("killua", "+55 11283799153");
            Contato c4    = new Contato("alphonse", "+55 11128738189");
            
            agenda.Cadastrar(c4);
        }
    }
}
