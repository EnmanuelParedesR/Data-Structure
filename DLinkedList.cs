using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata21_Video
{
    public class DLinkedList
    {
        public class DLinkNode
        {
            public String Value;
            public DLinkNode next, prev;

            public DLinkNode(String Value)
            {
                this.Value = Value;

            }
        }

        public DLinkNode Head, Tail;
        public int Size { get; private set; }

        public void Add(String Value)
        {
            DLinkNode NewNode = new DLinkNode(Value);

            if(Size == 0)
            {
                Head = Tail = NewNode;
                Size++;
                return;
            }

            Tail.next = NewNode;
            NewNode.prev = Tail;
            Tail = NewNode;
            Size++;

            return;
        }

        public DLinkNode FindNode(String Value)
        {
            DLinkNode cur =  Head;

            for (int i = 0; i < Size; i++)
            {
                if (cur.Value == Value)
                    return cur;
                else
                    cur = cur.next;
            }


            return null;

        }
    }
}
