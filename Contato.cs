namespace WhatsConsole
{
    public class Contato : Agenda
    {
        
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Contact { get; set; }

        public Contato(string _nome, string _telefone)
        {

            this.Nome = _nome;
            this.Telefone = _telefone;

        }

    }
}