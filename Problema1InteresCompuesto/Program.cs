// Problema 1: Módulo de capitalización recursiva (interés compuesto anual)
//
// Calcula el monto total acumulado C(n) de una inversión después de n años,
// a partir de un capital inicial m y una tasa de interés anual X (%).
//
//   Caso base:      C(0) = m
//   Caso recursivo: C(n) = C(n - 1) * (1 + i),   donde i = X / 100
//
// Restricción: el cálculo se resuelve solo con recursividad (sin for ni while).

Console.OutputEncoding = System.Text.Encoding.UTF8;

// Convierte la tasa porcentual (X) a su equivalente decimal (i).
static decimal ConvertirTasaADecimal(decimal tasaPorcentaje)
{
    return tasaPorcentaje / 100m;
}

// Devuelve el monto acumulado al final del año n.
static decimal CalcularMontoAcumulado(decimal capitalInicial, decimal interes, int anios)
{
    // Caso base: si no han transcurrido años, el monto es el capital inicial.
    if (anios == 0)
    {
        return capitalInicial;
    }

    // Caso recursivo: el monto del año anterior crece por el factor (1 + i).
    return CalcularMontoAcumulado(capitalInicial, interes, anios - 1) * (1 + interes);
}

Console.WriteLine("=== Cálculo de interés compuesto (recursivo) ===");

Console.Write("Ingrese el capital inicial (m): $");
if (!decimal.TryParse(Console.ReadLine(), out decimal capital) || capital < 0)
{
    Console.WriteLine("Error: el capital debe ser un valor numérico mayor o igual a 0.");
    return;
}

Console.Write("Ingrese la tasa de interés anual (X) en %: ");
if (!decimal.TryParse(Console.ReadLine(), out decimal tasa) || tasa < 0)
{
    Console.WriteLine("Error: la tasa debe ser un valor numérico mayor o igual a 0.");
    return;
}

Console.Write("Ingrese el tiempo de la inversión en años (n): ");
if (!int.TryParse(Console.ReadLine(), out int anios) || anios < 0)
{
    Console.WriteLine("Error: los años deben ser un número entero mayor o igual a 0.");
    return;
}

decimal interes = ConvertirTasaADecimal(tasa);
decimal montoFinal = CalcularMontoAcumulado(capital, interes, anios);

Console.WriteLine();
Console.WriteLine($"Capital inicial (m):     ${capital:N2}");
Console.WriteLine($"Tasa anual (X):          {tasa}%");
Console.WriteLine($"Interés en factor (i):   {interes}");
Console.WriteLine($"Años (n):                {anios}");
Console.WriteLine($"Monto acumulado C({anios}):  ${montoFinal:N2}");
