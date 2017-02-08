using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Puzzles puzz = new Puzzles();
            var mmm = puzz.minMaxSum(puzz.randomArr());
            int min = mmm.Item1;
            int max = mmm.Item2;
            int sum = mmm.Item3;
            System.Console.WriteLine("Min Max Sum!");
            System.Console.WriteLine("Min: {0}", min);
            System.Console.WriteLine("Max: {0}", max);
            System.Console.WriteLine("Sum: {0}", sum);
            System.Console.WriteLine("-------------------------------");

            int ctoss = puzz.tossCoin();
            if (ctoss==0){
                System.Console.WriteLine("Heads");
            }else{
                System.Console.WriteLine("Tails");
            }

            double tossRatio = puzz.tossCoins(500);
            System.Console.WriteLine("After tossing 500 coins, the ratio of heads is {0}", tossRatio);

            string[] names = {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            string[] newNames = puzz.nameShuffle(names);
            System.Console.WriteLine("-----------------------");
            foreach (string name in newNames){
                System.Console.WriteLine(name);
            }

        }
    }
}
