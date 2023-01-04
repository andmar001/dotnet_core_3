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
        public IEnumerable<Escuela> GetListaEvaluaciones()
        {
            IEnumerable<Escuela> rta;
            if(_diccionario.TryGetValue(LlaveDiccionario.Escuela, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                rta = lista.Cast<Escuela>();
            }
            {
                rta = null;
            }
            return rta;
        }
    }
}