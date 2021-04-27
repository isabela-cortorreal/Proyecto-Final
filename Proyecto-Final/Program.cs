using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final
{
    class Program
    {
        static void Main(string[] args)
        {
            Sistema_Prestamos sp = new Sistema_Prestamos();
            sp.menu_principal();
            sp.operaciones();
            sp.tabla_amortizacion();
        }
    }

    class Sistema_Prestamos
    {
        public float cuota, interes_pago, capital_pago, monto_prestamo, tasa_anual, tasa_mensual;
        public int num_pago, plazo;

        public void menu_principal()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("                      Bienvenido");
            Console.WriteLine("----------------------------------------------------------");
            Console.Write("\n" + "Ingrese el monto del prestamo: ");
            monto_prestamo = float.Parse(Console.ReadLine());
            Console.Write("\n" + "Ingrese su tasa de porcentaje anual: ");
            tasa_anual = float.Parse(Console.ReadLine());
            Console.Write("\n" +  "Ingrese el plazo de meses en los que desea pagar: ");
            plazo = int.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("\n" + "----------------------------------------------------------");
            Console.WriteLine("\n" + "Monto del prestamo en RD$: " + monto_prestamo);
            Console.WriteLine("Tasa de Porcentaje Anual: " + tasa_anual + "%");
            Console.WriteLine("Plazo: " + plazo + " Meses");
        }

        public void operaciones()
        {
            tasa_mensual = (tasa_anual / 100) / 12;

            cuota = tasa_mensual + 1;
            cuota = (float)Math.Pow(cuota, plazo);
            cuota = cuota - 1;
            cuota = tasa_mensual / cuota;
            cuota = tasa_mensual + cuota;
            cuota = monto_prestamo * cuota;

            Console.WriteLine("Valor Cuota: " + cuota + "\n");
        }

        public void tabla_amortizacion()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("                   Tabla de Amortización");
            Console.WriteLine("----------------------------------------------------------");
            num_pago = 1;
            Console.WriteLine("\n");
            Console.Write("Pago \t");
            Console.Write(" Cuota \t\t");
            Console.Write("Capital \t");
            Console.Write("Interes \t");
            Console.Write("Balance \t");
            Console.WriteLine("\n");
            

            for (int i = 1; i <= plazo; i++)
            {
                interes_pago = tasa_mensual * monto_prestamo;
                capital_pago = cuota - interes_pago;
                Console.Write(" {0} \t", num_pago);
                Console.Write("{0}\t", cuota);
                Console.Write("{0}\t", capital_pago);
                Console.Write("{0}\t", interes_pago);
                monto_prestamo = monto_prestamo - capital_pago;
                Console.Write("{0}\t\t\n", monto_prestamo);

                num_pago = num_pago + 1;
            }
            Console.ReadKey();
        }
    }
}