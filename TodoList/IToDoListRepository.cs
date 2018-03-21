namespace ToDoList.Domain
{
    public interface IToDoListRepository
    {
        void Cadastrar(string tarefa);

        string Consultar();

        void Apagar();
    }
}
