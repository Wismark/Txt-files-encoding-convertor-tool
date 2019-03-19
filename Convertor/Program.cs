using System;
using System.Text;

namespace Convertor
{
    class Program
    {
        static void Main(string[] args)
        {
           try
           {
               var strParams = new string[4]; 

                for (var i = 0; i < args.Length; i++)
                {
                    if (args[i] == "-i") strParams[0] = args[i + 1];
                    if (args[i] == "-o") strParams[1] = args[i + 1];
                    if (args[i] == "-if") strParams[2] = args[i + 1];
                    if (args[i] == "-of") strParams[3] = args[i + 1];
                }

               var inEncoding = Encoding.GetEncoding(Int32.Parse(strParams[0]));
               var outEncoding = Encoding.GetEncoding(Int32.Parse(strParams[1]));
               var success = Converter.Convert(strParams[2], strParams[3], inEncoding, outEncoding);

               Console.WriteLine(success ? "Success" : "Fail");
           }
           catch (Exception e)
           {
               Console.WriteLine(e);
           }          
        }
    }

}
