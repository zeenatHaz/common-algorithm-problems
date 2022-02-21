using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace depth_first_search
{
    public interface IDFS
    {
        public bool HasPathSum(TreeNode node,int sum); //lC112
        public IList<IList<int>> PathSum(TreeNode root, int targetSum); //LC113
        public int NoOfIslands(int[][] arr);
        public IList<string> BinaryTreePaths(TreeNode node); //LC 257
        public int SumNumbers(TreeNode node); // LC 129
        public int StringValid(TreeNode node); //Lc1430
        public int PathSumIII(TreeNode node);
        public int DiameterOfABTree(TreeNode node); //LC543
        public int MaxPathSum(TreeNode node); //LC129

    }
}
