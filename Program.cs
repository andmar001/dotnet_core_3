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
            Printer.Beep(1000, cantidad:2);
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
            

            Printer.WriteTitle("ObjetoEscuelaBase"); 
            WriteLine("Alumno: " + ob.Nombre);
            WriteLine("Alumno: " + ob.UniqueId);
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
