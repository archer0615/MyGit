using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSortBinarySearch
{
    public class SearchTree<T> where T : IComparable<T>
    {
        private T NodeData { get; set; }
        private SearchTree<T> LeftTree { get; set; }
        private SearchTree<T> RightTree { get; set; }

        public SearchTree(T nodeValue)
        {
            this.NodeData = nodeValue;
            this.LeftTree = null;
            this.RightTree = null;
        }
        public void InsertNode(T newItem)
        {
            T currentNodeValue = this.NodeData;

            if (currentNodeValue.CompareTo(newItem) > 0)
            {
                if (this.LeftTree == null)
                    this.LeftTree = new SearchTree<T>(newItem);
                else
                    this.LeftTree.InsertNode(newItem);
            }
            else
            {
                if (this.RightTree == null)
                    this.RightTree = new SearchTree<T>(newItem);
                else
                    this.RightTree.InsertNode(newItem);
            }
        }
        public void ViewTree()
        {
            if (this.LeftTree != null)
            {
                this.LeftTree.ViewTree();
            }
            Console.WriteLine(this.NodeData.ToString());
            if (this.RightTree != null)
            {
                this.RightTree.ViewTree();
            }
        }
    }
}
