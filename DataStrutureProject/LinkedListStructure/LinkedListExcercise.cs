using DataStructureProject;
using DataStructureProject.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProject.LinkedListStructure
{
    public class LinkedNode<T>
    {
        public LinkedNode<T> next;
        public T data;
    }

    public class LinkedList<T>
    {
        private LinkedNode<T> head;
        private int Size = 0;

        public int Count
        {
            get { return Size; }
        }

        public void AddFirst(T data)
        {
            Size++;
            var node = new LinkedNode<T>();
            node.data = data;
            node.next = head;
            head = node;
        }

        public void AddLast(T data)
        {
            Size++;
            if (head == null)
            {
                head = new LinkedNode<T>();
                head.data = data;
                head.next = null;
            }
            else
            {
                var node = new LinkedNode<T>();
                node.data = data;

                var current = head;
                while(current.next != null)
                {
                    current = current.next;
                }

                current.next = node;
            }
        }

        public void AddList(T[] data)
        {
            foreach (var item in data)
                AddLast(item);
        }

        public T FindByPosition(int position, bool fromTheEnd = false)
        {
            if (fromTheEnd)
                position = Size - position;

            var index = 0;
            var current = head;
            while(current.next != null)
            {
                if (index == position-1)
                    return current.data;

                current = current.next;
                index++;
            }
            return default(T);
        }

        public void Process(T[] data)
        {
            AddList(data);
            PrintAll();
            Console.WriteLine($"List count: {Count}");
            Console.Write("Position to look: ");
            var position = Console.ReadLine();
            var positionResult = FindByPosition(int.Parse(position));
            Console.WriteLine($"Item found: {positionResult}");
        }

        public void PrintAll()
        {
            var current = head;
            while(current.next != null)
            {
                Console.WriteLine(current.data.ToString());
                current = current.next;
            }
        }
    }
}