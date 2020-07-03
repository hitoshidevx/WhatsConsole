namespace WhatsConsole
{
    public interface IAgenda
    {

        void Cadastrar(Contato contact);
        void Excluir(Contato contact, string _term);
        void Listar();

    }
}