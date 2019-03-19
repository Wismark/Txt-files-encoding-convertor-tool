using System;
using System.IO;
using System.Text;

namespace Convertor
{
    public static class Converter
    {
        public static bool Convert(string fileInputName, string fileOutputName, Encoding inEncoding, Encoding outEncoding, bool overwrite = false)
        {
            try
            {
                if (File.Exists(fileInputName + ".txt"))
                {
                    using (StreamReader sr = new StreamReader(fileInputName + ".txt", inEncoding))
                    {
                        if (!overwrite) fileOutputName = GetUniqueName(fileOutputName);

                        using (StreamWriter sw = new StreamWriter(fileOutputName + ".txt", false, outEncoding))
                        {
                            while (!sr.EndOfStream)
                            {
                                FileInfo fileInfo = new FileInfo(fileInputName + ".txt");
                                var bufferSize = Math.Min(1024 * 1024, fileInfo.Length - 3);
                                char[] buffer = new char[bufferSize];
                                sr.ReadBlock(buffer, 0, (int) bufferSize);
                                sw.Write(buffer);
                            }
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

        private static string GetUniqueName(string name)
        {
            Int32 i = 1;
            string temp = name + $" ({i})";
            if (!File.Exists(name +".txt")) return name;
            
            while (File.Exists(temp + ".txt"))
            {
                i++;
                temp = name + $" ({i})";
            }

            return temp;
        }
    }
}
