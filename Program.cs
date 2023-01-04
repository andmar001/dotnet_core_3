using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += AccionDelEvento;//Para agregar el evento
            AppDomain.CurrentDomain.ProcessExit += (o, s) => Printer.Beep(2000,1000,1); //Para agregar el evento
            AppDomain.CurrentDomain.ProcessExit -= AccionDelEvento;//Para quitar el evento

            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");
            
            //Reportes
            var reporteador = new Reporteador(engine.GetDiccionarioObjetos());
            var evalList = reporteador.GetListaEvaluaciones();
            var listaAsignaturas = reporteador.GetListaAsignatura(); //que asignaturas hay
            var listaAsignaturasConEval = reporteador.GetDiccionarioEvaluacionXAsignatura(); //que asignaturas hay
            var listaPromedioXAsignatura = reporteador.GetPromedioPorAsignatura(); //promedio por asignatura
            
            foreach (var item in listaPromedioXAsignatura)
            {
                foreach (var alumno in item.Value)
                {
                    var tmp = alumno as Alumno;       
                }
            }
            
            var listaPromedioXAlumno = reporteador.GetMejoresPromedioPorAsignatura(1); //promedio por alumno

            foreach (var item in listaPromedioXAlumno)
            {
                foreach (var alumno in item.Value)
                {
                    var tmp = alumno as Alumno;       
                }
            }
        }

        private static void AccionDelEvento(object sender, EventArgs e)
        {
            Printer.WriteTitle("Saliendo");
            Printer.Beep(1000, cantidad: 1);
            Printer.WriteTitle("Salio");
        }

        private static void ImpimirCursosEscuela(Escuela escuela)
        {
            Printer.WriteTitle("Cursos de la Escuela");
            
            if (escuela?.Cursos != null)
            {
                foreach (var curso in escuela.Cursos)
                {
                    WriteLine($"Nombre {curso.Nombre  }, Id  {curso.UniqueId}");
                }
            }
        }

    }
}
