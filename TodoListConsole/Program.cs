using System;
using System.Collections.Generic;
using ToDoList.App;
using ToDoList.Domain;

namespace ToDoList.UI.ConsoleProject
{
    class Program
    {
        private static TipoRepository _tipoRepository;
        private static ToDoListApp _toDoListApp;

        static void Main(string[] args)
        {
            _tipoRepository = TipoRepository.Memoria;
            _toDoListApp = new ToDoListApp();

            CriarProjetoTarefas(null);
        }

        private static void CriarProjetoTarefas(IToDoList toDo = null)
        {
            Console.WriteLine("Digite 1 para criar um projeto.");
            Console.WriteLine("Digite 2 para criar uma tarefa.");
            Console.WriteLine("Digite 3 para consultar seus projetos e suas tarefas.");
            Console.WriteLine("Digite 4 para apagar o projeto.");
            Console.WriteLine("Digite 5 pra sair.");

            if (int.TryParse(Console.ReadLine().ToString(), out int opcao))
            {
                switch (opcao)
                {
                    case 1:

                        toDo = CadastrarProjeto();

                        break;
                    case 2:

                        toDo = CadastrarTarefa();

                        break;
                    case 3:

                        ConsultarProjeto(toDo);

                        break;
                    case 4:

                        ApagarProjeto(toDo);

                        break;
                    case 5:
                        return;
                    default:

                        Console.WriteLine("Opção inválida!");

                        break;
                }
            }
            else
                Console.WriteLine("Opção inválida!");

            CriarProjetoTarefas(toDo);
        }

        private static void ApagarProjeto(IToDoList toDo)
        {
            _toDoListApp.ApagarProjeto(_tipoRepository, toDo);
        }

        private static IToDoList CadastrarProjeto()
        {
            var textosTarefas = new List<string>();

            Console.WriteLine("Digite um título para o seu projeto:");

            var tituloProjeto = Console.ReadLine().ToString();

            Console.WriteLine("Digite a quantidade de tarefas que esse projeto terá.");

            if (int.TryParse(Console.ReadLine().ToString(), out int quantidadeTarefas) && quantidadeTarefas > 0)
            {
                for (int i = 0; i < quantidadeTarefas; i++)
                {
                    Console.WriteLine($"Digite o texto da tarefa { i + 1 }");

                    textosTarefas.Add(Console.ReadLine());
                }

                return _toDoListApp.CadastrarProjeto(_tipoRepository, tituloProjeto, quantidadeTarefas, textosTarefas);
            }
            else
            {
                Console.WriteLine("Quantidade de tarefas inválida.");

                return null;
            }
          
        }

        private static void ConsultarProjeto(IToDoList toDo)
        {
            Console.WriteLine(_toDoListApp.ConsultarProjeto(toDo));
        }

        private static IToDoList CadastrarTarefa()
        {
            Console.WriteLine("Digite o texto da sua tarefa:");

            var textoTarefa = Console.ReadLine().ToString();

            return _toDoListApp.CadastrarTarefa(_tipoRepository, textoTarefa);
        }
    }
}
