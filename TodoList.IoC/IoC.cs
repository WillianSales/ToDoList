using TodoList.CrossCutting.Factory;
using TodoList.Domain;

namespace TodoList.CrossCutting.IoC
{
    public static class IoC
    {
        private static ITodoListRepository _todoListRepository;

        public static ITodoListRepository ObterRepositorio(TipoRepository tipoRepository)
        {
            if (_todoListRepository == null)
                _todoListRepository = RepositoryFactory.CriarRepository(tipoRepository);

            return _todoListRepository;
        }
    }
}
