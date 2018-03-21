using ToDoList.Domain;

namespace ToDoList.App.Command
{
    public class RemoverTarefa : ICommand
    {
        private readonly IToDoList _todoList;
        private readonly IToDoListRepository _todoListRepository;

        public RemoverTarefa(IToDoListRepository todoListRepository, IToDoList todoList)
        {
            _todoList = todoList;
            _todoListRepository = todoListRepository;
        }

        public void Desfazer()
        {
            _todoListRepository.Cadastrar(_todoList.CriarTarefa());
        }

        public void Fazer()
        {
            _todoList.ApagarTarefa();
        }
    }
}
