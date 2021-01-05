/*
 * Puntos ejercicio: 14
 *
 * Este ejercicio consiste en una reimplementacion y extension del Lab1 usando
 * estructuras de datos incluidas en C#.
 *
 * Recordando el enunciado del Lab1: la Policia Nacional te ha contratado para
 * analizar una serie de homicidios  ocurridos en Santo Domingo.  La data que
 * recibes es una secuencia de eventos, donde cada evento tiene el dia y la
 * localidad donde ocurrio el homicidio.
 * 
 * Queremos determinar:
 * 1) la cantidad maxima de eventos que ocurrieron en un lapso de K dias y
 *    en cual rango de dias ocurrieron
 * 2) la localidad con la mayor cantidad de homicidios y cuantos homicidios
 *    ocurrieron en esa localidad
 * 3) la localidad con mas homicidios en un lapso de K dias, cuando ocurrieron
 *    y cuantos homicidios ocurrieron ahi
 *
 * NOTA: Si tus soluciones no tienen la complejidad requerida, vas a perder al
 *       menos 60% de los puntos asignados a esa seccion del ejercicio.
 *
 * Ubica todas las secciones con el tag TODO.  Cada tag les indicara que deben
 * completar.  Para TODOs que requieren respuestas, escribe las respuestas en
 * un comment.
 *
 * Instrucciones adicionales: 
 *   a) No borren los comments que existen en este codigo
 *   b) A menos que tengas una razon valida, no debes modificar los atributos
 *      existentes de las clases definidas
 *   c) Si utilizas/implementas una estructura de datos no incluida en C#, debes 
 *      justificarlo
 */

using System;
using System.Collections.Generic;
using System.IO;

// Para dar una exception para numeros negativos
public class NegativenumberException : Exception { }

// Definicion de un evento
public class Event
{
    public int day; // para simplificar, numeraremos los dias como 1, 2, 3, ...
    public String location;
    public Event(int day, String location)
    {
        this.day = day;
        this.location = location;
    }
}

// Las siguientes clases son los tipos de datos que los metodos a implementar
// deben devolver

// Para el metodo MaxNumberOfEventsInAnyKDayInterval

public class Result1
{
    public int fromDay, toDay;  // define el intervalo que va de fromDay a toDay
    public int count;           // cantidad de homicidios en ese intervalo
    public Result1(int fromDay, int toDay, int count)
    {
        this.fromDay = fromDay;
        this.toDay = toDay;
        this.count = count;
    }
}

// Para el metodo MostFrequentLocation
public class Result2
{
    public string location;    // define una localidad
    public int count;          // cantidad de homicidios ocurridos en 'location'
    public Result2(string location, int count)
    {
        this.location = location;
        this.count = count;
    }
}

// MostFrequentLocationInAnyKDayInterval
public class Result3
{
    public int fromDay, toDay;  // define el intervalo que va de fromDay a toDay
    public string location;     // define una localidad
    public int count;           // cantidad de homicidios ocurridos en esa
                                // localidad e intervalo 
    public Result3(int fromDay, int toDay, string location, int count)
    {
        this.fromDay = fromDay;
        this.toDay = toDay;
        this.location = location;
        this.count = count;
    }
}

// Clase para mantener un count en dias x
public class Interfrecuencia
{
    public int count, day; // Count : Define la cantidad maxima de eventos en K dias 
    // Day: define el lapzo de tiempo en que ocurrio ese count

    public Interfrecuencia(int count, int day)
    {
        this.count = count;
        this.day = day;
    }
}

public class InterLocaciones
{
    public int day;
    public string location;

    public InterLocaciones(int day, string location)
    {
        this.day = day;
        this.location = location;
    }
}

class HW5
{

    /*
     * Determina cual es la maxima cantidad de eventos en un lapso de K dias y
     * cual es ese intervalo.  En caso de empates, puedes devolver cualquiera
     * de los intervalos de K dias que tienen la misma maxima cantidad de
     * homicidios.
     */

