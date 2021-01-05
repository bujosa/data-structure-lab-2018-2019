/*
 *
 * Puntos ejercicio: 8 (+ 1 extra)
 *
 * En este ejercicio, implementaremos una estructura de datos que representa dos
 * stacks usando un solo arreglo dinamico.  Esta estructura debe proveer las
 * siguientes operaciones:
 *    Push(s, x)  agrega el elemento x en el stack indicado por s
 *    Pop(s)      extrae y devuelve el elemento en el tope del stack s
 *    Peek(s)     devuelve el elemento en el tope del stack s
 *    Size(s)     devuelve la cantidad de elementos en el stack s
 *
 * El parametro s es del tipo enumerated type (un enum en C#) con los valores
 * ONE y TWO.  Ver un ejemplo de uso en los metodos Size() y Main().
 *
 * La idea es que el primer stack crezca de izquierda a derecha empezando desde
 * la posicion 0 del arreglo, mientras que el segundo stack debe crecer de
 * derecha a izquierda partiendo desde la posicion arr.Lenght-1.
 * 
 * Ubica todas las secciones con el tag TODO.  Cada tag les indicara que deben
 * completar.  Para TODOs que requieren respuestas, escribe las respuestas en
 * un comment.
 *
 * Instrucciones adicionales: 
 *   a) No borren los comments que existen en este codigo
 *   b) No se permite usar las estructuras de datos en C#
 *   c) No alteren la firma de los metodos existentes; o sea, no pueden cambiar
 *      el return type, ni agregar mas parametros, ni modificar sus tipos de
 *      datos
 *
 */

using System;

 
/*
 * Este enumerated type identifica el stack sobre el cual quieres ejecutar
 * los metodos Push(), Pop(), o Size().
 */
public enum StackNumber { ONE, TWO };


class TwoStack
{
    const int INITIAL_CAPACITY = 2;   // capacidad inicial del arreglo dinamico
    // TIP: para debuggear sin haber implementado el metodo Resize(), aumenta
    //      esta constante a 20 por ejemplo

    private int[] arr = new int[INITIAL_CAPACITY];  // arreglo que representa
                                                    // los dos stacks

    private int size1, size2;   // cantidad de datos en los stacks ONE y TWO,
                                // respectivamente

    // TODO: implementa esta clase sin agregar atributos ni propiedades
    //       adicionales
    // Valor: 1 punto extra


    /*
     * Devuelve la cantidad de datos grabados en el stack 's'
     */
    public int Size(StackNumber stackNumber)
    {
        if (stackNumber == StackNumber.ONE)
            return size1;
        else
            return size2;
    }

    
    /*
     * Agrega el elemento con valor 'value' al tope del stack identificado por
     * 'stackNumber'
     */
    public void Push(StackNumber stackNumber, int value)
    {
        // TODO: implementar
        //       Si no hay suficiente espacio en el arreglo, agranda el arreglo
        //       al doble de su capacidad anterior
        // Complejidad esperada: O(1) avg case
        // Valor: 2.5 puntos

    }

    
    /*
     * Extrae y devuelve el elemento en el tope del stack identificado por
     * 'stackNumber'
     */
    public int Pop(StackNumber stackNumber)
    {
        // TODO: implementar
        //       Si la cantidad de datos se reduce a 1/4 de la capacidad total
        //       del arreglo, achica el arreglo a la mitad de la capacidad
        //       anterior
        // Complejidad esperada: O(1) avg case
        // Valor: 2.5 puntos

        return 0;
    }

    
    /*
     * Devuelve (sin extraer) el elemento en el tope del stack identificado por
     * 'stackNumber'
     */
    public int Peek(StackNumber stackNumber)
    {
        // TODO: implementar
        // Complejidad esperada: O(1) worst-case
        // Valor: 1 punto

        return 0;
    }

    
    /*
     * Recrea el arreglo con la nueva capacidad indicada por el parametro
     * newCapacity, copiando los datos del arreglo anterior al nuevo
     */
    private void Resize(int newCapacity)
    {
        // TODO: implementar
        // Complejidad esperada: Theta(N)
        // Valor: 2 puntos

    }
    
}
 

public class Lab2p
{
    static public void Main(string[] args)
    {
        Random rnd = new Random(1234567);

        TwoStack S = new TwoStack();

        for (int n = 1; n <= 10; n++)
        {
            // Aleatoriamente elige un numero entero de 0 a 9 y lo convierte
            // a string
            int value = rnd.Next(10);
            
            // Aleatoriamente elige un stack
            StackNumber stackNumber;
            if (rnd.Next(2) == 0)
                stackNumber = StackNumber.ONE;
            else
                stackNumber = StackNumber.TWO;
            S.Push(stackNumber, value);
            Console.WriteLine("Pushed {0} onto stack # {1}",
                              value, stackNumber);
        }
        
        Console.WriteLine("Size of stack # {0} : {1}",
                          StackNumber.ONE, S.Size(StackNumber.ONE));
        Console.WriteLine("Size of stack # {0} : {1}",
                          StackNumber.TWO, S.Size(StackNumber.TWO));
                          
        for (int n = 1; n <= 4; n++)
        {
            // Aleatoriamente elige un stack a ejecutar Pop
            StackNumber stackNumber;
            if (rnd.Next(2) == 0)
                stackNumber = StackNumber.ONE;
            else
                stackNumber = StackNumber.TWO;
            int value = S.Pop(stackNumber);
            Console.WriteLine("Popped {0} from stack # {1}",
                              value, stackNumber);
        }

        Console.WriteLine("Size of stack # {0} is {1}",
                          StackNumber.ONE, S.Size(StackNumber.ONE));
        Console.WriteLine("Size of stack # {0} is {1}",
                          StackNumber.TWO, S.Size(StackNumber.TWO));
                          
        
        Console.WriteLine("Peek into stack # {0} and got {1}",
                          StackNumber.ONE, S.Peek(StackNumber.ONE));
        Console.WriteLine("Peek into stack # {0} and got {1}",
                          StackNumber.TWO, S.Peek(StackNumber.TWO));

        Console.ReadLine();
    }
/*
Output esperado:

Pushed 7 onto stack # TWO
Pushed 2 onto stack # ONE
Pushed 6 onto stack # TWO
Pushed 9 onto stack # ONE
Pushed 5 onto stack # ONE
Pushed 4 onto stack # TWO
Pushed 0 onto stack # ONE
Pushed 1 onto stack # TWO
Pushed 2 onto stack # TWO
Pushed 8 onto stack # TWO
Size of stack # ONE : 4
Size of stack # TWO : 6
Popped 0 from stack # ONE
Popped 5 from stack # ONE
Popped 9 from stack # ONE
Popped 8 from stack # TWO
Size of stack # ONE is 1
Size of stack # TWO is 5
Peek into stack # ONE and got 2
Peek into stack # TWO and got 2
*/
}
 
