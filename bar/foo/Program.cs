using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace foo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hello world");
            Console.WriteLine();
            Console.Write("Square(8) = {0}", Square(8));
        }

        [MethodImpl(MethodImplOptions.ForwardRef)]
        public static extern int Square(int number);
    }
}
