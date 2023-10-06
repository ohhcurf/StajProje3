using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace StajProje3
{
    public class VeriYönetimi
    {
        private TreeNode currentTraversalNode;
        private TreeNode rootNode;
        private Queue<TreeNode> bfsQueue;
        private Stack<TreeNode> dfsStack;
        private int bfsCurrentStep = 0;
        private int dfsCurrentStep = 0;
        private int totalNodes;
        private bool bfsCompleted = false;
        private bool dfsCompleted = false;
        private VeriYönetimi veriYonetimi = new VeriYönetimi();
        public TreeNode LoadTreeFromText(string text)
        {
            TreeNode root = null;
            Dictionary<string, TreeNode> nodeDictionary = new Dictionary<string, TreeNode>();

            string[] lines = text.Split('\n');

            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                string parentData = parts[0].Trim();
                string[] childrenData = parts[1].Split(',').Select(s => s.Trim()).ToArray();

                if (!nodeDictionary.TryGetValue(parentData, out TreeNode parentNode))
                {
                    parentNode = new TreeNode(parentData);
                    nodeDictionary[parentData] = parentNode;

                    if (root == null)
                    {
                        root = parentNode;
                    }
                }

                foreach (string childData in childrenData)
                {
                    if (!nodeDictionary.TryGetValue(childData, out TreeNode childNode))
                    {
                        childNode = new TreeNode(childData);
                        nodeDictionary[childData] = childNode;
                    }

                    parentNode.Nodes.Add(childNode);
                }
            }

            return root;
        }

        public void LoadTreeView(TreeNode root)
        {
            treeView.Nodes.Clear();
            treeView.Nodes.Add(root);
        }
    }
}
