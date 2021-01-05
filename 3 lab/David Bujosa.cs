/*
 *
 * Puntos ejercicio: 10
 *
 * En este ejercicio implementaremos la siguiente variante de Open Addressing:
 * En la insercion de un nuevo key, la resolucion de colisiones es similar a
 * Linear Probing (con step size 1), excepto que solo iteraremos un maximo de
 * MAX_PROBES pasos.  Si despues de iterar MAX_PROBES veces, no se encontro un
 * bucket disponible, el nuevo key se agrega al final de una secuencia llamada
 * stash (este puede ser un Dynamic Array o Linked List).
 *
 * Para simplificar, asumiremos que los keys son numeros enteros y que no hay
 * Remove.
 *
 * Ubica todas las secciones con el tag TODO.  Cada tag les indicara que deben
 * completar.  Para TODOs que requieren respuestas, escribe las respuestas en
 * un comment.
 *
 * Instrucciones adicionales: 
 *   a) No borren los comments que existen en este codigo
 *   b) No alteren la firma de los metodos existentes; o sea, no pueden cambiar
 *      el return type, ni agregar mas parametros, ni modificar sus tipos de
 *      datos
 *
 */

using System;
using System.Collections.Generic;

public class KeyNotFoundException : System.Exception { }
public class DuplicateKeyException : System.Exception { }


    public class MyDictionary<V>
{
   
        // Pareja de Key y Value a grabar en cada bucket del Hash Table (y en el
        // stash)
        class KeyValuePair
      {
        public int key;
        public V value;
        public KeyValuePair(int key, V value)
        {
            this.key = key;
            this.value = value;
        }
      }

    const int INITIAL_SIZE = 3;  // capacidad inicial del arreglo arr

    // Hash Table normal
    private KeyValuePair[] arr = new KeyValuePair[INITIAL_SIZE];

    // Lista donde se graban los keys que no "caben" en el Hash Table
    private LinkedList<KeyValuePair> stash = new LinkedList<KeyValuePair>();
    // NOTA: Si te es mas comodo, puedes reemplazarlo por tu propio Dynamic
    //       Array o Linked List
    

    // Cantidad de datos grabados en la estructura de datos (incluyendo los
    // que estan en el stash)
    public int Size { get; private set; }
 


    // funcion hash a usar
    private int hash(int key)
    {  
        return key * 31 + 987654321;
    }


    const int MAX_PROBES = 10; // Maxima cantidad de probes antes de ir al stash
    const double MAX_LOAD_FACTOR = 0.5;  // Maximo Load Factor a permitir
    const int GROWTH_FACTOR = 2;  // Factor de crecimiento para Resize


    // Agregar 'key' al diccionario asociandolo al valor 'value'
    public void Add(int key, V value)
    {
        bool paso = true;
        int ContadorMaximo = 0;
        KeyValuePair p = Get(key);

        if (p != null )
            throw new DuplicateKeyException();

        double loadfactor = Size / arr.Length;

        if (loadfactor >=  MAX_LOAD_FACTOR)
            ResizeAndReindex(GROWTH_FACTOR * arr.Length);

        int pos = (int)(Math.Abs(hash(key)) % arr.Length);

        while (true)
        {
            if(ContadorMaximo == MAX_PROBES)
            {
                paso = false;
            }
            if (arr[pos] == null)
                break;
           
            pos++;

            if (pos >= arr.Length)
                pos = 0;

            ContadorMaximo++;
        }

        if(paso == false)
        {
            stash.AddLast(new KeyValuePair(key, value));
      
        }
        else
        {
            arr[pos] = new KeyValuePair(key, value);
         
        }

        Size++;

        // TODO: Implementar la estrategia descrita en el enunciado.  En adicion
        //       debes hacer ResizeAndReindex si el load factor excede el maximo
        //       load factor permitido
        // Valor: 3 puntos

    }


    private KeyValuePair Get(int key)
    {
        int contadorMaximo = 0;
        int pos = (int)(Math.Abs(hash(key)) % arr.Length);

        while (true)
        {
            
            if(contadorMaximo == MAX_PROBES)
            {
                LinkedListNode<KeyValuePair> cur = stash.First;
                while(cur!= null)
                {
                   
                    if(cur.Value.key == key)
                    {
                        return cur.Value;
                    }
                     cur = cur.Next;
                }
                if(cur == null)
                {
                    return null; 
                }

                   
            }
            if (arr[pos] == null)
                return null;

            if (arr[pos].key == key)
                return arr[pos];
            pos++;
            contadorMaximo++;
            if (pos >= arr.Length)
                pos = 0;
        }

    }


