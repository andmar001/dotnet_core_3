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

# Parametros de entrada y salida
Los parametros opcionales siempre deben ir al final de la lista de parametros 

# IReadOnlyList
Es una interfaz que nos permite crear objetos que no se pueden modificar, solo se pueden leer

# Diccionarios
Los diccionarios son una estructura de datos que nos permite almacenar datos de la forma llave-valor. La llave es un identificador único que nos permite acceder a los datos almacenados en el diccionario. Los diccionarios son muy útiles cuando queremos almacenar datos de forma asociativa, es decir, cuando queremos acceder a los datos a través de un identificador único.
Ejemplos de diccionarios:

Dictionary<int, string> diccionario = new Dictionary<int, string>();
    diccionario.Add(10, "Antonio");
    diccionario.Add(23, "Lorem insum");

    foreach (var keyValPair in diccionario)
    {
        WriteLine($"Key: {keyValPair.Key}, Value: {keyValPair.Value}");
    }
    Printer.WriteTitle("Acceso a diccionario");
    WriteLine(diccionario[23]);
    diccionario[0] = "Nuevo valor";
    WriteLine(diccionario[0]);
- llaves    
Las llaves de un diccionario deben ser únicas, es decir, no pueden existir dos llaves iguales en un diccionario. Si intentamos añadir una llave que ya existe en el diccionario, se producirá una excepción.

- struct
Las estructuras son tipos de datos que nos permiten almacenar varios valores en una sola variable. Las estructuras son tipos de datos que nos permiten almacenar varios valores en una sola variable. Las estructuras son tipos de datos que nos permiten almacenar varios valores en una sola variable.

- Eventos
Los eventos son una forma de notificar a otros objetos de que algo ha ocurrido. Los eventos son una forma de notificar a otros objetos de que algo ha ocurrido. Los eventos son una forma de notificar a otros objetos de que algo ha ocurrido.