using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    class Algos
    {
        public void oneTo255(){
            for (int i = 0; i < 256; i ++){
                System.Console.WriteLine(i);
            }
        }

        public void oddsTo255(){
            for (int i = 1; i < 256; i += 2){
                System.Console.WriteLine(i);
            }
        }

        public void sumTo255(){
            int total = 0;
            for (int i = 0; i < 256; i++){
                total += i;
                System.Console.WriteLine("Number is: {0} Total is: {1}", i, total);
            }
        }

        public void printArr(int[] arr){
            foreach (int item in arr){
                System.Console.WriteLine(item);
            }
        }

        public int maxArr(int[] arr){
            int max = arr[0];
            foreach (int item in arr){
                if(item > max){
                    max = item;
                }
            }
            return max;
        }

        public double avgArr(int[] arr){
            int total = 0;
            int count = 0;
            foreach (int item in arr){
                total += item;
                count++;
            }
            
            return (double)total/(double)count;
        }

        public int[] oddArr(){
            int[] oddArr = new int[256/2];
            for (int i = 1; i < 256; i +=2){
                oddArr[(i-1)/2] = i;
            }
            return oddArr;
        }
    }
}