    // Buscar 'key' en el diccionario devolviendo el valor asociado
    public V Find(int key)
    {
        KeyValuePair p = Get(key);
        if (p == null )
            throw new KeyNotFoundException();

      
        // TODO: Implementar tomando en cuenta la estrategia descrita para Add
        // Valor: 2 puntos

        return p.value;
    }


    // Resize y reindexar
    private void ResizeAndReindex(int newCapacity)
    {
        int contador = 0;
        KeyValuePair[] temporal = new KeyValuePair[newCapacity];
        LinkedList<KeyValuePair> nuevo = new LinkedList<KeyValuePair>();

        foreach (KeyValuePair p in arr)
        {
            bool mandar = true;
            if (p == null)
                continue;

            int pos = (int)Math.Abs(hash(p.key)) % temporal.Length;

            while (true)
            {
                if(contador == MAX_PROBES)
                {
                    mandar = false;
                    break;
                }
                if (temporal[pos] == null)
                    break;

                pos++;

                if (pos >= temporal.Length)
                    pos = 0;

                contador++;
            }
            if (mandar == false)
            {
                nuevo.AddLast(p);
            }
            else
            {
                temporal[pos] = p;
            }
           
            contador = 0;
        }
        LinkedListNode<KeyValuePair> cur = stash.First;
        while(cur!= null)
        {
            int pos = (int)Math.Abs(hash(cur.Value.key)) % temporal.Length;
            while (contador < MAX_PROBES)
            {
                if(temporal[pos] == null)
                {
                    temporal[pos] = cur.Value;
                    break;
                }
                if (pos >= temporal.Length)
                    pos = 0;
                contador++;
                pos++;
            }
            if(contador == MAX_PROBES)
            {
                nuevo.AddLast(cur);
               
            }
            cur = cur.Next;
            contador = 0;
        }
        arr = temporal;
        stash = nuevo;

        // TODO: Implementar tomando en cuenta la estrategia descrita para Add
        // Valor: 3 puntos

    }
}



public class Lab3d
{
    public static void Main(string[] args)
    {
        /*
        var D = new MyDictionary<string>();
        
        D.Add(1, "uno");
        D.Add(10, "diez");
        D.Add(11, "once");
        D.Add(3, "tres");
        D.Add(5, "cinco");
        D.Add(6, "seis");
        D.Add(0, "cero");
        D.Add(-3, "negativo tres");
        try
        {
            D.Add(3, "tres duplicado!");
            Console.WriteLine("NOK: Esto no debe imprimirse");
        }
        catch (DuplicateKeyException)
        {
            Console.WriteLine("OK: 3 esta duplicado");
        }

        try
        {
            string res = D.Find(3);
            Console.WriteLine("OK: valor asociado al key 3: {0}", res);
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine("NOK: Esto no debe imprimirse");
        }
        try
        {
            D.Find(-10);
            Console.WriteLine("NOK: Esto no debe imprimirse");
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine("OK: key -10 no existe");
        }
        Console.ReadKey();
        */
        // Experimento

        //  Console.WriteLine(startTime);

        var D = new MyDictionary<int>();

        long startTime = DateTime.Now.Ticks;

        for (int i = 0; i < 100000; i++)
        {
            D.Add(i, i);
        }

        
        long endTime = DateTime.Now.Ticks;
        //  Console.WriteLine(endTime);
        long duration = (endTime - startTime) / 10000;
        Console.WriteLine("Duracion: {0}ms", duration);

        
     

        var H = new MyDictionary<int>();

        long startTime1 = DateTime.Now.Ticks;

        for (int i = 0; i < 1000000; i++)
        {
            H.Add(i, i);
        }


        long endTime1 = DateTime.Now.Ticks;
        //  Console.WriteLine(endTime);
        long duration2 = (endTime1 - startTime1) / 10000;
        Console.WriteLine("Duracion: {0}ms", duration2);

        var F = new MyDictionary<int>();

        long startTime2 = DateTime.Now.Ticks;

        for (int i = 0; i < 10000000; i++)
        {
            F.Add(i, i);
        }


        long endTime2 = DateTime.Now.Ticks;
        //  Console.WriteLine(endTime);
        long duration3 = (endTime2 - startTime2) / 10000;
        Console.WriteLine("Duracion: {0}ms", duration3);

        // Como vemos aqui en el caso de la duracion2 duro 300 milisegundos yen duration3 fueron alrededor de ese multiplo por 10
        // aumente la contastante de datos *10 y el tiempo de 300*10 = concuerda con el resultado esperado 
        Console.WriteLine("En average case es Constante O(1)");
        Console.Read();
        // TODO: Diseña e implementa un experimento para determinar cual es
        //       la complejidad de la operacion Add en el average case.
        //       Presenta y justifica tu conclusion del experimento en un
        //       comment o en otro documento aparte        
        // Valor: 2 puntos

    }
}
