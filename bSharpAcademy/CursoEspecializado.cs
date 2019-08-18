using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bSharpAcademy
{
    public class CursoEspecializado : Curso
    {
        //Atr y prop
        private string _pre_requisitos;

        public string Pre_requisitos
        {
            get { return _pre_requisitos; }
            set { _pre_requisitos = value;}
        }


        //Oper y met

        public override string ToString()
        {

            return base.ToString() + " Pre-requisitos: " + this._pre_requisitos;

        }


        //Constructor

        public CursoEspecializado(string pre_requisitos, string id, string nombre, byte duracion, double precio)
            : base(id, nombre, duracion, precio)
        {
            Pre_requisitos = pre_requisitos;
        }





    }
}
