using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bSharpAcademy
{
    public class Instituto
    {
        public List<Alumno> alumnosList = new List<Alumno>();
        public List<Curso> listaCurso = new List<Curso>();
        private int idInscripcionActual = 0;

        #region metodosAlumno

        //BUSCAR ALUMNO

        public Alumno buscarAlumno(int pCi)
        {
            foreach (Alumno alumn in alumnosList)
            {
                if (alumn.Ci.Equals(pCi))
                    return alumn;
            }
            return null;
        }

        //ALTA ALUMNO

        public void altaAlumnos(Alumno palumno)
        {
            this.alumnosList.Add(palumno);
        }

        //BAJA ALUMNO

        public void bajaAlumno(Alumno palumno)
        {
            if (palumno == null)
                throw new Exception("No se ha encontrado el alumno.");

            alumnosList.Remove(palumno);
        }


        //MODIFICACION

        public bool modificarAlumno(Alumno pAlumno, Alumno pAlumnoEditar)
        {
            foreach (Alumno Alu in alumnosList)
            {
                if (Alu.Ci == pAlumno.Ci)
                {
                    pAlumno = pAlumnoEditar;
                    return true;
                }
            }
            return false;
        }




        #endregion

        #region metodosCursos

        //ALTA CURSO

        public bool altaCurso(Curso pcurso)
        {
            this.listaCurso.Add(pcurso);
            return true;
        }

        public string tipoCursoCorto(string opcionCurso)
        {
            string tipoDato = "";
            if (opcionCurso == "A")
            {
                tipoDato = "Programacion";
                return tipoDato;
            }
            else if (opcionCurso == "B")
            {
                tipoDato = "Economia";
                return tipoDato;
            }
            else if(opcionCurso == "C")
            {
                tipoDato = "Diseño";
                return tipoDato;
            }
            throw new Exception("El tipo especificado no existe");

        }



        //BUSCAR CURSO

        public Curso buscarCurso(string pId)
        {
            foreach (Curso curs in listaCurso)
            {
                if (curs.Id.Equals(pId))
                    return curs;
            }
            return null;
        }


        public void listarCurso(int tipo)
        {


            if (tipo == 0)
            {


                foreach (Curso curs in listaCurso)
                {
                    if (curs is CursoCorto)
                    {
                        Console.WriteLine(curs.ToString());
                    }
                }

            }
            else
            {
                foreach (Curso curs in listaCurso)
                {
                    if (curs is CursoEspecializado)
                    {
                        Console.WriteLine(curs.ToString());
                    }
                }


            }

        }


        #endregion

        #region metodosInscripcion

        public void RegistrarInscripcion(Inscripcion nuevaInscripcion, Alumno alumnoInscripcion)
        {
            try
            {
                idInscripcionActual++;
                nuevaInscripcion.Id = idInscripcionActual;
                alumnoInscripcion.inscripList.Add(nuevaInscripcion);
            }
            catch (Exception)
            {
                idInscripcionActual--;
            }


        }



        #endregion


        #region metodosListar

        public List<Curso> CursosOrdenados()
        {
            return listaCurso.OrderBy(x => x.Id).ToList();
        }


        public int cantidadInscripcionesXCurso(Curso Curs)
        {
            int cantidad = 0;

            foreach (Alumno alum in alumnosList)
            {

                foreach (Inscripcion insc in alum.inscripList)
                {
                    if (insc.ObjCurso.Id == Curs.Id)
                    {

                        cantidad++;

                    }
                }
            }

            return cantidad;

        }



        public class InscripcionAlumno
        {
            public Alumno alumno { get; set; }
            public Inscripcion inscripcion { get; set; }

            public override string ToString()
            {
                return alumno.ToString() + "\n" + inscripcion.ToString();
            }

        }

        public List<InscripcionAlumno> ListarInscripcionesACursos(string idCurso)
        {
            List<InscripcionAlumno> inscriptosACurso = new List<InscripcionAlumno>();

            foreach (Alumno Alumn in alumnosList)
            {

                foreach (Inscripcion inscr in Alumn.inscripList)
                {
                    if (inscr.ObjCurso.Id == idCurso)
                    {

                        InscripcionAlumno dato = new InscripcionAlumno();
                        dato.alumno = Alumn;
                        dato.inscripcion = inscr;
                        inscriptosACurso.Add(dato);

                    }
                }
            }

            return inscriptosACurso;
        }




        #endregion



    }
}

