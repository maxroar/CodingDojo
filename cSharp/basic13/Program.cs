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
            int[] arr = {2,3,4,5};
            int[] oddArr = algos.oddArr();

            for (int i = 0; i < oddArr.Length; i++){
                System.Console.WriteLine(oddArr[i]);
            }
            
        }
    }
}
