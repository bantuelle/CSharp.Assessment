using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    class Program
    {
        // Question 1: 
        // The purpose of this question is to write a method to extract information 
        // about a person based on their ID number.
        /*
            Write an algorithm to extract:
                1. The persons date of birth
                2. Gender
                3. Citizenship
                4. If the ID Number is valid
             A South African ID Number is broken down as follows:
                - The first 6 digits are the persons date of birth in the format YYMMDD
                - The next 4 digits indicate gender:
                    >> 0000 - 4999 = FEMALE
                    >> 5000 - 9999 = MALE
                - The 11th digit indicates citizenship of the person - 
                    >> 0 indicates a South African citizen
                    >> 1  indicates a foreign citizen
                - The last to digits are a checksum based on Luhn algorithm, this is used to validate the ID number
        */

        // NOTE: Please include comments in your code

        static void Main(string[] args)
        {
            var idNumberList = new List<string>
            {
                "7508305802089",
                "7512305802089"
            };
            foreach(var id in idNumberList)
            {
                var person = ValidateAndExtractInformation(id);
                Console.WriteLine($"Details for person with ID Number: {id}");
                Console.WriteLine($"Person Date Of Birth: {person.DateOfBirth.ToString()}");
                Console.WriteLine($"Person Gender: {person.Gender}");
                Console.WriteLine($"Is person a South African Citizen: {person.isSouthAfricanCitizen.ToString()}");
                Console.WriteLine($"Is ID Number Valid: {person.isValidIDNumber}");
                Console.WriteLine($"**************************************************");
            }
            Console.Read();
            
        }

        private static Person ValidateAndExtractInformation(string idNumber)
        {
            //Person object
            Person person = new Person();

            //Extract date of birth from first 6 digits of ID number
            string dobString = idNumber.Substring(0, 6);
            int year = int.Parse(dobString.Substring(0, 2));
            int month = int.Parse(dobString.Substring(2, 2));
            int day = int.Parse(dobString.Substring(4, 2));
            int century;
            if (year >= 0 && year <= 21)
            {
                century = 2000;
            }
            else
            {
                century = 1900;
            }
            DateTime dob = new DateTime(century + year, month, day);
            person.DateOfBirth = dob;

            //Extracting the person's gender from the next 4 digits in the ID number
            int genderDigit = int.Parse(idNumber.Substring(6, 4));

            //If the value of "genderDigit" is less than 5000 the gender is female. Else, male. 
            if (genderDigit < 5000)
            {
                person.Gender = "Female";
            }
            else
            {
                person.Gender = "Male";
            }

            //Extracting the person's citizenship from the 11th digit of the ID number.
            int citizenshipDigit = int.Parse(idNumber.Substring(10, 1));

            //If the 11th digit equals to 0, the person is a South African citizen. 
            if (citizenshipDigit == 0)
            {
                person.isSouthAfricanCitizen = true;
            }
            else
            {
                person.isSouthAfricanCitizen = false;
            }

            //Validate ID number using the Luhn algorithm
            int[] idDigits = idNumber.ToCharArray().Select(c => int.Parse(c.ToString())).ToArray(); //converting ID number digits into array
            int sum = 0;
            for (int i = 0; i < 12; i++)
            {
                int digit = idDigits[i];
                //Double the value of every second digit
                if (i % 2 == 0)
                {
                    digit *= 2;
                    //If the total value after doubling is greater than 9, subract 9 from that total
                    if (digit > 9) digit -= 9;
                }
                //Add the digit to the sum
                sum = sum + digit;
            }
            int checksum;
            //If the sum is a multiple of 10, the checksum is 0. Else, calculate the checksum
            if (sum % 10 == 0)
            {
                checksum = 0;
            }
            else
            {
                checksum = (10 - (sum % 10)) % 10;
            }

            //Set the validity of the ID number
            person.isValidIDNumber = (checksum == idDigits[12]);
            
            //Return the person object
            return person;
            
        }
        
    }
}
