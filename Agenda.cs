using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WhatsConsole
{
    public class Agenda : IAgenda
    {

        public List<Contato> contatos;
        private const string PATH = "Database/contatos.csv";

        //Deu errado :(
        // public Agenda()
        // {

        //     //-------------------------------------
        //     string folder = PATH.Split('/')[0];

        //     if(!Directory.Exists(folder)){
        //         Directory.CreateDirectory(folder);
        //     }
        //     //-------------------------------------

        //     if(File.Exists(PATH)){
        //         File.Create(PATH).Close();
        //     }

        // }
        public void Cadastrar(Contato ctt)
        {
            var line = new string[] { PrepararLinha(ctt) };
            File.AppendAllLines(PATH, line);
        }
        public void Excluir(Contato contact, string _term)
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

        public List<Contato> Listar()
        {
            List<Contato> lista = new List<Contato>();

            string[] linhas = File.ReadAllLines(PATH);
            
            lista = lista.OrderBy(x => x    .Nome).ToList();
            return lista;
        }   

        private string PrepararLinha(Contato c)
        {
            return $"Nome: {c.Nome} ; Telefone: {c.Telefone}";
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