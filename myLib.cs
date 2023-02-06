using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;


namespace NumbersInCSharp
{
    public class myLib
    {

        public myLib()
        {

        }

        public static Stack<Object> myStack;

        public static void digits(int num)
        {
            List<int> digits = new List<int>();
            while (num > 0)
            {
                digits.Insert(0, (num % 10));
                num = (num - (num % 10)) / 10;

            }

            foreach(int item in digits)
            {
                Console.Write(item.ToString() + " ");
            }
        }

        public static void setMyStack()
        {
            myStack = new Stack<Object>();

            int a = 1;
            int b = 2;
            int c = 3;

            string p = "+";
            string m = "-";

            myStack.Push(a);
            myStack.Push(m);
            myStack.Push(b);
            myStack.Push(p);
            myStack.Push(c);

            //1 - 2 + 3

            while (myStack.Count > 0)
            {
                var val = myStack.Peek();
                Console.WriteLine(val.ToString());
                myStack.Pop();
            }


        }


        public static Object returnObj(string s)
        {
            Object val;
            switch (s)
            {
                case "one":
                    val = 1;
                    break;
                case "two":
                    val = 2;
                    break;
                case "hi":
                    val = s;
                    break;
                case "plus":
                    val = "+";
                    break;
                default:
                    val = null;
                    break;
            }
            if (val != null)
                Console.WriteLine(val.ToString());
            return val;
        }

        public static void stringToNum(string s)
        {
            int result;
            if (Int32.TryParse(s, out result))
                Console.WriteLine("Is Number: " + result.ToString());
            else
                Console.WriteLine(s + " Is not a number");

        }

        public static void WorkWithIntegers()
        {
            int a = 18;
            int b = 6;
            int c = a + b;
            Console.WriteLine(c);


            // subtraction
            c = a - b;
            Console.WriteLine(c);

            // multiplication
            c = a * b;
            Console.WriteLine(c);

            // division
            c = a / b;
            Console.WriteLine(c);
        }
        
        public static void FizzBuzz()
        {
            for (int i = 1; i < 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                    continue;
                }                 
                if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                    continue;
                }
                if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                    continue;
                }              
                else
                    Console.WriteLine(i.ToString());
            }

        }

        static HashSet<string> perms;

        /// <summary>
        /// CCI #1.2
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        public static void checkPermutation(string s1, string s2)
        {
            perms = new HashSet<string>();
            permutation(s1);
            if (perms.Contains(s2))
                Console.WriteLine("true");
            else
                Console.WriteLine("false");
        }

        public static void permutation(string str)
        {
            permutation(str, "");
        }

        public static void permutation(string str, string prefix)
        {
            if (str.Length == 0)
            {
                Console.WriteLine(prefix);
                perms.Add(prefix);               
            }

            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    string rem = str.Substring(0, i) + str.Substring(i + 1);
                    permutation(rem, prefix + str[i]);
                }
            }
        }

        /// <summary>
        /// CCI # 1.4
        /// </summary>
        /// <param name="str"></param>
        public static void isPermutationPalindrome(string str)
        {
            if (permutation2(str))
                Console.WriteLine("true");
            else
                Console.WriteLine("false");
        }

        public static bool permutation2(string str)
        {
            return permutation2(str, "");
        }

        public static bool permutation2(string str, string prefix)
        {
            if (str.Length == 0)
            {
                Console.WriteLine(prefix);
                if (isPalindrome(prefix))
                    return true;
            }

            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    string rem = str.Substring(0, i) + str.Substring(i + 1);
                    permutation2(rem, prefix + str[i]);
                }
            }
            return false;
        }

        public static bool isPalindrome(string str)
        {
            int front = 0;
            int back = str.Length - 1;

            while (front < back)
            {
                if (str[front] != str[back])
                    return false;
                front++;
                back--;
            }

            return true;
        }

        //"mr_john__"
        /// <summary>
        /// CCI # 1.3
        /// </summary>
        /// <param name="input"></param>
        /// <param name="length"></param>
        public static void urlify(char[] input, int length)
        {
            int spaceCount = 0;

            // Count the number of spaces in the input string
            for (int i = 0; i < length; i++)
            {
                if (input[i] == ' ')
                {
                    spaceCount++;
                }
            }

            // Shift the characters to the right
            int newLength = length + spaceCount * 2;
            for (int i = length - 1; i >= 0; i--)
            {
                if (input[i] == ' ')
                {
                    input[newLength - 1] = '0';
                    input[newLength - 2] = '2';
                    input[newLength - 3] = '%';
                    newLength = newLength - 3;
                }
                else
                {
                    input[newLength - 1] = input[i];
                    newLength = newLength - 1;
                }
            }
        }

        public static bool stringRotation(string s1, string s2)
        {
            return true;
        }

        public static bool isSubstring(string s1, string s2)
        {
            return true;
        }
    }
    

    

    //tree class
    public class treeNode
    {
        public treeNode(Object t = null)
        {
            if (t != null)
                value = t;
        }

        Object value;

        public List<treeNode> child;

        public bool isRoot;

    }

    //using System.Linq;

    public static class Solution
    {
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            IList<IList<string>> output = new List<IList<string>>();

            //1. make a dictionary where key is the occurence of each letter and the value is a IList of words
            //   of each character together
            //2. go through the dictionary and add each list to the result

            Dictionary<int[], IList<string>> d = new Dictionary<int[], IList<string>>();
            for (int i = 0; i < strs.Length; i++)
            {
                int[] key = getKey(strs[i]);
                IList<string> list;
                if (!d.ContainsKey(key))
                {
                    list = new List<string>();
                    Console.WriteLine("new list, word: " + strs[i]);
                }
                else
                {
                    list = d[key];
                    Console.WriteLine("found list word: " + strs[i]);
                }
                    

                list.Add(strs[i]);
                d[key] = list;
                //d.Add(key, strs[i]);
            }

            foreach (KeyValuePair<int[], IList<string>> kvp in d)
            {
                output.Add(kvp.Value);
            }

            return output;
        }

        private static int[] getKey(string s)
        {
            int[] count = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int i = 0; i < s.Length; i++)
            {
                int idx = (int)s[i] - 'a';
                int c = count[(int)s[i] - 'a'];
                count[(int)s[i] - 'a'] += 1;
                Console.WriteLine("idx: " + idx.ToString() + " count: " + count[(int)s[i] - 'a'].ToString());
            }

            string key = "";
            for (int j = 0; j < 26; j++)
            {
                key += count[j].ToString();
            }
            Console.WriteLine("string: " + s + " key: " + key);
            Console.WriteLine();
            return count;


        }
    }



}
