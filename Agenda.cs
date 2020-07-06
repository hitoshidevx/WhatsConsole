using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WhatsConsole
{
    public class Agenda : IAgenda
    {

        public List<Contato> contatos;
        private const string PATH = "Database/contatos.csv";

        public Agenda()
        {

        //Era para ser um método que criava o folder 'database' e o file 'contatos', mas ele acabou bugando minha aplicação.

        }
        
        /// <summary>
        /// Faz o cadastro do contato na lista do csv
        /// </summary>
        /// <returns>
        /// Nada, pois a tipagem é void.
        /// </returns>
        public void Cadastrar(Contato ctt)
        {
            var line = new string[] { PrepararLinha(ctt) };
            File.AppendAllLines(PATH, line);
        }

        /// <summary>
        /// Faz a exclusão do contato na lista do csv
        /// </summary>
        /// <returns>
        /// Nada, pois a tipagem é void.
        /// </returns>
        public void Excluir(string _term)
        {
            List<string> lines = new List<string>();

            // Utilizei a bliblioteca StreamReader para ler o .csv
            using(StreamReader file = new StreamReader(PATH))
            {
                string line;
                while((line = file.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            // Removi as linhas que tiverem o termo passado como argumento
            lines.RemoveAll(l => l.Contains(_term));

            // Reescrevi o csv do zero
            ReescreverCSV(lines);
        }

        /// <summary>
        /// Lista no program a lista de contatos do arquivo .csv
        /// </summary>
        /// <returns>
        /// Retorna a lista no program
        /// </returns>
        
        public List<Contato> Listar()
        {
            
            string[] linhas = File.ReadAllLines(PATH);
            foreach(string linha in linhas){

                string[] dado = linha.Split(";");
                contatos.Add(new Contato( dado[0], dado[1] ) );

            }
            contatos = contatos.OrderBy( x => x.Nome ).ToList();
            return contatos;
        }   

        /// <summary>
        /// Prepara a linha com os atributos propriamente atribuídos no program para o arquivo .csv
        /// </summary>
        /// <returns>
        /// Retorna os atributos do contato
        /// </returns>
        private string PrepararLinha(Contato c)
        {
            return $"Nome:{c.Nome};Telefone:{c.Telefone}";
        }
        
        private void ReescreverCSV(List<string> lines){
            // Reescrevi o csv do zero
            using(StreamWriter output = new StreamWriter(PATH))
            {
                foreach(string ln in lines)
                {
                    output.Write(ln + "\n");
                }
            }   
        }

    }
}