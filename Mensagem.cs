using System;

namespace WhatsConsole
{
    public class Mensagem
    {
        
        public string Texto { get; set; }

        public string Destinatario { get; set; }

        /// <summary>
        /// Envia uma mensagem para o ultimo contato adicionado.
        /// </summary>
        /// <returns>
        /// Nada, pois a tipagem é void.
        /// </returns>
        public void Enviar(Contato ctts)
        {
            Console.WriteLine($"Que mensagem gostaria de enviar para {ctts.Nome}?");
            Texto = Console.ReadLine();

            if(Texto == ""){
                Console.WriteLine("A mensagem não pode ser vazia! >:(");
            }else{
                Console.WriteLine($"Mensagem: {Texto} enviada para {ctts.Nome}!");
            }

        }

    }
}