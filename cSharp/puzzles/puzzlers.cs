using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Puzzles
    {

        public int[] randomArr(){
            Random rand = new Random();
            int[] randArr = new int[10];
            for (int i = 0; i < 10; i++){
                randArr[i] = rand.Next(5,25);
            }
            return randArr;
        }
        public Tuple<int, int, int> minMaxSum(int[] arr){
            int max = arr[0];
            int min = arr[0];
            int total = 0;

            foreach (int item in arr){
                if(item > max){
                    max = item;
                }
                if (item < min){
                    min = item;
                }
                total += item;
            }
            return Tuple.Create(min, max, total);
        }

        public int tossCoin(){
            Random rand = new Random();
            int randToss = rand.Next(0,2);
            System.Console.WriteLine("Tossing Coin...");
            if (randToss == 1){
                return 0;
            }else{
                return 1;
            }
        }

        public double tossCoins(int tossNum){
            Random rand = new Random();
            int head = 0;
            int tails = 0;
            for (int i = 0; i < tossNum; i++){
                int result = tossCoin();
                if(result == 0){
                    head++;
                }else{
                    tails++;
                }
            }
            double ratio = (double)head/(double)tossNum;
            return ratio;
        }

        public string[] nameShuffle(string[] nameArr){
            Random rand = new Random();
            for (int i = 0; i < nameArr.Length; i++){
                string temp = nameArr[i];
                int randIdx = rand.Next(0,nameArr.Length);
                nameArr[i] = nameArr[randIdx];
                nameArr[randIdx] = temp;
            }
            foreach (string name in nameArr){
                System.Console.WriteLine(name);
            }
            List<string> newNames = new List<string>();
            for (int i = 0; i < nameArr.Length; i++){
                if (nameArr[i].Length > 5){
                    newNames.Add(nameArr[i]);
                }
            }

            return newNames.ToArray();
        }
    }
}
