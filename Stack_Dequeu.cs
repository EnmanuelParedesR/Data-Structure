using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackQueueDeck
{
    class StackVaciaException : Exception { }
    class DequeueVaciaException : Exception { }

    class Dequeue<Item>
    {
        private Item[] arr;
        public int size { get; private set; }
        public int head, tail;

        public Dequeue()
        {
            arr = new Item[5];
            size = 0;
            head = 0;
            tail = 0;
        }

        public Item PeekFirst()
        {
            if (size == 0)
            {
                throw new DequeueVaciaException();
            }

            return arr[head];
        }
        public Item PeekLast()
        {
            if (size == 0)
            {
                throw new DequeueVaciaException();
            }

            return arr[tail];
        }
        public Item RemoveFirst()
        {
            if (size == 0)
            {
                throw new DequeueVaciaException();
            }

            Item ret = arr[head];
            head++;

            if (size == 1)
            {
                head = tail = size = 0;
            }



            if (head == arr.Length)
                head = 0;

            size--;
            return ret;

        }

        public Item RemoveLast()
        {

            if (size == 0)
            {
                throw new DequeueVaciaException();
            }

            Item ret = arr[tail];
            tail--;

            if (size == 1)
            {

                head = tail = size = 0;
            }



            if (tail == -1)
                tail = arr.Length - 1;

            size--;
            return ret;
        }
        public void Append(Item value)
        {
            if (size == arr.Length)
            {
                const int FACTOR_CRECIMIENTO = 2;
                Resize(arr.Length * FACTOR_CRECIMIENTO);
            }

            if (size == 0)
            {
                AddFirst(value);
                return;
            }

            tail++;
            if (tail == arr.Length)
                tail = 0;

            arr[tail] = value;
            size++;

        }
        public void AddFirst(Item value)
        {
            if (size == arr.Length)
            {
                const int FACTOR_CRECIMIENTO = 2;
                Resize(arr.Length * FACTOR_CRECIMIENTO);
            }

            if (size == 0)
            {
                arr[head] = value;
                size++;
                return;
            }

            head--;
            if (head < 0)
                head = arr.Length - 1;

            arr[head] = value;
            size++;
        }
        private void Resize(int newCapacity)
        {
            Item[] newArr = new Item[newCapacity];

            for (int i = head, j = 0; j < size; i++, j++)
            {
                newArr[j] = arr[i % arr.Length];
            }

            arr = newArr;
            head = 0;
            tail = size - 1;


        }
    }
    class Stack<Item>
    {
        private Item[] arr;
        public int size { get; private set; }


        public Stack()
        {
            size = 0;
            arr = new Item[1];
        }



        public void Push(Item value)
        {
            if (size == arr.Length)
            {
                const int FACTOR_CRECIMIENTO = 2;
                Resize(arr.Length * FACTOR_CRECIMIENTO);
            }

            arr[size] = value;
            size++;

        }

        public Item Peek()
        {
            if (size == 0)
            {
                throw new StackVaciaException();
            }

            return arr[size - 1];
        }
        public Item Pop()
        {
            if (size == 0)
            {
                throw new StackVaciaException();
            }



            Item ret = arr[size - 1];
            size--;

            if (size * 4 <= arr.Length)
            {
                const int FACTOR_DECREMENTO = 2;
                Resize(arr.Length / FACTOR_DECREMENTO);
            }

            return ret;
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public void Resize(int newCapacity)
        {
            Item[] newArr = new Item[newCapacity];
            for (int i = 0; i < size; i++)
            {
                newArr[i] = arr[i];
            }

            arr = newArr;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                sb.Append(arr[i] + " ");

            }
            return sb.ToString();
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> s1 = new Stack<int>();
            s1.Push(3);
            s1.Push(4);
            Console.WriteLine("Size = {0} , Stack: {1}", s1.size, s1);
            s1.Push(5);
            s1.Push(6);

            Console.WriteLine("Size = {0} , Stack: {1}", s1.size, s1);
            s1.Pop();
            s1.Pop();
            s1.Pop();
            Console.WriteLine("Size = {0} , Stack: {1}", s1.size, s1);


            Dequeue<int> d1 = new Dequeue<int>();
            d1.AddFirst(1);
            d1.Append(2);
            d1.Append(3);
            d1.AddFirst(-1);

            d1.RemoveFirst();
            d1.RemoveLast();
            d1.RemoveFirst();

            d1.Append(2);
            d1.Append(2);
            d1.Append(2);
            d1.Append(2);
            d1.Append(2);
            d1.Append(2);
            d1.Append(2);
            d1.Append(2);


            Console.Read();

        }
    }
}
