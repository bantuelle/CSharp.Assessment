using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnitTests")]
namespace Question1
{
    internal class Person
    {
        internal DateTime DateOfBirth { get; set; }
        internal string Gender { get; set; }
        internal bool isSouthAfricanCitizen { get; set; }
        internal bool isValidIDNumber { get; set; }
    }
}