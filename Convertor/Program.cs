using System;
using System.IO;
using System.Text;

namespace Convertor
{
    class Program
    {
        static void Main(string[] args)
        {
           try
           {
               string fileInputName="", fileOutputName="defaultOutput.txt";
               Encoding inEncoding = Encoding.Default; Encoding outEncoding = Encoding.Default;
               bool overwrite = false;

                for (var i = 0; i < args.Length; i++)
                {
                    if (args[i] == "-i") inEncoding = Encoding.GetEncoding(int.Parse(args[i + 1]));  
                    if (args[i] == "-o") outEncoding = Encoding.GetEncoding(int.Parse(args[i + 1]));
                    if (args[i] == "-if") fileInputName = args[i + 1];
                    if (args[i] == "-of") fileOutputName = args[i + 1];
                    if (args[i] == "-ow") overwrite = args[i + 1] == "true";
                }

                if (!File.Exists(fileInputName))
                {
                    throw new FileNotFoundException("Input file not exists!");
                }

                if (!overwrite)
                {
                    fileOutputName = GetUniqueName(fileOutputName);
                }

                var success = Converter.Convert(fileInputName, fileOutputName, inEncoding, outEncoding);

                Console.WriteLine(success ? "Success" : "Fail");
           }
           catch (Exception e)
           {
               Console.WriteLine(e);
           }          
        }

        private static string GetUniqueName(string name)
        {
            int i = 1;
            string temp = $" ({i})" + name;
            if (!File.Exists(name))
            {
                return name;
            }

            while (File.Exists(temp))
            {
                i++;
                temp = $" ({i})" + name;
            }

            return temp;
        }
    }

}
