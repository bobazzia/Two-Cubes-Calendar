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

        public int TurnLeft(int currentNumber, int lastFrontLineIndex)
        {
            if (currentNumber == this.BottomNumber || currentNumber == this.TopNumber)
            {
                lastFrontLineIndex = 3;
                return lastFrontLineIndex;
            }
            
            else if (lastFrontLineIndex == this.FrontLineNumbers.Length - 1)
            {
                lastFrontLineIndex = 0;
                return lastFrontLineIndex;
            }

            else
            {
                lastFrontLineIndex ++;
                return lastFrontLineIndex;
            }
        }

        public int TurnRight(int currentNumber, int lastFrontLineIndex)
        {
            if (currentNumber == this.BottomNumber || currentNumber == this.TopNumber)
            {
                lastFrontLineIndex = 1;
                return lastFrontLineIndex;
            }

            if (lastFrontLineIndex == 0)
            {
                lastFrontLineIndex = this.FrontLineNumbers.Length - 1;
                return lastFrontLineIndex;
            }
            else
            {
                lastFrontLineIndex --;
                return lastFrontLineIndex;
            }
        }

        public int TurnUp(int currentNumber, int lastFrontLineIndex)
        {
            if (this.FrontLineNumbers.Contains(currentNumber))
            {
                return this.BottomNumber;
            }

            else if (currentNumber == this.BottomNumber)
            {
                return this.FrontLineNumbers[lastFrontLineIndex];
            }

            else
            {
                if (lastFrontLineIndex + 2 > this.FrontLineNumbers.Length - 1)
                {
                    lastFrontLineIndex = lastFrontLineIndex - 2;
                }

                else
                {
                    lastFrontLineIndex += 2;
                }

                return this.FrontLineNumbers[lastFrontLineIndex];
            }
        }

        public int TurnDown(int currentNumber, int lastFrontLineIndex)
        {
            if (this.FrontLineNumbers.Contains(currentNumber))
            {
                return this.TopNumber;
            }

            else if (currentNumber == this.TopNumber)
            {
                return this.FrontLineNumbers[lastFrontLineIndex];
            }

            else
            {
                if (lastFrontLineIndex + 2 > this.FrontLineNumbers.Length - 1)
                {
                    lastFrontLineIndex = lastFrontLineIndex - 2;
                }

                else
                {
                    lastFrontLineIndex += 2;
                }

                return this.FrontLineNumbers[lastFrontLineIndex];
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

        // Create FindIndex method, but not use for now with 
        //public static int FindIndex(int currentNumber, int[] intArray)
        //{
        //    var currentNumberIndex = -1;
        //    if (intArray.Contains(currentNumber))
        //    {
        //        for (int i = 0; i < intArray.Length; i++)
        //        {
        //            if (intArray[i] == currentNumber)
        //            {
        //                currentNumberIndex = i;
        //            }
        //        }
        //    }
        //    return currentNumberIndex;
        //}
    }
}
