using System;

namespace WhatsConsole
{
    public class Mensagem
    {
        
        public string Texto { get; set; }

        public string Destinatário { get; set; }

        public void Enviar(Contato ctts)
        {
            Console.WriteLine($"Que mensagem gostaria de enviar para {ctts.Nome}?");
            Texto = Console.ReadLine();
            Console.WriteLine($"Mensagem: \n{Texto} enviada para {ctts.Nome}");

        }

    }
}