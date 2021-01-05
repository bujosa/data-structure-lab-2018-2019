/*
 * Puntos ejercicio: 8 puntos
 * 
 * Este es un ejercicio 'fun' que encontre en internet. Imaginate que estas
 * atrapado dentro de un calabozo (dungeon en ingles) cuyas dimensiones son
 * desconocidas.  De este calabozo, solo conocemos lo siguiente:
 *    a) Existen dos tipos de calabozos:
 *       1) Rectangular: se puede modelar como una matrix rectangular (de dos
 *          dimensiones) donde cada fila tiene la misma cantidad de celdas
 *       2) Jagged: se puede modelar como un jagged array, donde cada fila no
 *          necesariamente tiene la misma cantidad de celdas que otras filas
 *    b) Cada celda del arreglo (jagged o no) representa una habitacion del
 *       calabozo
 *    c) Cada habitacion tiene puertas en las 4 direcciones cardinales: Norte,
 *       Sur, Este y Oeste, las cuales llevan a otra habitacion o hacia el
 *       abismo!
 *
 * Tu ubicacion inicial en el calabozo tambien es desconocida.  En cualquier
 * momento, puedes abrir una de las puertas en la habitacion donde te encuentras
 * y (si esa puerta te lleva a otra habitacion) atravesarla para llegar a la
 * habitacion adyacente.
 * 
 * Tu objetivo es determinar la cantidad total de habitaciones que existen en
 * el calabozo.
 * 
 * Para todas estas interaciones, solo tienes que usar el siguiente metodo
 * publico expuestos en la clase Dungeon:
 *   # GoThruDoor(d): abre e intentas atravesar la puerta en la direccion 'd' de
 *      la habitacion donde te encuentras actualmente; devuelve true si logras
 *      llegar a otra habitacion
 *
 * NOTA: Sugiero que ignores el codigo en las clases Dungeon, RectangularDungeon
 * y JaggedDungeon, porque no es relevante para completar este ejercicio.
 * 
 * Ubica todas las secciones con el tag TODO.  Cada tag les indicara que deben
 * completar.  Para TODOs que requieren respuestas, escribe las respuestas en
 * un comment.
 *
 * Instrucciones adicionales: 
 *   a) No borren los comments que existen en este codigo
 *   b) En la version final que sometas, no debes alterar las clases Dungeon,
 *      RectangularDungeon y JaggedDungeon
 *
 */


using System;



// Definicion de las 4 direcciopnes cardinales
public enum Direction
{
    NORTH, SOUTH, EAST, WEST
}


// -----------------------------------------------------------------------------
// Definicion de un calabozo
public abstract class Dungeon
{
    public int Id { get; protected set; }
    protected char[][] cells;
    protected int currentRow, currentCol;
    protected long numberOfRooms;

    // Abre la puerta ubicada en la direccion 'direction' de la habitacion
    // actual e intenta atravesarla
    // Devuelve true si logras moverte a la otra habitacion detras de la puerta
    public bool GoThruDoor(Direction direction)
    {
        int nextRow = currentRow;
        int nextCol = currentCol;
        switch (direction)
        {
            case Direction.NORTH:
                nextRow = currentRow - 1;
                break;
            case Direction.SOUTH:
                nextRow = currentRow + 1;
                break;
            case Direction.EAST:
                nextCol = currentCol + 1;
                break;
            case Direction.WEST:
                nextCol = currentCol - 1;
                break;
        }
        try
        {
            if (cells[nextRow][nextCol] != '.')
                return false;
            currentRow = nextRow;
            currentCol = nextCol;
            ++NumberOfMoves;
            return true;
        }
        catch (IndexOutOfRangeException)
        {
            return false;
        }
    }

    // Verifica si tu respuesta coincide con la respuesta esperada
    public bool AnswerMatches(long yourAnswer)
    {
        return yourAnswer == this.numberOfRooms;
    }

    // Cantidad de veces que GoThruDoor es ejecutado
    public int NumberOfMoves { get; private set; }
}


