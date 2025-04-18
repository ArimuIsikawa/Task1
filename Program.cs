using System;
using System.Text;

namespace Task1
{
    internal class Program
    {
        public static string Compress(string line)
        {
            if (line.Length <= 1)
                return line;

            StringBuilder NewLine = new StringBuilder();

            int count = 1;
            char symbol = line[0];
            for (int i = 1; i < line.Length; ++i)
            {
                if (line[i] == symbol)
                    ++count;
                else
                {
                    NewLine.Append(symbol);
                    NewLine.Append(count.ToString());
                    count = 1;
                    symbol = line[i];
                }
            }

            if (count == 1)
                NewLine.Append(symbol);
            else
            {
                NewLine.Append(symbol);
                NewLine.Append(count.ToString());
            }

            return NewLine.ToString();
        }

        public static string DeCompress(string line)
        {
            if (line.Length <= 1)
                return line;

            StringBuilder NewLine = new StringBuilder();

            bool setupNum = false;
            char symbol = line[0];
            int i = 0;
            string num = "";

            while (i < line.Length)
            {
                //a10e
                if (!char.IsDigit(line[i]))
                {
                    if (setupNum == true)
                    {
                        setupNum = false;
                        int max = int.Parse(num);
                        for (int j = 0; j < max - 1; ++j)
                            NewLine.Append(symbol);
                        num = "";
                    }
                    else
                    {
                        symbol = line[i];
                        NewLine.Append(symbol);
                        ++i;
                    }
                }
                else
                {
                    setupNum = true;
                    num += line[i];
                    ++i;
                }
            }

            if ((i == line.Length) && (setupNum == true))
            {
                int max = int.Parse(num);
                for (int j = 0; j < max - 1; ++j)
                    NewLine.Append(symbol);
            }

            return NewLine.ToString();
        }

        public static bool IsLatinLowLetter(char ch)
        {
            return (ch >= 'a' && ch <= 'z');
        }

        public static bool CheckLine(string line)
        {
            // Проверяет наличие букв верхнего регистра и цифр
            for (int i = 0; i < line.Length; ++i)
            {
                if (char.IsDigit(line[i]) || char.IsUpper(line[i]) || !IsLatinLowLetter(line[i]))
                    return false;
            }
            return true;
        }

        public static void Main()
        {
            //string line = Console.ReadLine();
            const string line = "aaabbeeeeeeeeee";

            if (CheckLine(line))
            {
                string CompressedLine = Compress(line);
                Console.WriteLine(CompressedLine);

                Console.WriteLine(DeCompress(CompressedLine));
            }
            else
                Console.WriteLine("Входная строка имеет не верный формат");
            Console.ReadKey();
        }
    }
}
