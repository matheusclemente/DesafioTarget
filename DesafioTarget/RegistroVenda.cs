public class VendasData
{
    public List<Venda> Vendas { get; set; } = [];

}

public class Venda
{
    private const double valorParaComissaoMinima = 100;
    private const double valorParaComissaoMaxima = 500;

    private const double taxaComissaoMinima = 0.01;
    private const double taxaComissaoMaxima = 0.05;

    public string Vendedor { get; set; } = "---";
    public double Valor { get; set; }

    public double calcularComissao()
    {
        if (Valor < valorParaComissaoMinima)
        {
            return 0;
        }
        else if (Valor < valorParaComissaoMaxima)
        {
            return Valor * taxaComissaoMinima;
        }
        else
        {
            return Valor * taxaComissaoMaxima;
        }
    }

}