    static Result1 MaxNumberOfEventsInAnyKDayInterval(Event[] events, int K)
    {
        // TODO: implementar algoritmo que resuelva este problema e indique cual
        //       es su complejidad average case. Asume que el arreglo de eventos
        //       'events' ya esta ordenada por dia.
        // HINT: Usa un Doubly Ended Queue para grabar los eventos de los
        //       ultimos K dias.
        // Complejidad esperada: mejor que O((N-K)*K)
        // Valor: 3 puntos


        // Documentacion de LinkedList: https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.linkedlist-1?view=netframework-4.7.2
        // Operaciones utilizadas: RemoveFirst, AddLast, Count, son O(1) 


        if (events.Length == 0)
            throw new InvalidOperationException(); // O(1)  

        int MaxDay = 0; // O(1)

        LinkedList<Event> Dlink = new LinkedList<Event>(); // O(1)

        int tmp = 0; // O(1)

        for (int i = 0; i < events.Length; i++) // O(N)
        {
            if (events[i].day < 0) // Si el numero es negativo simplemente lo saltara porque no existen dias negativos 
                continue; // O(1)
            
            if (Dlink.Count == 0)
            {
                Dlink.AddLast(events[i]); // O(1)
            }
            else if(events[i].day >= Dlink.First.Value.day && events[i].day < Dlink.First.Value.day + K)
                Dlink.AddLast(events[i]); // O(1)
            else
            {
                Dlink.RemoveFirst(); // O(1)
                i--; // O(1) // Esto puede ser que el ciclo se demore dependiendo de la Distancia de los datos
            }

            if(Dlink.Count >= MaxDay)
            {
                tmp = Dlink.Last.Value.day; // O(1)
                MaxDay = Dlink.Count; // O(1)
            }

        }

        int number = tmp + 1 - K; // O(1)

        if(number < 0)
            number = 0; // O(1)

        if (tmp < K)
            tmp = K; // O(1)

        Result1 var = new Result1(number, tmp, MaxDay); // O(1)

        return var;

        // Mi complejidad en avg case es O(N) and el Worst case es O(N)*M donde M es la diferencia de lapso K dias entre los datos 
    }

    /*
     * Determina la localidad donde los homicidios son mas frecuentes y cuantos
     * homicidios en total ocurrieron ahi.  En caso de empates, puedes devolver
     * cualquiera de las localidades que tienen la misma maxima cantidad de
     * homicidios.
     */
    static Result2 MostFrequentLocation(Event[] events)
    {
        // TODO: implementar algoritmo que resuelva este problema e indique cual
        //       es su complejidad average case
        // Valor: 3 puntos
        // Complejidad esperada: mejor que O(N^2)

        // Documentacion de Dictionary : https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.dictionary-2?view=netframework-4.7.2
        // Documentacion : TrygetValue  https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.dictionary-2.trygetvalue?view=netframework-4.7.2
        // Operaciones utilizadas de Dictionary: Trygetvalue, remove son O(1), add O(1) AVG case 
        // El Stack solo contiene un dato en la pila por lo tanto las operaciones Add y Pop se mantienen contante

        if (events.Length == 0) 
            throw new InvalidOperationException(); // O(1)  

        int count = 0; //  O(1)

        Dictionary<string, int> ord = new Dictionary<string, int>(); // Crearlo es constante
        
        Stack<Result2> stack = new Stack<Result2>(); // Crearlo es constante 
      
        foreach (var obj in events) // O(N)
        {

            if (obj.day < 0) // Si el numero es negativo simplemente lo saltara porque no existen dias negativos 
                continue; // O(1)

            bool flag = false; // O(1)
            flag = ord.TryGetValue(obj.location, out int radio); // O(1)

            if(flag)
            {
                ord.TryGetValue(obj.location, out int radio2); // O(1) 
                radio2++; // O(1) avg
                ord.Remove(obj.location); // O(1) 
                ord.Add(obj.location, radio2); // O(1) 

                if(radio2 > count) 
                {
                    count = radio2; //  O(1)
                    Result2 res2 = new Result2(obj.location, count); //  O(1)
                    if (stack.Count != 0) // O(1)
                        stack.Pop(); //  O(1)
                    stack.Push(res2); //  O(1)
                }
            }
            else
            {
                Result2 res2 = new Result2(obj.location, 1); // O(1)
                ord.Add(obj.location, 1); // O(1) 
                 
            }

         
        }

        if (stack.Count == 0)
        {
            var dato = events[0]; // O(1)
            Result2 res = new Result2(dato.location, 1); // O(1)
            stack.Push(res); // O(1)
        }

        return stack.Pop(); // O(1)

        // Mi complejidad esperada en avg case es O(N) 
      
    }


