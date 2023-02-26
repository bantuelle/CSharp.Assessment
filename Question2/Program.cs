using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    class Program
    {
        // Question 2:
        // Find every position in an input string where a letter is succeeded by itself
        // Please note that space is not a letter, each time a duplicated letter is found, write this letter plus it's position into the duplicate list
        
        /*
         * Example if data is "letter" position of t is 3 and value is tt
        */
            
        // NOTE: Please include comments in your code
        
        static void Main(string[] args)
        {
            const string data = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commmodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

            var duplicates = GetDuplicatedCharacters(data);
            foreach (var duplicate in duplicates)
            {
                Console.WriteLine("Duplicated letter '{0}' found at position {1}", duplicate.DuplicatedLetter, duplicate.DuplicatedPosition);
            }
            Console.Read();
        }

        private static List<StringPosition> GetDuplicatedCharacters(string data)
        {
            //List to hold the duplicated characters and their positions.
            List<StringPosition> duplicates = new List<StringPosition>();

            //Loop through each character in the input string 
            for (int i = 1; i < data.Length; i++)
            {
                //Get current and previous characters
                char currChar = data[i];
                char prevChar = data[i - 1];

                //Check if the current character is a letter and not a space, and if it matches the previous character
                if (char.IsLetter(currChar) && currChar != ' ' && char.ToUpper(currChar) == char.ToUpper(prevChar))
                {
                    // Add the duplicated letter and its position to the duplicates list
                    duplicates.Add(new StringPosition { DuplicatedLetter = char.ToUpper(currChar), DuplicatedPosition = i });
                }
            }

            return duplicates;
        }
    }
}
