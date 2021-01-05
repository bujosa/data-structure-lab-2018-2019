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


// Definicion de un evento
public class Event
{
    public int day; // para simplificar, numeraremos los dias como 1, 2, 3, ...
    public String location;
    public Event(int day, String location)
    {
        this.day      = day;
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
        this.toDay   = toDay;
        this.count   = count;
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
        this.count    = count;
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
        this.fromDay  = fromDay;
        this.toDay    = toDay;
        this.location = location;
        this.count    = count;
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


        return null;
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


        return null;
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
        //       es su complejidad average case. Asume que el arreglo de eventos
        //       'events' ya esta ordenada por dia.
        //       Para simplificar, puedes asumir que el dia maximo es D = 10000
        // Complejidad esperada: mejor que O((N-K)*K)
        // Valor: 8 puntos


        return null;
    }



    public static void Main(string[] args)
    {
        Event[] events = {
            new Event( 1, "Villa Francisca"),
            new Event( 4, "Capotillo"),
            new Event( 5, "Capotillo"),
            new Event( 5, "Capotillo"),
            new Event(10, "Cristo Rey"),
            new Event(10, "Los Guandules"),
            new Event(10, "La Zurza"),
            new Event(12, "Gualey"),
            new Event(13, "Villa Juana"),
            new Event(16, "27 de Febrero"),
            new Event(16, "Los Guandules"),
            new Event(17, "San Carlos"),
            new Event(22, "Palma Real"),
            new Event(25, "Palma Real"),
            new Event(26, "Villa Consuelo"),
            new Event(28, "Los Rios"),
            new Event(33, "Villas Agricolas"),
            new Event(38, "La Cienaga"),
            new Event(38, "Capotillo"),
            new Event(41, "Ensanche Espaillat"),
            new Event(41, "La Zurza"),
            new Event(42, "Los Guandules"),
            new Event(42, "San Carlos"),
            new Event(42, "Villa Consuelo"),
            new Event(42, "Los Guandules"),
            new Event(47, "Cristo Rey")
        };

        Array.Sort(events,
                   delegate(Event a, Event b) {
                      return a.day.CompareTo(b.day);
                   });

        var res1 = MaxNumberOfEventsInAnyKDayInterval(events, 7);
        Console.WriteLine("La maxima cantidad de eventos en 7 dias fueron " +
                          "{0} y ocurrieron entre el dia {1} y {2}.",
                          res1.count, res1.fromDay, res1.toDay);
        Console.WriteLine();

        var res2 = MostFrequentLocation(events);
        Console.WriteLine("La localidad con mayor cantidad de homicidios es " +
                          "{0} donde hubo un total de {1} homicidios.",
                          res2.location, res2.count);
        Console.WriteLine();

        var res3 = MostFrequentLocationInAnyKDayInterval(events, 7);
        Console.WriteLine(
            "Del dia {0} al dia {1}, la localidad con mas homicidios es " +
            "{2} con {3} homicidios.",
            res3.fromDay, res3.toDay, res3.location, res3.count
        );
        Console.WriteLine();
    }

/*

Mi output:

La maxima cantidad de eventos en 7 dias fueron 8 y ocurrieron entre el dia 36 y 42.

La localidad con mayor cantidad de homicidios es Capotillo donde hubo un total de 4 homicidios.

Del dia 4 al dia 10, la localidad con mas homicidios es Capotillo con 3 homicidios.

*/
}
