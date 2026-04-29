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
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        decimal totalFacturadoDia = 0;
        int totalClientesAtendidos = 0;
        decimal precioProductoMasCaro = 0;
        string nombreProductoMasCaro = "";

        bool terminarDia = false;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("========================================");
        Console.WriteLine("   SIMULADOR DE CAJA - SUPERMERCADO");
        Console.WriteLine("========================================\n");
        Console.ResetColor();

        while (!terminarDia)
        {
            decimal subtotalCliente = 0;
            int productosDeEsteCliente = 0;
            bool masProductos = true;

            List<string> nombres = new List<string>();
            List<decimal> precios = new List<decimal>();
            List<int> cantidades = new List<int>();
            List<decimal> subtotales = new List<decimal>();

            Console.WriteLine($"--- CLIENTE #{totalClientesAtendidos + 1} ---");

            while (masProductos)
            {
                Console.Write("Nombre del producto: ");
                string nombreProd = Console.ReadLine()!;

                decimal precio;
                Console.Write("Precio (C$): ");
                while (!decimal.TryParse(Console.ReadLine(), out precio) || precio <= 0)
                {
                    Console.Write("Ingrese un precio válido mayor que 0: ");
                }

                int cantidad;
                Console.Write("Cantidad: ");
                while (!int.TryParse(Console.ReadLine(), out cantidad) || cantidad <= 0)
                {
                    Console.Write("Ingrese una cantidad válida mayor que 0: ");
                }

                decimal subtotalProducto = precio * cantidad;

                nombres.Add(nombreProd);
                precios.Add(precio);
                cantidades.Add(cantidad);
                subtotales.Add(subtotalProducto);

                subtotalCliente += subtotalProducto;
                productosDeEsteCliente += cantidad;

                if (precio > precioProductoMasCaro)
                {
                    precioProductoMasCaro = precio;
                    nombreProductoMasCaro = nombreProd;
                }

                Console.Write("¿Desea agregar otro producto para este cliente? (s/n): ");
                if (Console.ReadLine()!.ToLower() != "s")
                {
                    masProductos = false;
                }
            }

            totalClientesAtendidos++;

            decimal descuento = 0;
            string porcentajeDescuento = "0%";

            if (subtotalCliente > 3000)
            {
                descuento = subtotalCliente * 0.10m;
                porcentajeDescuento = "10%";
            }
            else if (subtotalCliente > 1000)
            {
                descuento = subtotalCliente * 0.05m;
                porcentajeDescuento = "5%";
            }

            decimal totalAPagar = subtotalCliente - descuento;
            totalFacturadoDia += totalAPagar;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n------------- FACTURA DEL CLIENTE -------------");
            

            Console.WriteLine("Producto\tCantidad\tPrecio\t\tSubtotal");

            for (int i = 0; i < nombres.Count; i++)
            {
                Console.WriteLine($"{nombres[i]}\t\t{cantidades[i]}\t\tC${precios[i]:N2}\tC${subtotales[i]:N2}");
            }
            Console.ResetColor();

            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine($"Subtotal:             C${subtotalCliente:N2}");
            Console.WriteLine($"Descuento aplicado:   {porcentajeDescuento}");
            Console.WriteLine($"Descuento:            C${descuento:N2}");
            Console.WriteLine($"Total a pagar:        C${totalAPagar:N2}");
            Console.WriteLine($"Productos comprados:  {productosDeEsteCliente}");
            Console.WriteLine("-----------------------------------------------\n");
            Console.ResetColor();

            Console.Write("¿Hay más clientes en la fila? (s/n): ");
            if (Console.ReadLine()!.ToLower() != "s")
            {
                terminarDia = true;
            }
        }

        decimal promedioCompra = totalClientesAtendidos > 0 ? totalFacturadoDia / totalClientesAtendidos : 0;

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n========================================");
        Console.WriteLine("        CIERRE DE CAJA FINAL");
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
