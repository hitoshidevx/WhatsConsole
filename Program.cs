using System;
using System.Collections.Generic;

namespace WhatsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Contato ctt = new Contato("killua", "+55 11-979788810");

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
