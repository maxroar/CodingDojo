using System;
using System.Collections.Generic;
// 
// using Algos;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Algos algos = new Algos();
            int[] arr = {-2, 2,3,4,5};
            
            // saving this in comments for reference when receiving a tuple return value
            /////////////////////////////////
            // var mma = algos.minMaxAvg(arr);
            // System.Console.WriteLine(mma);
            
            object[] toStr = algos.numToString(arr);
            foreach (object item in toStr){
                System.Console.WriteLine(item);
            }

            
        }
    }
}
