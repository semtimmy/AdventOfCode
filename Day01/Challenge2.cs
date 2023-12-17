using System.IO;

namespace HelloWorld
{
    class Hello {        
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
                char parser = ParseStringForFirstDigit(line, i, "");
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
                
                char parser = ParseStringForLastDigit(line, i, "");
                if (parser != '-')
                    return parser;
            }
            return '0';
        }

        static char ParseStringForFirstDigit(string line, int CurrentIndex, string buffer)
        //for each given index, compare the character at that index to each typed out digit
        //if it finds a match, look forward recursively and check if it spells out a full digit
        {
            //if the buffer contains a digit, return the digit
            int digit = Array.IndexOf(NUMBERS, buffer) + 1;
            if (digit > 0)
                {
                    return (char)(digit + '0');
                }

            //for each typed out digit, check if the current character and the current digit character matches
            for (int i = 0; i < NUMBERS.Length; i++)
                {
                    if (NUMBERS[i].Length > buffer.Length)
                        if (line[CurrentIndex] == NUMBERS[i][buffer.Length])
                        //if it matches, try find the next one
                        {
                            buffer += line[CurrentIndex];
                            return ParseStringForFirstDigit(line, CurrentIndex + 1, buffer);
                        }
                }
            //otherwise return the "failed" character
            return '-';
        }

        static char ParseStringForLastDigit(string line, int CurrentIndex, string buffer)
        //inverse of ParseStringForLastDigit
        {
            int digit = Array.IndexOf(NUMBERS, buffer) + 1;
            if (digit > 0)
                {
                    return (char)(digit + '0');
                }

            for (int i = 0; i < NUMBERS.Length; i++)
                {
                    if (NUMBERS[i].Length > buffer.Length)
                        if (line[CurrentIndex] == NUMBERS[i][NUMBERS[i].Length - buffer.Length - 1])
                        {
                            buffer = line[CurrentIndex] + buffer;
                            return ParseStringForLastDigit(line, CurrentIndex - 1, buffer);
                        }
                }
            return '-';
        }
    }
}