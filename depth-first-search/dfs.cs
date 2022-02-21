using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace depth_first_search
{
    public class DFS : IDFS
    {
        public IList<string> BinaryTreePaths(TreeNode node)
        {
            List<string> paths = new List<string>();
            if (node == null)
            {
                return paths;
            }
            string str = "";
            findPaths(node, str, paths);
            return paths;
        }

        private void findPaths(TreeNode node, string str, List<string> paths)
        {
            
            if (node == null)
            {
                return;
            }
            str += node.val;
            if(node.left==null && node.right == null)
            {
                paths.Add(str);
                return;
            }
            else
            {
                if(node.left!=null)findPaths(node.left, str+"->", paths);
                if (node.right != null) findPaths(node.right, str + "->", paths);
            }
        }
        int res = 0;
        public int DiameterOfABTree(TreeNode root)
        {
            getDiameter(root);
            return res;

        }
        private int getDiameter(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }
            // Find height of left and right subTrees
            int l = getDiameter(node.left);
            int r = getDiameter(node.right);
            // New global max is either already reached,
            // or is acheived using this node as the root
            res = Math.Max(res, l + r);
            // Return height of tree rooted at this node
            return 1 + Math.Max(l, r);
            
        }
        public int MaxPathSum(TreeNode node)
        {
            throw new NotImplementedException();
        }

        public int NoOfIslands(int[][] arr)
        {
            throw new NotImplementedException();
        }

        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
            {
                return false;
            }
            else if (root.left == null && root.right == null && sum - root.val == 0)
            {
                return true;
            }
            else
            {
                return HasPathSum(root.left, sum - root.val) || HasPathSum(root.right, sum - root.val);
            }
        }

        public IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            List<IList<int>> res = new List<IList<int>>();
            if (root == null)
            {
                return res;
            }
            helper(root, targetSum, new List<int>(), res);
            return res;
        }

        private void helper(TreeNode root, int target, List<int> list, List<IList<int>> res)
        {
            if (root == null)
            {
                return;
            }
            list.Add(root.val);
            if (root.left == null && root.right == null && root.val - target == 0)
            {
                res.Add(list);
                return;
            }
            helper(root.left, target - root.val, list, res);
            helper(root.right, target - root.val, list, res);

            //backtracking becuase you need to remove the root before backtracking.
            list.Remove(list.Count - 1);
        }

        public int PathSumIII(TreeNode node)
        {
            throw new NotImplementedException();
        }

       

        public int StringValid(TreeNode node)
        {
            throw new NotImplementedException();
        }

        public int SumNumbers(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            List<string> paths = new List<string>();
            int sum = 0;
            calculatePathValues(root, "", paths);
            foreach (var ele in paths)
            {
                sum = sum + Convert.ToInt32(ele);
            }

            return sum;
        }

        private void calculatePathValues(TreeNode root,string path,List<string> paths)
        {
            if (root == null)
            {
                return;
            }
            path = path + root.val;
            if(root.left==null && root.right == null)
            {
                //means we have reached a leaf node.
                paths.Add(path);
                return;
            }
            if (root.left != null)
            {
                calculatePathValues(root.left, path, paths);
            }
            if (root.right != null)
            {
                calculatePathValues(root.right, path, paths);
            }


        }
    }
}
