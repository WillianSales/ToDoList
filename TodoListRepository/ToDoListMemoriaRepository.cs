using System.Text;
using ToDoList.Domain;

namespace ToDoList.Infra.Repository
{
    public class ToDoListMemoriaRepository : IToDoListRepository
    {
        private StringBuilder _toDoList;

        public ToDoListMemoriaRepository()
        {
            _toDoList = new StringBuilder();
        }

        public void Apagar()
        {
            _toDoList.Clear();
        }

        public void Cadastrar(string tarefa)
        {
            _toDoList.AppendLine(tarefa);
        }

        public string Consultar()
        {
            return _toDoList.ToString();
        }
    }
}
