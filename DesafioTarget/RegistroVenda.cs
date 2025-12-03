public class Venda
{
    public string Vendedor { get; set; } = "---";
    public double Valor { get; set; }

    public double calcularComissao()
    {
        if (Valor < 100)
        {
            return 0;
        }
        else if (Valor < 500)
        {
            return Valor * 0.01;
        }
        else
        {
            return Valor * 0.05;
        }
    }

}