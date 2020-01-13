using ConsoleApp.Models;
using System;

namespace ConsoleApp
{
    public class StartUp
    {
        public static void Main()
        {
            Console.WriteLine("***** Two cubes calendar! Enjoy! *****");
            Console.WriteLine();
            Console.WriteLine("This is a two cubes calendar. Every cube have six digits and you can rotate the cubes and set the date.");
            Console.WriteLine("The command should be in two words and rotate one of the cubes.");
            Console.WriteLine("The first word must be \"left\" or \"right\" to show which cube you want to rotate");
            Console.WriteLine("The second can be: \"left\", \"right\", \"up\", \"donw\" or \"rotate\"(you guess for what :) ) for the direction of rotation of the cube");
            Console.WriteLine("For example: \"left left\", \"right left\", \"right up\", \"left rotate\"");
            Console.WriteLine("You can rotate the cubes(the left to become right) with command: \"rotate cubes\"");
            Console.WriteLine();
            Console.WriteLine("The numbers for the left cube at the start are: 1, 2, 3, 4 on the line, 0 on the bottom and 5 on the top");
            Console.WriteLine("The numbers for the right cube at the start are: 1, 2, 6, 7 on the line, 0 on the bottom and 8 on the top");
            Console.WriteLine();

            //creating cube A
            var cubeA = new Cube
            {
                BottomNumber = 0,
                TopNumber = 5,
                FrontLineNumbers = new int[4]
                {
                    1, 2, 3, 4
                }
            };
            //creating cube Б
            var cubeB = new Cube
            {
                BottomNumber = 0,
                TopNumber = 8,
                FrontLineNumbers = new int[4]
                {
                    1, 2, 6, 7
                }
            };
            //defaul start value of the cubes: number and index
            var currentLeftNumber = 1;
            var currentRightNumber = 1;
            var lastFrontLineLeftIndex = 0;
            var lastFrontLineRightIndex = 0;

            Console.WriteLine("And the start value of the cubes is:");
            Console.WriteLine("   " + currentLeftNumber + " " + currentRightNumber);
           
            var input = Console.ReadLine();

            while (input.ToLower() != "end")
            {
                var inputParams = input.Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                if (inputParams.Length == 0)
                {
                    Console.WriteLine("Invalid command!");
                }
                //behavior of left cube
                else if (inputParams[0].ToLower() == "left")
                {
                    if (inputParams.Length == 1)
                    {
                        Console.WriteLine("Invalid command!");
                    }
                    else if (inputParams[1].ToLower() == "left")
                    {
                        var newIndex = cubeA.TurnLeft(currentLeftNumber, lastFrontLineLeftIndex);
                        currentLeftNumber = cubeA.FrontLineNumbers[newIndex];
                        lastFrontLineLeftIndex = newIndex;
                        Console.WriteLine("   " + currentLeftNumber + " " + currentRightNumber);
                    }

                    else if (inputParams[1].ToLower() == "right")
                    {
                        var newIndex = cubeA.TurnRight(currentLeftNumber, lastFrontLineLeftIndex);
                        currentLeftNumber = cubeA.FrontLineNumbers[newIndex];
                        lastFrontLineLeftIndex = newIndex;
                        Console.WriteLine("   " + currentLeftNumber + " " + currentRightNumber);
                    }

                    else if (inputParams[1].ToLower() == "up")
                    {
                        currentLeftNumber = cubeA.TurnUp(currentLeftNumber, lastFrontLineLeftIndex);
                        if (currentLeftNumber == cubeA.BottomNumber)
                        {
                            if (lastFrontLineLeftIndex + 2 > cubeA.FrontLineNumbers.Length - 1)
                            {
                                lastFrontLineLeftIndex = lastFrontLineLeftIndex - 2;
                            }
                            else
                            {
                                lastFrontLineLeftIndex += 2;
                            }
                        }
                        
                        Console.WriteLine("   " + currentLeftNumber + " " + currentRightNumber);
                    }

                    else if (inputParams[1].ToLower() == "down")
                    {
                        currentLeftNumber = cubeA.TurnDown(currentLeftNumber, lastFrontLineLeftIndex);
                        if (currentLeftNumber == cubeA.TopNumber)
                        {
                            if (lastFrontLineLeftIndex + 2 > cubeA.FrontLineNumbers.Length - 1)
                            {
                                lastFrontLineLeftIndex = lastFrontLineLeftIndex - 2;
                            }
                            else
                            {
                                lastFrontLineLeftIndex += 2;
                            }
                        }
                        
                        Console.WriteLine("   " + currentLeftNumber + " " + currentRightNumber);
                    }

                    else if (inputParams[1].ToLower() == "rotate")
                    {
                        if (currentLeftNumber == 6 || currentLeftNumber == 9)
                        {
                            currentLeftNumber = cubeA.RotateNumberSixOrNine(currentLeftNumber);
                            Console.WriteLine("   " + currentLeftNumber + " " + currentRightNumber);
                        }
                        
                        else
                        {
                            Console.WriteLine("You can rotate only the numbers 6 and 9.");
                        }
                    }
                    
                    else
                    {
                        Console.WriteLine("Invalid command!");
                    }
                }
                //behavior of right cube
                else if(inputParams[0].ToLower() == "right")
                {
                    if (inputParams[1].ToLower() == "left")
                    {
                        var newIndex = cubeB.TurnLeft(currentRightNumber, lastFrontLineRightIndex);
                        currentRightNumber = cubeB.FrontLineNumbers[newIndex];
                        lastFrontLineRightIndex = newIndex;
                        Console.WriteLine("   " + currentLeftNumber + " " + currentRightNumber);
                    }

                    else if (inputParams[1].ToLower() == "right")
                    {
                        var newIndex = cubeB.TurnRight(currentRightNumber, lastFrontLineRightIndex);
                        currentRightNumber = cubeB.FrontLineNumbers[newIndex];
                        lastFrontLineRightIndex = newIndex;
                        Console.WriteLine("   " + currentLeftNumber + " " + currentRightNumber);
                    }

                    else if (inputParams[1].ToLower() == "up")
                    {
                        currentRightNumber = cubeB.TurnUp(currentRightNumber, lastFrontLineRightIndex);
                        if (currentRightNumber != cubeB.BottomNumber)
                        {
                            if (lastFrontLineRightIndex + 2 > cubeA.FrontLineNumbers.Length - 1)
                            {
                                lastFrontLineRightIndex = lastFrontLineRightIndex - 2;
                            }
                            else
                            {
                                lastFrontLineRightIndex += 2;
                            }
                        }
                        Console.WriteLine("   " + currentLeftNumber + " " + currentRightNumber);
                    }

                    else if (inputParams[1].ToLower() == "down")
                    {
                        currentRightNumber = cubeB.TurnDown(currentRightNumber, lastFrontLineRightIndex);
                        if (currentRightNumber == cubeB.TopNumber)
                        {
                            if (lastFrontLineRightIndex + 2 > cubeB.FrontLineNumbers.Length - 1)
                            {
                                lastFrontLineRightIndex = lastFrontLineRightIndex - 2;
                            }
                            else
                            {
                                lastFrontLineRightIndex += 2;
                            }
                        }
                        Console.WriteLine("   " + currentLeftNumber + " " + currentRightNumber);
                    }

                    else if (inputParams[1].ToLower() == "rotate")
                    {
                        if (currentRightNumber == 6 || currentRightNumber == 9)
                        {
                            currentRightNumber = cubeB.RotateNumberSixOrNine(currentRightNumber);

                            Console.WriteLine("   " + currentLeftNumber + " " + currentRightNumber);
                        }
                        
                        else
                        {
                            Console.WriteLine("You can rotate only the numbers 6 and 9.");
                        }
                    }
                    
                    else
                    {
                        Console.WriteLine("Invalid command!");
                    }
                }
                // rotate cubes from left to right
                else if (inputParams[0].ToLower() == "rotate" && inputParams[1].ToLower() == "cubes")
                {
                    var currentCube = cubeA;
                    cubeA = cubeB;
                    cubeB = currentCube;

                    currentLeftNumber = 1;
                    currentRightNumber = 1;
                    lastFrontLineLeftIndex = 0;
                    lastFrontLineRightIndex = 0;

                    Console.WriteLine("The cubes are rotated.");
                    Console.WriteLine(currentLeftNumber + " " + currentRightNumber);
                }
                
                else
                {
                    Console.WriteLine("Invalid command!");
                }

                input = Console.ReadLine();
            }
        }
    }
}
