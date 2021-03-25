using System;

namespace MarsRoverAydin2
{
    class Program
    {
        static void Main(string[] args)
        {
            General.CreatePlateau();

            while (1 == 1)
            {
                Rovers Rover = General.CreateRover();
                String Steps = General.ReadSteps();

                Rover.GoOn(Steps);

                if (Rover.OutPlateau)
                {
                    Console.WriteLine("Rover is Out Plateau!!..");
                    General.PlateauOuts.Add(Rover.GetDetail());
                }

                if (Rover.PassedOutPlateau)
                    Console.WriteLine("from this point previously exited from the plateau!!!");

                Console.WriteLine(Rover.GetDetail());
            }

        }



    }
}
