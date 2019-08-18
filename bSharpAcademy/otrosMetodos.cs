using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bSharpAcademy
{
    public class otrosMetodos
    {
        public static void titulo()
        {
            //Variabls para el menu
            
            string tituloAplicacion = "Bienvenido a la Academia BeSharp (Univeridad de San Jorgito)";
            int lineaBordes = tituloAplicacion.Length;
            
            //Menu

            Console.Clear();
            Console.Title = "Academia BeSharp";

            Console.WriteLine("\t\t\t".PadLeft(lineaBordes, '='));
            Console.WriteLine(tituloAplicacion);
            Console.WriteLine("\n\n\n".PadLeft(lineaBordes, '='));
        }

        //Metodo validacion alumno telefono
        public static bool testDatoNumero(string pNumero)
        {
            int a;
            bool succes = int.TryParse(pNumero, out a);
            return succes;
        }

        internal static bool isADouble(string auxPrecio)
        {
            double a;
            bool succes = double.TryParse(auxPrecio, out a);
            return succes;
        }

        internal static bool isNotEmp(string auxNombre)
        {
            return String.IsNullOrEmpty(auxNombre);
        }

        internal static bool isAByte(string auxDuracion)
        {
            byte a;
            bool succes = byte.TryParse(auxDuracion, out a);
            return succes;
        }

        internal static bool isAInt(string auxInt)
        {
            int a;
            bool succes = int.TryParse(auxInt, out a);
            return succes;
        }

    }
}
