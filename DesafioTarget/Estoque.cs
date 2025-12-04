namespace DesafioTarget;

/// <summary>
///  Conjunto de dados de estoque.
/// </summary>
class EstoqueData
{
    /// <summary>
    /// Lista de produtos em estoque.
    /// </summary>
    public List<Produto> Estoque { get; set; } = new List<Produto>();

    /// <summary>
    /// Realiza a entrada de produtos no estoque.
    /// </summary>
    /// <param name="codigoProduto">Número identificador do produto</param>
    /// <param name="quantidade">Quantidade do produto a ser movimentada</param>
    /// <returns>Quantidade atualizada do estoque, ou -1 em caso de código não encontrado</returns>
    public int EntradaProduto(int codigoProduto, int quantidade)
    {
        var produto = Estoque.FirstOrDefault(p => p.CodigoProduto == codigoProduto);
        if (produto != null)
        {
            produto.Estoque += quantidade;
            return produto.Estoque;
        }
        return -1; // Produto não encontrado
    }

    /// <summary>
    /// Realiza a retirada de produtos do estoque.
    /// </summary>
    /// <param name="codigoProduto">Número identificador do produto</param>
    /// <param name="quantidade">Quantidade do produto a ser movimentada</param>
    /// <returns>Quantidade atualizada do estoque, ou -1 em caso de código não encontrado, ou -2 caso o estoque seja insuficiente</returns>
    public int SaidaProduto(int codigoProduto, int quantidade)
    {
        var produto = Estoque.FirstOrDefault(p => p.CodigoProduto == codigoProduto);
        if (produto != null)
        {
            if (produto.Estoque >= quantidade)
            {
                produto.Estoque -= quantidade;
                return produto.Estoque;
            }
            else
            {
                return -2; // Estoque insuficiente
            }
        }
        return -1; // Produto não encontrado
    }

    public int ConsultarEstoque(int codigoProduto)
    {
        var produto = Estoque.FirstOrDefault(p => p.CodigoProduto == codigoProduto);
        if (produto != null)
        {
            return produto.Estoque;
        }
        return -1; // Produto não encontrado
    }
}

/// <summary>
/// Produto no estoque.
/// </summary>
class Produto
{
    /// <summary>
    /// Número identificador único do produto.
    /// </summary>
    public int CodigoProduto { get; set; }
    /// <summary>
    /// Descrição do produto.
    /// </summary>
    public string Descricao { get; set; } = "---";
    /// <summary>
    /// Quantidade disponível no estoque.
    /// </summary>
    public int Estoque { get; set; }
}