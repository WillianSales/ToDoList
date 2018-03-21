namespace ToDoList.Domain
{
    public class ToDo : IToDoList
    {
        private string _texto;
        private readonly IToDoListRepository _todoListRepository;

        public ToDo(IToDoListRepository todoListRepository, string texto)
        {
            _todoListRepository = todoListRepository;
            _texto = texto;
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
            return _texto;
        }
    }
}
