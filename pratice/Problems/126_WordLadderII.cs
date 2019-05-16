using System.Collections.Generic;


namespace practice.Problems
{
    public static class WordLadder
    {

        /*
         *  https://leetcode.com/problems/word-ladder-ii
            Construct a graph using BFS, each word node contains all possible combination of previous nodes in the grpah that has the shortest path
            Solution requires quite a lot of extra space because at each node we are storing the entire list of previous shortest nodes up the the current node
        */
        public static IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            Dictionary<string, List<IList<string>>> graph = new Dictionary<string, List<IList<string>>>();
            Queue<string> wordQ = new Queue<string>();
            HashSet<string> words = new HashSet<string>(wordList);
            int shortestPath = 1;
            bool foundEnd = false;
            wordQ.Enqueue(beginWord);
            graph.Add(beginWord, new List<IList<string>> { new List<string>(new string[] { beginWord }) });
            
            while(wordQ.Count != 0)
            {
                for(int i = wordQ.Count; i > 0; i--)
                {
                    string currentWord = wordQ.Dequeue();
                    for(int j = 0; j < currentWord.Length; j++)
                    {
                        for (char ch = 'a'; ch <= 'z'; ch++)
                        {
                            char[] word = currentWord.ToCharArray();
                            word[j] = ch;
                            string newWord = new string(word);
                            if (words.Contains(newWord))
                            {
                                var currentWordsList = graph[currentWord]; // get current solution at current word node
                                graph.TryGetValue(newWord, out var stringList);
                                if (stringList == null)
                                {
                                    //we want to add the new word to the current word node's wordlist
                                    if (newWord.Equals(endWord))
                                        foundEnd = true; 
                                        // we do not return once the endword is found because there could be other paths that also leads to the endword                                
                                    var solutionList = new List<IList<string>>();
                                    foreach (var list in currentWordsList)
                                    {    
                                        var newList = new List<string>(list)
                                        {
                                            newWord
                                        };
                                        solutionList.Add(newList);
                                        
                                    }
                                    graph.Add(newWord, solutionList);
                                    wordQ.Enqueue(newWord);
                                }
                                else if (stringList[0].Count - 1 == shortestPath)
                                {
                                    //we have already seen this word before
                                    //if statement evaluates to true it means that there is another solution with same shortest path length to the new word node

                                    foreach (List<string> list in currentWordsList)
                                    {
                                        var newList = new List<string>(list)
                                        {
                                            newWord
                                        };
                                        stringList.Add(newList);
                                    }
                                    
                                }

                            }

                        }
                    }

                }
                shortestPath++;
            }

            if (foundEnd)
            {
                return graph[endWord];
            }
                
            return null;
        }


    }
}
