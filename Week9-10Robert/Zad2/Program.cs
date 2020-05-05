using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad2
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<double> parent = null;
            BinaryTree<double> P = new BinaryTree<double> (5, parent);
            P.Add(15);
            P.Add(21);
            P.Print();
            P.Remove(15);
            P.Print();
            Console.WriteLine(P.Search(21));
            Console.ReadKey();
        }
    }
}
