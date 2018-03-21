using System.Collections.Generic;
using System.Text;
using ToDoList.App.Command;
using ToDoList.CrossCutting.Factory;
using ToDoList.Domain;

namespace ToDoList.App
{
    public class ToDoListApp
    {
        public IToDoList CadastrarProjeto(TipoRepository tipoRepository, string tituloProjeto, int quantidadeTarefas, List<string> textosTarefas)
        {
            var tarefas = new List<IToDoList>();

            foreach (var textoTarefa in textosTarefas)
            {
                IToDoList toDo = ToDoListFactory.CriarTodo(TipoToDo.Todo, tipoRepository, null, null, textoTarefa);
                tarefas.Add(toDo);
            }

            var projeto = ToDoListFactory.CriarTodo(TipoToDo.Projeto, tipoRepository, tarefas, tituloProjeto);

            GerenciadorTarefa gerenciadorTarefas = new GerenciadorTarefa(new AdicionarTarefa(RepositoryFactory.CriarRepository(tipoRepository), projeto), new RemoverTarefa(RepositoryFactory.CriarRepository(tipoRepository), projeto));

            gerenciadorTarefas.Adicionar();

            return projeto;
        }

        public string ConsultarProjeto(IToDoList toDo)
        {
            if (toDo == null)
                return "Não existe projeto criado.";

            var textoTarefas = toDo.ConsultarTarefas();

            if (string.IsNullOrEmpty(textoTarefas))
                return "Não existe projeto criado.";

            StringBuilder textoProjeto = new StringBuilder();

            textoProjeto.AppendLine("Esse são os seus projetos:");
            textoProjeto.AppendLine(textoTarefas);

            return textoProjeto.ToString();
        }

        public IToDoList CadastrarTarefa(TipoRepository tipoRepository, string textoTarefa)
        {
            var toDo = ToDoListFactory.CriarTodo(TipoToDo.Todo, tipoRepository, null, null, textoTarefa);

            GerenciadorTarefa gerenciadorTarefas = new GerenciadorTarefa(new AdicionarTarefa(RepositoryFactory.CriarRepository(tipoRepository), toDo), new RemoverTarefa(RepositoryFactory.CriarRepository(tipoRepository), toDo));

            gerenciadorTarefas.Adicionar();

            return toDo;
        }

        public void ApagarProjeto(TipoRepository tipoRepository, IToDoList toDo)
        {
            if (toDo == null)
                toDo = ToDoListFactory.CriarTodo(TipoToDo.Projeto, tipoRepository, new List<IToDoList>(), string.Empty);

            GerenciadorTarefa gerenciadorTarefas = new GerenciadorTarefa(new AdicionarTarefa(RepositoryFactory.CriarRepository(tipoRepository), toDo), new RemoverTarefa(RepositoryFactory.CriarRepository(tipoRepository), toDo));

            gerenciadorTarefas.Remover();
        }
    }
}
