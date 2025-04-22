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

            NewLine.Append(symbol);
            if (count > 1)
                NewLine.Append(count);

            return NewLine.ToString();
        }

        public static string DeCompress(string line)
        {
            if (line.Length <= 1)
                return line;

            StringBuilder NewLine = new StringBuilder();

            char symbol = line[0];
            int i = 0;

            while (i < line.Length)
            {
                char current = line[i];
                if (char.IsLetter(current))
                {
                    symbol = current;
                    NewLine.Append(symbol);
                    i++;
                }
                else
                {
                    string numBuilder = "";
                    while (i < line.Length && char.IsDigit(line[i]))
                    {
                        numBuilder += line[i];
                        i++;
                    }
                    int count = int.Parse(numBuilder.ToString());
                    for (int j = 1; j < count; j++)
                        NewLine.Append(symbol);
                }
            }

            return NewLine.ToString();
        }

        public static bool IsLatinLowLetter(char ch)
        {
            return (ch >= 'a' && ch <= 'z');
        }

        public static bool IsValidInputLine(string line)
        {
            if (string.IsNullOrEmpty(line))
                return false;

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

            if (IsValidInputLine(line))
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
