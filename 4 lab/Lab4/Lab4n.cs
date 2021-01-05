/*
 * 
 * Puntos ejercicio: 14 (+2 extras)
 *
 * Este ejercicio consiste en completar/implementar algunas operaciones de un
 * Binary Search Tree.  En este Binary Search Tree, solo grabaremos keys (sin un
 * value asociado). La operacion de Remove esta implementada usando lapidas
 * (removed flag en el nodo). En cada nodo x, tendremos subtreeSize para indicar
 * la cantidad de datos grabados en el subtree cuya raiz es x.
 * 
 * En las complejidades especificadas, H es la altura del arbol
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
 *   c) No alteren los atributos existentes de las clases
 * 
 */

using System;
using System.Text;


class InvalidRotation : System.Exception {}
class DuplicateKey : System.Exception {}
class KeyNotFound : System.Exception {}
class InvalidOperation : System.Exception {}


// Definicion de Binary Search Tree (no balanceado)
public class BinarySearchTree
{
    // Definicion de un nodo del Binary Search Tree
    class TreeNode
    {
        public int key;
        public TreeNode left, right, parent;
        public bool removed;     // indica si este key esta borrado
        public int subtreeSize;  // cantidad de datos presentes (exclyendo los
                                 // que tienen removed == true) en el subtree
                                 // cuya raiz es este nodo
        public TreeNode(int key)
        {
            this.key = key;
            this.removed = false;
            this.subtreeSize = 1;
        }
    }

    // Metodo para evitar acceder subtreeSize de un nodo null
    private int SubtreeSize(TreeNode x)
    {
        if (x == null)
            return 0;
        else
            return x.subtreeSize;
    }
    
    private TreeNode root;    // raiz del Binary Search Tree


    /*
     * Devuelve la cantidad de datos grabados en el arbol
     */
    public int Size
    {
        get { return SubtreeSize(root); } // Size del tree = SubtreeSize de root
    }


    /*
     * Agrega 'key' al arbol.  Si ya existe (y removed esta apagado), lanza la
     * excepcion DuplicateKey.
     */
    public void Add(int key)
    {
        // TODO: Modifica el siguiente codigo para actualizar subtreeSize de
        //       todos los nodos afectados y tomar en cuenta el removed flag.
        //       Si 'key' existe, pero borrado, resucitalo.
        // Complejidad esperada: O(H)
        // Valor: 2 puntos

        if (root == null)
        {
            root = new TreeNode(key);
            return;
        }
        TreeNode cur = root, prev = null;
        while (cur != null)
        {
            if (key == cur.key)
                throw new DuplicateKey();
            prev = cur;
            if (key < cur.key)
                cur = cur.left;
            else
                cur = cur.right;
        }
        TreeNode newNode = new TreeNode(key);
        if (key < prev.key)
            prev.left = newNode;
        else
            prev.right = newNode;
        newNode.parent = prev;

    }

    
    /*
     * Elimina 'key' del arbol (usando lapidas). Si no existe, lanza KeyNotFound
     */
    public void Remove(int key)
    {
        // TODO: Modifica el siguiente codigo para actualizar subtreeSize de
        //       todos los nodos afectados.
        // Complejidad esperada: O(H)
        // Valor: 1 punto

        TreeNode cur = root;
        while (cur != null)
        {
            if (key == cur.key)
            {
                cur.removed = true;    // marca este key como borrado
                return;
            }
            if (key < cur.key)
                cur = cur.left;
            else
                cur = cur.right;
        }
        throw new KeyNotFound();
    }
    
    
    /*
     * Devuelve true si 'key' existe en el arbol.
     */
    public bool Contains(int key)
    {
        TreeNode cur = root;
        while (cur != null)
        {
            if (key == cur.key)
                return !cur.removed;
            if (key < cur.key)
                cur = cur.left;
            else
                cur = cur.right;
        }
        return false;
    }


    /*
     * Devuelve el maximo key presente en el arbol
     */
    public int Max()
    {
        if (Size == 0)
            throw new KeyNotFound();
        TreeNode max = this.MaxNode();
        return max.key;
    }


    /*
     * Devuelve el minimo key presente en el arbol
     */
    public int Min()
    {
        if (Size == 0)
            throw new KeyNotFound();
        TreeNode min = this.MinNode();
        return min.key;
    }

    
    /*
     * Encuentra el nodo con el maximo key
     */
    private TreeNode MaxNode()
    {
        // TODO: Implementar algoritmo que analizamos en clase: antes de bajar
        //       por un edge, detecta si vale la pena avanzar por ahi.  Eso lo
        //       logramos inspeccionando el subtree size.
        // Complejidad esperada: O(H)
        // Valor: 4 puntos

        return null;
    }

    
    /*
     * Encuentra el nodo con el minimo key
     */
    private TreeNode MinNode()
    {
        // TODO: Implementar algoritmo similar a MaxNode
        // Complejidad esperada: O(H)
        // Valor: 0 puntos (incluido en MaxNode)

        return null;
    }

    
    /* 
     *  rotateRight(Q) rota el nodo Q hacia la derecha.
     */
    private void RotateRight(TreeNode Q)
    { 
        if (Q == null || Q.left == null)
            throw new InvalidRotation();
        
        TreeNode par = Q.parent;
        TreeNode P = Q.left;
        TreeNode B = P.right;
        if (B != null)
            B.parent = Q;
        Q.left = B;
        Q.parent = P;
        P.right = Q;
        P.parent = par;
        if (par != null) {
            if (Q == par.left)
                par.left = P;
            else
                par.right = P;
        }
        else
            root = P;

        // TODO: Actualiza subtreeSize de todos los nodos afectados
        // Complejidad esperada: O(1) worst-case
        // Valor: 1 punto
    }


