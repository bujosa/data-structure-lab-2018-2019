/*
 *
 * Puntos ejercicio: 6 puntos
 *
 * La policia nacional te ha contratado para analizar una serie de homicidios 
 * ocurridos en Santo Domingo.  La data que te piden analizar es una secuencia
 * cronologica de eventos, donde cada evento tiene el dia y la localidad donde
 * ocurrio el homicidio.
 * 
 * Queremos determinar:
 * 1) la cantidad maxima de eventos que ocurrieron en un lapso de K dias
 * 2) la localidad con la mayor cantidad de homicidios
 *
 * Ubica todas las secciones identificas con el tag TODO.  Cada tag les indicara
 * que deben completar.  Para TODOs que requieren respuestas, escribe las
 * respuestas en un comment.
 *
 * Instrucciones adicionales: 
 *   a) No borren los comments que existen en este codigo
 *   b) A menos que tengas una razon valida, no debes modificar la clase Event
 *
 */


using System;
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



public class Lab1a
{
    // Determina cual es la maxima cantidad de eventos en un lapso de K dias.
    // Puedes asumir que el arreglo de eventos 'events' esta ordenada por dia
    static int MaxNumberOfEventsWithinKDays(Event[] events, int K)
    {
        int contador = 0, contador2 = 0;
        int n = events.Length;
        int y = K;
       
        for (int h = 0; h < n; h++)
        {

            contador = 0;
            int contador3 = events[h].day;
            for (int i = 0; i < n; i++)
            {
                            
               if (events[i].day >= contador3 && events[i].day < contador3 + y)
                {
                        contador += 1;
                }

            }

            if (contador2 < contador)
            {
                contador2 = contador;
            }          
        }

        // TODO: implementar algoritmo (no necesariamente eficiente) que
        //       resuelva este problema
        // Valor: 2 puntos

        // TODO: indica cual es la complejidad de tu algoritmo en el worst-case
        // Valor: 0.5 puntos

        // En el worst case es 0(N^2)  
        // Use 0 para que represente el simbolo Theta

        return contador2;
    }


    // Determina la localidad donde los homicidios son mas frecuentes
    // En el caso de empates, puedes devolver cualquiera de las localidades
    // que tienen la misma maxima cantidad de homicidios
    public static string mayorfrecuencia;

    public static string MostFrequentLocation(Event[] events)
    {

        int contador = 0, contador2 =0; 
       
        int n = events.Length;
        string comparadorlogico;
        string frecuenciamenor;
        string mayorfrecuencia = null;

        for (int i =0; i < n;i++)
        {
            contador = 0;
            frecuenciamenor = events[i].location;
            for(int j =0; j < n; j++)
            {
                comparadorlogico = events[j].location;
                if (comparadorlogico == frecuenciamenor)
                   {   
                     contador++;
                   }

            }
            if (contador2 < contador)
            {
                contador2 = contador;
                mayorfrecuencia = frecuenciamenor;
            }
        }
        // TODO: implementar algoritmo (no necesariamente eficiente) que
        //       resuelva este problema
        // Valor: 3 puntos

        // TODO: indica cual es la complejidad de tu algoritmo en el worst-case
        // Valor: 0.5 puntos

        // En el worst case (Peor de los casos) es 0(N^2)

        return mayorfrecuencia;
    }

    // Esta variable es donde se almacena la cantidad de dias que eximinara
    public static int abc = 7;

    public static void Main(string[] args)
    {
        Event[] events = new Event[20];
        events[0] = new Event(1, "Villa Francisca");
        events[1] = new Event(4, "Capotillo");
        events[2] = new Event(5, "Capotillo");
        events[3] = new Event(5, "Capotillo");
        events[4] = new Event(10, "Cristo Rey");
        events[5] = new Event(10, "Los Guandules");
        events[6] = new Event(10, "La Zurza");
        events[7] = new Event(12, "Gualey");
        events[8] = new Event(13, "Villa Juana");
        events[9] = new Event(16, "27 de Febrero");
        events[10] = new Event(16, "Los Guandules");
        events[11] = new Event(17, "San Carlos");
        events[12] = new Event(22, "Palma Real");
        events[13] = new Event(25, "Palma Real");
        events[14] = new Event(26, "Villa Consuelo");
        events[15] = new Event(28, "Los Rios");
        events[16] = new Event(33, "Villas Agricolas");
        events[17] = new Event(38, "La Cienaga");
        events[18] = new Event(38, "Capotillo");
        events[19] = new Event(41, "Ensanche Espaillat");
    

        Console.WriteLine("Maxima cantidad de eventos en 7 dias: {0}",
                          MaxNumberOfEventsWithinKDays(events, abc));

        Console.WriteLine("Localidad con mayor cantidad de homicidios: {0}",
                          MostFrequentLocation(events));

        Console.Read();

        /*
        Output de mi solucion:

        Maxima cantidad de eventos en 7 dias: 7
        Localidad con mayor cantidad de homicidios: Capotillo

        */
    }

}