using System.Collections.Generic;
using System.Text;

namespace ToDoList.Domain
{
    public class Projeto : IToDoList
    {
        private readonly string _titulo;
        private readonly IList<IToDoList> _todoLists;
        private StringBuilder _textoProjeto;
        private readonly IToDoListRepository _todoListRepository;

        public Projeto(IToDoListRepository todoListRepository,string titulo, IList<IToDoList> todoLists)
        {
            _titulo = titulo;
            _todoLists = todoLists;
            _todoListRepository = todoListRepository;
        }

        public void ApagarTarefa()
        {
            _todoListRepository.Apagar();
        }

        public string ConsultarTarefas()
        {
            return _todoListRepository.Consultar();
        }

        public string CriarTarefa()
        {
            StringBuilder texto = new StringBuilder();

            if (_textoProjeto == null)
                _textoProjeto = new StringBuilder();

            texto.AppendLine($"Título: { _titulo } ");

            foreach (var item in _todoLists)
            {
                texto.AppendLine($"Tarefa: { item.CriarTarefa() }");
            }

            if (texto.Length > 0)
                _textoProjeto.AppendLine(texto.ToString());

            return _textoProjeto.ToString();
        }
    }
}
