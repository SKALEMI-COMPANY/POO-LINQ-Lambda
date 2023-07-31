using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Skalemi Company
// Si te surge alguna duda, contáctame.
// michaelvinces.skalemi@gmail.com

namespace Práctica_LINQ
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Programador: SKALEMI COMPANY\n");
            // List with eah element of type Student 
            List<Estudiante> details = new List<Estudiante>() {
            new Estudiante{ Id = 1, Nombre = "Liza", Apellido="Zambrano", Promedio= 10, Edad=22 },
                new Estudiante{ Id = 2, Nombre = "Stewart",  Apellido="Rivera",Promedio= 9.9M , Edad=19 },
                new Estudiante{ Id = 3, Nombre = "Tina",  Apellido="Mendoza",Promedio= 7.8M, Edad=20  },
                new Estudiante{ Id = 4, Nombre = "Stefani",  Apellido="Pico",Promedio= 5, Edad=18  },
                new Estudiante { Id = 5, Nombre = "Trish",  Apellido="Restrepo",Promedio= 3, Edad=23  }
        };


            Console.WriteLine("Dado la siguiente coleccion de datos, utilizando expresiones Lambda: \n");
            //Dado la siguiente coleccion de datos, utilizando expresiones Lambda:
            //1. Muestre por pantalla los nombres de los estudiantes

            var solonombre = details.Aggregate("",(mensaje,estudiante)=>mensaje+= "  >>" + estudiante.Nombre+"\n");
            Console.WriteLine("  1. Muestre por pantalla los nombres de los estudiantes: ");
            Console.WriteLine(solonombre);

            //2. Muestre por pantalla los nombres y apellidos de los estudiantes ordenados por promedio de mayor a menor
            
            var porpromedio = details.OrderByDescending(x => x.Promedio)
                .Aggregate("", (mensaje, estudiante) => mensaje += "  Promedio: " + estudiante.Promedio+
                "\t" +estudiante.Nombre+" "+estudiante.Apellido+ "\n");           
            Console.WriteLine("\n  2. Muestre por pantalla los nombres y apellidos de los estudiantes ordenados por promedio de mayor a menor: ");
            Console.WriteLine(porpromedio);

            //3. Muestre por pantalla los apellidos de los estudiantes ordenados ascendente alfabéticamente
            var porapellido = details.OrderBy(x => x.Apellido)
                .Aggregate("", (mensaje, estudiante) => mensaje += "  >>" + estudiante.Apellido + "\n");
            Console.WriteLine("\n  3. Muestre por pantalla los apellidos de los estudiantes ordenados ascendente alfabéticamente: ");
            Console.WriteLine(porapellido);

            //4.Muestre por pantalla los datos del estudiante mas joven
            var edadmenor = details.OrderBy(x => x.Edad).First(); 
            Console.WriteLine("\n  4. Muestre por pantalla los datos del estudiante mas joven: ");
            Console.WriteLine($"  ID: {edadmenor.Id}" +
                $"\n  Estudiante: {edadmenor.Nombre} {edadmenor.Apellido}" +
                $"\n  Promedio: {edadmenor.Promedio}\n  Edad: {edadmenor.Edad}");



            Console.WriteLine("\n--------- Presione Enter para pasar al siguiente ejercicio ---------");
            Console.ReadKey();
            Console.Clear();

            //Dado la siguiente coleccion de datos, utilizando expresiones Lambda:
            Console.WriteLine("  Dado la siguiente coleccion de datos, utilizando expresiones Lambda:");
            List<int> numeros = new List<int> { 1, 2, 3, 4, 5, 6, 1, 2, 3, 4, 5, 6 };
            Console.Write("  [Números]\t");
            foreach (var item in numeros)
            {
                Console.Write(item + "\t");
            }
            //1. Muestre por pantalla el cuadrado de los números
            var potencia = numeros.Select((numero) => numero * numero)
                .Aggregate("",(calculo,numero)=>calculo+=numero+"\t");

            Console.WriteLine("\n\n   1. Muestre por pantalla el cuadrado de los números");
            Console.Write("  [Potencia(2)]\t");
            Console.WriteLine(potencia);
 

            //2. Muestre por pantalla los números pares

            var pares = numeros.Where((numero) => numero % 2 == 0)
                .Aggregate("", (calculo, numero) => calculo += numero + "\t");

            Console.WriteLine("\n\n   2. Muestre por pantalla los números pares");
            Console.Write("  [Números pares]\t");
            Console.WriteLine(pares);


            //3. Muestre por pantalla el resultado de multiplicar por 5 los numero impares
            Func<int, bool> numeroimPar = (numero) => numero % 2 != 0;
            var producto=numeros.Where(numeroimPar)
                .Select(numero=>numero*5)
                .Aggregate("", (calculo, numero) => calculo += numero + "\t");

            var impar = numeros.Where(numeroimPar)
                .Aggregate("", (calculo, numero) => calculo += numero + "\t");
            

            Console.WriteLine("\n\n   3. Muestre por pantalla el resultado de multiplicar por 5 los números impares");
            Console.Write("  [Números Impares]\t");
            Console.WriteLine(impar);
            Console.Write("  [Producto(5)]\t\t");
            Console.WriteLine(producto);   
            
            Console.ReadKey();
            
        }

    }
}
