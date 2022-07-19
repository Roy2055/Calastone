using System.Text.RegularExpressions;

namespace MyTest
{
    public class ValidateWord
    {

        public static string ValidWord(string inputWord)
        {
            string originalWord = inputWord;

            if (inputWord.Length < 3)
            {
                return ""; //too small
            }

            StringComparison c = StringComparison.OrdinalIgnoreCase;
            if (inputWord.Contains('t', c))
            {
                return "";  //contains invalid letter
            }

            string cleanWord = Regex.Replace(inputWord, @"[^A-Za-z]+", String.Empty);

            int offset = cleanWord.Length / 2;

            if (cleanWord.Length % 2 == 0)
            {
                //Even word
                string newString = cleanWord[offset - 1].ToString() + cleanWord[offset].ToString();

                if (Regex.Match(newString, @"[aeiou]").Length > 0)
                {
                    return "";  //found vowels
                }
                else
                {
                    return " " + originalWord; //No Vowels
                }
            }
            else
            {
                //Console.WriteLine("The word is Fraction");
                if (Regex.Match(cleanWord[offset].ToString(), @"[^aeiou]").Length > 0)
                {
                    return " " + originalWord; //Found Vowel(s)
                }
                else
                {
                    return ""; //No Vowels
                }
            }
        }
    }
}