using System.Text.Json;
using DesafioTarget;

JsonSerializerOptions options = new()
{
    PropertyNameCaseInsensitive = true,
};

System.Console.WriteLine("Desafio Target - Selecione o desafio (1, 2 ou 3):");
string desafioSelecionado = Console.ReadLine()!;
switch (desafioSelecionado)
{
    case "1":
        Desafio1();
        break;
    case "2":
        Desafio2();
        break;
    case "3":
        Desafio3();
        break;
    default:
        System.Console.WriteLine("Opção inválida. Por favor, selecione 1, 2 ou 3.");
        break;
}

// Desafio 1
void Desafio1()
{
    string jsonString = File.ReadAllText("vendas.json");
    var listaDeVendas = JsonSerializer.Deserialize<VendasData>(jsonString, options)!;

    // Total de comissões por vendedor
    var comissaoPorVendedor = new Dictionary<string, double>();

    foreach (var venda in listaDeVendas.Vendas)
    {
        var comissao = venda.CalcularComissao();
        if (comissaoPorVendedor.ContainsKey(venda.Vendedor))
        {
            comissaoPorVendedor[venda.Vendedor] += comissao;
        }
        else
        {
            comissaoPorVendedor[venda.Vendedor] = comissao;
        }
    }

    foreach (var comissao in comissaoPorVendedor)
    {
        Console.WriteLine($"Vendedor: {comissao.Key} - Comissão Total: {comissao.Value.ToString("C2")}");
    }

}


// Desafio 2
void Desafio2()
{
    string jsonString = File.ReadAllText("estoque.json");
    var estoque = JsonSerializer.Deserialize<EstoqueData>(jsonString, options)!;

    System.Console.WriteLine("Informe o código do produto:");
    int codigoProduto = Convert.ToInt32(Console.ReadLine());
    System.Console.WriteLine("Informe o tipo de movimentação:\n1 - Entrada\n2 - Saída\n3 - Consulta");
    int tipoMovimentacao = Convert.ToInt32(Console.ReadLine());
    switch (tipoMovimentacao)
    {
        case 1:
            System.Console.WriteLine("Informe a quantidade para entrada:");
            int quantidadeEntrada = Convert.ToInt32(Console.ReadLine());
            int novoEstoqueEntrada = estoque.EntradaProduto(codigoProduto, quantidadeEntrada);
            if (novoEstoqueEntrada != -1)
            {
                System.Console.WriteLine($"Novo estoque do produto {codigoProduto}: {novoEstoqueEntrada}");
            }
            else
            {
                System.Console.WriteLine("Código do produto não encontrado.");
            }
            break;
        case 2:
            System.Console.WriteLine("Informe a quantidade para saída:");
            int quantidadeSaida = Convert.ToInt32(Console.ReadLine());
            int novoEstoqueSaida = estoque.SaidaProduto(codigoProduto, quantidadeSaida);
            if (novoEstoqueSaida == -1)
            {
                System.Console.WriteLine("Código do produto não encontrado.");
            }
            else if (novoEstoqueSaida == -2)
            {
                System.Console.WriteLine("Estoque insuficiente para a retirada.");
            }
            else
            {
                System.Console.WriteLine($"Novo estoque do produto {codigoProduto}: {novoEstoqueSaida}");
            }
            break;
        case 3:
            int estoqueAtual = estoque.ConsultarEstoque(codigoProduto);
            if (estoqueAtual != -1)
            {
                System.Console.WriteLine($"Estoque atual do produto {codigoProduto}: {estoqueAtual}");
            }
            else
            {
                System.Console.WriteLine("Código do produto não encontrado.");
            }
            break;
        default:
            System.Console.WriteLine("Tipo de movimentação inválido.");
            break;
    }
}

// Desafio 3
void Desafio3()
{
    System.Console.WriteLine("Informe o valor inicial:");
    double valorInicial = Convert.ToDouble(Console.ReadLine());
    System.Console.WriteLine("Informe a data de vencimento (formato: yyyy-MM-dd):");
    DateTime dataDeVencimento = DateTime.Parse(Console.ReadLine()!);
    double valorJuros = Financas.CalcularJurosCompostos(valorInicial, dataDeVencimento);
    System.Console.WriteLine($"Valor dos juros na data de hoje: {valorJuros.ToString("C2")}");
}