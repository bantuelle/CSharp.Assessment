using NUnit.Framework;
using System;
using System.Reflection;
using Question1;
using NUnit.Framework.Internal;
using Assert = NUnit.Framework.Assert;

namespace Question1Test
{
    public class Tests
    {
        [TestFixture]
        public class PersonTests
        {
            [TestCase("9103215432087", "1991-03-21", "Male", true, true)]
            [TestCase("7601026182089", "1976-01-02", "Male", true, false)]
            [TestCase("7512305802089", "1975-12-30", "Male", true, false)]
            [TestCase("8412165084087", "1984-12-16", "Female", true, true)]
            [TestCase("8008025080089", "1980-08-02", "Male", true, true)]
            [TestCase("7809305229087", "1978-09-30", "Male", true, true)]
            [TestCase("1212121212121", "", "", false, false)]
            [TestCase("8101225241082", "", "", false, false)]
            [TestCase("", "", "", false, false)]

            //Test if the whole program works
            public void ValidateAndExtractInformation_Works(string idNumber, string expectedDateOfBirth, string expectedGender, bool expectedIsSouthAfricanCitizen, bool expectedIsValidIDNumber)
            {
                //Arrange
                Type type = typeof(Program);
                MethodInfo method = type.GetMethod("ValidateAndExtractInformation", BindingFlags.Static | BindingFlags.NonPublic);

                //Act
                Person person = (Person)method.Invoke(null, new object[] { idNumber });

                //Assert
                Assert.AreEqual(expectedDateOfBirth, person.DateOfBirth.ToString("yyyy-MM-dd"));
                Assert.AreEqual(expectedGender, person.Gender);
                Assert.AreEqual(expectedIsSouthAfricanCitizen, person.isSouthAfricanCitizen);
                Assert.AreEqual(expectedIsValidIDNumber, person.isValidIDNumber);
            }

            //Test if the correct date of birth gets extracted from the ID number
            [Test]
            public void ValidateAndExtractInformation_ExpectedDateOfBirth_IsCorrect()
            {
                //Arrange
                Type type = typeof(Program);
                MethodInfo method = type.GetMethod("ValidateAndExtractInformation", BindingFlags.Static | BindingFlags.NonPublic);
                string idNumber = "7508305802089";
                string expectedDateOfBirth = "1975-08-30";

                //Act
                Person person = (Person)method.Invoke(null, new object[] { idNumber });

                //Assert
                Assert.AreEqual(expectedDateOfBirth, person.DateOfBirth.ToString("yyyy-MM-dd"));
            }

            //Test if the correct gender gets extracted from the ID number
            [Test]
            public void ValidateAndExtractInformation_Gender_IsCorrect()
            {
                //Arrange
                Type type = typeof(Program);
                MethodInfo method = type.GetMethod("ValidateAndExtractInformation", BindingFlags.Static | BindingFlags.NonPublic);
                string idNumber = "7508305802089";
                string expectedGender = "Female";

                //Act
                Person person = (Person)method.Invoke(null, new object[] { idNumber });

                //Assert
                Assert.AreEqual(expectedGender, person.Gender);
            }

            //Test if the correct citizenship gets extracted from the ID number
            [Test]
            public void ValidateAndExtractInformation_Citizenship_IsCorrect()
            {
                //Arrange
                Type type = typeof(Program);
                MethodInfo method = type.GetMethod("ValidateAndExtractInformation", BindingFlags.Static | BindingFlags.NonPublic);
                string idNumber = "7508305802089";
                bool expectedIsSouthAfricanCitizen = true;

                //Act
                Person person = (Person)method.Invoke(null, new object[] { idNumber });

                //Assert
                Assert.AreEqual(expectedIsSouthAfricanCitizen, person.isSouthAfricanCitizen);
            }

            //Test if the ID number is valid
            [Test]
            public void ValidateAndExtractInformation_IDNumberIsValid()
            {
                //Arrange
                Type type = typeof(Program);
                MethodInfo method = type.GetMethod("ValidateAndExtractInformation", BindingFlags.Static | BindingFlags.NonPublic);
                string idNumber = "7508305802089";
                bool expectedIsValidIDNumber = true;

                //Act
                Person person = (Person)method.Invoke(null, new object[] { idNumber });

                //Assert
                Assert.AreEqual(expectedIsValidIDNumber, person.isValidIDNumber);
            }
        }
    }
}