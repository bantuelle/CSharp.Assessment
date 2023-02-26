using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnitTests")]
namespace Question2
{
    internal class StringPosition
    {
        internal char DuplicatedLetter {get;set;}
        internal int DuplicatedPosition { get; set; }
    }
}