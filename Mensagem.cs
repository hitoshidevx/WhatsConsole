namespace WhatsConsole
{
    public class Mensagem
    {
        
        public string Texto { get; set; }

        public string Destinatário { get; set; }

        public string Enviar(string _contato)
        {
            return "A mensagem foi enviada para {}";
        }

    }
}