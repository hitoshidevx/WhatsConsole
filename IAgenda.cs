using System.Collections.Generic;

namespace WhatsConsole
{
    public interface IAgenda
    {

        void Cadastrar(Contato contatos);
        void Excluir(string _term);
        List<Contato> Listar();

    }
}