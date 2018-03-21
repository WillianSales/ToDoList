using ToDoList.Domain;

namespace ToDoList.App.Command
{
    public class AdicionarTarefa : ICommand
    {
        private readonly IToDoList _todoList;
        private readonly IToDoListRepository _todoListRepository;

        public AdicionarTarefa(IToDoListRepository todoListRepository, IToDoList todoList)
        {
            _todoList = todoList;
            _todoListRepository = todoListRepository;
        }

        public void Desfazer()
        {
            _todoList.ApagarTarefa();
        }

        public void Fazer()
        {
            _todoListRepository.Cadastrar(_todoList.CriarTarefa());
        }
    }
}
