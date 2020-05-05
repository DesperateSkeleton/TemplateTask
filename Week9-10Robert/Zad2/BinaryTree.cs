using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad2
{
    class BinaryTree<T> where T : IComparable<T>
    {
        private BinaryTree<T> parent, left, right;
        private T val;
        private List<T> listForPrint = new List<T>();

        public BinaryTree(T val, BinaryTree<T> parent)
        {
            this.val = val;
            this.parent = parent;
        }

        public void Add(T val)
        {
            if (val.CompareTo(this.val) < 0)
            {
                if (this.left == null)
                {
                    this.left = new BinaryTree<T>(val, this);
                }
                else
                {
                    this.left.Add(val);
                }
            }
            else
            {
                if (this.right == null)
                {
                    this.right = new BinaryTree<T>(val, this);
                }
                else
                {
                    this.right.Add(val);
                }
            }
        }

        private BinaryTree<T> Search(BinaryTree<T> tree, T val)
        {
            if (tree == null) return null;
            switch (val.CompareTo(tree.val))
            {
                case 1: return Search(tree.right, val);
                case -1: return Search(tree.left, val);
                case 0: return tree;
                default: return null;
            }
        }

        public BinaryTree<T> Search(T val)
        {
            return Search(this, val);
        }

        public bool Remove(T val)
        {
            BinaryTree<T> tree = Search(val);
            if (tree == null)
            {
                return false;
            }

            BinaryTree<T> CurrentTree;

            if (tree == this)
            {
                if (tree.right != null)
                {
                    CurrentTree = tree.right;
                }
                else CurrentTree = tree.left;

                while (CurrentTree.left != null)
                {
                    CurrentTree = CurrentTree.left;
                }
                T temp = CurrentTree.val;
                this.Remove(temp);
                tree.val = temp;

                return true;
            }

            if (tree.left == null && tree.right == null && tree.parent != null)
            {
                if (tree == tree.parent.left)
                    tree.parent.left = null;
                else
                {
                    tree.parent.right = null;
                }
                return true;
            }

            if (tree.left != null && tree.right == null)
            {
                tree.left.parent = tree.parent;
                if (tree == tree.parent.left)
                {
                    tree.parent.left = tree.left;
                }
                else if (tree == tree.parent.right)
                {
                    tree.parent.right = tree.left;
                }
                return !false;
            }

            if (tree.left == null && tree.right != null)
            {
                tree.right.parent = tree.parent;
                if (tree == tree.parent.left)
                {
                    tree.parent.left = tree.right;
                }
                else if (tree == tree.parent.right)
                {
                    tree.parent.right = tree.right;
                }
                return true;
            }

            if (tree.right != null && tree.left != null)
            {
                CurrentTree = tree.right;

                while (CurrentTree.left != null)
                {
                    CurrentTree = CurrentTree.left;
                }

                if (CurrentTree.parent == tree)
                {
                    CurrentTree.left = tree.left;
                    tree.left.parent = CurrentTree;
                    CurrentTree.parent = tree.parent;
                    if (tree == tree.parent.left)
                    {
                        tree.parent.left = CurrentTree;
                    }
                    else if (tree == tree.parent.right)
                    {
                        tree.parent.right = CurrentTree;
                    }
                    return true;
                }

                else
                {
                    if (CurrentTree.right != null)
                    {
                        CurrentTree.right.parent = CurrentTree.parent;
                    }
                    CurrentTree.parent.left = CurrentTree.right;
                    CurrentTree.right = tree.right;
                    CurrentTree.left = tree.left;
                    tree.left.parent = CurrentTree;
                    tree.right.parent = CurrentTree;
                    CurrentTree.parent = tree.parent;
                    if (tree == tree.parent.left)
                    {
                        tree.parent.left = CurrentTree;
                    }
                    else
                    {
                        tree.parent.right = CurrentTree;
                    }

                    return true;
                }
            }
            return false;
        }
        private void Print(BinaryTree<T> node)
        {
            if (node == null) return;
            Print(node.left);
            listForPrint.Add(node.val);
            Console.Write(node + " ");
            if (node.right != null)
                Print(node.right);
        }
        public void Print()
        {
            listForPrint.Clear();
            Print(this);
            Console.WriteLine();
        }

        public override string ToString()
        {
            return val.ToString(); 
        }
    }
}
