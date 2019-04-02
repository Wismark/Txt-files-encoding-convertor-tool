using System.IO;
using System.Text;

namespace Convertor
{
    public static class Converter
    {
        public static bool Convert(string fileInputName, string fileOutputName, Encoding inEncoding, Encoding outEncoding)
        {
            try
            {
                using (var sr = new StreamReader(fileInputName, inEncoding))
                {                    
                    using (var sw = new StreamWriter(fileOutputName, false, outEncoding))
                    {
                        var bufferSize = 10000;
                        var buffer = new char[bufferSize];
                        while (!sr.EndOfStream)
                        {
                            sw.Write(buffer, 0, sr.Read(buffer, 0, bufferSize));
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
