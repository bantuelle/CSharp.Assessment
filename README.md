# CSharpJuniorDevAssessment
CSharp Developer Assessment

Question 1:

Write an algorithm to extract:
    
    1. The persons date of birth
    2. Gender
    3. Citizenship
    4. If the ID Number is valid
    
 A South African ID Number is broken down as follows:
    
	1. The first 6 digits are the persons date of birth in the format YYMMDD
    2. The next 4 digits indicate gender:
        >> 0000 - 4999 = FEMALE
        >> 5000 - 9999 = MALE
    3. The 11th digit indicates citizenship of the person - 
        >> 0 indicates a South African citizen
        >> 1  indicates a foreign citizen
    4. The last to digits are a checksum based on Luhn algorithm, this is used to validate the ID number

Question 2:

 Find every position in an input string where a letter is succeeded by itself
 Please note that space is not a letter, each time a duplicated letter is found, write this letter plus it's position into the duplicate list
        
    1. Example if data is "letter" position of t is 3 and value is tt 