// Definicion de un calabozo rectangular
public class RectangularDungeon : Dungeon
{
    // Construye el calabozo identificado por 'id' de tipo rectangular con
    // dimensiones maximas de MAXROWS x MAXCOLUMNS.
    public RectangularDungeon(int id, int MAXROWS, int MAXCOLUMNS)
    {
        this.Id = id;
        Random rnd = new Random(id * 17);
        int R = rnd.Next(1, MAXROWS + 1);
        int C = rnd.Next(1, MAXCOLUMNS + 1);
        this.cells = new char[R][];
        for (int row = 0; row < R; ++row)
        {
            this.cells[row] = new char[C];
            for (int col = 0; col < this.cells[row].Length; ++col)
            {
                this.cells[row][col] = '.';
                this.numberOfRooms++;
            }
        }
        this.currentRow = rnd.Next(0, cells.Length);
        this.currentCol = rnd.Next(0, cells[currentRow].Length);
    }
}


// Definicion de un calabozo jagged
public class JaggedDungeon : Dungeon
{
    // Construye el calabozo identificado por 'id' de tipo jagged con
    // dimensiones maximas de MAXROWS x MAXCOLUMNS.
    public JaggedDungeon(int id, int MAXROWS, int MAXCOLUMNS)
    {
        this.Id = id;
        Random rnd = new Random(id * 13);
        int R = rnd.Next(1, MAXROWS + 1);
        this.cells = new char[R][];
        for (int row = 0; row < R; ++row)
        {
            int C = rnd.Next(1, MAXCOLUMNS + 1);
            this.cells[row] = new char[C];
            for (int col = 0; col < this.cells[row].Length; ++col)
            {
                cells[row][col] = '.';
                this.numberOfRooms++;
            }
        }
        this.currentRow = rnd.Next(0, cells.Length);
        this.currentCol = rnd.Next(0, cells[currentRow].Length);
    }
}


// -----------------------------------------------------------------------------


public class Lab1b
{

    public static long solve(RectangularDungeon d)
    {
        int habitacion = 0;
        int habitacion2 = 0;
        int movimiento = 0;
        int reset = 0;
       
       
            // Obtener Altura
            for (bool movNorte = true; movNorte == true;)
            {
                movNorte = d.GoThruDoor(Direction.NORTH);
                if (movNorte == true)
                {
                    habitacion += 1;
                }
               
           
            }

            habitacion = habitacion + 1;


            // Obtener Altura
            for (bool movSur = true; movSur == true;)
            {
                movSur = d.GoThruDoor(Direction.SOUTH);
                if (movSur == true)
                {
                    habitacion2 += 1;
                }
              
            }
            habitacion2 = habitacion2 + 1;


            if (habitacion2 >= habitacion)
            {
                movimiento = habitacion2;
            }
            else
            {
            movimiento = habitacion;
            }

            habitacion = 0;
            habitacion2 = 0;

            for (bool movEste = true; movEste == true;)
            {
                movEste = d.GoThruDoor(Direction.EAST);
                if (movEste == true)
                {
                    habitacion += 1;
                }
                
            }
            habitacion = habitacion + 1;

            for (bool movOeste = true; movOeste == true;)
            {
                movOeste = d.GoThruDoor(Direction.WEST);
                if (movOeste == true)
                {
                    habitacion2 += 1;
                }
               
            }
            habitacion2 = habitacion2 + 1;

            if (habitacion2 >= habitacion)
            {
                reset = movimiento;
                movimiento = movimiento * habitacion2;

                if (movimiento == 0)
                {

                    movimiento = habitacion2;
                }
                if (movimiento == 0)
                {
                    movimiento = reset;
                }
            }
            else
            {
            movimiento = movimiento * habitacion;
            }

           

               

        
        // TODO: implementar algoritmo para determinar la cantidad total de
        //       habitaciones existentes en el calabozo tipo matrix rectangular
        // Valor: 4 puntos
        // Restriccion: la cantidad de movimientos de tu solucion no debe
        //              exceder 4 veces el de mi solucion; ver ejemplo en Main
        //              para comparar tus resultados contra los mios

        // Ejemplo de interaccion:
        // d.GoThruDoor(Direction.SOUTH);

        return movimiento;
    }


