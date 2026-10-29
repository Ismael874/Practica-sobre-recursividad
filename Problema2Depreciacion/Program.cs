// Problema 2: Cálculo de depreciación por saldo decreciente (recursivo)
//
// Calcula el valor contable V(t) de un activo fijo después de t años de uso,
// a partir de su costo inicial V y una tasa de depreciación anual d (%).
//
//   Caso base:      V(0) = V
//   Caso recursivo: V(t) = V(t - 1) * r,   donde r = 1 - d / 100
//
// Restricción: el cálculo se resuelve solo con recursividad (sin for ni while).

Console.OutputEncoding = System.Text.Encoding.UTF8;

// Calcula el factor de retención de valor (r) a partir de la tasa de depreciación (d).
static decimal CalcularFactorRetencion(decimal tasaDepreciacion)
{
    return 1 - tasaDepreciacion / 100m;
}

// Devuelve el valor contable del activo al final del año t.
static decimal CalcularValorContable(decimal costoInicial, decimal factorRetencion, int anios)
{
    // Caso base: antes de comenzar su uso, el activo vale su costo de compra.
    if (anios == 0)
    {
        return costoInicial;
    }

    // Caso recursivo: el valor del año anterior (t - 1) se multiplica por r.
    return CalcularValorContable(costoInicial, factorRetencion, anios - 1) * factorRetencion;
}

// Muestra el valor de cada año desde 0 hasta t, también de forma recursiva.
static void MostrarFlujo(decimal costoInicial, decimal factorRetencion, int anios)
{
    if (anios < 0)
    {
        return;
    }

    MostrarFlujo(costoInicial, factorRetencion, anios - 1);

    decimal valor = CalcularValorContable(costoInicial, factorRetencion, anios);
    string etiqueta = anios == 0 ? " (caso base)" : "";
    Console.WriteLine($"  Año {anios}: ${valor:N2}{etiqueta}");
}

Console.WriteLine("=== Cálculo de depreciación por saldo decreciente (recursivo) ===");

Console.Write("Ingrese el valor de compra original (V): $");
if (!decimal.TryParse(Console.ReadLine(), out decimal costo) || costo < 0)
{
    Console.WriteLine("Error: el valor de compra debe ser un número mayor o igual a 0.");
    return;
}

Console.Write("Ingrese la tasa de depreciación anual (d) en %: ");
if (!decimal.TryParse(Console.ReadLine(), out decimal tasa) || tasa < 0 || tasa > 100)
{
    Console.WriteLine("Error: la tasa debe ser un número entre 0 y 100.");
    return;
}

Console.Write("Ingrese los años de vida útil transcurridos (t): ");
if (!int.TryParse(Console.ReadLine(), out int anios))
{
    Console.WriteLine("Error: los años deben ser un número entero.");
    return;
}

if (anios < 0)
{
    Console.WriteLine("Error: no se permiten años negativos.");
    return;
}

decimal factor = CalcularFactorRetencion(tasa);
decimal valorFinal = CalcularValorContable(costo, factor, anios);

Console.WriteLine();
Console.WriteLine($"Factor de retención (r): {factor}");
Console.WriteLine("Flujo de depreciación:");
MostrarFlujo(costo, factor, anios);
Console.WriteLine();
Console.WriteLine($"Valor contable V({anios}): ${valorFinal:N2}");
