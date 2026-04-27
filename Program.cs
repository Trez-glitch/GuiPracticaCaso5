/*Caso 5. Taller grupal: Simulador de caja de supermercado (Caso integrador)
Una tienda desea simular el funcionamiento de una caja registradora para procesar compras
de varios clientes. En grupos, diseñe un programa en C# que permita ingresar productos
comprados por cada cliente (nombre, precio y cantidad), acumulando subtotales y
calculando el total a pagar.
El sistema deberá incluir:
• Uso de ciclos para registrar múltiples productos por cliente.
• Uso de acumuladores para subtotal y total de ventas.
• Uso de contadores para cantidad de productos procesados.
• Uso de condicionales para aplicar descuentos:
o 5% si la compra supera C$1,000
o 10% si supera C$3,000
Además, el sistema deberá calcular:
• Total facturado.
• Número de clientes atendidos.
• Producto con mayor precio.
• Promedio de compra por cliente. */

using System;

class Program
{
    static void Main()
    {
        // Variables globales (Acumuladores y Contadores del día)
        decimal totalFacturadoDia = 0;
        int totalClientesAtendidos = 0;
        decimal precioProductoMasCaro = 0;
        string nombreProductoMasCaro = "";

        bool terminarDia = false;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("========================================");
        Console.WriteLine("   SIMULADOR DE CAJA - SUPERMERCADO     ");
        Console.WriteLine("========================================\n");
        Console.ResetColor();

        while (!terminarDia)
        {
            totalClientesAtendidos++;
            decimal subtotalCliente = 0;
            int productosDeEsteCliente = 0;
            bool masProductos = true;

            Console.WriteLine($"--- CLIENTE #{totalClientesAtendidos} ---");

            // Ciclo para registrar productos por cliente
            while (masProductos)
            {
                Console.Write("Nombre del producto: ");
                string nombreProd = Console.ReadLine()!;

                Console.Write("Precio (C$): ");
                decimal precio = decimal.Parse(Console.ReadLine()!);

                Console.Write("Cantidad: ");
                int cantidad = int.Parse(Console.ReadLine()!);

                // Lógica para encontrar el producto más caro del día
                if (precio > precioProductoMasCaro)
                {
                    precioProductoMasCaro = precio;
                    nombreProductoMasCaro = nombreProd;
                }

                // Acumuladores y contadores por cliente
                subtotalCliente += (precio * cantidad);
                productosDeEsteCliente += cantidad;

                Console.Write("¿Desea agregar otro producto para este cliente? (s/n): ");
                if (Console.ReadLine()!.ToLower() != "s") masProductos = false;
            }

            // Aplicación de condicionales para descuentos
            decimal descuento = 0;
            if (subtotalCliente > 3000)
                descuento = subtotalCliente * 0.10m; // 10%
            else if (subtotalCliente > 1000)
                descuento = subtotalCliente * 0.05m; // 5%

            decimal totalAPagar = subtotalCliente - descuento;
            totalFacturadoDia += totalAPagar;

            // Reporte por cliente
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n------------------------------------");
            Console.WriteLine($"Subtotal:       C${subtotalCliente:N2}");
            Console.WriteLine($"Descuento:      C${descuento:N2}");
            Console.WriteLine($"Total a Pagar:  C${totalAPagar:N2}");
            Console.WriteLine($"Productos:      {productosDeEsteCliente}");
            Console.WriteLine("------------------------------------\n");
            Console.ResetColor();
            
            Console.Write("¿Hay más clientes en la fila? (s/n): ");
            if (Console.ReadLine()!.ToLower() != "s") terminarDia = true;
        }

        // Cálculos finales y cierre
        decimal promedioCompra = totalClientesAtendidos > 0 ? totalFacturadoDia / totalClientesAtendidos : 0;

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n========================================");
        Console.WriteLine("        CIERRE DE CAJA FINAL            ");
        Console.WriteLine("========================================");
        Console.WriteLine($"Clientes atendidos:      {totalClientesAtendidos}");
        Console.WriteLine($"Total facturado:         C${totalFacturadoDia:N2}");
        Console.WriteLine($"Promedio por cliente:    C${promedioCompra:N2}");
        Console.WriteLine($"Producto más caro:       {nombreProductoMasCaro} (C${precioProductoMasCaro:N2})");
        Console.WriteLine("========================================");
        Console.ResetColor();
        
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
        Console.ResetColor();
    }
}
