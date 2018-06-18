using System;
using System.Collections.Generic;

//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


class ArregloVacio : System.Exception { }
class PosicionInvalida : System.Exception { }

class DynamicArray<Item>
{
    public Item[] arr { get; private set; }

    private int size = 0;

    public int Size()
    {
        return size;
    }

    public DynamicArray()
    {
        arr = new Item[1];
    }

    public Item get(int pos)
    {
        if (pos < 0 || pos >= size)
            throw new PosicionInvalida();
        return arr[pos];
    }

    public void set(int pos, Item value)
    {
        if (pos < 0 || pos >= size)
            throw new PosicionInvalida();
        arr[pos] = value;
    }



    public void Append(Item x)
    {
        if (arr.Length == size)
        {
            const int FACTOR_CRECIMIENTO = 2;
            // el arreglo ya esta lleno -> debemos agrandarlo
            Resize(FACTOR_CRECIMIENTO * arr.Length);
        }

        arr[size] = x;
        size++;
    }

    public Item RemoveLast()
    {
        if (size <= 0)
            throw new ArregloVacio();
        Item t = arr[size - 1];
        //  arr[size - 1] = null;
        size--;
        if (size * 4 < arr.Length)
        {
            Resize(arr.Length / 2);
        }
        return t;
    }

    public void Resize(int newCapacity)
    {
        Item[] newArr = new Item[newCapacity];    // Theta(C)

        for (int i = 0; i < arr.Length && i < newArr.Length; i++)   // C/2 = Theta(C)
            newArr[i] = arr[i];  // O(1)

        arr = newArr;   // O(1)
        if (size > arr.Length)   // O(1)
            size = arr.Length;   // O(1)
    }
}


class Program
{
    static void Main(string[] args)
    {
        DynamicArray<int> d = new DynamicArray<int>();
        d.Append(3);
        d.Append(1);
        d.Append(1);
        d.Append(2);

        Console.WriteLine(d.arr[0]);
        Console.WriteLine(d.arr[1]);
        Console.WriteLine(d.get(2));
        Console.WriteLine(d.get(3));
        d.set(2, 7);

        //   d.arr = null;    // no permitido porque es privado
        d.Append(3);

        DynamicArray<string> B = new DynamicArray<string>();
        B.Append("Hello");
        B.Append("World");
        Console.WriteLine(B.arr[0] + " " + B.arr[1]);

        

        Console.Read();

        /*
        long startTime = DateTime.Now.Ticks;
        Console.WriteLine(startTime);
        const int N = 100000000;
        for (int n = 1; n <= N; n++)
            d.Append(n);
        long endTime = DateTime.Now.Ticks;
        Console.WriteLine("Termino");
        Console.WriteLine(endTime);
        Console.WriteLine("Duracion: {0}", (endTime - startTime) / 10000);
        Console.Read();

        List<int> A = new List<int>();
        A.Add(1);
 */
    }
}
