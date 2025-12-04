namespace DesafioTarget;
/// <summary>
///  Conjunto de dados de vendas.
/// </summary>
public class VendasData
{
    /// <summary>
    /// Lista de vendas.
    /// </summary>
    public List<Venda> Vendas { get; set; } = [];

}

/// <summary>
/// Venda realizada por um vendedor.
/// </summary>
public class Venda
{
    /// <summary>
    /// Nome do vendedor.
    /// </summary>
    public string Vendedor { get; set; } = "---";
    /// <summary>
    /// Valor da venda.
    /// </summary>
    public double Valor { get; set; }

    private const double valorParaComissaoMinima = 100;
    private const double valorParaComissaoMaxima = 500;

    private const double taxaComissaoMinima = 0.01;
    private const double taxaComissaoMaxima = 0.05;

    /// <summary>
    /// Calcula a comissão da venda com base no valor.
    /// </summary>
    /// <returns>Valor da comissão.</returns>
    public double CalcularComissao()
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