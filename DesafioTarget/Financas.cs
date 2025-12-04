namespace DesafioTarget;

/// <summary>
/// Conjunto de funcionalidades financeiras.
/// </summary>
public static class Financas
{
    /// <summary>
    /// Calcula os juros compostos sobre um valor inicial, considerando uma multa diária.
    /// </summary>
    /// <param name="valorInicial">Valor inicial sobre o qual os juros serão calculados</param>
    /// <param name="dataDeVencimento">Data de vencimento a partir de quando serão calculados os juros.</param>
    /// <returns>Valor do montante de juros</returns>
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
