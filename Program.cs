using System;
using System.Collections.Generic;

namespace WhatsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Contato ctt = new Contato("gon", "+55 11-979788801");

            Agenda agenda = new Agenda();
            
            agenda.Cadastrar(ctt);
            agenda.Excluir("gon");

            foreach( Contato item in agenda.Listar() )
            {
                Console.WriteLine($"Nome: {item.Nome} - Numero: {item.Telefone}");
            }

            // Mensagem msg = new Mensagem();
            // msg.Enviar(ctt);

            

        }
    }
}
