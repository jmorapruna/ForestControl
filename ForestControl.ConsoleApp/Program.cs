using ForestControl.Core;
using ForestControl.Core.Models;
using ForestControl.Core.Services;
using System;

namespace ForestControl.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintBanner();

            IInstructionReaderService instructionReaderService = new InstructionReaderService();

            string areaDimensionsLine = Console.ReadLine();
            var initialPosition = instructionReaderService.ReadAreaDimensions(areaDimensionsLine);

            while (true)
            {
                string firstLine = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(firstLine))
                    return;

                string secondLine = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(secondLine))
                    return;

                var instructions = instructionReaderService.ReadTwoLinesOfInstructions(firstLine, secondLine);
                var drone = new Drone(instructions.InitialPosition, instructions.InitialDirection, initialPosition);

                foreach (var step in instructions.Steps)
                {
                    drone.ExecuteStep(step);
                }

                Console.WriteLine($"{drone.Position.X} {drone.Position.Y} {drone.Direction.GetCode()}");
            }
        }

        private static void PrintBanner()
        {
            Console.WriteLine(@"
                                 ____                             __      
                                /\  _`\                          /\ \__   
                                \ \ \L\_\___   _ __    __    ____\ \ ,_\  
                                 \ \  _\/ __`\/\`'__\/'__`\ /',__\\ \ \/  
                                  \ \ \/\ \L\ \ \ \//\  __//\__, `\\ \ \_ 
                                   \ \_\ \____/\ \_\\ \____\/\____/ \ \__\
                                    \/_/\/___/  \/_/ \/____/\/___/   \/__/
                                          
                                          
                                 ____                    __                 ___      
                                /\  _`\                 /\ \__             /\_ \     
                                \ \ \/\_\    ___     ___\ \ ,_\  _ __   ___\//\ \    
                                 \ \ \/_/_  / __`\ /' _ `\ \ \/ /\`'__\/ __`\\ \ \   
                                  \ \ \L\ \/\ \L\ \/\ \/\ \ \ \_\ \ \//\ \L\ \\_\ \_ 
                                   \ \____/\ \____/\ \_\ \_\ \__\\ \_\\ \____//\____\
                                    \/___/  \/___/  \/_/\/_/\/__/ \/_/ \/___/ \/____/



                                Welcome to Forest Control

                                Enter the dimensions of the drone area in the first line,
                                followed by a sequence of pairs of instructions lines.

");
        }
    }
}
