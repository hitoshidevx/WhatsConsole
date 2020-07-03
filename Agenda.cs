using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WhatsConsole
{
    public class Agenda : IAgenda
    {

        List<Contato> contatos;
        private const string PATH = "Database/agenda.csv";

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

        public void Cadastrar(Contato ctts)
        {
            var line = new string[] { PrepararLinha(ctts) };
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

        public void Listar()
        {
            List<Agenda> contatos = new List<Agenda>();

            string[] linhas = File.ReadAllLines(PATH);
            
            foreach(string linha in linhas){

            }
        }


        private string PrepararLinha(Contato ctts)
        {
            return $"Nome: {ctts.Nome}\nTelefone: {ctts.Telefone}";
        }

    }
}