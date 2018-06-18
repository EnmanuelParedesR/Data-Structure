using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BinarySearchTree<Value>
{
    public class TreeNode
    {
        public int key { get; set; }
        public Value value { get; set; }
        public TreeNode left, right;
        // TreeNode parent;
        public int subtree_size = 1;
        public TreeNode(int key, Value value)
        {
            this.key = key;
            this.value = value;
        }
    }

    public TreeNode root;
    int size;

    public int subtree_size(TreeNode x)
    {
        if (x == null)
            return 0;
        else
            return x.subtree_size;
    }

    public Value find(int key)
    {
        TreeNode x = findNode(key);
        if (x == null)
            return default(Value);   // null!!!
        else
            return x.value;
    }

    private TreeNode findNode(int key)
    {
        TreeNode cur = root;
        while (cur != null)
        {
            if (key == cur.key)
                return cur;
            if (key < cur.key)
                cur = cur.left;
            else
                cur = cur.right;
        }
        return null;
    }

    public void add(int key, Value value)
    {
        if (size == 0)
        {
            root = new TreeNode(key, value);
            size = 1;
            return;
        }

        Stack<TreeNode> S = new Stack<TreeNode>();
        TreeNode cur = root, prev = null;
        while (cur != null)
        {
            if (key == cur.key)
                throw new Exception("Key duplicado");
            S.Push(cur);
            prev = cur;
            if (key < cur.key)
                cur = cur.left;
            else
                cur = cur.right;
        }
        if (key < prev.key)
            prev.left = new TreeNode(key, value);
        else
            prev.right = new TreeNode(key, value);
        //  cur.parent = prev;
        size++;

        foreach (TreeNode x in S)
            x.subtree_size++;

    }

    public int? min()
    {
        if (root == null) return null;
        TreeNode cur = root;
        while (cur.left != null)
            cur = cur.left;
        return cur.key;
    }

    public TreeNode minNode(TreeNode x)
    {
        if (x == null) return null;
        TreeNode cur = x;
        while (cur.left != null)
            cur = cur.left;
        return cur;
    }


    public int? successor(int key)
    {
        int? best = null;
        TreeNode cur = root;
        while (cur != null)
        {
            if (key == cur.key)
                cur = cur.right;
            else if (key < cur.key)
            {
                best = cur.key;
                cur = cur.left;
            }
            else
                cur = cur.right;
        }
        return best;
    }

    public int[] InOrderIteration()
    {
        int[] resultado = new int[size];
        Stack<TreeNode> S = new Stack<TreeNode>();
        TreeNode cur = root;
        for (int i = 0; i < size; i++)
        {
            while (cur != null)
            {
                S.Push(cur);
                cur = cur.left;
            }
            cur = S.Pop();
            resultado[i] = cur.key;
            cur = cur.right;
        }
        return resultado;
    }

    public int rank(int key)
    {
        int res = 0;
        TreeNode cur = root;
        while (cur != null)
        {
            if (key == cur.key)
            {
                res += subtree_size(cur.left);
                break;
            }
            if (key < cur.key)
                cur = cur.left;
            else
            {
                res += subtree_size(cur.left) + 1;
                cur = cur.right;
            }
        }
        return res;
    }

    public int select(int pos)
    {
        if (pos < 0 || pos >= size) throw new Exception("Invalid position");
        int k = pos;
        TreeNode cur = root;
        while (cur != null)
        {
            if (k == subtree_size(cur.left))
                return cur.key;
            if (k < subtree_size(cur.left))
                cur = cur.left;
            else
            {
                k -= (1 + subtree_size(cur.left));
                cur = cur.right;
            }
        }
        throw new Exception("WTF!");
    }

    public Value remove(int key)
    {
        // INCOMPLETO!!!

        if (findNode(key) == null)
            throw new Exception("Key does not exist");

        TreeNode cur = root, prev = null;

        size--;
        while (cur != null)
        {
            cur.subtree_size--;
            if (key == cur.key)
            {
                if (cur.left == null && cur.right == null)
                {
                    if (prev == null)
                        root = null;
                    else if (cur == prev.left)
                        prev.left = null;
                    else
                        prev.right = null;
                    return cur.value;
                }
                else if (cur.left == null && cur.right != null)
                {
                    if (prev == null)
                        root = cur.right;
                    else if (cur == prev.left)
                        prev.left = cur.right;
                    else
                        prev.right = cur.right;
                    return cur.value;
                }
                else if (cur.left != null && cur.right == null)
                {

                }
                else
                {
                    // tiene dos hijos :-(
                }
            }
            prev = cur;
            if (key < cur.key)
                cur = cur.left;
            else
                cur = cur.right;
        }


        return default(Value);
    }

}


class Program
{
    static void Main(string[] args)
    {
        BinarySearchTree<string> bst = new BinarySearchTree<string>();
        bst.add(20, "veinte");
        bst.add(50, "cincuenta");
        bst.add(10, "diez");
        bst.add(15, "quince");
        bst.add(100, "cien");
        bst.add(40, "cuarenta");

        Console.WriteLine(bst.find(15));

        foreach (int x in bst.InOrderIteration())
        {
            Console.Write(x + " ");
        }
        Console.WriteLine();

        Console.WriteLine(bst.successor(18));
        Console.WriteLine("'" + bst.successor(100) + "'");
        Console.WriteLine(bst.min());

        Console.WriteLine(bst.subtree_size(bst.root));

        Console.WriteLine(bst.rank(50));
        Console.WriteLine(bst.rank(27));

        Console.WriteLine(bst.select(4));

        bst.remove(100);

        foreach (int x in bst.InOrderIteration())
        {
            Console.Write(x + " ");
        }

        Console.Read();
    }
}
