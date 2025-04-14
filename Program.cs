using System;

namespace Task1
{
    internal class Program
    {
        public static string Compress(string line)
        {
            if (line.Length <= 1)
                return line;

            string NewLine = "";

            int count = 1;
            char symbol = line[0];
            for (int i = 1; i < line.Length; ++i)
            {
                if (line[i] == symbol)
                    ++count;
                else
                {
                    NewLine += symbol + count.ToString();
                    count = 1;
                    symbol = line[i];
                }
            }

            if (count == 1)
                NewLine += symbol;
            else
                NewLine += symbol + count.ToString();

            return NewLine;
        }

        public static string DeCompress(string line)
        {
            if (line.Length <= 1)
                return line;

            string NewLine = "";

            int i = 0;
            while (i < line.Length)
            {
                //a3b2c3d2e
                if ((i + 1 < line.Length) && char.IsDigit(line[i + 1]))
                {
                    int count = int.Parse(line[i + 1].ToString());
                    for (int j = 0; j < count; ++j)
                        NewLine += line[i];
                    i += 2;
                }
                else
                {
                    NewLine += line[i];
                    i += 1;
                }
            }

            return NewLine;
        }

        public static void Main()
        {
            //string line = Console.ReadLine();

            const string line = "aaabbcccdde";

            string CompressedLine = Compress(line);
            Console.WriteLine(CompressedLine);

            Console.WriteLine(DeCompress(CompressedLine));
            Console.ReadKey();
        }
    }
}
