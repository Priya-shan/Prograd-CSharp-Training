using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
/*
 Question:
English to Pig Latin Translator



Pig latin has two very simple rules:

If a word starts with a consonant move the first letter(s) of the word, 
till you reach a vowel, to the end of the word and add "ay" to the end.
have ➞ avehay
cram ➞ amcray
take ➞ aketay
cat ➞ atcay
shrimp ➞ impshray
trebuchet ➞ ebuchettray
If a word starts with a vowel add "yay" to the end of the word.
ate ➞ ateyay
apple ➞ appleyay
oaken ➞ oakenyay
eagle ➞ eagleyay
Write two functions to make an English to pig latin translator. 
The first function TranslateWord(word) takes a single word and returns that word 
translated into pig latin. The second function TranslateSentence(sentence) takes an 
English sentence and returns that sentence translated into pig latin.

Examples
TranslateWord("flag") ➞ "agflay"

TranslateWord("Apple") ➞ "Appleyay"

TranslateWord("button") ➞ "uttonbay"

TranslateWord("") ➞ ""

TranslateSentence("I like to eat honey waffles.") ➞ "Iyay ikelay otay eatyay oneyhay afflesway."
TranslateSentence("Do you think it is going to rain today?") ➞ "Oday ouyay inkthay ityay isyay oinggay otay ainray odaytay?"
Notes
Regular expressions will help you not mess up the punctuation in the sentence.
If the original word or sentence starts with a capital letter, the translation should preserve its case (see examples #2, #5 and #6).
 */
namespace Practice_Problems
{
    internal class LatinTranslator
    {
        private static char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        public static void Main(string[] args)
        { 
            Console.WriteLine(PigLatinTranslator("Do you think it is going to rain today?"));
        }
        public static bool isVowel(char letter)
        {
            return vowels.Contains(letter);
        }

        public static string Translate_word(string word)
        {
            string translatedWord = "";
            string endWord = "ay";
            if (isVowel(word[0]))
            {
                endWord = "yay";
            }

            int flag = 0;
            for (int i = 0; i < word.Length; i++)
            {
                if (isVowel(word[i]))
                {
                    translatedWord += word.Substring(i) + word.Substring(0, i) + endWord;
                    flag = 1;
                    break;
                }

            }
            return flag == 1 ? translatedWord : word;
        }
        public static string PigLatinTranslator(string messageToTranslate)
        {
            string translatedMessage = "";
            string[] words = messageToTranslate.Split(' ');
            foreach (string word in words)
            {
                if (Regex.IsMatch(word, @"^[a-zA-z]+$"))
                {
                    translatedMessage += Translate_word(word);
                }
                else
                {
                    translatedMessage += Translate_word(word.Substring(0, word.Length - 2));
                    translatedMessage += word[word.Length - 1];

                }

                translatedMessage += " ";
            }
            return translatedMessage;
        }
    }
}
