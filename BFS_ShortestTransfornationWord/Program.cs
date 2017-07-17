using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_ShortestTransfornationWord
{
    class Program
    {
        static void Main(string[] args)
        {

            //Given two words (start and end), and a dictionary, find the length of shortest transformation sequence from start to end, such that only one letter can be changed at a time and each intermediate word must exist in the dictionary. For example, given:

            //start = "hit"
            //end = "cog"
            //dict = ["hot","dot","dog","lot","log"]
            //One shortest transformation is "hit" -> "hot" -> "dot" -> "dog" -> "cog", the program should return its length 5.
            var HS = new HashSet<string>();
            HS.Add("hot");
            HS.Add("dot");
            HS.Add("dog");
            HS.Add("lot");
            HS.Add("log");
            Program.bfs("hit", "cog", HS);
        }


        public static int bfs(string beginWord, string endWord, HashSet<string> WordDictionary )
        {
            //add endWord to the hashset
            WordDictionary.Add(endWord);

            //Intialize a queue
            Queue<WordNode> queue = new Queue<WordNode>();

            //add a beginWord
            queue.Enqueue(new WordNode(beginWord,1));

            while (queue.Count > 0)
            {
                //pop off
                WordNode top =  queue.Dequeue();

                string word = top.Word;

                //if word == endword: return steps
                if (word.Equals(endWord))
                {
                    return top.NumSteps;
                }

                char[] arr = word.ToCharArray();

                //Linear Search
                for (int i = 0; i < arr.Length; i++) // length of word that comes from Queue
                {
                    for (char j = 'a'; j <= 'z'; j++) //Iterate from a to z
                    {
                        char temp = arr[i]; // save temp to revert back to previous char value

                        arr[i] = j;

                        string newWord = new string(arr); // assemble string with new char value

                        if (WordDictionary.Contains(newWord)) // if dictionary contain the word
                        {
                            queue.Enqueue(new WordNode(newWord,top.NumSteps +1)); //add word to queue and increment step
                            WordDictionary.Remove(newWord); // remove from dictionary
                        }
                        arr[i] = temp; //revert it
                    }
                }

            }
            return 0;
        }
    }

    class WordNode
    {
        public string Word { get; private set; }
        public int NumSteps { get; private set; }

        public WordNode(string word, int numSteps)
        {
            this.Word = word;
            this.NumSteps = numSteps;
        }
    }
}
