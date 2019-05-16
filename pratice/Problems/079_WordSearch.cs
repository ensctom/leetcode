using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace practice.Problems
{
    /*
     https://leetcode.com/problems/word-search/
     board =
    [
      ['A','B','C','E'],
      ['S','F','C','S'],
      ['A','D','E','E']
    ]

    Given word = "ABCCED", return true.
    Given word = "SEE", return true.
    Given word = "ABCB", return false.
         */
    public static class WordSearch
    {
        class Point
        {
            public int x;
            public int y;
            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
        class NodeState
        {
            public bool hasCheckedLeft;
            public bool hasCheckedRight;
            public bool hasCheckedTop;
            public bool hasCheckedBot;

            public NodeState()
            {
            }

            public NodeState(NodeState ns)
            {
                hasCheckedLeft = ns.hasCheckedLeft;
                hasCheckedRight = ns.hasCheckedRight;
                hasCheckedTop = ns.hasCheckedTop;
                hasCheckedBot = ns.hasCheckedBot;
            }
        }

        class Node
        {
            public Point p;
            public NodeState state;

            public Node(Point p, NodeState state)
            {
                this.p = p;
                this.state = state;
            }
        }

        public static bool DoesWordExistIterative(char[][] board, string word)
        {
            //worse case O(m *n * 4^s) where 'm' and 'n' are the dimension of board and 's' is the length of word
            int m = board.Length;
            int n = board[0].Length;
            bool[,] visited = new bool[m, n];
            Stack<Node> ns = new Stack<Node>();
            //search through entire board and do a dfs on each element
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int k = 0;
                    if (board[i][j] == word[k])
                    {
                        ns.Push(new Node(new Point(i, j), new NodeState()));
                        visited[i, j] = true;
                        while (ns.Count != 0)
                        {
                            Node curNode = ns.Peek();
                            int row = curNode.p.x;
                            int col = curNode.p.y;

                            bool exhausted = false;
                            while (!exhausted)
                            {
                                if (ns.Count == word.Length)
                                    return true;                               

                                //check down
                                if (row < board.Length - 1 && board[row + 1][col] == word[k + 1] && !curNode.state.hasCheckedBot && !visited[row + 1,col])
                                {
                                    Node z = ns.Pop();
                                    z.state.hasCheckedBot = true;
                                    ns.Push(new Node(new Point(row++, col), new NodeState(z.state)));
                                    z.state.hasCheckedBot = false;

                                    NodeState newState = new NodeState
                                    {
                                        hasCheckedTop = true
                                    };
                                    visited[row, col] = true;
                                    ns.Push(new Node(new Point(row, col), new NodeState(newState)));
                                    curNode = ns.Peek();
                                    k++;
                                    continue;
                                }
                                //check up
                                else if (row > 0 && board[row - 1][col] == word[k + 1] && !curNode.state.hasCheckedTop && !visited[row-1, col])
                                {
                                    Node z = ns.Pop();
                                    z.state.hasCheckedTop = true;
                                    ns.Push(new Node(new Point(row--, col), new NodeState(z.state)));
                                    z.state.hasCheckedTop = false;

                                    NodeState newState = new NodeState
                                    {
                                        hasCheckedBot = true
                                    };
                                    visited[row, col] = true;
                                    ns.Push(new Node(new Point(row, col), new NodeState(newState)));
                                    curNode = ns.Peek();
                                    k++;
                                    continue;
                                }
                                //check right
                                else if (col < board[0].Length - 1 && board[row][col + 1] == word[k + 1] && !curNode.state.hasCheckedRight && !visited[row,col + 1])
                                {
                                    //update the state of the last item on the stack
                                    // then repush it 
                                    Node z = ns.Pop();
                                    z.state.hasCheckedRight = true;
                                    ns.Push(new Node(new Point(row, col++), new NodeState(z.state)));
                                    z.state.hasCheckedRight = false;

                                    //add the current point and mark the previous left node as visited in nodestate
                                    NodeState newState = new NodeState
                                    {
                                        hasCheckedLeft = true
                                    };
                                    visited[row, col] = true;
                                    ns.Push(new Node(new Point(row, col), new NodeState(newState)));
                                    curNode = ns.Peek();
                                    k++;
                                    continue;
                                }//check left
                                else if (col > 0 && board[row][col - 1] == word[k + 1] && !curNode.state.hasCheckedLeft && !visited[row, col - 1])
                                {
                                    Node z = ns.Pop();
                                    z.state.hasCheckedLeft = true;
                                    ns.Push(new Node(new Point(row, col--), new NodeState(z.state)));
                                    z.state.hasCheckedLeft = false;

                                    visited[row, col] = true;
                                    ns.Push(new Node(new Point(row, col), new NodeState
                                    {
                                        hasCheckedRight = true
                                    }));
                                    curNode = ns.Peek();
                                    k++;
                                    continue;
                                }
                                //did not find any matching character, need to perform backtrack 
                                Node x = ns.Pop();
                                visited[x.p.x, x.p.y] = false;
                                exhausted = true;
                                k--; 
                                                               
                            }                          
                        }                                               
                    }
                }
            }
            return false;
        }
        public static bool DoesWordExist(char[][] board, string word)
        {
            //worse case O(m *n * 4^s) where 'm' and 'n' are the dimension of board and 's' is the length of word
            int m = board.Length;
            int n = board[0].Length;
            bool[,] visited = new bool[m, n];
            //search through entire board and do a dfs on each element
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (dfs(board, i, j, word, 0, visited))
                        return true;
                }
            }
            return false;
        }


        static bool dfs(char[][] board, int row, int col, string word, int k, bool[,] visited)
        {
           //complexity if this is O(4^s)
           //check boundary & if element was visited and if board[][] = word[k]
            if (row < 0 || row >= board.Length ||
               col < 0 || col >= board[0].Length ||
               visited[row, col] ||
               word[k] != board[row][col])
                return false;

            //if index is the same length as the iterator, it means we found the sequence
            if (word.Length - 1 == k)
                return true;

            visited[row, col] = true;
            //do a dfs on each neighbour
            if (dfs(board, row - 1, col, word, k + 1, visited) ||
                dfs(board, row + 1, col, word, k + 1, visited) ||
                dfs(board, row, col - 1, word, k + 1, visited) ||
                dfs(board, row, col + 1, word, k + 1, visited))
                return true;

            visited[row, col] = false; // unmark visited nodes
            return false;
        }
    }
}
