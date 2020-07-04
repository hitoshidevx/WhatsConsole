using System;
using System.Collections.Generic;

namespace WhatsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Contato ctt = new Contato("obito", "+55 11-987654321");

            Agenda agenda = new Agenda();
            
            agenda.Cadastrar(ctt);
            // agenda.Excluir("killua");

            List<Contato> Lista = agenda.Listar();

            foreach(Contato c in Lista)
            {
                Console.WriteLine($"Nome: {ctt.Nome} - Numero: {ctt.Telefone}");
            }

            Mensagem msg = new Mensagem();
            // msg.Enviar(ctt);

            

        }
    }
}
