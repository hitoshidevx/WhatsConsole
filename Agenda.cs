using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WhatsConsole
{
    public class Agenda : IAgenda
    {

        public List<Contato> contatos { get; set; }
        private const string PATH = "Database/contatos.csv";

        public Agenda()
        {

            //-------------------------------------
            string folder = PATH.Split('/')[0];

            if(!Directory.Exists(folder)){
                Directory.CreateDirectory(folder);
            }
            //-------------------------------------

            if(File.Exists(PATH)){
                File.Create(PATH).Close();
            }

        }
        public void Cadastrar(Contato ctt)
        {
            var line = new string[] { PrepararLinha(ctt) };
            File.AppendAllLines(PATH, line);
        }

        public List<Contato> Listar()
        {
            List<Contato> lista = new List<Contato>();

            string[] linhas = File.ReadAllLines(PATH);
            
            lista = lista.OrderBy(y => y.Nome).ToList();
            return lista;
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
        public void RemoverLinhas(List<string> lines, string _term){

            using (StreamReader file = new StreamReader(PATH)){

                string line;
                while ( (line = file.ReadLine()) != null){ 
                    lines.Add(line);
                }
                lines.RemoveAll(x => x.Contains(_term));
            }

        }

        public string Separar(string dado){
            return dado.Split('=')[1];
        }

        private string PrepararLinha(Contato ctts)
        {
            return $"Nome: {ctts.Nome} ; Telefone: {ctts.Telefone}";
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