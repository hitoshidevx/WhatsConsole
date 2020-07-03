using System.Collections.Generic;
using System.IO;

namespace WhatsConsole
{
    public class Agenda : IAgenda
    {

        List<Contato> contatos = new List<Contato>();
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

        public void Cadastrar(Contato contatos)
        {
            var linha = new string[] { PrepararLinha(contatos) };
            File.AppendAllLines(PATH, linha);
    
        }

        public void Excluir(Contato contact, string _term)
        {
            List<string> linhas = new List<string>();

            // Utilizei a bliblioteca StreamReader para ler o .csv
            using(StreamReader arquivo = new StreamReader(PATH))
            {
                string linha;
                while((linha = arquivo.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }

            // Removi as linhas que tiverem o termo passado como argumento
            linhas.RemoveAll(l => l.Contains(_term));

            // Reescrevi o csv do zero
            ReescreverCSV(linhas);
        }

        public void Listar()
        {
            List<Agenda> contatos = new List<Agenda>();

            string[] linhas = File.ReadAllLines(PATH);
            
            foreach(string linha in linhas){

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

        private string PrepararLinha(Contato contatos)
        {
            return $"{contatos}";
        }

    }
}