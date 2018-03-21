using ToDoList.Domain;
using ToDoList.Infra.Repository;

namespace ToDoList.CrossCutting.Factory
{
    public static class RepositoryFactory
    {
        private static IToDoListRepository _toDoListRepository = null;

        public static IToDoListRepository CriarRepository(TipoRepository tipoRepository)
        {
            switch (tipoRepository)
            {
                case TipoRepository.Memoria:

                    if (_toDoListRepository == null)
                        _toDoListRepository = new ToDoListMemoriaRepository();

                    return _toDoListRepository;

                case TipoRepository.Arquivo:

                    if (_toDoListRepository == null)
                    {
                        var diretorio = System.IO.Path.GetFullPath(@"..\..\..\Arquivo");
                        _toDoListRepository = new ToDoListArquivoRepository(diretorio, "TodoList.txt");
                    }

                    return _toDoListRepository;

                default:
                    return null;
            }
        }

    }
}
