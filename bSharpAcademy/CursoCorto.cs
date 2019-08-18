using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bSharpAcademy
{
    public class CursoCorto : Curso
    {

        //Atr y prop

        private string _area;

        public string Area
        {
            get { return _area; }
            set
            {

                if (value != "Programacion" && value != "Economia" && value != "Diseño")
                    throw new Exception("Area de curso ingresada es invalida");

                _area = value;
            }
        }


        //Oper & Met

        public override string ToString()
        {

            return base.ToString() + " Area: " + this._area;

        }

        //Constructor

        public CursoCorto(string area, string id, string nombre, byte duracion, double precio)
            : base(id, nombre, duracion, precio)
        {
            this.Area = area;
        }
    }
}