    /*
     * Determina la localidad con mayor cantidad de homicidios en cualquier
     * intervalo de K dias y devuelve esa localidad, la cantidad de homicidios
     * y el intervalo de K dias.  En caso de empates, puedes devolver cualquier
     * intervalo que contega ese maximo y cualquier localidad con la maxima
     * cantidad de homicidios.
     */

    static Result3 MostFrequentLocationInAnyKDayInterval(Event[] events, int K)
    {
        // TODO: implementar algoritmo que resuelva este problema e indique cual
        //       es su complejidad average case
        //       Para simplificar, puedes asumir que el dia maximo es D = 10000
        // Complejidad esperada: mejor que O((N-K)*K) 
        // Valor: 8 puntos

        // Documentacion de Dictionary : https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.dictionary-2?view=netframework-4.7.2
        // Documentacion : TrygetValue  https://docs.microsoft.com/es-es/dotnet/api/system.collections.generic.dictionary-2.trygetvalue?view=netframework-4.7.2
        // Operaciones utilizadas: Trygetvalue, remove; son O(1) y add O(1) avg

        if (events.Length == 0)
            throw new InvalidOperationException(); // O(1)  

        Dictionary<string, Interfrecuencia> ord = new Dictionary<string, Interfrecuencia>(); // Crearlo es constante
        LinkedList<InterLocaciones> locaciones = new LinkedList<InterLocaciones>(); // Crearlo es Constante

        int MaxFrecuencia = 0, day = 0; // O(1)
        string location = string.Empty; // O(1)

        for ( int i = 0; i < events.Length; i++) // O(N) 
        {
            if (events[i].day < 0) // Si el numero es negativo simplemente lo saltara porque no existen dias negativos 
                continue; // O(1)

            bool flag = false; // O(1)

            flag = ord.TryGetValue(events[i].location, out Interfrecuencia a); // O(1)

            if (ord.Count == 0)
            {
                InterLocaciones H = new InterLocaciones(events[i].day, events[i].location);
                locaciones.AddLast(H);
                Interfrecuencia z = new Interfrecuencia(1, events[i].day); // O(1)  
                ord.Add(events[i].location, z); // O(1) avg 
                MaxFrecuencia = 1; // O(1)
                location = events[i].location; // O(1)
                day = events[i].day; // O(1)

            }
            else if (flag)
            {
                if (events[i].day >= a.day && events[i].day < a.day + K)
                {
                    a.count++; // O(1)

                    if (a.count >= MaxFrecuencia )
                    {
                        MaxFrecuencia = a.count; // O(1)
                        location = events[i].location; // O(1)
                        day = a.day; // O(1) 
                    }

                    ord.Remove(events[i].location); // O(1)
                    ord.Add(events[i].location, a); // O(1)
                    InterLocaciones H = new InterLocaciones(events[i].day, events[i].location);
                    locaciones.AddLast(H);
                }
                else
                {
                    int B = 0;
                    string tmp = locaciones.First.Value.location; // O(1)
                    locaciones.RemoveFirst(); // O(1)
                    ord.TryGetValue(tmp, out Interfrecuencia value);
                    if (value == null)
                        B = 1;
                    else
                    {
                        B = value.count;
                        if (value.count > 1)
                            B--;   // O(1)
                    }

                    Interfrecuencia Z = new Interfrecuencia (B, events[i].day); // O(1)
                    ord.Remove(events[i].location); // O(1)
                    ord.Add(events[i].location, Z); // O(1)
                    i--;
                }
            }
            else
            {
                InterLocaciones H = new InterLocaciones(events[i].day, events[i].location);
                if (events[i].day >= locaciones.First.Value.day && events[i].day < locaciones.First.Value.day + K)
                {
                    locaciones.AddLast(H);
                    Interfrecuencia Z = new Interfrecuencia(1, events[i].day); //O(1)
                    ord.Add(events[i].location, Z); // O(1)
                }
                else
                {
                    string tmp = locaciones.First.Value.location;
                    ord.Remove(tmp);
                    locaciones.RemoveFirst();
                    i--;
                }
               
            }
            
        }

        int number = day + K - 1; // O(1)

        Result3 var = new Result3(day, number , location, MaxFrecuencia); // O(1)

            return var;

        // Mi complejidad en el avg case es O(N) lineal
    }

