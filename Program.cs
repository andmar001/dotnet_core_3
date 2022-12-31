using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using CoreEscuela.Util;
using static System.Console;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");
            Printer.Beep(1000, cantidad:1);
            ImpimirCursosEscuela(engine.Escuela);

            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.DrawLine(20);
            Printer.WriteTitle("Prueba de polimorfismo");
           
            var alumnoTest = new Alumno { Nombre = "Claire Underwood" };
           
            ObjetoEscuelaBase ob = alumnoTest;

            Printer.WriteTitle("Alumno");
            WriteLine("Alumno: " + alumnoTest.Nombre);
            WriteLine("Alumno: " + alumnoTest.UniqueId);
            WriteLine("Alumno: " + alumnoTest.GetType());
            

            Printer.WriteTitle("ObjetoEscuela"); 
            WriteLine("Alumno: " + ob.Nombre);
            WriteLine("Alumno: " + ob.UniqueId);
            WriteLine("Alumno: " + ob.GetType());

            var objDummy = new ObjetoEscuelaBase() { Nombre = "Frank Castle" };
            Printer.WriteTitle("ObjetoEscuelaBase");
            WriteLine("Alumno: " + objDummy.Nombre);
            WriteLine("Alumno: " + objDummy.UniqueId);
            WriteLine("Alumno: " + objDummy.GetType());

            //Evaluación
            var evaluacion = new Evaluacion()
            {
                Nombre = "Evaluacion de Matemáticas",
                Nota = 4.5f,
                Alumno = alumnoTest,
                Asignatura = new Asignatura { Nombre = "Matemáticas" }
            };
            Printer.WriteTitle("Evaluación");
            WriteLine("Evaluación: " + evaluacion.Nombre);
            WriteLine("Evaluación: " + evaluacion.UniqueId);
            WriteLine("Evaluación: " + evaluacion.Nota);
            WriteLine("Evaluación: " + evaluacion.GetType());

            ob = evaluacion;
            Printer.WriteTitle("ObjetoEscuela");
            WriteLine("Alumno: " + ob.Nombre);
            WriteLine("Alumno: " + ob.UniqueId);
            WriteLine("Alumno: " + ob.GetType());

            //Casting  --- Convierte un objeto en otro tipo de objeto (Errores del polimorfismo)
            //alumnoTest =(Alumno) (ObjetoEscuelaBase)evaluacion;       
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
