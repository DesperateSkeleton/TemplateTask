using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week9_10Robert
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack1<double> P = new Stack1<double> (5);
            P.Push(3);
            P.Push(777);
            P.Push(double.MaxValue);
            P.Pop();
            while (P.thisstack.Count() > 0)
            {
                Console.WriteLine(P.thisstack.First().ToString());
                P.Pop();
            }

            Stack1<double> S = new Stack1<double>(6);


            Console.ReadKey();
        }
    }
}
