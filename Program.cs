using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace MyTest
{
    public class Program : ValidateWord

    {
        static async Task Main(string[] args)
        {
            ///Dpwn load from internet.
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
                ///Write file to disk
                file.Write(finalText);
            }  
        }
    }
}
