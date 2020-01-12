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
            Console.WriteLine("The numbers for the left cube at the start are: 0, 1, 2, 3, 4, 5");
            Console.WriteLine("The numbers for the right cube at the start are: 0, 1, 2, 6, 7, 8");
            Console.WriteLine();
           

            var cubeA = new Cube
            {
                BottomNumber = 0,
                TopNumber = 5,
                FrontLineNumbers = new int[4]
                {
                    1, 2, 3, 4
                }
            };

            var cubeB = new Cube
            {
                BottomNumber = 0,
                TopNumber = 8,
                FrontLineNumbers = new int[4]
                {
                    1, 2, 6, 7
                }
            };

            var currentLeftNumber = 1;
            var currentRightNumber = 1;
            Console.WriteLine("And the start value of the cubes is:");
            Console.WriteLine("   " + currentLeftNumber + " " + currentRightNumber);
           
            var input = Console.ReadLine();

            while (input.ToLower() != "end")
            {
                var inputParams = input.Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                if (inputParams[0].ToLower() == "left")
                {
                    if (inputParams[1].ToLower() == "left")
                    {
                        var newIndex = cubeA.TurnLeft(currentLeftNumber);
                        currentLeftNumber = cubeA.FrontLineNumbers[newIndex];
                        Console.WriteLine("   " + currentLeftNumber + " " + currentRightNumber);
                    }

                    else if (inputParams[1].ToLower() == "right")
                    {
                        var newIndex = cubeA.TurnRight(currentLeftNumber);
                        currentLeftNumber = cubeA.FrontLineNumbers[newIndex];
                        Console.WriteLine("   " + currentLeftNumber + " " + currentRightNumber);
                    }

                    else if (inputParams[1].ToLower() == "up")
                    {
                        currentLeftNumber = cubeA.TurnUp(currentLeftNumber);
                        Console.WriteLine("   " + currentLeftNumber + " " + currentRightNumber);
                    }

                    else if (inputParams[1].ToLower() == "down")
                    {
                        currentLeftNumber = cubeA.TurnDown(currentLeftNumber);
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
                else if(inputParams[0].ToLower() == "right")
                {
                    if (inputParams[1].ToLower() == "left")
                    {
                        var newIndex = cubeB.TurnLeft(currentRightNumber);
                        currentRightNumber = cubeB.FrontLineNumbers[newIndex];
                        Console.WriteLine("   " + currentLeftNumber + " " + currentRightNumber);
                    }

                    else if (inputParams[1].ToLower() == "right")
                    {
                        var newIndex = cubeB.TurnRight(currentRightNumber);
                        currentRightNumber = cubeB.FrontLineNumbers[newIndex];
                        Console.WriteLine("   " + currentLeftNumber + " " + currentRightNumber);
                    }

                    else if (inputParams[1].ToLower() == "up")
                    {
                        currentRightNumber = cubeB.TurnUp(currentRightNumber);
                        Console.WriteLine("   " + currentLeftNumber + " " + currentRightNumber);
                    }

                    else if (inputParams[1].ToLower() == "down")
                    {
                        currentRightNumber = cubeB.TurnDown(currentRightNumber);
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
                
                else if (inputParams[0].ToLower() == "rotate" && inputParams[1].ToLower() == "cubes")
                {
                    var currentCube = cubeA;
                    cubeA = cubeB;
                    cubeB = currentCube;
                    currentLeftNumber = 1;
                    currentRightNumber = 1;
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
