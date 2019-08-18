using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bSharpAcademy
{
    public abstract class Curso
    {
        //Atr & Prop
        private string _id;
        private string _nombre;
        private byte _duracion;
        private double _precio;

        public string Id
        {
            get { return _id; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new Exception("Debe indicar un Id para el alumno");

                if (value.Trim().Length > 6)
                    throw new Exception("El ID de curso debe tener un máximo de 6 caracteres.");

                _id = value;

            }
        }

        public string Nombre
        {
            get { return _nombre; }
            set
            {

                if (String.IsNullOrEmpty(value))
                    throw new Exception("Debe indicar un nombre para el curso.");

                _nombre = value;
            }
        }

        public byte Duracion
        {
            get { return _duracion; }
            set
            {
                if (value <= 0)
                    throw new Exception("Debe indicar un numero de semanas valido.");
                _duracion = value;
            }
        }



        public double Precio
        {
            get { return _precio; }
            set
            {
                if (value <= 0)
                    throw new Exception("Debe indicar un precio valido.");

                _precio = value;
            }
        }

        //Oper & Met
        public override string ToString()
        {
            return " Id: " + this._id + " Nombre: " + this._nombre + " Duración en semanas: " + this._duracion + " Precio: " + this._precio;
        }



        //Constructor
        public Curso(string id, string nombre, byte duracion, double precio)
        {
            Id = id;
            Nombre = nombre;
            Duracion = duracion;
            Precio = precio;
        }
    }
}
