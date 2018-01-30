using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiteMap
{
    class Tree<T>
    {
        /// <summary>
        /// Возвращает значение узла дерева
        /// </summary>
        public T Value {get; private set; }
        /// <summary>
        /// Возвращает Dictionary массив веток узла
        /// </summary>
        public Dictionary<T, Tree<T>> Nodes { get; private set; } = new Dictionary<T, Tree<T>>();

        /// <summary>
        /// Добавляет ветку в узел
        /// </summary>
        /// <param name="value">
        /// Значение узла в новой ветке
        /// </param>
        public void AddNode(T value)
        {
            if (value.ToString() == "") return;

            Nodes.Add(value, new Tree<T>(value));
            
        }

        /// <summary>
        /// Возвращает данный екземпляр в формате OPML
        /// </summary>
        /// <returns></returns>
        private string ToOPML()
        {
            
                StringBuilder output = new StringBuilder();

                output.Append(Constants.outlineHead1);
                output.Append(Value);
                output.Append(Constants.outlineHead2);

                output.Append(ToOPMLWithoutMain());
                

                output.Append(Constants.outlineFooter);
                return output.ToString();
        }
        /// <summary>
        /// Возвращает текущее дерево в формате string, без значения даннго узла
        /// </summary>
        /// <param name="b">
        /// True или False
        /// </param>
        /// <returns></returns>
        public string ToOPMLWithoutMain()
        {
            StringBuilder output = new StringBuilder();
            foreach (var element in Nodes)
            {
                output.Append(element.Value.ToOPML());
            }
            return output.ToString();
        }
        
        public TreeNode ToTreeNode()
        {
            TreeNode treeNode = new TreeNode();
            treeNode.Text=Value.ToString();
            foreach(var node in Nodes)
            {
                treeNode.Nodes.Add(node.Value.ToTreeNode());
            }
            return treeNode;
        }

        /// <summary>
        /// Конструктор узла.
        /// </summary>
        /// <param name="value">
        /// Значение узла.
        /// </param>
        public Tree(T value)
        {
            Value = value;
        }

        public bool ContainsInFirstNodes(T value)
        {
            try
            {
                Tree<T> k = Nodes[value];
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
