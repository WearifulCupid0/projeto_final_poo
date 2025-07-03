using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main(string[] args)
    {
        Biblioteca minhaBiblioteca = new Biblioteca();

        // adicionando alguns livros e membros para teste
        minhaBiblioteca.AdicionarLivro("O Senhor dos Anéis", "J.R.R. Tolkien");
        minhaBiblioteca.AdicionarLivro("1984", "George Orwell");
        minhaBiblioteca.AdicionarLivro("Dom Quixote", "Miguel de Cervantes");

        minhaBiblioteca.AdicionarMembro("João da Silva");
        minhaBiblioteca.AdicionarMembro("Maria Oliveira");

        // exemplo de fluxo de uso
        minhaBiblioteca.ListarLivrosDisponiveis();
        minhaBiblioteca.ListarMembros();

        Console.WriteLine("\n--- Realizando Empréstimo ---");
        minhaBiblioteca.RealizarEmprestimo(1, 1); // joao pega "O Senhor dos Anéis"
        minhaBiblioteca.RealizarEmprestimo(2, 2); // maria pega "1984"

        Console.WriteLine("\n--- Situação Atual ---");
        minhaBiblioteca.ListarTodosOsLivros();
        minhaBiblioteca.ListarMembros();

        Console.WriteLine("\n--- Realizando Devolução ---");
        minhaBiblioteca.RealizarDevolucao(1); // joao devolve "O Senhor dos Anéis"

        Console.WriteLine("\n--- Situação Final ---");
        minhaBiblioteca.ListarTodosOsLivros();
        minhaBiblioteca.ListarMembros();

    }
}
