using System;

namespace TuplasLambdaPractica
{
    delegate int Operacion(int x, int y); //para ejercicio lambda 1
    class Program
    {
        static void Main(string[] args)
        {
            #region tupla
            var proveedor = ("Manuel", "Velázquez", 50);
            Console.WriteLine($"Proveedor: {proveedor.Item1}, {proveedor.Item2}, {proveedor.Item3}");

            //valores nombrados
            var proveedorB = (Nombre: "Manuel", Apellido: "Velázquez", Edad: 50);
            Console.WriteLine($"Proveedor: {proveedorB.Nombre}, {proveedorB.Apellido}, {proveedorB.Edad}");

            //especificar tipos
            (string Nombre, string Apellido, int Edad) proveedorC = (Nombre: "Carmen", Apellido: "Nieto", Edad: 35);

            proveedorB.Nombre = "María";
            Console.WriteLine($"Proveedor: {proveedorB.Nombre}, {proveedorB.Apellido}");

            //asignar una tupla a otra
            proveedorB = proveedorC;
            Console.WriteLine($"Proveedor: {proveedorB.Nombre}, {proveedorB.Apellido}");
            #endregion

            #region lambda 1
            Operacion op = (a, b) => a * b;
            Console.WriteLine($"total: {op(2, 2)}");

            Operacion potencia = (a, b) =>  //a es base, b es potencia
            {
                Console.WriteLine($"{a} elevado a la {b} potencia..");
                return (int)Math.Pow(a, b);
            };

            int x = 2;
            int z = 4;
            int t = potencia(x, z);
            Console.WriteLine($"Total {t}");

            //usando Func y Action delegates
            Func<int, int, int> pot = (x, y) => (int)Math.Pow(x, y);
            Console.WriteLine($"potencia: {pot(5, 5)}");

            Func<string, string, bool> igual = (a, b) => a.Equals(b);
            string cadA = "Noemi";
            string cadB = "noemi";
            Console.WriteLine($"Son iguales? : {igual(cadA, cadB)}");
            #endregion

            #region lambda 2
            int a = 5;
            Func<int, int> suma = s => x + a;
            a = 10;
            Console.WriteLine($"Suma = { suma(2) }");

            //iteraciones ciclo for
            Func<int, int, int> potB = (x, y) => (int)Math.Pow(x, y);
            int baseP = 5;
            for (int i = 1; i <= 3; i++)
            {
                int res = potB(baseP, i);
                Console.WriteLine($"{baseP} Elevado a la {i} potencia = { res }");
            }

            //iteraciones foreach
            Action<char> mayus = (ch) => Console.WriteLine(Char.ToUpper(ch)+"\n");
            Console.WriteLine("Ingresa un texto");
            string cadenaUsuario = Console.ReadLine();
            foreach(char c in cadenaUsuario)
            {
                mayus(c);
            }

            //tuplas
            Func<(int, int), (int, int)> invertir = c => (c.Item1 * -1, c.Item2 * -1);
            var coordenadas = (-20, 50);
            Console.WriteLine($"Coordenadas Invertidas {invertir(coordenadas)}");

            #endregion
        }
    }
}
