using System.Collections.Generic;
using System;

namespace CoreEscuela.Entidades
{
    public class Alumno:ObjetoEscuelaBase
    {
    
        // inicializar la lista de evaluaciones
        public List<Evaluacion> Evaluaciones { get; set; } = new List<Evaluacion>();
    }
}