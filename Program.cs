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

            Dictionary<int, string> diccionario = new Dictionary<int, string>();
            diccionario.Add(10, "Antonio");
            diccionario.Add(23, "Lorem insum");

            foreach (var keyValPair in diccionario)
            {
                WriteLine($"Key: {keyValPair.Key}, Value: {keyValPair.Value}");
            }
           
            var dictTemp = engine.GetDiccionarioObjetos();

            engine.ImprimirDiccionario(dictTemp);
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
