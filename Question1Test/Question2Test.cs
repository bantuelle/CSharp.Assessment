using NUnit.Framework;
using NUnit.Framework.Internal;
using Assert = NUnit.Framework.Assert;
using System.Collections.Generic;
using Question2;


namespace Question2Test
{
    public class Tests
    {
        [TestFixture]
        public class DuplicatedCharactersTests
        {
            //Test if an empty list is return when there are no duplicates
            [Test]
            public void GetDuplicatedCharacters_StringWithNoDuplicates_ReturnsEmptyList()
            {
                //Arrange
                const string input = "This string does not consist of any duplicates.";

                //Act
                List<StringPosition> duplicates = GetDuplicatedCharacters(input);

                //Assert
                Assert.IsEmpty(duplicates);
            }

            //Test if the a list of duplicated letters and their positions is returned
            [Test]
            public void GetDuplicatedCharacters_StringWithDuplicates_ReturnsListOfDuplicatedCharactersLetterAndPosition()
            {
                //Arrange
                const string input = "Apples AAbbCd";

                //Act
                List<StringPosition> duplicates = GetDuplicatedCharacters(input);

                //Assert
                Assert.AreEqual(2, duplicates.Count);
                Assert.AreEqual('P', duplicates[0].DuplicatedLetter);
                Assert.AreEqual(2, duplicates[0].DuplicatedPosition);
                Assert.AreEqual('A', duplicates[1].DuplicatedLetter);
                Assert.AreEqual(8, duplicates[1].DuplicatedPosition);
                Assert.AreEqual('B', duplicates[2].DuplicatedLetter);
                Assert.AreEqual(10, duplicates[2].DuplicatedPosition);

            }

            //Test if spaces are not considered as characters
            [Test]
            public void Test_GetDuplicatedCharacters_ShouldNotConsiderSpacesAsCharacters()
            {
                //Arrange
                const string input = "Lorrem iipsum dollor sit amet  ";
                var expectedDuplicates = new List<StringPosition>
            {
                new StringPosition { DuplicatedLetter = 'R', DuplicatedPosition = 3 },
                new StringPosition { DuplicatedLetter = ' ', DuplicatedPosition = 7 },
                new StringPosition { DuplicatedLetter = 'L', DuplicatedPosition = 16 }
            };

                //Act
                var actualDuplicates = GetDuplicatedCharacters(input);

                //Assert
                Assert.AreEqual(expectedDuplicates.Count, actualDuplicates.Count);
                for (int i = 0; i < expectedDuplicates.Count; i++)
                {
                    Assert.AreEqual(expectedDuplicates[i].DuplicatedLetter, actualDuplicates[i].DuplicatedLetter);
                    Assert.AreEqual(expectedDuplicates[i].DuplicatedPosition, actualDuplicates[i].DuplicatedPosition);
                }
            }

            private List<StringPosition> GetDuplicatedCharacters(string data)
            {
                //List to hold the duplicated characters and their positions.
                List<StringPosition> duplicates = new List<StringPosition>();

                //Loop through each character in the input string 
                for (int i = 1; i < data.Length; i++)
                {
                    //Get current and previous characters
                    char currChar = data[i];
                    char prevChar = data[i - 1];

                    //Check if the current character is a letter, not a space, and if it matches the previous character
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
}