    public static long solve(JaggedDungeon d)
    {

        int habitacion = 0;
  
        for (bool movoeste = true; movoeste == true;)
        {
            movoeste = d.GoThruDoor(Direction.WEST);
           
        }
        for (bool movnorte = true; movnorte == true;)
        {
            movnorte = d.GoThruDoor(Direction.NORTH);
        }

        bool movsur = true;
        do
        {
            for(bool moveste = true; moveste == true;)
            {
                moveste = d.GoThruDoor(Direction.EAST);
                if(moveste == true)
                {
                    habitacion += 1;
                }
            }
            habitacion += 1;
            for(bool movoeste = true; movoeste == true;)
            {
                movoeste = d.GoThruDoor(Direction.WEST);
                if(movoeste == false)
                {
                    movsur = d.GoThruDoor(Direction.SOUTH);
                }
            }
        } while (movsur == true);
        // TODO: implementar algoritmo para determinar la cantidad total de
        //       habitaciones existentes en el calabozo tipo jagged array
        // Valor: 4 puntos
        // Restriccion: la cantidad de movimientos de tu solucion no debe
        //              exceder 4 veces el de mi solucion; ver ejemplo en Main
        //              para comparar tus resultados contra los mios
        // NOTA: aunque el nombre del metodo, solve, es igual al de la version
        //       rectangular, C# logra distinguir ambas versiones por el tipo
        //       de parametro que recibe cada metodo.  Si te molesta, puedes
        //       renombrar estos metodos.

        // Ejemplo de interaccion:
        // d.GoThruDoor(Direction.SOUTH);

        return habitacion;
    }


    public static void Main(string[] args)
    {

        Console.WriteLine("====================");
        Console.WriteLine("Rectangular Dungeons");
        Console.WriteLine("====================");
        for (int id = 1; id <= 10; id++)
        {
            RectangularDungeon d = new RectangularDungeon(id, 20, 20);
            long yourAnswer = solve(d);
            Console.WriteLine("Dungeon # {0,3} |  yourAnswer: {1,4}" +
                              "  correct: {2,3}  numberOfMoves: {3,5}",
                              id, yourAnswer,
                              d.AnswerMatches(yourAnswer) ? "Yes" : "No",
                              d.NumberOfMoves);
        }
        Console.WriteLine();

        Console.WriteLine("===============");
        Console.WriteLine("Jagged Dungeons");
        Console.WriteLine("===============");
        for (int id = 1; id <= 10; id++)
        {
            JaggedDungeon d = new JaggedDungeon(id, 20, 20);
            long yourAnswer = solve(d);
            Console.WriteLine("Dungeon # {0,3} |  yourAnswer: {1,4}" +
                              "  correct: {2,3}  numberOfMoves: {3,5}",
                              id, yourAnswer,
                              d.AnswerMatches(yourAnswer) ? "Yes" : "No",
                              d.NumberOfMoves);
        }
        Console.WriteLine();

        Console.Read();

        /*
        Output de mi solucion:

        ====================
        Rectangular Dungeons
        ====================
        Dungeon #   1 |  yourAnswer:  221  correct: Yes  numberOfMoves:    39
        Dungeon #   2 |  yourAnswer:  160  correct: Yes  numberOfMoves:    42
        Dungeon #   3 |  yourAnswer:  128  correct: Yes  numberOfMoves:    32
        Dungeon #   4 |  yourAnswer:   96  correct: Yes  numberOfMoves:    22
        Dungeon #   5 |  yourAnswer:   48  correct: Yes  numberOfMoves:    28
        Dungeon #   6 |  yourAnswer:   15  correct: Yes  numberOfMoves:    18
        Dungeon #   7 |  yourAnswer:  270  correct: Yes  numberOfMoves:    62
        Dungeon #   8 |  yourAnswer:  240  correct: Yes  numberOfMoves:    50
        Dungeon #   9 |  yourAnswer:  210  correct: Yes  numberOfMoves:    39
        Dungeon #  10 |  yourAnswer:  154  correct: Yes  numberOfMoves:    40

        ===============
        Jagged Dungeons
        ===============
        Dungeon #   1 |  yourAnswer:  139  correct: Yes  numberOfMoves:   276
        Dungeon #   2 |  yourAnswer:   78  correct: Yes  numberOfMoves:   165
        Dungeon #   3 |  yourAnswer:   25  correct: Yes  numberOfMoves:    59
        Dungeon #   4 |  yourAnswer:  143  correct: Yes  numberOfMoves:   281
        Dungeon #   5 |  yourAnswer:   93  correct: Yes  numberOfMoves:   179
        Dungeon #   6 |  yourAnswer:  110  correct: Yes  numberOfMoves:   214
        Dungeon #   7 |  yourAnswer:   61  correct: Yes  numberOfMoves:   117
        Dungeon #   8 |  yourAnswer:   17  correct: Yes  numberOfMoves:    33
        Dungeon #   9 |  yourAnswer:  157  correct: Yes  numberOfMoves:   306
        Dungeon #  10 |  yourAnswer:  113  correct: Yes  numberOfMoves:   224

        */
    }
}
