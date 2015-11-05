#define TEST2

using System;
using System.Diagnostics;
using System.Text;

namespace dotTraceExample1
{
    public class Program
    {
        static int[] array;
        static string str;
        static void Main(string[] args)
        {
            str = "1";
            array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            NotOptimizedCode1();
            OptimizedCode1();
        }

#if TEST1
        static void NotOptimizedCode1()
        {
            for(long i=0;i<1000000000;i++)
                Sub1(1);
        }

        static void OptimizedCode1()
        {
            object a = new object();
            for (long i = 0; i < 1000000000; i++)
                Sub1(a);
        }

        static void Sub1(object obj)
        {
            //
        }

#endif

#if TEST2
        static void NotOptimizedCode1()
        {
            for (int i = 0; i < array.Length; i++)
                Console.WriteLine(array[i]);
        }

        static void OptimizedCode1()
        {
            int length = array.Length;
            for (int i = 0; i < length; i++)
                Console.WriteLine(array[i]);
        }

#endif

#if TEST3
        static void NotOptimizedCode1()
        {
            for (int i = 0; i < 100000; i++)
                str += "1";
        }

        static void OptimizedCode1()
        {
            StringBuilder sb = new StringBuilder(str);
            for (int i = 0; i < 100000; i++)
                sb.Append("1");
            str = sb.ToString();
        }
#endif
    }
}
