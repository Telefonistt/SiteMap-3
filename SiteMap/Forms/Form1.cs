using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace SiteMap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        OpenFileDialog openDialog = new OpenFileDialog();
        SaveFileDialog saveDialog = new SaveFileDialog();

        CreatorTreeURL treeCreator;
        Strings strClass;

        private void UpdateTree(int updateMethod)
        {
            if(updateMethod==0)
            {
                string[] lines = textBox1.Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                string[] lines2 = Strings.CutStringList(lines, @"://");
                lines2 = Strings.CutStringList(lines2, @"www.");
                //string head = Strings.SplitFirst(lines[0], '.', true);//первая часть URL без адреса страницы

                string main = Strings.SplitFirst(lines2[0], '/', false);//главная страница сайта
                Constants con = new Constants(main);

                int method = comboBox1.SelectedIndex;//как записывать узлы дерева(полный урл и только подкатегория)
                                                     //treeView1.
                string head = comboBox2.Text;
                strClass = new Strings(con);
                treeCreator = new CreatorTreeURL(lines2, head, main, method);
            }
            
            
            
        }
        

        public string Main()
        {
            UpdateTree(0);
            string content = strClass.CreateOPML(treeCreator.TreeURL.ToOPML());
            return content;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            saveDialog.InitialDirectory = Directory.GetCurrentDirectory();
            saveDialog.AddExtension = true;
            saveDialog.DefaultExt = "opml";
            saveDialog.Filter = "opml files (*.opml)|*.opml";
            saveDialog.FileName = "urls";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Файл сохраняется.\nПожалуйста подождите некоторое время и закройте это окно =)");

                try
                {
                    string content = Main();
                    FileWork.WriteToFile(saveDialog.FileName, content);
                    MessageBox.Show("Успешное сохранение!");
                }
                catch
                {
                    MessageBox.Show("Ошибка при создании файла");
                }
                
                
            }
        }
        //menu item Sava_as/txt
        private void txtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveDialog.InitialDirectory = Directory.GetCurrentDirectory();
            saveDialog.AddExtension = true;
            saveDialog.DefaultExt = "txt";
            saveDialog.Filter = "txt files (*.txt)|*.txt";
            saveDialog.FileName = "urls";
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                string content = textBox1.Text;
                FileWork.WriteToFile(saveDialog.FileName, content);
                MessageBox.Show("Успешное сохранение!");
            }
        }
        //menu item Sava_as/opml
        private void opmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex==1)
            {
                comboBox2.Enabled = true;
            }
            else
            {
                comboBox2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateTree(0);
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(treeCreator.TreeURL.ToTreeNode());
        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // Move the dragged node when the left mouse button is used.
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }

            // Copy the dragged node when the right mouse button is used.
            else if (e.Button == MouseButtons.Right)
            {
                DoDragDrop(e.Item, DragDropEffects.Copy);
            }
        }

        // Set the target drop effect to the effect 
        // specified in the ItemDrag event handler.
        private void treeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        // Select the node under the mouse pointer to indicate the 
        // expected drop location.
        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = treeView1.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.
            treeView1.SelectedNode = treeView1.GetNodeAt(targetPoint);
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = treeView1.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            TreeNode targetNode = treeView1.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            // Confirm that the node at the drop location is not 
            // the dragged node or a descendant of the dragged node.
            if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
            {
                // If it is a move operation, remove the node from its current 
                // location and add it to the node at the drop location.
                if (e.Effect == DragDropEffects.Move)
                {
                    draggedNode.Remove();
                    targetNode.Nodes.Add(draggedNode);
                }

                // If it is a copy operation, clone the dragged node 
                // and add it to the node at the drop location.
                else if (e.Effect == DragDropEffects.Copy)
                {
                    targetNode.Nodes.Add((TreeNode)draggedNode.Clone());
                }

                // Expand the node at the location 
                // to show the dropped node.
                targetNode.Expand();
            }
        }
        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            // Check the parent node of the second node.
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            // If the parent node is not null or equal to the first node, 
            // call the ContainsNode method recursively using the parent of 
            // the second node.
            return ContainsNode(node1, node2.Parent);
        }
        //ы
        private void txtToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
            openDialog.Filter = "txt files (*.txt)|*.txt";// "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openDialog.InitialDirectory = Directory.GetCurrentDirectory();
            openDialog.Title = "Открыть файл";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                label4.Text = openDialog.FileName;
                textBox1.Text = File.ReadAllText(openDialog.FileName);
            }

        
        }

        //открыть opml файл
        private void oPMLToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                label4.Text = openFileDialog1.FileName;
                string path= openFileDialog1.FileName;
                //OpmlReader.Load(openFileDialog1.FileName);
                //textBox1.Text = OpmlReader.Source;
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                LoadTreeFromXmlDocument(doc);
            }
        }







        private void LoadTreeFromXmlDocument(XmlDocument dom)
        {
            try
            {
                // SECTION 2. Initialize the TreeView control.
                treeView1.Nodes.Clear();
                TreeNodeCollection currentNodeCollect = treeView1.Nodes;
                // SECTION 3. Populate the TreeView with the DOM nodes.
                foreach (XmlNode node in dom.DocumentElement.ChildNodes)
                {
                    if (node.Name == "head")
                    {
                        foreach(XmlNode nodeHead in node.ChildNodes)
                        {
                            if(nodeHead.Name=="title")
                            {
                                currentNodeCollect.Add(nodeHead.InnerText);
                                currentNodeCollect = currentNodeCollect[0].Nodes;
                                break;
                            }
                        } 
                    }
                    if (node.Name == "body" )
                    {
                        foreach (XmlNode nodeInBody in node.ChildNodes)
                        {
                            if (nodeInBody.Name == "outline")
                            {
                                AddNode(currentNodeCollect, nodeInBody);

                            }
                            else continue;
                        }
                        break;
                    }
                   
                    
                        //&& node.ChildNodes.Count == 0)//&& node.ChildNodes.Count == 1 && string.IsNullOrEmpty(GetAttributeText(node, "text")))
                        
                    
                }

                treeView1.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        static string GetAttributeText(XmlNode inXmlNode, string name)
        {
            XmlAttribute attr = (inXmlNode.Attributes == null ? null : inXmlNode.Attributes[name]);
            return attr == null ? null : attr.Value;
        }

        private void AddNode(TreeNodeCollection nodes, XmlNode inXmlNode)
        {
            if (inXmlNode.HasChildNodes)
            {
                string text = GetAttributeText(inXmlNode, "text");
                if (string.IsNullOrEmpty(text))
                    text = ""; //inXmlNode.Name;
                TreeNode newNode = nodes.Add(text);
                XmlNodeList nodeList = inXmlNode.ChildNodes;
                for (int i = 0; i <= nodeList.Count - 1; i++)
                {
                    if (inXmlNode.ChildNodes[i].Name == "outline")
                    {
                        XmlNode xNode = inXmlNode.ChildNodes[i];
                        AddNode(newNode.Nodes, xNode);

                    }
                    else continue;
                    
                }
            }
            else
            {
                // If the node has an attribute "name", use that.  Otherwise display the entire text of the node.
                string text = GetAttributeText(inXmlNode, "text");
                if (string.IsNullOrEmpty(text))
                    text = (inXmlNode.OuterXml).Trim();
                TreeNode newNode = nodes.Add(text);
            }
        }
    }
}
