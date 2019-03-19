using System;
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
                using (StreamReader sr = new StreamReader(fileInputName, inEncoding))
                {                    
                    using (StreamWriter sw = new StreamWriter(fileOutputName, false, outEncoding))
                    {
                        var fileInfo = new FileInfo(fileInputName);
                        var bufferSize = Math.Min(1024*1024, fileInfo.Length);
                        var buffer = new char[bufferSize];
                        while (!sr.EndOfStream)
                        {
                            sr.Read(buffer, 0, (int)bufferSize);
                            sw.Write(buffer);
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
