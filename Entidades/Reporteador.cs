using System.Data;
using System.Linq;
using System;
using System.Collections.Generic;
namespace CoreEscuela.Entidades
{
    public class Reporteador
        {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObdEscuela)
        {
            //que no sea nulo
            if(dicObdEscuela == null)
                throw new ArgumentNullException(nameof(dicObdEscuela));
            
            _diccionario = dicObdEscuela;
        }

        // reporte de lista de evaluacioness
        public IEnumerable<Evaluacion> GetListaEvaluaciones()
        {
            IEnumerable<Evaluacion> rta;
            if(_diccionario.TryGetValue(LlaveDiccionario.Evaluacion, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                return lista.Cast<Evaluacion>();
            }
            {
                return new List<Evaluacion>();
            }
        }

        public IEnumerable<string>GetListaAsignatura()
        {
            return GetListaAsignatura(out var dummy);
        }
        //Obtener solo la lista de asignaturas
        public IEnumerable<string>GetListaAsignatura( out IEnumerable<Evaluacion> listaEvaluaciones)
        {
            listaEvaluaciones = GetListaEvaluaciones();

            return (from Evaluacion eval in listaEvaluaciones
                   select eval.Asignatura.Nombre).Distinct();
        }
        //Obtener el diccionario de evaluaciones por asignatura
        public Dictionary<string, IEnumerable<Evaluacion>> GetDiccionarioEvaluacionXAsignatura()
        {
            var dicRespuesta = new Dictionary<string, IEnumerable<Evaluacion>>();

            var listaAsignaturas = GetListaAsignatura(out var listaEval);

            foreach (var asig in listaAsignaturas)
            {
                var evalsAsign = from eval in listaEval
                                 where eval.Asignatura.Nombre == asig
                                 select eval;

                dicRespuesta.Add(asig, evalsAsign);
            }

            return dicRespuesta;

        }

        public Dictionary<string, IEnumerable<object>> GetPromedioPorAsignatura()
        {
            var respuesta = new Dictionary<string, IEnumerable<object>>();

            var dicEvalPorAsignatura = GetDiccionarioEvaluacionXAsignatura();

            foreach (var asigConEval in dicEvalPorAsignatura)
            {
                var promediosAlumnos = from eval in asigConEval.Value
                            group eval by new {
                                eval.Alumno.UniqueId,
                                eval.Alumno.Nombre
                            }
                            into grupoEvalsAlumno
                            select new AlumnoPromedio
                            {
                                alumnoId = grupoEvalsAlumno.Key.UniqueId,
                                alumnoNombre = grupoEvalsAlumno.Key.Nombre,
                                promedio = grupoEvalsAlumno.Average(evaluacion => evaluacion.Nota)
                            };

                respuesta.Add(asigConEval.Key, promediosAlumnos);
            }

            return respuesta;
        }
    }
}