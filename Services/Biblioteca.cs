public class Biblioteca
{
    private List<Livro> acervo = new List<Livro>();
    private List<Membro> membros = new List<Membro>();
    private int proximoIdLivro = 1;
    private int proximoIdMembro = 1;

    public void AdicionarLivro(string titulo, string autor)
    {
        acervo.Add(new Livro(proximoIdLivro++, titulo, autor));
        Console.WriteLine("Livro adicionado com sucesso!");
    }

    public void AdicionarMembro(string nome)
    {
        membros.Add(new Membro(proximoIdMembro++, nome));
        Console.WriteLine("Membro adicionado com sucesso!");
    }

    public void ListarLivrosDisponiveis()
    {
        Console.WriteLine("\n--- Livros Disponíveis ---");
        var livrosDisponiveis = acervo.Where(l => l.Disponivel);
        if (livrosDisponiveis.Any())
        {
            foreach (var livro in livrosDisponiveis)
            {
                livro.ExibirDetalhes();
            }
        }
        else
        {
            Console.WriteLine("Nenhum livro disponível no momento.");
        }
    }

    public void ListarTodosOsLivros()
    {
        Console.WriteLine("\n--- Acervo Completo ---");
        if (acervo.Any())
        {
            foreach (var livro in acervo)
            {
                livro.ExibirDetalhes();
            }
        }
        else
        {
            Console.WriteLine("O acervo está vazio.");
        }
    }


    public void ListarMembros()
    {
        Console.WriteLine("\n--- Membros da Biblioteca ---");
        if (membros.Any())
        {
            foreach (var membro in membros)
            {
                membro.ExibirDetalhes();
            }
        }
        else
        {
            Console.WriteLine("Nenhum membro cadastrado.");
        }
    }

    public void RealizarEmprestimo(int idLivro, int idMembro)
    {
        var livro = acervo.FirstOrDefault(l => l.Id == idLivro);
        var membro = membros.FirstOrDefault(m => m.Id == idMembro);

        if (livro == null)
        {
            Console.WriteLine("Livro não encontrado.");
            return;
        }

        if (membro == null)
        {
            Console.WriteLine("Membro não encontrado.");
            return;
        }

        if (!livro.Disponivel)
        {
            Console.WriteLine("O livro não está disponível para empréstimo.");
            return;
        }

        var emprestimo = new Emprestimo(livro, membro);
        membro.Emprestimos.Add(emprestimo);
        livro.Disponivel = false;

        Console.WriteLine($"Empréstimo realizado com sucesso! \"{livro.Titulo}\" para {membro.Nome}.");
        Console.WriteLine($"Data para devolução: {emprestimo.DataDevolucaoPrevista.ToShortDateString()}");
    }

    public void RealizarDevolucao(int idLivro)
    {
        var livro = acervo.FirstOrDefault(l => l.Id == idLivro);

        if (livro == null)
        {
            Console.WriteLine("Livro não encontrado.");
            return;
        }

        if (livro.Disponivel)
        {
            Console.WriteLine("Este livro já consta como disponível.");
            return;
        }

        var emprestimoAtivo = membros.SelectMany(m => m.Emprestimos)
                                     .FirstOrDefault(e => e.Livro.Id == idLivro && e.DataDevolucaoReal == null);

        if (emprestimoAtivo == null)
        {
            Console.WriteLine("Não foi encontrado um empréstimo ativo para este livro.");
            return;
        }

        emprestimoAtivo.DataDevolucaoReal = DateTime.Now;
        livro.Disponivel = true;

        var multa = emprestimoAtivo.CalcularMulta();
        Console.WriteLine($"Devolução de \"{livro.Titulo}\" por {emprestimoAtivo.Membro.Nome} realizada com sucesso.");

        if (multa > 0)
        {
            Console.WriteLine($"Atenção: Multa por atraso no valor de R$ {multa:F2}.");
        }
    }
}