    /* 
     * rotateLeft(P) rota el nodo P hacia la izquierda.
     */
    private void RotateLeft(TreeNode P)
    {
        if (P == null || P.right == null)
           throw new InvalidRotation();

        TreeNode par = P.parent;
        TreeNode Q = P.right;
        TreeNode B = Q.left;
        if (B != null)
            B.parent = P;
        P.right = B;
        P.parent = Q;
        Q.left = P;
        Q.parent = par;
        if (par != null) {
            if (P == par.left)
                par.left = Q;
            else
                par.right = Q;
        }
        else
            root = Q;

        // TODO: Actualiza subtreeSize de todos los nodos afectados
        // Complejidad esperada: O(1) worst-case
        // Valor: 0 puntos (incluido en RotateRight)
    }


    /* 
     * Concatena el arbol 'other' al arbol 'this', formando un arbol mas grande
     * en 'this' con todos los keys de ambos arboles originales.  Esta operacion
     * solamente es valida si *todos* los keys del arbol 'other' son mayores que
     * cada key del arbol 'this'.  De lo contrario, lanza InvalidOperation.
     */
    public void Concatenate(BinarySearchTree other)
    {
        // TODO: Implementar usando rotaciones
        // ASUMPTION: el arbol no tiene lapidas
        // HINTS: Intenta contestar las siguientes preguntas:
        //   [1] Como luce un arbol donde root tiene el maximo key? Trata de
        //       dibujar un arbol con el maximo en el root
        //   [2] En el caso de que el maximo se encuentra en el root, que harias
        //       para para "pegar" el arbol 'other'?
        // Complejidad esperada: O(H)
        // Valor: 6 puntos
        //        2 puntos extras si logras implementar esta operacion (con la
        //        misma complejidad) sin asumir que no existen lapidas


    }


    /*
     * Imprimir arbol a la consola de forma jerarquica
     */
    public void prettyPrintBST() {
        prettyPrintBST(root);
    }


    /*
     * Imprime el subtree rooted at cur a la consola de forma jerarquica
     */
    private void prettyPrintBST(TreeNode cur, string pad = "") {
        if (pad.Length >= 4)
            Console.Write(pad.Substring(0, pad.Length-4) + "+---");
        if (cur == null) {
            Console.WriteLine(" *");
            return;
        }
        if (cur.removed)
            Console.Write(" !");
        Console.WriteLine(" {0} ({1})", cur.key, cur.subtreeSize);
        if (cur.left == null && cur.right == null)
            return;
        prettyPrintBST(cur.left, pad + "|   ");
        prettyPrintBST(cur.right, pad + "    ");
        Console.WriteLine(pad);
    }
}


public class Lab4n
{

    public static void Main(string[] args)
    {
        BinarySearchTree tree1 = new BinarySearchTree();
        tree1.Add(40);
        tree1.Add(60);
        tree1.Add(10);
        tree1.Add(25);
        tree1.Add(30);
        tree1.Add(50);
        tree1.Add(70);
        tree1.Add(20);
        tree1.Remove(25);
        Console.WriteLine("Tree #1:");
        tree1.prettyPrintBST();

        BinarySearchTree tree2 = new BinarySearchTree();
        tree2.Add(80);
        tree2.Add(90);
        tree2.Add(85);
        tree2.Add(75);
        tree2.Add(77);
        tree2.Remove(90);
        tree2.Add(100);
        tree2.Add(90);   // resucita key 90
        Console.WriteLine("Tree #2:");
        tree2.prettyPrintBST();
        
        tree1.Add(25);   // resucita key 25
        
        tree1.Concatenate(tree2);
        Console.WriteLine("Concatenated Tree1 + Tree2:");
        tree1.prettyPrintBST();
    }
}


/*
Mi output:

Tree #1:
 40 (7)
+--- 10 (3)
|   +--- *
|   +--- ! 25 (2)
|       +--- 20 (1)
|       +--- 30 (1)
|       
|   
+--- 60 (3)
    +--- 50 (1)
    +--- 70 (1)
    

Tree #2:
 80 (6)
+--- 75 (2)
|   +--- *
|   +--- 77 (1)
|   
+--- 90 (3)
    +--- 85 (1)
    +--- 100 (1)
    

Concatenated Tree1 + Tree2:
 70 (14)
+--- 40 (7)
|   +--- 10 (4)
|   |   +--- *
|   |   +--- 25 (3)
|   |       +--- 20 (1)
|   |       +--- 30 (1)
|   |       
|   |   
|   +--- 60 (2)
|       +--- 50 (1)
|       +--- *
|       
|   
+--- 80 (6)
    +--- 75 (2)
    |   +--- *
    |   +--- 77 (1)
    |   
    +--- 90 (3)
        +--- 85 (1)
        +--- 100 (1)
        
    

 */
