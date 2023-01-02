# Tipos de clase

- abstract
Las clases abstractas no pueden ser instanciadas, pero pueden ser extendidas. Las clases abstractas pueden contener métodos abstractos y métodos normales.

- sealed
Las clases selladas no pueden ser extendidas. -- herencia
Si permiten crear instancias de la clase.

- polimorfismo
Es la habilidad de un objeto de tomar múltiples formas. En la programación orientada a objetos, polimorfismo se refiere a la habilidad de un objeto de tomar múltiples formas. En la programación orientada a objetos, polimorfismo se refiere a la habilidad de un objeto de tomar múltiples formas.

- pruebas de polimorfismo
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

    // ob = evaluacion;

    //Casting  --- Convierte un objeto en otro tipo de objeto (Errores del polimorfismo)
    // alumnoTest =(Alumno) (ObjetoEscuelaBase)evaluacion;    
    if(ob is Alumno)
    {
        Alumno alumnoRecuperado = (Alumno)ob;
        Console.WriteLine("Alumno recuperado: " + alumnoRecuperado.Nombre);
    }   
    if(ob is Evaluacion)
    {
        Evaluacion evaluacionRecuperada = (Evaluacion)ob;
        Console.WriteLine("Evaluación recuperada: " + evaluacionRecuperada.Nombre);
    }

    //as --- reasignacion de objetos
    // validacion 
    Alumno alumnoRecuperado2 = ob as Alumno;
    if(alumnoRecuperado2 != null)
    {
        Console.WriteLine("Alumno recuperado: " + alumnoRecuperado2.Nombre);
    }
    else
    {
        Console.WriteLine("El objeto no es un alumno");
    }
            - 

- toString podemos sobreescribir el metodo toString para que nos devuelva el nombre de la clase y el nombre del objeto
