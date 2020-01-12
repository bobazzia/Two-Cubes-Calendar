using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp.Models
{
    public class Cube
    {
        public int TopNumber { get; set; }
        public int[] FrontLineNumbers { get; set; }
        public int BottomNumber { get; set; }

        public int TurnLeft(int currentNumber)
        {
            var currentIndex = FindIndex(currentNumber, this.FrontLineNumbers);

            if (currentIndex == this.FrontLineNumbers.Length - 1)
            {
                return 0;
            }
            else
            {
                return currentIndex + 1;
            }
        }

        public int TurnRight(int currentNumber)
        {
            var currentIndex = FindIndex(currentNumber, this.FrontLineNumbers);

            if (currentIndex == 0)
            {
                return this.FrontLineNumbers.Length - 1;
            }
            else
            {
                return currentIndex - 1;
            }
        }

        public int TurnUp(int currentNumber)
        {
            if (this.FrontLineNumbers.Contains(currentNumber))
            {
                return this.BottomNumber;
            }
            else
            {
                return this.FrontLineNumbers[0];
            }
        }

        public int TurnDown(int currentNumber)
        {
            
            if (this.FrontLineNumbers.Contains(currentNumber))
            {
                return this.TopNumber;
            }
            else
            {
                return this.FrontLineNumbers[0];
            }
        }

        public int RotateNumberSixOrNine(int currentNumber)
        {
            if (currentNumber == 6)
            {
                return 9;
            }

            if (currentNumber == 9)
            {
                return 6;
            }
            return 0;
        }

        public static int FindIndex(int currentNumber, int[] intArray)
        {
            var currentNumberIndex = -1;
            if (intArray.Contains(currentNumber))
            {
                for (int i = 0; i < intArray.Length; i++)
                {
                    if (intArray[i] == currentNumber)
                    {
                        currentNumberIndex = i;
                    }
                }
            }
            return currentNumberIndex;
        }
    }
}
