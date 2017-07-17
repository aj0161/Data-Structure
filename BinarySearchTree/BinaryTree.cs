using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    class BinaryTree
    {
        Node root;

        public void InsertIteratively(int id)
        {
            Node newNode = new Node(id);

            if (root == null)
            {
                root = newNode;
            }
            else
            {
                Node current = root;
                Node tempParent;

                while (true)
                {
                    tempParent = current;
                    if (id < current.item)
                    {
                        current = current.leftChild;
                        if (current == null)
                        {
                            tempParent.leftChild = newNode;  //store in left!!
                            Console.WriteLine("LeftChild : " + newNode.item);
                            return;
                        }
                    }
                    else
                    {
                        current = current.rightChild;
                        if (current == null)
                        {
                            tempParent.rightChild = newNode;  //store in right!!
                            Console.WriteLine("RightChild : " + newNode.item);
                            return;
                        }

                    }
                }

            }
        }

        public void InsertRecrusively(int id)
        {
            root = insertRecrusively(root, id);
        }

        private Node insertRecrusively(Node Rootnode, int id)
        {
            if (Rootnode == null)
            {
                return new Node(id);
            }
            else
            {
                if (id < Rootnode.item)
                {
                    Rootnode.leftChild = insertRecrusively(Rootnode.leftChild, id);
                }
                else
                {
                    Rootnode.rightChild = insertRecrusively(Rootnode.rightChild, id);
                }
            }
            return Rootnode;
        }

        public void Delete(int id)
        {
            bool isDeleted = false;
            if (root == null)
            {
                return;
            }
            else
            {
                Node current = root;
                Node tempParent;
                while (!isDeleted)
                {
                    tempParent = current;

                    //id is matched!
                    if (id == current.item)
                    {
                        //case1: the node has no child
                        if (current.leftChild == null && current.rightChild == null)
                        {
                            //make the parent node set to null
                            tempParent.item = 0;
                            tempParent = root;
                            return;
                        }

                        //case 2: the node has two children
                        else if ((current.leftChild != null) && (current.rightChild != null))
                        {
                            int minValueFrmRightSubTree = FindMininRightSubTree(current); //find min in right subtree OR you can find max in Left subtree
                            current.item = minValueFrmRightSubTree; // copy the min value in the targetted node.

                            //delete the duplicate Node
                            Node temp;
                            while (current != null)
                            {
                                temp = current;
                                current = current.rightChild;
                                //found the duplicate item
                                if (current.item == minValueFrmRightSubTree)
                                {
                                    //delete it
                                    temp.rightChild = current;
                                    isDeleted = true;
                                    break;
                                }
                            }
                        }

                        //case 3: the node has either left or right child
                        else if (current.leftChild != null)
                        {
                            //make the left child of itself attach to parent left child
                            tempParent.leftChild = current.leftChild;
                            tempParent = root;
                            return;
                        }
                        else if (current.rightChild != null)
                        {
                            //make the right child of itself attach to parent left child
                            tempParent.rightChild = current.rightChild;
                            tempParent = root;
                            return;
                        }


                    }
                    //logic to move to next child: can be left or right !!
                    current = id >= current.item ? current.rightChild : current.leftChild;
                }
            }
        }

        public void DeleteUsingRecrusion(int id)
        {

        }

        // find min in right subtree
        private int FindMininRightSubTree(Node node)
        {
            if (node.rightChild != null)
            {
                return node.rightChild.item;
            }

            return -1;
        }

        //take it off from here
        public static void MaxSubArraySum()
        {
            int[] Array = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

            int firstIndex = 0, secondIndex;
            int answer = int.MinValue;
            int sum = 0, output = 0;

            for (int i = 1; i < Array.Length; i++)
            {
                if (answer <= Array[i - 1])
                {
                    firstIndex = Array[i - 1];
                }
                else
                {
                    firstIndex = answer;
                }

                secondIndex = Array[i];
                sum = firstIndex + secondIndex;

                if (sum > answer)
                {
                    answer = sum;
                    if (sum > output)
                    {
                        output = sum;
                    }
                }
                else
                {
                    answer = Array[i];
                }
            }
        }

        //this algorithm works ifthere's atleast one positive element in an array
        public static void KandaneAlgorithm()
        {
            int[] A = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            int answer = 0; //keep track of maximum value
            int sum = 0;

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] + sum > 0)
                    sum += A[i];
                else
                    sum = 0;

                answer = Math.Max(answer, sum);
            }
        }

        public static void MaxSubArray()
        {
            int[] A = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            int sum = int.MinValue;
            int last = 0;

            foreach (int num in A)
            {
                last += num;
                sum = Math.Max(sum, last);
                if (last < 0)
                {
                    last = 0;
                }
            }
            Console.WriteLine("sum: " + sum);
        }

        //Find out the maximum sub-array of non negative numbers from an array.
        public static void MaxSubArrayNonNegative()
        {
            int[] A = new int[] { 1, 2, 5, -7, 2, 3 }; //The answer is [1, 2, 5] as its sum is larger than [2, 3]
            int answer = 0; //keep track of maximum value
            int sum = 0;

            List<int> newList = new List<int>();
            List<int> maxList = new List<int>();

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > 0)
                {
                    sum += A[i];
                    newList.Add(A[i]);
                }  
                else
                {
                    sum = 0;
                     newList = new List<int>();
                }

                answer = Math.Max(answer, sum);
            }

            if (answer < sum || answer == sum && newList.Count > maxList.Count)
            {

            }
        }
    }

     class Node
    {
        public int item;
        public Node leftChild;
        public Node rightChild;

        public Node(int item)
        {
            this.item = item;
            leftChild = null;
            rightChild = null;
        }
    }


}
