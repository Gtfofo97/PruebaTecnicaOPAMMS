using System;

namespace ContadorPalabras
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cadena = "";
            //Solicitamos la cadena string
            Console.WriteLine("Escribe una frase u oración: ");
            cadena = Console.ReadLine().ToString().Trim();

            //Solicitamos la palabra a buscar en la cadena
            //Console.WriteLine("Escribe la palabra a buscar en la cadena: ");
            //palabra = Console.ReadLine().ToString().Trim();

            string frase = cadena.ToLower(); //Cadena de texto a minusculas
            string[] miArreglo = frase.Split(' '); //fragmenta la cadena y devuelve un array
            int items = miArreglo.Length; // cuenta los elementos del array
            for (int i = 0; i < miArreglo.Length; i++)
            {
                Console.WriteLine(miArreglo[i]);
            }
            Console.WriteLine("La cadena tiene: " + items + " palabras ");
        }
    }
}
