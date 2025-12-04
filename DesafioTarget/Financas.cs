public static class Financas
{
    public static double CalcularJurosCompostos(double valorInicial, DateTime dataDeVencimento)
    {
        const double taxaJuros = 0.025;

        int diasAposVencimento = (DateTime.Today - dataDeVencimento).Days;
        if (diasAposVencimento <= 0)
        {
            return 0;
        }
        else
        {
            return valorInicial * (Math.Pow((1 + taxaJuros), diasAposVencimento) - 1);
        }
    }
}
