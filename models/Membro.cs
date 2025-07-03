public class Membro
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public List<Emprestimo> Emprestimos { get; private set; }

    public Membro(int id, string nome)
    {
        Id = id;
        Nome = nome;
        Emprestimos = new List<Emprestimo>();
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"ID: {Id} | Nome: {Nome}");
        if (Emprestimos.Any(e => e.DataDevolucaoReal == null))
        {
            Console.WriteLine("  Livros emprestados atualmente:");
            foreach (var emprestimo in Emprestimos.Where(e => e.DataDevolucaoReal == null))
            {
                Console.WriteLine($"    - Livro \"{emprestimo.Livro.Titulo}\" (Devolver em: {emprestimo.DataDevolucaoPrevista.ToShortDateString()})");
            }
        }
    }
}
