﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slidingWindow
{
    public class Sliding : ISliding
    {
        public IList<int> FindSubstring(string s, string[] words)
        {
            IList<int> res = new List<int>();

            int n = words.Length;
            int lengthOfWord = words[0].Length;
            int windowLength = lengthOfWord * n;

            //create a dictionalry to store the freq of words.
            Dictionary<string, int> wordFreq = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (!wordFreq.ContainsKey(word))
                {
                    wordFreq.Add(word, 1);
                }
                else
                {
                    wordFreq[word] += 1;
                }
            }

            //foo:1 ,bar:2....

            //create thewords with window length.

            for (int i = 0; i < s.Length - windowLength + 1; i++)
            {
                string sub = s.Substring(i, windowLength);
                if (findWordInWordBank(wordFreq, sub, lengthOfWord))
                {
                    res.Add(i);
                }
            }

            return res;
        }

        private bool findWordInWordBank(Dictionary<string, int> wordFreq, string windowSubString, int lengthOfWord)
        {
            
            Dictionary<string, int> seen = new Dictionary<string, int>();
            for (int i = 0; i < windowSubString.Length; i = i + lengthOfWord)
            {
                string word = windowSubString.Substring(i, lengthOfWord);
               
                if (!seen.ContainsKey(word))
                {
                    seen.Add(word, 1);
                }
                else
                {
                    seen[word] += 1;
                }
            }

            foreach (var word in wordFreq)
            {
                int value = 0;
                if (seen.ContainsKey(word.Key))
                {
                     value = seen[word.Key];
                }
                else
                {
                    value = 0;
                }
               
                if (word.Value != value)
                    return false; //Word freq must match between map and seen
            }


            return true;

        }
        public string MinWindow(string s, string t)
        {
            string result = "";
            s = "ADOBECODEBANC";
            t = "ABC";
            if (t.Length > s.Length || t.Length==0 || s.Length==0)
            {
                return result;
            }
            int minLength = int.MaxValue;
            int windlowLength = t.Length;

            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (char c in t)
            {
                if (dic.ContainsKey(c))
                    dic[c]++;
                else
                    dic.Add(c, 1);
            }
            // A:1,B:1,C:1
            int left = 0, right = 0, minlen = s.Length + 1, counter = dic.Count;
            while (right < s.Length)
            {
                char rightChar = s[right];
                if (dic.ContainsKey(rightChar))
                {
                    dic[rightChar]--;
                    if (dic[rightChar] == 0)
                        counter--;
                }

                right++;

                while (counter == 0)
                {

                }
            }
                return result;

        }
    }
}
