public class Program
{
    
    private static Biblioteca minhaBiblioteca = new Biblioteca();

    public static void Main(string[] args)
    {
        // Populando a biblioteca com alguns dados iniciais para facilitar os testes
        minhaBiblioteca.AdicionarLivro("O Senhor dos Anéis", "J.R.R. Tolkien");
        minhaBiblioteca.AdicionarLivro("1984", "George Orwell");
        minhaBiblioteca.AdicionarMembro("João da Silva");
        Console.Clear(); // Limpa as mensagens de adição iniciais

        bool executando = true;
        while (executando)
        {
            ExibirMenu();
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    AdicionarLivro();
                    break;
                case "2":
                    AdicionarMembro();
                    break;
                case "3":
                    RealizarEmprestimo();
                    break;
                case "4":
                    RealizarDevolucao();
                    break;
                case "5":
                    minhaBiblioteca.ListarTodosOsLivros();
                    break;
                case "6":
                    minhaBiblioteca.ListarMembros();
                    break;
                case "0":
                    executando = false;
                    Console.WriteLine("\nObrigado por usar o sistema da biblioteca!");
                    break;
                default:
                    Console.WriteLine("\nOpção inválida. Por favor, tente novamente.");
                    break;
            }

            if (executando)
            {
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    private static void ExibirMenu()
    {
        Console.Clear();
        Console.WriteLine("========== Menu da Biblioteca ==========");
        Console.WriteLine("1. Adicionar novo livro");
        Console.WriteLine("2. Cadastrar novo membro");
        Console.WriteLine("3. Realizar empréstimo");
        Console.WriteLine("4. Realizar devolução");
        Console.WriteLine("5. Listar todos os livros");
        Console.WriteLine("6. Listar todos os membros");
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("0. Sair do sistema");
        Console.WriteLine("======================================");
        Console.Write("Digite a sua opção: ");
    }

    private static void AdicionarLivro()
    {
        Console.Clear();
        Console.WriteLine("--- Adicionar Novo Livro ---");
        Console.Write("Digite o título do livro: ");
        string titulo = Console.ReadLine();
        Console.Write("Digite o autor do livro: ");
        string autor = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(titulo) && !string.IsNullOrWhiteSpace(autor))
        {
            minhaBiblioteca.AdicionarLivro(titulo, autor);
        }
        else
        {
            Console.WriteLine("\nErro: Título e autor não podem ser vazios.");
        }
    }

    private static void AdicionarMembro()
    {
        Console.Clear();
        Console.WriteLine("--- Cadastrar Novo Membro ---");
        Console.Write("Digite o nome do membro: ");
        string nome = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(nome))
        {
            minhaBiblioteca.AdicionarMembro(nome);
        }
        else
        {
            Console.WriteLine("\nErro: O nome não pode ser vazio.");
        }
    }

    private static void RealizarEmprestimo()
    {
        Console.Clear();
        Console.WriteLine("--- Realizar Empréstimo ---");
        minhaBiblioteca.ListarTodosOsLivros();
        Console.WriteLine("---------------------------");
        minhaBiblioteca.ListarMembros();

        Console.Write("\nDigite o ID do livro a ser emprestado: ");
        if (!int.TryParse(Console.ReadLine(), out int idLivro))
        {
            Console.WriteLine("\nID do livro inválido.");
            return;
        }

        Console.Write("Digite o ID do membro que está pegando o livro: ");
        if (!int.TryParse(Console.ReadLine(), out int idMembro))
        {
            Console.WriteLine("\nID do membro inválido.");
            return;
        }

        minhaBiblioteca.RealizarEmprestimo(idLivro, idMembro);
    }

    private static void RealizarDevolucao()
    {
        Console.Clear();
        Console.WriteLine("--- Realizar Devolução ---");
        minhaBiblioteca.ListarTodosOsLivros();

        Console.Write("\nDigite o ID do livro a ser devolvido: ");
        if (!int.TryParse(Console.ReadLine(), out int idLivro))
        {
            Console.WriteLine("\nID do livro inválido.");
            return;
        }

        minhaBiblioteca.RealizarDevolucao(idLivro);
    }
}
