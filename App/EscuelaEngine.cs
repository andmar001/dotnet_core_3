using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace CoreEscuela
{
    public sealed class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {

        }
        public void Inicializar()
        {
            Escuela = new Escuela("Platzi Academay", 2012, TiposEscuela.Primaria,
            ciudad: "Bogotá", pais: "Colombia"
            );

            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();

        }

        #region Métodos de carga
        private void CargarEvaluaciones()
        {
            var lista = new List<Evaluacion>(); 
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)  //a cada alumno se le asignan 5 evaluaciones
                    {
                        var rnd = new Random(System.Environment.TickCount);

                        for (int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluacion
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                Nota = (float)(5 * rnd.NextDouble()),
                                Alumno = alumno
                            };
                            alumno.Evaluaciones.Add(ev);
                        }                        
                    }
                    
                }
                
            }
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                var listaAsignaturas = new List<Asignatura>(){
                            new Asignatura{Nombre="Matemáticas"} ,
                            new Asignatura{Nombre="Educación Física"},
                            new Asignatura{Nombre="Castellano"},
                            new Asignatura{Nombre="Ciencias Naturales"}
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnosAlAzar( int cantidad)
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos =  from n1 in nombre1
                                from n2 in nombre2
                                from a1 in apellido1
                                select new Alumno{ Nombre=$"{n1} {n2} {a1}" };
            
            return listaAlumnos.OrderBy( (al)=> al.UniqueId ).Take(cantidad).ToList();
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                        new Curso(){ Nombre = "101", Jornada = TiposJornada.Mañana },
                        new Curso() {Nombre = "201", Jornada = TiposJornada.Mañana},
                        new Curso{Nombre = "301", Jornada = TiposJornada.Mañana},
                        new Curso(){ Nombre = "401", Jornada = TiposJornada.Tarde },
                        new Curso() {Nombre = "501", Jornada = TiposJornada.Tarde},
            };
            
            Random rnd = new Random();
            foreach(var c in Escuela.Cursos)
            {
                int cantRandom = rnd.Next(5, 20);
                c.Alumnos = GenerarAlumnosAlAzar(cantRandom);
            }
        }
        #endregion    
        //devuelve todos los objetos de la escuela
        public List<ObjetoEscuelaBase> GetObjetosEscuela()
        {
            var listaObj = new List<ObjetoEscuelaBase>();

            listaObj.Add(Escuela);
            listaObj.AddRange(Escuela.Cursos);
            
            foreach (var curso in Escuela.Cursos)
            {
                listaObj.AddRange(curso.Asignaturas);
                listaObj.AddRange(curso.Alumnos);

                foreach (var alumno in curso.Alumnos)
                {
                    listaObj.AddRange(alumno.Evaluaciones);
                }
            }

            return listaObj;
        }
        //sobrecarga del método GetObjetosEscuela, develve una lista y un conteo de evaluaciones -- tupla
        public IReadOnlyList <ObjetoEscuelaBase> GetObjetosEscuela(
                                out int conteoEvaluaciones,
                                out int conteoAlumnos,
                                out int conteoAsignaturas,
                                out int conteoCursos,
                                bool traeEvaluaciones = true,
                                bool traeAlumnos= true,
                                bool traeAsignaturas= true,
                                bool traeCursos= true
        )
        {
            // asignaciones multiples
            conteoEvaluaciones = conteoAlumnos = conteoAsignaturas = conteoCursos = 0;

            var listaObj = new List<ObjetoEscuelaBase>();

            listaObj.Add(Escuela);
            if(traeCursos)
                listaObj.AddRange(Escuela.Cursos);
            
            conteoCursos = Escuela.Cursos.Count;
            foreach (var curso in Escuela.Cursos)
            {
                conteoAsignaturas += curso.Asignaturas.Count;
                conteoAlumnos += curso.Alumnos.Count;
                
                if(traeAsignaturas)
                    listaObj.AddRange(curso.Asignaturas);

                if(traeAlumnos)
                    listaObj.AddRange(curso.Alumnos);
                
                if (traeEvaluaciones)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        listaObj.AddRange(alumno.Evaluaciones);
                        conteoEvaluaciones += alumno.Evaluaciones.Count; //cuenta el número de evaluaciones
                    }
                }
            }

            return listaObj.AsReadOnly();
        }
        //sobrecarga del método GetObjetosEscuela
        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
                                bool traeEvaluaciones = true,
                                bool traeAlumnos= true,
                                bool traeAsignaturas= true,
                                bool traeCursos= true
        )
        {
            return GetObjetosEscuela(out int dummy, out dummy, out dummy, out dummy, traeEvaluaciones, traeAlumnos, traeAsignaturas, traeCursos);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
                                out int conteoEvaluaciones,
                                bool traeEvaluaciones = true,
                                bool traeAlumnos= true,
                                bool traeAsignaturas= true,
                                bool traeCursos= true
        )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out int dummy, out dummy, out dummy, traeEvaluaciones, traeAlumnos, traeAsignaturas, traeCursos);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
                                out int conteoEvaluaciones,
                                out int conteoCursos,
                                bool traeEvaluaciones = true,
                                bool traeAlumnos= true,
                                bool traeAsignaturas= true,
                                bool traeCursos= true
        )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out conteoCursos,out int dummy, out dummy, traeEvaluaciones, traeAlumnos, traeAsignaturas, traeCursos);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetosEscuela(
                                out int conteoEvaluaciones,
                                out int conteoCursos,
                                out int conteoAsignaturas,
                                bool traeEvaluaciones = true,
                                bool traeAlumnos= true,
                                bool traeAsignaturas= true,
                                bool traeCursos= true
        )
        {
            return GetObjetosEscuela(out conteoEvaluaciones, out conteoCursos, out conteoAsignaturas,out int dummy, traeEvaluaciones, traeAlumnos, traeAsignaturas, traeCursos);
        }


    }
}