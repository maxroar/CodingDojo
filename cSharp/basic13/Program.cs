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
            
            int[] pos = algos.posOnly(arr);

            foreach (int item in pos){
                System.Console.WriteLine(item);
            }
            
            
        }
    }
}
