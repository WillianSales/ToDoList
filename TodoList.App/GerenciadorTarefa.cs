using ToDoList.App.Command;

namespace ToDoList.App
{
    public class GerenciadorTarefa
    {
        private readonly ICommand _adicionar;
        private readonly ICommand _remover;

        public GerenciadorTarefa(ICommand adicionar, ICommand remover)
        {
            _adicionar = adicionar;
            _remover = remover;
        }

        public void Adicionar()
        {
            _adicionar.Fazer();
        }

        public void Remover()
        {
            _remover.Fazer();
        }
    }
}
