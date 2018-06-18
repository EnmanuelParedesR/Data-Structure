using System;
using System.Collections.Generic;

//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


class SLinkNode<Item>
{
    public Item value;
    public SLinkNode<Item> next;
    public SLinkNode(Item value)
    {
        this.value = value;
    }
}

class ListaVacia : System.Exception { }

class SLinkedList<Item>
{
    public int size { get; set; }
    private SLinkNode<Item> head;

    public void AddFront(Item value)
    {
        SLinkNode<Item> newNode = new SLinkNode<Item>(value);
        newNode.next = head;
        head = newNode;
        size++;
    }

    public Item RemoveFront()
    {
        if (size == 0)
            throw new ListaVacia();
        Item ret = head.value;
        head = head.next;
        size--;
        return ret;
    }
}

class Program
{
    static void Main(string[] args)
    {
        SLinkedList<int> lista = new SLinkedList<int>();
        lista.AddFront(3);
        lista.AddFront(-1);
        lista.AddFront(9);
        lista.AddFront(5);

        lista.RemoveFront();
        lista.RemoveFront();

        Console.WriteLine("removed item: {0}", lista.RemoveFront());
        Console.WriteLine("size: {0}", lista.size);
        Console.ReadLine();
    }
}
