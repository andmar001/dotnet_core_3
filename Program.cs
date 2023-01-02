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
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("BIENVENIDOS A LA ESCUELA");
            Printer.Beep(1000, cantidad:1);
            ImpimirCursosEscuela(engine.Escuela);

            var listaObjetos = engine.GetObjetosEscuela(true, false,false,false);

            // var listaILugar = from obj in listaObjetos
            //                   where obj is Escuela
            //                   select (Escuela)obj;
            //implementacion de interfaz
            // engine.Escuela.LimpiarLugar();


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
