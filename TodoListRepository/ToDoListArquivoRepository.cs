using System;
using System.IO;
using System.Text;
using ToDoList.Domain;

namespace ToDoList.Infra.Repository
{
    public class ToDoListArquivoRepository : IToDoListRepository
    {
        private readonly string _diretorioArquivo;
        private readonly string _nomeArquivo;

        public ToDoListArquivoRepository(string diretorioArquivo, string nomeArquivo)
        {
            _diretorioArquivo = diretorioArquivo;
            _nomeArquivo = nomeArquivo;
        }

        public void Apagar()
        {
            if (File.Exists($"{_diretorioArquivo}\\{_nomeArquivo}"))
            {
                File.Delete($"{_diretorioArquivo}\\{_nomeArquivo}");
            }
        }

        public void Cadastrar(string tarefa)
        {
            var textoArquivo = Consultar();

            StreamWriter sw = new StreamWriter($"{_diretorioArquivo}\\{_nomeArquivo}");

            if (!string.IsNullOrEmpty(textoArquivo))
                sw.WriteLine(textoArquivo);

            sw.WriteLine(tarefa);

            sw.Close();
        }

        public string Consultar()
        {
            if (!File.Exists($"{_diretorioArquivo}\\{_nomeArquivo}"))
            {
                return string.Empty;
            }

            String linha;
            StringBuilder texto = new StringBuilder();

            StreamReader sr = new StreamReader($"{_diretorioArquivo}\\{_nomeArquivo}");

            linha = sr.ReadLine();

            while (linha != null)
            {
                texto.AppendLine(linha);

                linha = sr.ReadLine();
            }

            sr.Close();

            return texto.ToString();
        }
    }
}

