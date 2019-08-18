using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bSharpAcademy
{
    public class Alumno
    {
        private int _ci;
        private string _nombre;
        private string _telefono;
        private string _direccion;

        public int Ci
        {
            get { return _ci; }
            set
            {
                if (value.ToString().Trim().Length != 7)
                    throw new Exception("La cédula debe tener 7 digitos. No incluya guión ni dígito verificador");
                _ci = value;
            }

        }

        public string Nombre
        {
            get { return _nombre; }
            set {

                if (String.IsNullOrEmpty(value))
                    throw new Exception("Debe indicar un nombre para el alumno");
                
                _nombre = value; }
        }

        public string Telefono
        {
            get { return _telefono; }
            set { 
                if(otrosMetodos.testDatoNumero(value) == false)
                    throw new Exception("Solo se permite el ingreso de números en el campo teléfono");
                if(value.Length <= 7 || value.Length >= 10)
                    throw new Exception("Debe indicar un telefono de 8 o 9 digitos");

                _telefono = value; }
        }

        public string Direccion
        {
            get { return _direccion; }
            set {

                if (String.IsNullOrEmpty(value))
                    throw new Exception("Debe indicar una dirección para el alumno");
                
                _direccion = value; }
        }


        public List<Inscripcion> inscripList = new List<Inscripcion>();

        // Oper & Met

        public override string ToString()
        {
         
            return " \n Ci: " + Ci + " \n Nombre: " + Nombre + " \n Telefono: " + Telefono + "\n Direccion: " + Direccion;

        }


        //Constructor

        public Alumno(int ci, string nombre, string telefono, string direccion)
        {

            Ci = ci;
            Nombre = nombre;
            Telefono = telefono;
            Direccion = direccion;

        }

        public Alumno()
        {

        }

    }
}
