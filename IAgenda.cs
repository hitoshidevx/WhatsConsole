namespace WhatsConsole
{
    public interface IAgenda
    {

        void Cadastrar(Contato contatos);
        void Excluir(Contato contact, string _term);
        void Listar();

    }
}