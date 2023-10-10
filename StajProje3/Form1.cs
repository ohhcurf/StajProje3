namespace StajProje3
{
    public partial class Form1 : Form
    {
        private CustomQueue<TreeNode> customBFSQueue = new CustomQueue<TreeNode>();
        private CustomStack<TreeNode> customDFSStack = new CustomStack<TreeNode>();
        private TreeNode currentTraversalNode;
        private TreeNode rootNode;
        private int bfsCurrentStep = 0;
        private int dfsCurrentStep = 0;
        private bool bfsCompleted = false;
        private bool dfsCompleted = false;
        private TreeNode selectedNode;

        public Form1()
        {
            InitializeComponent();
        }

        //
        // File Upload & Create Tree
        //
        // Create Tree
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
        // File Upload
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

                    // Aðacý çiz
                    nodePictureBox.Invalidate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Dosya yükleme sýrasýnda bir hata oluþtu.\n\nHata Detayý: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




        //
        // Buttons & BFS/DFS
        //
        // BFS Button
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
                visitedNodeList.Items.Clear();
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
        // BFS Function
        private void BFSStep()
        {
            if (customBFSQueue.Count > 0)
            {
                processLabel.Visible = false;
                TreeNode node = customBFSQueue.Dequeue();

                OutputNodeData(node.Text);
                node.Name = "Selected";
                selectedNode = node;

                foreach (TreeNode child in node.Nodes)
                {
                    customBFSQueue.Enqueue(child);
                }

                if (customBFSQueue.Count == 0)
                {
                    processLabel.Visible = true;
                    processLabel.Text = "BFS iþlemi tamamlandý.";

                    DFSBTN.Visible = true;
                    BFSBTN.Text = "BFS";
                    bfsCompleted = true;
                }
            }
            else
            {
                bfsCompleted = true;
            }
            nodePictureBox.Invalidate();
        }

        // DFS Button
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
                visitedNodeList.Items.Clear();
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
        // DFS Function
        private void DFSStep()
        {
            if (customDFSStack.Count > 0)
            {
                processLabel.Visible = false;
                TreeNode node = customDFSStack.Pop();

                OutputNodeData(node.Text);
                node.Name = "Selected";
                selectedNode = node;

                foreach (TreeNode child in node.Nodes)
                {
                    customDFSStack.Push(child); // Stack'e çocuk düðümleri ekleyin
                }

                if (customDFSStack.Count == 0)
                {
                    processLabel.Visible = true;
                    processLabel.Text = "DFS iþlemi tamamlandý.";

                    BFSBTN.Visible = true;
                    DFSBTN.Text = "DFS";
                    dfsCompleted = true;
                }

                nodePictureBox.Invalidate();
            }
            else
            {
                dfsCompleted = true;
            }

        }
        // Show the visited node in the visitedNodesList
        private void OutputNodeData(string data)
        {
            visitedNodeList.Items.Add(data);
        }




        //
        // Drawing Nodes
        //
        private void nodePictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (rootNode != null)
            {
                using (Graphics g = nodePictureBox.CreateGraphics())
                {
                    g.Clear(Color.White);
                }

                DrawTree(rootNode, e.Graphics, nodePictureBox.Width / 2, 50, 100, 100);
            }
        }

        private void DrawTree(TreeNode node, Graphics g, int x, int y, int xOffset, int yOffset)
        {
            if (node == null)
                return;

            int nodeSize = 30;

            if (node.Name == "Selected") g.FillEllipse(Brushes.Red, x - nodeSize / 2, y - nodeSize / 2, nodeSize, nodeSize);
            if (node.Name != "Selected") g.FillEllipse(Brushes.LightBlue, x - nodeSize / 2, y - nodeSize / 2, nodeSize, nodeSize);


            if (selectedNode != null && selectedNode == node) selectedNode.Name = "Unselected";


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
    }
}