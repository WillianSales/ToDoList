namespace ToDoList.Domain
{
    public interface IToDoList
    {
        string CriarTarefa();
        void ApagarTarefa();
        string ConsultarTarefas();
    }
}
