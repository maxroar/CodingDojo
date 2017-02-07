using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<object> unboxList = new List<object>();
            // List[] unbox = new List[];
            unboxList.Add(7);
            unboxList.Add(28);
            unboxList.Add(-1);
            unboxList.Add(true);
            unboxList.Add("stringy");
            
            int total = 0;

            foreach (object item in unboxList){
                if (item is int){
                    total = total + (int)item;
                    System.Console.WriteLine("This is an int");
                }
                else if (item is bool){
                    System.Console.WriteLine("This is a boolean");
                }
                else if (item is string){
                    System.Console.WriteLine("This is a string");
                }
                else{
                    System.Console.WriteLine("WHAT IS THIS?!?!?");
                }
                
            }
            System.Console.WriteLine(total);
        }
    }
}
