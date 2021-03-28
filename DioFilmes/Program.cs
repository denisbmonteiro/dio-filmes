using System;
using DioFilmes.Enum;
using DioFilmes.Model;
using DioFilmes.Repository;

namespace DioFilmes
{
    internal class Program
    {
        private static readonly MovieRepository _repository = new MovieRepository();

        private static void Main(string[] args)
        {
            var entradaOpcaoMenu = ObterOpcaoMenu();

            while (entradaOpcaoMenu != "X")
            {
                switch (entradaOpcaoMenu)
                {
                    case "1":
                        ListarFilmes();
                        break;
                    case "2":
                        InserirFilme();
                        break;
                    case "3":
                        AtualizarFilme();
                        break;
                    case "4":
                        ExcluirFilme();
                        break;
                    case "5":
                        VisualizarFilme();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Informe uma opção válida!");
                        break;
                }

                entradaOpcaoMenu = ObterOpcaoMenu();
            }
        }

        private static void ListarFilmes()
        {
            Console.WriteLine("### Listar filmes ###");
            Console.WriteLine();

            var filmes = _repository.Lista();

            if (filmes.Count == 0)
            {
                Console.WriteLine("Nenhum filme cadastrado!");
                Console.WriteLine();
                return;
            }

            foreach (var filme in filmes)
            {
                Console.WriteLine("{0} - {1}{2}", filme.RetornaId(), filme.RetornaTitulo(), filme.RetornaExcluido() ? " *Excluído*" : "");
            }

            Console.WriteLine();
        }

        private static void InserirFilme()
        {
            Console.WriteLine("### Inserir novo filme ###");
            Console.WriteLine();

            var entradaGenero = ObterOpcaoGenero();
            var entradaTitulo = ObterOpcaoTitulo();
            var entradaAno = ObterOpcaoAno();
            var entradaDescricao = ObterOpcaoDescricao();

            Console.WriteLine();

            var novoFilme = new MovieModel(
                id: _repository.ProximoId(),
                genero: (EnumGenero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao
            );

            _repository.Insere(novoFilme);
        }

        private static void AtualizarFilme()
        {
            Console.WriteLine("### Atualizar filme ###");
            Console.WriteLine();

            if (_repository.Lista().Count == 0)
            {
                Console.WriteLine("Nenhum filme cadastrado!");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Digite o id do filme para atualizar:");
            Console.WriteLine();
            Console.Write("-> ");

            var idFilme = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            Console.WriteLine();

            var entradaGenero = ObterOpcaoGenero();
            var entradaTitulo = ObterOpcaoTitulo();
            var entradaAno = ObterOpcaoAno();
            var entradaDescricao = ObterOpcaoDescricao();

            Console.WriteLine();

            var atualizaFilme = new MovieModel(
                id: idFilme,
                genero: (EnumGenero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao
            );

            _repository.Atualiza(idFilme, atualizaFilme);
        }

        private static void ExcluirFilme()
        {
            Console.WriteLine("### Excluir filme ###");
            Console.WriteLine();

            if (_repository.Lista().Count == 0)
            {
                Console.WriteLine("Nenhum filme cadastrado!");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Digite o id do filme para excluir:");
            Console.WriteLine();
            Console.Write("-> ");

            var idFilme = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            _repository.Exclui(idFilme);

            Console.WriteLine();
        }

        private static void VisualizarFilme()
        {
            Console.WriteLine("### Visualizar filme ###");
            Console.WriteLine();

            if (_repository.Lista().Count == 0)
            {
                Console.WriteLine("Nenhum filme cadastrado!");
                Console.WriteLine();
                return;
            }

            Console.WriteLine("Digite o id do filme para visualizar:");
            Console.WriteLine();
            Console.Write("-> ");

            var idFilme = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            Console.WriteLine();
            Console.WriteLine(_repository.RetornaPorId(idFilme));
            Console.WriteLine();
        }

        private static string ObterOpcaoMenu()
        {
            Console.WriteLine("===========================================================");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine();

            Console.WriteLine("1 - Listar filmes");
            Console.WriteLine("2 - Inserir novo filme");
            Console.WriteLine("3 - Atualizar filme");
            Console.WriteLine("4 - Excluir filme");
            Console.WriteLine("5 - Visualizar filme");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            Console.WriteLine("===========================================================");
            Console.WriteLine();
            Console.Write("-> ");

            var entradaOpcaoMenu = Console.ReadLine()?.ToUpper();

            Console.WriteLine();

            return entradaOpcaoMenu;
        }

        private static int ObterOpcaoGenero()
        {
            foreach (int i in System.Enum.GetValues(typeof(EnumGenero)))
            {
                Console.WriteLine("{0} - {1}", i, System.Enum.GetName(typeof(EnumGenero), i));
            }

            Console.WriteLine();
            Console.WriteLine("Digite o gênero entre as opções acima:");
            Console.WriteLine();
            Console.Write("-> ");

            var entradaGenero = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            return entradaGenero;
        }

        private static string ObterOpcaoTitulo()
        {
            Console.WriteLine();
            Console.WriteLine("Digite o título do filme:");
            Console.WriteLine();
            Console.Write("-> ");

            var entradaTitulo = Console.ReadLine();

            return entradaTitulo;
        }

        private static int ObterOpcaoAno()
        {
            Console.WriteLine();
            Console.WriteLine("Digite o ano de lançamento do filme:");
            Console.WriteLine();
            Console.Write("-> ");

            var entradaAno = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            return entradaAno;
        }

        private static string ObterOpcaoDescricao()
        {
            Console.WriteLine();
            Console.WriteLine("Digite a descrição do filme:");
            Console.WriteLine();
            Console.Write("-> ");

            var entradaDescricao = Console.ReadLine();

            return entradaDescricao;
        }
    }
}