    static void ReadTestFromFile(string filename,
                              out int K, out Event[] events)
    {
        var fileStream = new FileStream(filename,
                                        FileMode.Open, FileAccess.Read);
        using (var streamReader = new StreamReader(fileStream))
        {
            char[] blanks = { ' ' };
            string line;
            K = 1;
            while ((line = streamReader.ReadLine()) != null)
            {
                if (line == null)
                    throw new Exception("Input file ended prematurely");
                line = line.Trim();
                if (line.Length == 0 || line[0] == '#')
                    continue;
                K = int.Parse(line);
                break;
            }

            List<Event> eventList = new List<Event>();
            while ((line = streamReader.ReadLine()) != null)
            {
                if (line == null)
                    throw new Exception("Input file ended prematurely");
                line = line.Trim();
                if (line.Length == 0 || line[0] == '#')
                    continue;
                string[] tokens
                    = line.Split(blanks, 2,
                                 StringSplitOptions.RemoveEmptyEntries);
                Event ev = new Event(int.Parse(tokens[0]), tokens[1]);
                eventList.Add(ev);
            }
            events = eventList.ToArray();
        }

    }


    public static void Main(string[] args)
    {

        string filename = @"C:\Users\David\Downloads\test\input3.txt";

        int K;
        Event[] events;
        ReadTestFromFile(filename, out K, out events);

        Array.Sort(events,
                   delegate (Event a, Event b) {
                       return a.day.CompareTo(b.day);
                   });


        var res1 = MaxNumberOfEventsInAnyKDayInterval(events, K);
        Console.WriteLine("La maxima cantidad de eventos en {3} dias fueron " +
                          "{0} y ocurrieron entre el dia {1} y {2}.",
                          res1.count, res1.fromDay, res1.toDay, K);
        Console.WriteLine();

        var res2 = MostFrequentLocation(events);
        Console.WriteLine("La localidad con mayor cantidad de homicidios es " +
                          "{0} donde hubo un total de {1} homicidios.",
                          res2.location, res2.count);
        Console.WriteLine();

        var res3 = MostFrequentLocationInAnyKDayInterval(events, K);
        Console.WriteLine(
            "Del dia {0} al dia {1}, la localidad con mas homicidios es " +
            "{2} con {3} homicidios.",
            res3.fromDay, res3.toDay, res3.location, res3.count
        );

        Console.WriteLine();
        Console.ReadKey();

    }

    /*

    Mi output:

    La maxima cantidad de eventos en 7 dias fueron 8 y ocurrieron entre el dia 36 y 42.

    La localidad con mayor cantidad de homicidios es Capotillo donde hubo un total de 4 homicidios.

    Del dia 4 al dia 10, la localidad con mas homicidios es Capotillo con 3 homicidios.


    */
}
