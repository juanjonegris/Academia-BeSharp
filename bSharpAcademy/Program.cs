using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bSharpAcademy
{
    public class Program
    {
        public static Instituto bSharp = new Instituto();


        static void Main(string[] args)
        {

            MyMenu();

        }

        #region menu

        static void MyMenu()
        {

            otrosMetodos.titulo();

            string opcion;
            Console.WriteLine("\t A) Mantenimiento de Alumnos");
            Console.WriteLine("\t B) Agregar Curso Corto");
            Console.WriteLine("\t C) Agregar Curso de Especializacion");
            Console.WriteLine("\t D) Inscripcion a Cursos");
            Console.WriteLine("\t E) Listado de Cursos");
            Console.WriteLine("\t F) Listado de Inscripciones");
            Console.WriteLine("\t S) Salir \n");
            Console.WriteLine("\t Por favor ingrese una opción: \n");
            //Carga variable opcion
            opcion = Console.ReadLine().ToUpper();
            metodoSeleccinado(opcion);
        }

        #endregion

        #region metodoSeleccionar

        private static void metodoSeleccinado(string opcion)
        {

            switch (opcion)
            {

                case "A":
                    MantenimientoAlumnos();
                    break;

                case "B":
                    AgregarCursoCorto();
                    break;

                case "C":
                    AgregarCursoEspecializacion();
                    break;

                case "D":
                    InscripcionACursos();
                    break;

                case "E":
                    ListadoCursosOrdenados();
                    break;

                case "F":
                    ListadoInscripciones();
                    break;

                case "S":
                    Console.WriteLine("Presione una tecla para salir");
                    Console.ReadKey();
                    exitmeth();
                    break;

                default:
                    Console.WriteLine("Opcion incorrecta. Ingrese un valor válido");
                    Console.ReadKey();
                    MyMenu();
                    break;
            }

            MyMenu();
        }



        private static void exitmeth()
        {
            Environment.Exit(0);
        }

        #endregion

        #region MantenimientodeAlumno

        private static void MantenimientoAlumnos()
        {
            otrosMetodos.titulo();
            int cedula = 0;
            try
            {
                Console.WriteLine("Ingrese el numero de Cedula - Sin el digito verificador");
                cedula = Convert.ToInt32(Console.ReadLine());
                if (cedula.ToString().Length > 7)
                    throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine("Ha ingresado un caracter inválido");
                Console.ReadKey();
                MyMenu();
            }

            Alumno resultadoBusqueda = bSharp.buscarAlumno(cedula);

            if (resultadoBusqueda == null)
            {
                otrosMetodos.titulo();
                Console.WriteLine("El alumno no se encuenta registrado. \n ¿Quiere darlo de alta en el sistema? Presione: \n A - Darlo de alta: \n Presione cualquier Tecla para salir");

                string opcionAlumnoNoIngresado = Console.ReadLine().ToUpper();

                if (opcionAlumnoNoIngresado == "A")
                {
                    Alumno alumnoIngreso = AltaOEditAlumno(cedula);
                    bSharp.altaAlumnos(alumnoIngreso);
                    Console.Clear();
                    Console.WriteLine("Alumno ingresado con éxito - Presione una tecla para salir!");
                    Console.ReadKey();
                    MyMenu();
                }
                MyMenu();
            }
            else
            {
                otrosMetodos.titulo();
                Console.WriteLine("El alumno {0} se encuentra registrado\n", resultadoBusqueda.Nombre);

                //Listar datos del alumno
                Console.WriteLine("".PadLeft(50, '='));
                Console.WriteLine(resultadoBusqueda.ToString());
                Console.WriteLine("".PadLeft(50, '='));

                //Eliminar o Editar alumno
                Console.WriteLine("A - Eliminar alumno: \n B - Editar el alumno: \n Cualquier otra tecla para volver al Menu Principal.");
                string opcionEditOrBorrarAlumno = Console.ReadLine().ToUpper();

                if (opcionEditOrBorrarAlumno == "A")
                {
                    try
                    {
                        bSharp.bajaAlumno(resultadoBusqueda);
                        Console.WriteLine("Alumno eliminado con exito. Presione una tecla para seguir");
                        Console.ReadKey();
                        MyMenu();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message + "\n Ha habido un problema al eliminar el alumno. Presione una volver al Menu Principal");
                        Console.ReadKey();
                        MyMenu();
                    }
                }

                else if (opcionEditOrBorrarAlumno == "B")
                {

                    Alumno alumnoEditar = AltaOEditAlumno(cedula);
                    bSharp.modificarAlumno(resultadoBusqueda, alumnoEditar);
                    Console.Clear();
                    Console.WriteLine("Alumno Editado con éxito - Presione una tecla para salir!");
                    Console.ReadKey();
                    MyMenu();
                }
                else
                {
                    MyMenu();
                }

            }

            Console.ReadKey();
        }



        public static Alumno AltaOEditAlumno(int cedula)
        {
            otrosMetodos.titulo();
            try
            {
                Console.WriteLine("Alumno cedula: {0}", cedula);
                Console.WriteLine("Ingrese nombre: ");
                string nombreNewAlumno = Console.ReadLine();
                Console.WriteLine("Ingrese teléfono: ");
                string telefonoNewAlumno = Console.ReadLine();
                Console.WriteLine("Ingrese direccion: ");
                string direccionNewAlumno = Console.ReadLine();

                Alumno alumnoIngresoOEdit = new Alumno(cedula, nombreNewAlumno, telefonoNewAlumno, direccionNewAlumno);
                return alumnoIngresoOEdit;

            }
            catch (FormatException)
            {
                Console.WriteLine("Ha ingresado un dato invalido");
                Console.ReadKey();
                MantenimientoAlumnos();
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                MantenimientoAlumnos();
                return null;
            }






        }

        #endregion

        #region AgregarCursoCorto

        //CURSO CORTO
        private static void AgregarCursoCorto()
        {
            byte flag = 0;
            CursoExisteOCrear(flag);
        }


        private static void crearCursoCorto(string idCurso, int flag)
        {
            try
            {
                string curNombre;
                byte curDuracion;
                double curPrecio;
                atributosComunesCurso(flag, out curNombre, out curDuracion, out curPrecio);
                //Seleccionar Area
                otrosMetodos.titulo();
                Console.WriteLine("INGRESAR CURSO CORTO");
                Console.WriteLine("Seleccione area del curso \n A-Programacion \n B-Economía \n C-Diseño");

                string opcionCurso = Console.ReadLine().ToUpper();
                string tipoCurso = bSharp.tipoCursoCorto(opcionCurso);

                Curso corto = new CursoCorto(tipoCurso, idCurso, curNombre, curDuracion, curPrecio);

                bool resultado = bSharp.altaCurso(corto);

                if (resultado)
                {
                    otrosMetodos.titulo();
                    Console.WriteLine("Curso ingresado con éxito - Presione una tecla pra seguir\n" + corto.ToString());
                    Console.ReadKey();
                    MyMenu();
                }
                else
                {
                    otrosMetodos.titulo();
                    Console.WriteLine("Error al ingresar el curso");
                    Console.ReadKey();
                    MyMenu();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

        }


        //Si existe mostrar, sino crear curso
        private static void CursoExisteOCrear(byte flag)
        {
            Console.WriteLine("Ingrese el Id del Curso");
            try
            {
                string idCurso = Console.ReadLine();
                if (otrosMetodos.isNotEmp(idCurso) == true)
                    throw new Exception("El ID del curso no puede estar vacío");
                if (idCurso.Length > 6)
                    throw new Exception("El ID de curso debe tener un máximo de 6 caracteres.");
                Curso resultadoBusquedaCurso = bSharp.buscarCurso(idCurso);
                if (resultadoBusquedaCurso == null)
                {
                    if (flag == 0)
                        crearCursoCorto(idCurso, flag);
                    else if (flag == 1)
                        crearCursoEspecializado(idCurso, flag);
                }
                else
                {
                    otrosMetodos.titulo();
                    Console.WriteLine("El curso ya existe - Info del Curso\n" + resultadoBusquedaCurso.ToString());
                    Console.WriteLine("Presione una tecla para seguir");
                    Console.ReadKey();
                    MyMenu();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }


        //Alta de nuevo curso



        private static void volverAingresarCurso(string idCurso, int flag)
        {
            crearCursoCorto(idCurso, flag);
        }


        #endregion


        #region AgregarCursoEspecializacion

        private static void AgregarCursoEspecializacion()
        {
            byte flag = 1;
            CursoExisteOCrear(flag);
        }

        private static void crearCursoEspecializado(string idCurso, int pFlag)
        {
            string curNombre;
            byte curDuracion;
            double curPrecio;
            int flag = pFlag;
            atributosComunesCurso(flag, out curNombre, out curDuracion, out curPrecio);
            string preRequisitos = "\n REQUISITOS CURSO ESPECIALIZADO \n Para inscribirse al Curso debe tener 18 años al momento de iniciarse el curso.\n Asimismo debe contar con todas las asignaturas de 6to año de secundaria aprovadas. \n Firma: La Dirección";

            Curso cursoEsp = new CursoEspecializado(preRequisitos, idCurso, curNombre, curDuracion, curPrecio);

            bSharp.altaCurso(cursoEsp);

            otrosMetodos.titulo();
            Console.WriteLine("Curso ingresado con éxito - Presione una tecla pra seguir\n" + cursoEsp.ToString());
            Console.ReadKey();
            MyMenu();

        }


        //Pedir atributos comunes
        private static void atributosComunesCurso(int flag, out string curNombre, out byte curDuracion, out double curPrecio)
        {
            string nombreTipoCurso;

            if (flag == 0)
                nombreTipoCurso = "CORTO";
            else
                nombreTipoCurso = "ESPECIALIZADO";

            otrosMetodos.titulo();
            Console.WriteLine("INGRESAR CURSO " + nombreTipoCurso + "\n Ingrese el título del Curso.");
            string auxNombre = Console.ReadLine();
            if (otrosMetodos.isNotEmp(auxNombre) == true)
                throw new Exception("El dato ingresado no es valido. El campo nu puede estar vacío");
            curNombre = auxNombre;

            otrosMetodos.titulo();
            Console.WriteLine("INGRESAR CURSO " + nombreTipoCurso + " \n Ingrese la duración en semanas del Curso.");
            string auxDuracion = Console.ReadLine();
            if (otrosMetodos.isAByte(auxDuracion) != true)
                throw new Exception("El dato ingresado no es valido.");
            curDuracion = Convert.ToByte(auxDuracion);

            otrosMetodos.titulo();
            Console.WriteLine("INGRESAR CURSO " + nombreTipoCurso + "\n Ingrese precio del Curso");
            string auxPrecio = Console.ReadLine();
            if (otrosMetodos.isADouble(auxPrecio) != true)
                throw new Exception("El dato ingresado no es valido.");
            curPrecio = Convert.ToDouble(auxPrecio);
        }


        #endregion


        #region InscripcionACursos


        private static void InscripcionACursos()
        {
            // Corroborar si existe un curso, sino devolver al Menu
            if (bSharp.listaCurso.Count == 0)
            {
                otrosMetodos.titulo();
                Console.WriteLine("No hay cursos ingresados en el sistema. \n No es posible realizar una inscripcion. \n Presione una tecla para salir");
                Console.ReadKey();
                MyMenu();
            }
            otrosMetodos.titulo();
            Console.WriteLine("INSCRIPCIÓN CURSOS B/SHARP \n Ingrese cedula del alumnno \n \"S\" para salir al Menu");

            string opcionCedula = Console.ReadLine();

            if (opcionCedula.ToUpper() == "S")
            {
                MyMenu();
            }
            try
            {
                if (otrosMetodos.isAInt(opcionCedula) != true || otrosMetodos.isNotEmp(opcionCedula) == true)
                    throw new Exception("Ingrese un dato de cédula válido");
                int cedula = Convert.ToInt32(opcionCedula);

                Alumno alumnoInscribir = bSharp.buscarAlumno(cedula);

                if (alumnoInscribir == null)
                {
                    otrosMetodos.titulo();
                    Console.WriteLine("El alumno no existe. \n El alumno ya debe estar previamente registrado. \n Presione una tecla para Registrar el Alumno.\n Presione \"S\" para salir.");
                    string opcionRegistroOSAliralMenu = Console.ReadLine().ToUpper();
                    if (opcionRegistroOSAliralMenu == "S")
                    {
                        MyMenu();
                    }
                    else
                    {
                        Alumno alumnoIngreso = AltaOEditAlumno(cedula);
                        bSharp.altaAlumnos(alumnoIngreso);
                        Console.Clear();
                        Console.WriteLine("Alumno ingresado con éxito - Presione una tecla para salir!");
                        Console.ReadKey();
                        MyMenu();
                    }

                }
                //Alumno existe
                else
                {
                    elegirTipodeCurso(alumnoInscribir);
                }


            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        private static void elegirTipodeCurso(Alumno alumnoInscribir)
        {
            otrosMetodos.titulo();
            Console.WriteLine("TIPO DE CURSO");
            Console.WriteLine("A- Inscripción Curso Corto");
            Console.WriteLine("B- Inscripción Curso Especializado");
            string opcionTipoCurso = Console.ReadLine().ToUpper();

            //INSCRIPCION A CURSO CORTO

            if (opcionTipoCurso == "A")
            {
                otrosMetodos.titulo();
                Console.WriteLine("LISTADO CURSOS CORTOS");
                int flag = 0;
                bSharp.listarCurso(flag);
                Console.WriteLine("Ingrese el ID del curso al que desea inscribirse");
                string idSeleccionado = Console.ReadLine();
                Curso CursoSeleccionado = bSharp.buscarCurso(idSeleccionado);

                if (CursoSeleccionado == null)
                {
                    otrosMetodos.titulo();
                    Console.WriteLine("No se ha encontrado ningun curso con ese código.\n Presione \"S\" para volver al Menú o cualquier tecla para volver a inscripciones.");
                    string opcionSalir = Console.ReadLine().ToUpper();

                    if (opcionSalir == "S")
                    {
                        MyMenu();
                    }
                    else
                    {
                        InscripcionACursos();
                    }

                }
                else
                {
                    altaAlumnoaCurso(CursoSeleccionado, alumnoInscribir);
                }


            }

            //INSCRIPCION A CURSO ESPECIALIZADO

            else if (opcionTipoCurso == "B")
            {
                otrosMetodos.titulo();
                Console.WriteLine("LISTADO CURSOS ESPECIALIZADOS");
                int flag = 1;
                bSharp.listarCurso(flag);
                Console.WriteLine("Ingrese el ID del curso al que desea inscribirse");
                string idSeleccionado = Console.ReadLine();
                Curso CursoSeleccionado = bSharp.buscarCurso(idSeleccionado);
                if (CursoSeleccionado == null)
                {
                    otrosMetodos.titulo();
                    Console.WriteLine("No se ha encontrado ningun curso con ese código.\n Presione \"S\" para volver al Menú o cualquier tecla para volver a inscripciones.");
                    string opcionSalir = Console.ReadLine().ToUpper();

                    if (opcionSalir == "S")
                    {
                        MyMenu();
                    }
                    else
                    {
                        InscripcionACursos();
                    }

                }
                else
                {

                    altaAlumnoaCurso(CursoSeleccionado, alumnoInscribir);

                }

            }
            else
            {
                InscripcionACursos();

            }

        }

        private static void altaAlumnoaCurso(Curso CursoSeleccionado, Alumno alumnoInscribir)
        {
            Console.WriteLine("Ingrese nombre de empleado");
            
            try
            {
                string nombreEmpleado = Console.ReadLine();
                if (otrosMetodos.isNotEmp(nombreEmpleado) == true)
                {
                    Console.WriteLine("Debe ingresar \"Peludo\", mínimo.");
                    Console.ReadKey();
                    InscripcionACursos();
                }

                DateTime fecha = DateTime.Now;
                Inscripcion nuevaInscripcion = new Inscripcion(fecha, nombreEmpleado, CursoSeleccionado);
                bSharp.RegistrarInscripcion(nuevaInscripcion, alumnoInscribir);
                otrosMetodos.titulo();
                Console.WriteLine("Alumno {0} inscripto con éxito al curso {1}.\n Presione una tecla para volver al Menu Principal.", alumnoInscribir.Nombre, CursoSeleccionado.Nombre);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

        }


        #endregion


        #region ListadoCursos


        private static void ListadoCursosOrdenados()
        {
            otrosMetodos.titulo();
            List<Curso> listaOrdenada = bSharp.CursosOrdenados();

            foreach (Curso Curs in listaOrdenada)
            {
                Console.WriteLine("Curso: " + Curs.ToString());
                int cantidadInscripciones = bSharp.cantidadInscripcionesXCurso(Curs);
                Console.WriteLine("Número de Inscripciones: " + cantidadInscripciones + "\n");
            }

            Console.ReadKey();
        }


        #endregion


        #region ListadoInscripciones

        private static void ListadoInscripciones()
        {
            otrosMetodos.titulo();
            Console.WriteLine("LISTADO DE INSCRIPTOS A LOS DIFERENTES CURSOS.\n Ingrese el ID del curso: ");


            string idCursoBuscar = Console.ReadLine();
            Curso cursoExiste = bSharp.buscarCurso(idCursoBuscar);

            if (cursoExiste == null)
            {
                otrosMetodos.titulo();
                Console.WriteLine("El curso no existe. Presione una tecla para volver al menu");
                Console.ReadKey();
                MyMenu();
            }

            otrosMetodos.titulo();
            List<Instituto.InscripcionAlumno> listaInscripcionACurso = bSharp.ListarInscripcionesACursos(idCursoBuscar);

            foreach (Instituto.InscripcionAlumno insc in listaInscripcionACurso)
            {
                Console.WriteLine(" Inscripcion :{0} \n ", insc.ToString() + " \n\n");

            }

            Console.WriteLine("Prsesione una tecla para salir. ");
            Console.ReadKey();
            MyMenu();


            #endregion

        }
    }
}
