﻿using System.Collections.Generic;
using System;
using binary_search;

namespace binarySearch
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = { 8, 10, 20, 80, 100, 200, 400, 500, 3, 2, 1 };
            int[] arrC = { 1, 2, 8, 10, 10, 12, 19 };
            Binary obj = new Binary();
            Console.WriteLine("max is :"+ obj.Bitonic(arr));
            obj.Bitonic_Binary_Search(arr);
            Console.WriteLine("max is :" + obj.Bitonic_Binary_Search(arr));
            int[] arr1 = { 1, 2, 3, 2, 1, 0 };
            Console.WriteLine("element found at index:" + obj.findElement(arr1, 0) );
            int ceil = 3;
            int index = obj.ceilingOfANumber(arrC, ceil);

            if (index == -1)
                Console.WriteLine("Ceiling of " + 8 + " doesn't exist in array");
                  else
            Console.WriteLine("ceiling of the number is: " + arrC[index]);

            //next greatest letter

            char[] letters = { 'c', 'f', 'j' };
            char key = 'a';
            Console.WriteLine("next greatest charater is :" + obj.nextLetter(letters, key));

            int[] firstAndSecond = { 5, 7, 7, 8, 8, 10 };
            obj.numberRange(firstAndSecond, 8);
            Console.ReadLine();
        }
    }
}