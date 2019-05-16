using impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace practice.Problems
{
    public static class BinaryTreeSerialization
    {
        public static string Serialize(TreeNode root)
        {
            //use bfs to do level order traversal
            if (root == null)
                return null;
            //serialize using level order traversal
            Queue<TreeNode> q = new Queue<TreeNode>();
            StringBuilder sb = new StringBuilder();

            q.Enqueue(root);

            while (q.Count != 0)
            {
                TreeNode curNode = q.Dequeue();

                if (curNode != null)
                {
                    sb.Append(curNode.val.ToString());
                    q.Enqueue(curNode.left);
                    q.Enqueue(curNode.right);
                }
                else
                {
                    sb.Append("null");
                }
                sb.Append(",");

            }

            return sb.ToString();

        }

        public static TreeNode Deserialize(string data)
        {
            if (string.IsNullOrEmpty(data))
                return null;
            string[] values = data.Split(",");           
            TreeNode root = new TreeNode(int.Parse(values[0]));

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            int k = 0;
            while(q.Count != 0)
            {
                TreeNode curNode = q.Dequeue();

                if((k*2+1) < values.Length && values[k*2 +1] != "null")
                {
                    curNode.left = new TreeNode(int.Parse(values[k * 2 + 1]));
                    q.Enqueue(curNode.left);
                }
                if ((k * 2 + 2) < values.Length && values[k * 2 + 2] != "null")
                {
                    curNode.right = new TreeNode(int.Parse(values[k * 2 + 2]));
                    q.Enqueue(curNode.right);
                }
                k++;

            }

            return root;
        }
    }
}
