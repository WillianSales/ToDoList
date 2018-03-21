using System.Collections.Generic;
using ToDoList.Domain;

namespace ToDoList.CrossCutting.Factory
{
    public static class ToDoListFactory
    {
        public static IToDoList CriarTodo(TipoToDo tipoTodo, TipoRepository tipoRepository, IList<IToDoList> tarefas = null, string tituloProjeto = "", string textoTarefa = "")
        {
            switch (tipoTodo)
            {
                case TipoToDo.Projeto:
                    return new Projeto(RepositoryFactory.CriarRepository(tipoRepository), tituloProjeto, tarefas);
                case TipoToDo.Todo:
                    return new ToDo(RepositoryFactory.CriarRepository(tipoRepository), textoTarefa);
                default:
                    return null;
            }
        }
    }
}
