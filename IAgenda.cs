using System.Collections.Generic;

namespace WhatsConsole
{
    public interface IAgenda
    {

        void Cadastrar(Contato contatos);
        void Excluir(Contato contact, string _term);
        List<Contato> Listar();

    }
}