using System;
using System.Diagnostics;

namespace Lesson2
{
    public class LinkedList<T>
    {
        private int _countElements;
        private Node<T> Head { get; set; }

        private Node<T> Tail { get; set; }


        public LinkedList()
        {
            Head = null;
            Tail = null;
            _countElements = 0;
        }

        public LinkedList(T value)
        {
            var item = new Node<T>(value);
            Head = item;
            Tail = item;
            _countElements = 1;
        }

        public int GetCount()
        {
            return _countElements;
        }

        public void Add(T value)
        {
            if (Head == null)
            {
                var item = new Node<T>(value);
                Head = item;
                Tail = item;
                _countElements = 1;
            }
            else
            {
                var item = new Node<T>(value);
                Tail.NextNode = item;
                item.PrevNode = Tail;
                Tail = item;
                _countElements++;
            }
        }

        public void RemoveNodeByValue(T value)
        {
            var current = Head;

            if (Head.Value.Equals(value))
            {
                RemoveFirstElement();
                _countElements--;
            }
            else
            {
                while (current != null)
                {
                    if (current.Value.Equals(value))
                    {
                        if (current == Tail)
                        {
                            RemoveLastElement();
                            _countElements--;
                        }
                        else
                        {

                            current.PrevNode.NextNode = current.NextNode;
                            current.NextNode.PrevNode = current.PrevNode;
                            _countElements--;
                            return;
                        }
                    }
                    else
                    {
                        current = current.NextNode;
                    }
                }
            }
        }

        public void RemoveNodeByIndex(int index)
        {
            if (index == 0)
            {
                RemoveFirstElement();
            }
            else if (index == _countElements - 1)
            {
                RemoveLastElement();
            }
            else if (index < 0 || index >= _countElements)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                if (index >= _countElements / 2)
                {
                    int counter = _countElements - 1;
                    var current = Tail;

                    while (current != null)
                    {
                        if (counter == index)
                        {
                            current.PrevNode.NextNode = current.NextNode;
                            current.NextNode.PrevNode = current.PrevNode;
                            _countElements--;
                            return;
                        }

                        current = current.PrevNode;
                        counter--;

                    }
                }
                else
                {
                    int counter = 0;
                    var current = Head;

                    while (current != null)
                    {
                        if (counter == index)
                        {
                            current.PrevNode.NextNode = current.NextNode;
                            current.NextNode.PrevNode = current.PrevNode;
                            _countElements--;
                            return;
                        }

                        current = current.NextNode;
                        counter++;
                    }
                }
            }
        }

        public void RemoveLastElement()
        {
            if (_countElements == 1)
            {
                Tail = null;
                Head = null;
                _countElements--;
            }
            else if (_countElements > 1)
            {
                Tail = Tail.PrevNode;
                Tail.NextNode = null;
                _countElements--;
            }
        }

        public void RemoveFirstElement()
        {
            if (_countElements == 1)
            {
                Tail = null;
                Head = null;
                _countElements--;
            }
            else if (_countElements > 1)
            {
                Head = Head.NextNode;
                Head.PrevNode = null;
                _countElements--;
            }
        }

        public void OutputAllItems()
        {
            var current = Head;

            while (current != null)
            {
                Console.Write(current.Value + " ");
                current = current.NextNode;
            }

            Console.WriteLine();
        }

        public Node<T> FindNode(int searchValue)
        {
            var current = Head;

            while (current != null)
            {
                if (current.Value.Equals(searchValue))
                {
                    return current;
                }

                current = current.NextNode;
            }

            return null;
        }

    }
}
