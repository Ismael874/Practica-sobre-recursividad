# Práctica sobre recursividad

Dos programas de consola en C# (.NET 10) que resuelven cálculos financieros usando
**únicamente funciones recursivas** (sin `for` ni `while`).

| Proyecto | Descripción |
|---|---|
| `Problema1InteresCompuesto` | Monto acumulado de una inversión con interés compuesto anual. |
| `Problema2Depreciacion` | Valor contable de un activo con depreciación por saldo decreciente. |

## Cómo ejecutar

```bash
dotnet run --project Problema1InteresCompuesto
dotnet run --project Problema2Depreciacion
```

Los decimales se escriben con punto (`1500.50`), según la configuración regional del equipo.

---

## Problema 1: Interés compuesto recursivo

### Variables

| Variable | Descripción | Tipo |
|---|---|---|
| `m` | Capital inicial depositado | `decimal` |
| `X` | Tasa de interés anual (%) | `decimal` |
| `i` | Interés en factor (`X / 100`) | `decimal` (calculado) |
| `n` | Tiempo de la inversión en años | `int` (≥ 0) |
| `C(n)` | Monto acumulado después de `n` años | `decimal` (salida) |

### Lógica recursiva

- **Caso base** (`n = 0`): `C(0) = m`
- **Caso recursivo** (`n > 0`): `C(n) = C(n - 1) × (1 + i)`

### Diagrama de flujo

```mermaid
flowchart TD
    A([Inicio]) --> B[/Leer capital m/]
    B --> C[/Leer tasa X/]
    C --> D[/Leer años n/]
    D --> E{¿Datos válidos?<br/>m ≥ 0, X ≥ 0, n ≥ 0}
    E -- No --> F[/Mostrar error/] --> Z([Fin])
    E -- Sí --> G["i = X / 100"]
    G --> H["C = CalcularMontoAcumulado(m, i, n)"]
    H --> I[/Mostrar C con dos decimales/]
    I --> Z

    subgraph R["CalcularMontoAcumulado(m, i, n)"]
        R1{¿n = 0?}
        R1 -- Sí --> R2["Retornar m<br/>(caso base)"]
        R1 -- No --> R3["Retornar CalcularMontoAcumulado(m, i, n - 1) × (1 + i)<br/>(caso recursivo)"]
    end
```

### Ejemplo

Capital `$1,000`, tasa `10%`, `2` años:

- C(0) = 1,000.00
- C(1) = 1,000.00 × 1.10 = 1,100.00
- C(2) = 1,100.00 × 1.10 = **1,210.00**

---

## Problema 2: Depreciación por saldo decreciente

### Variables

| Variable | Descripción | Tipo |
|---|---|---|
| `V` | Valor de compra original | `decimal` |
| `d` | Tasa de depreciación anual (%) | `decimal` (0 a 100) |
| `r` | Factor de retención (`1 - d / 100`) | `decimal` (calculado) |
| `t` | Años de vida útil transcurridos | `int` (≥ 0) |
| `V(t)` | Valor contable al final del año `t` | `decimal` (salida) |

### Lógica recursiva

- **Caso base** (`t = 0`): `V(0) = V`
- **Caso recursivo** (`t > 0`): `V(t) = V(t - 1) × r`

### Diagrama de flujo

```mermaid
flowchart TD
    A([Inicio]) --> B[/Leer valor de compra V/]
    B --> C[/Leer tasa d/]
    C --> D[/Leer años t/]
    D --> E{¿t < 0?}
    E -- Sí --> F[/"Error: no se permiten años negativos"/] --> Z([Fin])
    E -- No --> G["r = 1 - d / 100"]
    G --> H["Vt = CalcularValorContable(V, r, t)"]
    H --> I[/Mostrar flujo año por año y Vt con dos decimales/]
    I --> Z

    subgraph R["CalcularValorContable(V, r, t)"]
        R1{¿t = 0?}
        R1 -- Sí --> R2["Retornar V<br/>(caso base)"]
        R1 -- No --> R3["Retornar CalcularValorContable(V, r, t - 1) × r<br/>(caso recursivo)"]
    end
```

### Ejemplo

Laptop de `$1,000` con depreciación de `20%` anual:

- Año 0: $1,000.00 (caso base)
- Año 1: $800.00
- Año 2: $640.00
- Año 3: **$512.00**
