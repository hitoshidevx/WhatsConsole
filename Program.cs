using System;
using System.Collections.Generic;

namespace WhatsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Contato ctt = new Contato("hittoxy", "+55 11-989877709");

            Agenda agenda = new Agenda();
            
            agenda.Cadastrar(ctt);

            List<Contato> Lista = agenda.Listar();

            foreach(Contato c in Lista)
            {
                Console.WriteLine($"Nome: {ctt.Nome} - Numero: {ctt.Telefone}");
            }

            Mensagem msg = new Mensagem();
            msg.Enviar(ctt);

            

        }
    }
}
