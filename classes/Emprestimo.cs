public class Emprestimo
{
    public Livro Livro { get; private set; }
    public Membro Membro { get; private set; }
    public DateTime DataEmprestimo { get; private set; }
    public DateTime DataDevolucaoPrevista { get; private set; }
    public DateTime? DataDevolucaoReal { get; set; }

    public Emprestimo(Livro livro, Membro membro)
    {
        Livro = livro;
        Membro = membro;
        DataEmprestimo = DateTime.Now;
        DataDevolucaoPrevista = DateTime.Now.AddDays(14); // Prazo de 14 dias para devolução
        DataDevolucaoReal = null;
    }

    public decimal CalcularMulta()
    {
        if (DataDevolucaoReal.HasValue && DataDevolucaoReal.Value > DataDevolucaoPrevista)
        {
            var diasAtraso = (DataDevolucaoReal.Value - DataDevolucaoPrevista).Days;
            return diasAtraso * 1.50m; // R$ 1,50 por dia de atraso
        }
        return 0;
    }
}