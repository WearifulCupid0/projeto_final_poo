public class Livro
{
    public int Id { get; private set; }
    public string Titulo { get; private set; }
    public string Autor { get; private set; }
    public bool Disponivel { get; set; }

    public Livro(int id, string titulo, string autor)
    {
        Id = id;
        Titulo = titulo;
        Autor = autor;
        Disponivel = true;
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($"  ID: {Id} | Título: \"{Titulo}\" | Autor: {Autor} | Disponível: {(Disponivel ? "Sim" : "Não")}");
    }
}
