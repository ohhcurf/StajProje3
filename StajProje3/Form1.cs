using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace StajProje3
{
    public partial class Form1 : Form
    {
        private CustomQueue<TreeNode> customBFSQueue = new CustomQueue<TreeNode>();
        private CustomStack<TreeNode> customDFSStack = new CustomStack<TreeNode>();
        private TreeNode currentNode = null;
        private TreeNode lastVisitedNodeBFS = null;
        private TreeNode lastVisitedNodeDFS = null;
        private TreeNode currentTraversalNode;
        private TreeNode rootNode;
        private int bfsCurrentStep = 0;
        private int dfsCurrentStep = 0;
        private int totalNodes;
        private bool bfsCompleted = false;
        private bool dfsCompleted = false;
        private Dictionary<TreeNode, Point> nodePositions;

        public Form1()
        {
            InitializeComponent();
            nodePositions = new Dictionary<TreeNode, Point>();
            // Double Buffering'i etkinleþtir
            this.SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

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

        private void FileUploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Metin Dosyalarý|*.txt";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog1.FileName;
                    string fileContent = File.ReadAllText(filePath);
                    rootNode = LoadTreeFromText(fileContent);
                    currentTraversalNode = rootNode;
                    totalNodes = rootNode.GetNodeCount(true);

                    // Aðacý çiz
                    pictureBox1.Invalidate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dosya yükleme sýrasýnda bir hata oluþtu.\n\nHata Detayý: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DrawTree(TreeNode node, Graphics g, int x, int y, int xOffset, int yOffset)
        {
            if (node == null)
                return;

            int nodeSize = 30;

            g.FillEllipse(Brushes.LightBlue, x - nodeSize / 2, y - nodeSize / 2, nodeSize, nodeSize);
            g.DrawString(node.Text, new Font("Arial", 12), Brushes.Black, x - nodeSize / 4, y - nodeSize / 4);

            int childX = x - xOffset * (node.Nodes.Count - 1) / 2;
            int childY = y + yOffset;

            foreach (TreeNode childNode in node.Nodes)
            {
                g.DrawLine(Pens.Black, x, y + nodeSize / 2, childX, childY - nodeSize / 2);
                DrawTree(childNode, g, childX, childY, xOffset, yOffset);
                childX += xOffset;
            }
        }


        private void BFSBTN_Click(object sender, EventArgs e)
        {
            if (currentTraversalNode == null)
            {
                MessageBox.Show("Lütfen önce bir metin dosyasý yükleyin.");
                return;
            }

            DFSBTN.Visible = false;
            BFSBTN.Text = "Ýleri";

            if (bfsCompleted || dfsCompleted)
            {
                listBox.Items.Clear();
                dfsCompleted = false;
                bfsCompleted = false;
                dfsCurrentStep = 0;
                bfsCurrentStep = 0;
            }

            if (bfsCurrentStep == 0)
            {
                customBFSQueue.Enqueue(currentTraversalNode);
            }

            BFSStep();
            bfsCurrentStep++;
        }
        private void BFSStep()
        {
            if (customBFSQueue.Count > 0)
            {
                TreeNode node = customBFSQueue.Dequeue();

                // Eðer daha önce bir düðüm ziyaret edildiyse, rengini eski haline döndür
                if (lastVisitedNodeBFS != null)
                {
                    lastVisitedNodeBFS.BackColor = SystemColors.Control; // Eski rengi ayarlayýn
                }

                // Düðümün rengini deðiþtir (örneðin sarý yapabilirsiniz)
                node.BackColor = Color.Yellow;

                OutputNodeData(node.Text);

                foreach (TreeNode child in node.Nodes)
                {
                    customBFSQueue.Enqueue(child);
                }

                lastVisitedNodeBFS = node; // Son ziyaret edilen düðümü güncelle

                if (customBFSQueue.Count == 0)
                {
                    MessageBox.Show("BFS iþlemi tamamlandý.");
                    DFSBTN.Visible = true;
                    BFSBTN.Text = "BFS";
                    bfsCompleted = true;
                }
            }
            else
            {
                bfsCompleted = true;
            }
            pictureBox1.Invalidate();
        }




        private void DFSBTN_Click(object sender, EventArgs e)
        {
            if (currentTraversalNode == null)
            {
                MessageBox.Show("Lütfen önce bir metin dosyasý yükleyin.");
                return;
            }

            BFSBTN.Visible = false;
            DFSBTN.Text = "Ýleri";

            if (bfsCompleted || dfsCompleted)
            {
                listBox.Items.Clear();
                dfsCompleted = false;
                bfsCompleted = false;
                dfsCurrentStep = 0;
                bfsCurrentStep = 0;
            }

            if (dfsCurrentStep == 0)
            {
                customDFSStack.Push(currentTraversalNode);
            }

            DFSStep();
            dfsCurrentStep++;
        }

        // DFS iþlemini gerçekleþtirirken DFSStep metodunu güncelleyin
        private void DFSStep()
        {
            if (customDFSStack.Count > 0)
            {
                TreeNode node = customDFSStack.Pop();

                // Eðer daha önce bir düðüm ziyaret edildiyse, rengini eski haline döndür
                if (lastVisitedNodeDFS != null)
                {
                    lastVisitedNodeDFS.BackColor = SystemColors.Control; // Eski rengi ayarlayýn
                }

                // Düðümün rengini deðiþtir (örneðin turuncu yapabilirsiniz)
                node.BackColor = Color.Orange;

                OutputNodeData(node.Text);

                foreach (TreeNode child in node.Nodes)
                {
                    customDFSStack.Push(child); // Stack'e çocuk düðümleri ekleyin
                }

                lastVisitedNodeDFS = node; // Son ziyaret edilen DFS düðümünü güncelle

                if (customDFSStack.Count == 0)
                {
                    MessageBox.Show("DFS iþlemi tamamlandý.");
                    BFSBTN.Visible = true;
                    DFSBTN.Text = "DFS";
                    dfsCompleted = true;
                }
            }
            else
            {
                dfsCompleted = true;
            }
            pictureBox1.Invalidate();
        }



        private void OutputNodeData(string data)
        {
            listBox.Items.Add(data);
        }



        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (rootNode != null)
            {
                Color nodeColor = Color.LightBlue;
                Color textColor = Color.Black;
                int nodeRadius = 30;

                DrawTree(rootNode, e.Graphics, pictureBox1.Width / 2, 50, 100, 100);

                foreach (var node in nodePositions.Keys)
                {
                    Point nodePosition = nodePositions[node];
                    int x = nodePosition.X;
                    int y = nodePosition.Y;

                    Rectangle rect = new Rectangle(x - nodeRadius, y - nodeRadius, 2 * nodeRadius, 2 * nodeRadius);
                    e.Graphics.FillEllipse(new SolidBrush(nodeColor), rect);
                    e.Graphics.DrawEllipse(Pens.Black, rect);

                    string labelText = node.Text;
                    SizeF labelSize = e.Graphics.MeasureString(labelText, Font);
                    float labelX = x - labelSize.Width / 2;
                    float labelY = y - labelSize.Height / 2;
                    e.Graphics.DrawString(labelText, Font, new SolidBrush(textColor), labelX, labelY);
                }
            }
        }
    }
}