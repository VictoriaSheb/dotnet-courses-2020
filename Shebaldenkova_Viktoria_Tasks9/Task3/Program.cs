using System;
using System.Text.RegularExpressions;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"\b([a-z])(\w+?)\b", RegexOptions.IgnoreCase);
            string text = @"AAa aaa ere Ere, you uuu uuuu uuu .//,.uuu";
            int count = 0;
            MatchCollection matches = regex.Matches(text.ToLower());
            string[] words = new string[matches.Count];
            foreach (var match in matches)
            {
                words[count++]=match.ToString();
            } 
            for (int i = 0; i < words.Length; i++) 
            {
                count = 1;
                if (words[i] != null)
                {
                    for (int j = i+1; j < words.Length; j++)
                    {
                        if (words[i] == words[j])
                        {
                            count++;
                            words[j] = null;
                        }
                    }
                    Console.WriteLine("'{0}' повторяется {1} раз", words[i], count);
                }
            }
            Console.ReadLine();
        }
    }
}
