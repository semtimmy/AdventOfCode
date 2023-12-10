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
				
				//Fir each line in file, get first and last digit as char, append to eachother, then parse as int. finally add them together
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
		
		//Get first digit in line
        static char GetFirstDigit(string line)
        {
            for (int i = 0; i < line.Length; i += 1)
            {
                if (Char.IsNumber(line[i])) {return line[i];}
            }
            return '0';
        }
		
		//Get last digit in line
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