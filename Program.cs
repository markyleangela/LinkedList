using System;

namespace ConsoleApp1
{
    class Node
    {
        int data;
        Node next=null;

        public Node(int data, Node next)
        {
            this.data = data;
            this.next = next;
        }

        public Node getNext()
        {
            return next;
        }
        public void setNext(Node n)
        {
            this.next = n;
        }

        public int getData()
        {
            return data;
        }
        public void setData(int n)
        {
            this.data = n;
        }

    }

    class LinkedList
    {
        Node head = null;
        Node tail = null;
        int size = 0;

        Node create_node(int data)
        {
            Node new_node = new Node(data, null);
            return new_node;

        }

        public void addNode(int data)
        {
            Node newest = create_node(data);
            if (head == null)
            {
                head = newest;
                tail = newest;

            }else if(tail != null)
            {
                tail.setNext(newest);
                tail = newest;
            }
            size++;
        }

        public void addHead(int data)
        {
            Node newest = create_node(data);
            if (head != null)
            {
                newest.setNext(head);
                if (head == tail)
                {
                    tail = head;
                }
                head = newest;
                
            }
            else
            {
                head = newest;
                tail = newest;
                
            }
            size++;
        }

        public void addAt(int data,int pos)
        {
            
             if(pos == 1)
            {
                addHead(data);
                return;
            }else if(pos == size)
            {
                addNode(data);
                return;
            }

            Node currentnode = head;
            Node newest = create_node(data);
            int currentpos = 0;

            while (currentnode != null)
            {

                currentpos++;
                if (currentpos == pos - 1)
                {
                    
                    newest.setNext(currentnode.getNext());
                    currentnode.setNext(newest);
                    size++;
                    return;
                }
                else
                {
                    currentnode = currentnode.getNext();
                }

                
            }
            
            

        }

        public void removeAt(int pos1)
        {
            Node currentnode = head;
            int count = 0;
            if(pos1 == 1)
            {
                head = head.getNext();
                size--;
                return;
            }

            while(currentnode != null)
            {
                count++;
                if(count != pos1 - 1)
                {
                    currentnode = currentnode.getNext();
                }
                else
                {
                    if(pos1 == size)
                    {
                        tail = currentnode;

                    }
                    currentnode.setNext(currentnode.getNext().getNext());
                    size--;
                }
            }
        }

        public void moveAt(int pos1, int pos2)
        {
            if(pos1 == pos2)
            {
                Console.WriteLine("ALREADY IN PLACE!");
            }

            Node currentnode = head;
            int count = 0, data = 0;
            while(currentnode != null)
            {
                count++;
                if(count == pos1)
                {
                    data = currentnode.getData();
                    break;
                }
                currentnode = currentnode.getNext();
            }
            if(pos2 > pos1)
            {
                addAt(data, pos2);
                removeAt(pos1);
            }
            else
            {
                addAt(data, pos2);
                removeAt(pos1 +1);
            }
            
        }

      

        public int getSize()
        {
            return size;
        }

        public void PrintLinkedList()
        {
            Node currentnode = head;
            if (currentnode == null)
            {
                Console.Write("EMPTY LINKEDLIST");
                return;
            }

            while (true)
            {
                Console.Write(currentnode.getData() + " >>");
                if (currentnode == tail)
                {
                    return;
                }
                currentnode = currentnode.getNext();
            }
        }

        public int getHead()
        {
            return head.getData();
        }

        public int getTail()
        {
            return tail.getData();
        }
    }

    class Program
    {

        static void Main(string[] args)
        {

            LinkedList L1 = new LinkedList();
            L1.addNode(1);
            L1.addNode(2);
            L1.addNode(3);
            L1.addNode(4);
            L1.addNode(5);
            L1.moveAt(5, 1);
            Console.WriteLine("size: " + L1.getSize());
            Console.WriteLine("Head: " + L1.getHead());
            Console.WriteLine("Tail: " + L1.getTail());
            L1.PrintLinkedList();
            Console.ReadLine();

        }
    }
}
