using System;

namespace WhatsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Contato ctt = new Contato();
            
            ctt.Nome = "hittoxy";
            ctt.Telefone = "+55 11979788809";

            Agenda agenda = new Agenda();
            
            agenda.Cadastrar(ctt);

            Mensagem msg = new Mensagem();
            msg.Enviar(ctt);
        }
    }
}
