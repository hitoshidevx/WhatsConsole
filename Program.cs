using System;

namespace WhatsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Contato ctt = new Contato();

            Agenda agenda = new Agenda();

            agenda.Cadastrar(ctt);
        }
    }
}
