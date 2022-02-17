using System.Collections.Generic;
using System;
using binary_search;

namespace binarySearch
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = { 8, 10, 20, 80, 100, 200, 400, 500, 3, 2, 1 };
            Binary obj = new Binary();
            Console.WriteLine("max is :"+ obj.Bitonic(arr));
            obj.Bitonic_Binary_Search(arr);
            Console.WriteLine("max is :" + obj.Bitonic_Binary_Search(arr));
            int[] arr1 = { 1, 2, 3, 2, 1, 0 };
            Console.WriteLine("element found at index:" + obj.findElement(arr1, 0) );
            Console.ReadLine();
        }
    }
}
