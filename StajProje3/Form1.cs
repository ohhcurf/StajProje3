using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace StajProje3
{
    public partial class Form1 : Form
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

        public Form1()
        {
            InitializeComponent();
        }




        private TreeNode LoadTreeFromText(string text)
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




        private void LoadTreeView(TreeNode root)
        {
            treeView.Nodes.Clear();
            treeView.Nodes.Add(root);
        }




        private void FileUploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Metin Dosyalar�|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    string fileContent = File.ReadAllText(filePath);
                    rootNode = LoadTreeFromText(fileContent);
                    LoadTreeView(rootNode);
                    currentTraversalNode = rootNode;
                    totalNodes = rootNode.GetNodeCount(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dosya y�kleme s�ras�nda bir hata olu�tu.\n\nHata Detay�: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




        private void BFS(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                HighlightNode(node);
                OutputNodeData(node.Text);
                Application.DoEvents();
                Thread.Sleep(500);

                foreach (TreeNode child in node.Nodes)
                {
                    queue.Enqueue(child);
                }
            }
        }




        private void DFS(TreeNode root)
        {
            if (root == null)
            {
                MessageBox.Show("L�tfen �nce bir metin dosyas� y�kleyin.");
                return;
            }

            dfsStack = new Stack<TreeNode>();
            dfsStack.Push(root);
            DFSStep();
        }




        private void BFSBTN_Click(object sender, EventArgs e)
        {
            if (currentTraversalNode == null)
            {
                MessageBox.Show("L�tfen �nce bir metin dosyas� y�kleyin.");
                return;
            }

            if (bfsCompleted)
            {
                listBox.Items.Clear();
                bfsCompleted = false;
            }

            if (bfsCurrentStep == 0)
            {
                bfsQueue = new Queue<TreeNode>();
                bfsQueue.Enqueue(currentTraversalNode);
            }

            BFSStep();
            bfsCurrentStep++;
        }



        private void BFSStep()
        {
            if (bfsQueue.Count > 0)
            {
                TreeNode node = bfsQueue.Dequeue();
                HighlightNode(node);
                OutputNodeData(node.Text);

                foreach (TreeNode child in node.Nodes)
                {
                    bfsQueue.Enqueue(child);
                }

                if (bfsQueue.Count == 0)
                {
                    MessageBox.Show("BFS i�lemi tamamland�.");
                    bfsCompleted = true;
                }
            }
            else
            {
                bfsCompleted = true;
            }
        }



        private void DFSBTN_Click(object sender, EventArgs e)
        {
            if (currentTraversalNode == null)
            {
                MessageBox.Show("L�tfen �nce bir metin dosyas� y�kleyin.");
                return;
            }

            if (dfsCompleted)
            {
                listBox.Items.Clear();
                dfsCompleted = false;
            }

            if (dfsCurrentStep == 0)
            {
                dfsStack = new Stack<TreeNode>();
                dfsStack.Push(currentTraversalNode);
            }

            DFSStep();
            dfsCurrentStep++;
        }




        private void DFSStep()
        {
            if (dfsStack.Count > 0)
            {
                TreeNode node = dfsStack.Pop();
                HighlightNode(node);
                OutputNodeData(node.Text);

                foreach (TreeNode child in node.Nodes)
                {
                    dfsStack.Push(child);
                }

                if (dfsStack.Count == 0)
                {
                    MessageBox.Show("DFS i�lemi tamamland�.");
                    dfsCompleted = true;
                }
            }
            else
            {
                dfsCompleted = true;
            }
        }




        private void HighlightNode(TreeNode node)
        {
            treeView.SelectedNode = node;
            treeView.Focus();
        }




        private void OutputNodeData(string data)
        {
            listBox.Items.Add(data);
        }
    }
}
