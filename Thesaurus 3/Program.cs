using System;
using System.Collections.Generic;
using System.Linq;


namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {

            //string ThesaurusWords = "Hello my name is Jon";
            Console.WriteLine("Input a sentence to thesaurusize!\n");
            string ThesaurusWords = Console.ReadLine();

            List<string> ThesaurusWordlist = ThesaurusWords.Split(new char[] { ' ' }).ToList();

            

            string wordgetterresponse;
            List<string> wordgetterlist;
            string wordRandomizerword;

            var wordlist = new List<string>();

            foreach (string word in ThesaurusWordlist)
            {
                WordGetter w = new WordGetter(word, out wordgetterresponse,out wordgetterlist);
                WordRandomizer w2 = new WordRandomizer(wordgetterresponse, wordgetterlist, out wordRandomizerword);
                wordlist.Add(wordRandomizerword);
            }

            //Console.WriteLine(wordgetterresponse);

            foreach(string word in wordlist)
            {
                Console.Write(word + " ");
            }

            

            Console.ReadKey();
        }

    }
}
