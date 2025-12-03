using System.Text.Json;
using System.Xml.Serialization;

// Desafio 1
string jsonString = File.ReadAllText("vendas.json");
JsonSerializerOptions options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,
};
var listaDeVendas = JsonSerializer.Deserialize<VendasData>(jsonString, options)!;

// Total de comissões por vendedor
var comissaoPorVendedor = new Dictionary<string, double>();

foreach (var venda in listaDeVendas.Vendas)
{
    var comissao = venda.calcularComissao();
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


// Desafio 2

