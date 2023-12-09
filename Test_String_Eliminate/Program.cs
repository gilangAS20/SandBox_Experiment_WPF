using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_String_Eliminate
{
    class Program
    {
        static void Main(string[] args)
        {
            string operation = "+1*2+3/";

            string resultEliminate = operation.Substring(0, operation.Length-1);
            string resultEliminate1 = operation.Remove(0);
            Console.WriteLine("Result: " + resultEliminate);
            Console.WriteLine("Result: " + resultEliminate1);
            Console.ReadKey();
        }
    }
}
