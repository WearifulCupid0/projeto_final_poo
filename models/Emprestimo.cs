public class Emprestimo
{
    public Livro Livro { get; private set; }
    public Membro Membro { get; private set; }
    public DateTime DataEmprestimo { get; private set; }
    public DateTime DataDevolucaoPrevista { get; set; }
    public DateTime? DataDevolucaoReal { get; set; }

    public Emprestimo(Livro livro, Membro membro)
    {
        Livro = livro;
        Membro = membro;
        DataEmprestimo = DateTime.Now;
        DataDevolucaoPrevista = DateTime.Now.AddDays(14);
        DataDevolucaoReal = null;
    }

    public decimal CalcularMulta()
    {
        if (DataDevolucaoReal.HasValue && DataDevolucaoReal.Value > DataDevolucaoPrevista)
        {
            var diasAtraso = (DataDevolucaoReal.Value - DataDevolucaoPrevista).Days;
            if (diasAtraso > 0)
            {
                return diasAtraso * 1.50m; // R$ 1,50 por dia de atraso
            }
        }
        return 0;
    }
}
