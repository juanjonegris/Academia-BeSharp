using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bSharpAcademy
{
    public class Inscripcion
    {

        //Atr & prop
        
        
        private DateTime _fecha;

        private string _empleado;

        private Curso _objCurso;

        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Empleado
        {
            get { return _empleado; }
            set { 
                if(String.IsNullOrEmpty(value))
                    throw new Exception("Debe ingresar un nombre de empleado.");
                _empleado = value; }
        }

        
        public Curso ObjCurso
        { 
            get {return _objCurso;}
            set {
                //TODO validacion de curso
                
                _objCurso = value;}
        }

        public DateTime Fecha 
        {
            get { return _fecha;}
            set {
                if(value > DateTime.Now)
                    throw new Exception("No se puede ingresar una fecha posterior al dia de hoy");
                
                
                
                _fecha = value;}
        }


        //Oper & Met

        public override string ToString()
        {
            return " Id: " + Id + " Fecha: " + Fecha + " Empleado: " + Empleado + " Curso: " + ObjCurso;
        }
            
        

        //Contructor
       
            
        public Inscripcion(DateTime fecha, string empleado, Curso objCurso)
        {
            Fecha = fecha;
            Empleado = empleado;
            ObjCurso = objCurso;
        }
     
    }
}
