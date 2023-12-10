using System;
using System.IO;

namespace AdventOfCode
{
    class ChallengeOne{        
        static void Main(string[] args)
        {
            try
            {
                string[] lines = File.ReadAllLines("C:/Users/semis/Desktop/AdventOfCode/Day1/AdventOfCode/input.txt");
                int solution = 0;

                for (int i = 0; i < lines.Length; i++)
                {
                    solution += int.Parse(Char.ToString(GetFirstDigit(lines[i])) + Char.ToString(GetLastDigit(lines[i])));
                }
                
                Console.WriteLine(solution.ToString());

             }
             catch(Exception e)
             {
                Console.WriteLine(e);
             }
        }
        static char GetFirstDigit(string line)
        {
            for (int i = 0; i < line.Length; i += 1)
            {
                if (Char.IsNumber(line[i])) {return line[i];}
            }
            return '0';
        }

        
        static char GetLastDigit(string line)
        {
            for (int i = line.Length - 1; i >= 0; i -= 1)
            {
                if (Char.IsNumber(line[i])) {return line[i];}
            }
            return '0';
        }
    }
}