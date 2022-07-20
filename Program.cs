using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace MyTest
{
    public class Program : ValidateWord

    {
        /// <summary>
        /// Validates a text file from github
        /// Eliminates words from the file based on the following
        /// criteria:
        /// 1. The has a vowel as the middle character(s);
        /// 2. The word contains a 't';
        /// 3. The word is less than 3 charaters.
        /// class <c>ValidWord</c> is used to ascertain if the word is valid.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static async Task Main(string[] args)
        {
            ///Download from internet.
            string filePath = @"https://raw.githubusercontent.com/Roy2055/RepoTest/main/SampleFile.txt";
            HttpClient httpClient = new();
            var content = await httpClient.GetStringAsync(filePath);
           
            string[] lines = content.Split(
                new string[] { Environment.NewLine }, StringSplitOptions.None);
               
            string finalText = "";
            foreach (string line in lines)
            {
                StringBuilder sb = new();
                string[] allWords = Regex.Split(line, @" ");

                for (int i = 0; i < allWords.Length; i++) 
                {
                    
                    sb.Append(ValidWord(allWords[i]));
                }
                ///File ouptut
                finalText += sb.ToString() + "\n";
            }
            using (System.IO.StreamWriter file = new(@"c:\testFileCleaned.txt"))
            {
                ///Write file to local disk
                Console.WriteLine("File cleansing completed.");
                file.Write(finalText);
            }  
        }
    }
}
