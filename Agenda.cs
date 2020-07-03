using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WhatsConsole
{
    public class Agenda : IAgenda
    {

        List<Contato> contatos { get; set; }
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
        public void Cadastrar(Contato ctts)
        {
            var line = new string[] { PrepararLinha(ctts) };
            File.AppendAllLines(PATH, line);
    
        }
        public List<Contato> Listar()
        {
            List<Contato> contatos = new List<Contato>();

            string[] linhas = File.ReadAllLines(PATH);
            
            foreach(string linha in linhas){

                string[] dado = linha.Split(";");

                Contato ctt  = new Contato();
                ctt.Nome     = Separar(dado[1]);
                ctt.Telefone = Separar(dado[1]);
   
                contatos.Add(ctt);
            }
            contatos = contatos.OrderBy(y => y.Nome).ToList();
            return contatos;
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

        private string PrepararLinha(Contato ctts)
        {
            return $"Nome: {ctts.Nome} ; Telefone: {ctts.Telefone}";
        }

    }
}