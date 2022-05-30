using System;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("   Tree diagram");
            Console.WriteLine("         2");
            Console.WriteLine("       /   \\");
            Console.WriteLine("      3     4");
            Console.WriteLine("     / \\");
            Console.WriteLine("    5   6");
            Console.WriteLine();


            Node node2 = new Node(2);
            Node node3 = new Node(3);
            Node node4 = new Node(4);
            Node node5 = new Node(5);
            Node node6 = new Node(6);

            node2.left = node3;
            node2.right = node4;
            node3.left = node5;
            node3.right = node6;

            Console.WriteLine("Sum of all values of this tree is " + sumValues(node2));
            Console.WriteLine("Is the tree emtpy? " + Empty(node2));
            Console.WriteLine("Size of the tree is " + Size(node2));
            Console.WriteLine("Sum of the leaves from top is " + SumOfLeaves(node2)); //Should be 15
            Console.WriteLine("Sum of the leaves from Node3 is : " + SumOfLeaves(node3)); //Should be 11
            Console.ReadLine();



        }

        public static int sumValues(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            return root.data + sumValues(root.left) + sumValues(root.right);
        }

        public static bool Empty(Node root)
        {
            if(root.left == null && root.right == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static int Size(Node root)
        {
            int size = 0;

            if(root != null)
            {
                size++;

                if(root.right != null)
                {
                    size = size + Size(root.right);
                }

                if(root.left != null)
                {
                    size = size + Size(root.left);
                }

                return size;
            }
            else
            {
                return size;
            }
        }

        public static int SumOfLeaves(Node root)
        {
            int total = 0;


            if(root.left != null || root.right != null)
            {
                total = total + SumOfLeaves(root.right);
                total = total + SumOfLeaves(root.left);
            }
            else
            {
                return root.data;
            }

            return total;
        }


    }



    public class Node
    {
        public int data;
        public Node left;
        public Node right;

        public Node(int data)
        {
            this.data = data;
        }
    }

}
