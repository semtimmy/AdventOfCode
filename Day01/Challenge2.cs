using System.IO;

namespace AdventOfCode
{
    class ChallengeTwo{         
        static string[] NUMBERS = {"one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};

        static void Main(string[] args)
        {
            try
            {
                string[] lines = File.ReadAllLines("C:/Users/semis/Desktop/AdventOfCode/Day1/AdventOfCode/input.txt");
                int solution = 0;

                //For each line in file, get first and last digit as character and append them to eachother, and add this to the solution
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
        //returns first digit in the given line
        {
            for (int i = 0; i < line.Length; i++)
            {
                //return if number
                if (Char.IsNumber(line[i])) 
                    return line[i];
                
                //check if current character is the start of a new typed out digit
                char parser = ParseStringForDigit(line, i, "", true);
                if (parser != '-')
                    return parser;
            }
            return '0';
        }

        static char GetLastDigit(string line)
        //inverse of GetFirstDigit
        {
            for (int i = line.Length - 1; i >= 0; i -= 1)
            {
                if (Char.IsNumber(line[i])) 
                    return line[i];
                
                char parser = ParseStringForDigit(line, i, "", false);
                if (parser != '-')
                    return parser;
            }
            return '0';
        }

        static char ParseStringForDigit(string line, int currentIndex, string buffer, bool searchForward)
        {
            int digit = Array.IndexOf(NUMBERS, buffer) + 1;
            if (digit > 0)
            {
                return (char)(digit + '0');
            }

            int increment = searchForward ? 1 : -1;

            for (int i = 0; i < NUMBERS.Length; i++)
            {
                if (NUMBERS[i].Length > buffer.Length)
                {
                    int compareIndex = searchForward ? buffer.Length : NUMBERS[i].Length - buffer.Length - 1;

                    if (line[currentIndex] == NUMBERS[i][compareIndex])
                    {
                        buffer = searchForward ? buffer + line[currentIndex] : line[currentIndex] + buffer;
                        return ParseStringForDigit(line, currentIndex + increment, buffer, searchForward);
                    }
                }
            }

            return '-';
        }
    }
}