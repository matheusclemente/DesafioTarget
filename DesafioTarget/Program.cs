using System.Text.Json;
using System.Xml.Serialization;

// Desafio 1
string jsonString = File.ReadAllText("vendas.json");
JsonSerializerOptions options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true,
};
var listaDeVendas = JsonSerializer.Deserialize<VendasData>(jsonString, options)!;

foreach (var venda in listaDeVendas.Vendas)
{
    Console.WriteLine($"Vendedor: {venda.Vendedor} - Valor: {venda.Valor} - Comissão: {venda.calcularComissao()}");
}

