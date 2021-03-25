using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MarsRoverAydin2
{
    static class General
    {
        public static readonly Plateaus Plateau;
        public static readonly List<String> PlateauOuts;

        static General()
        {
            Plateau = new Plateaus();
            PlateauOuts = new List<String>();
        }


        public enum Directions
        {
            N,
            E,
            S,
            W
        }

        private static string[] ReadAndSplit(string ScreenMessage)
        {
            Console.WriteLine(ScreenMessage);
            string ReadObject = Console.ReadLine().ToString().ToUpper();

            if (ReadObject == "PLATEAU")
                WriteAndInvoke(null, "CreatePlateau");

            return ReadObject.Split(" ");
        }

        private static void WriteAndInvoke(string ScreenMessage, string MethodName)
        {
            if (ScreenMessage != null)
                Console.WriteLine(ScreenMessage);

            
            MethodInfo[] methods = typeof(General).GetMethods();
            foreach (MethodInfo info in methods)
            {
                if (info.Name == MethodName)
                    info.Invoke(null, null);
            }
        }

        private static void isValidGoOnSteps(string steps)
        {
            for (int i = 0; i < steps.Length; i++)
            {
                if (steps[i] !='L' && steps[i] != 'R' && steps[i] != 'M')
                    WriteAndInvoke("Error Rover Control!.. Enter L or R or M", "ReadSteps");
            }
        }




        public static void CreatePlateau()
        {
            var ReadCoordinates = General.ReadAndSplit("Enter Plateau Coordinates(x y) : ");

            if (ReadCoordinates.Length != 2)
                WriteAndInvoke("Error Plateau Coordinates!!!!", "CreatePlateau");

            if (!int.TryParse(ReadCoordinates[0], out int n) || !int.TryParse(ReadCoordinates[1], out int m))
                WriteAndInvoke("Error Plateau Coordinates!!!!", "CreatePlateau");

            Plateau.Set(int.Parse(ReadCoordinates[0]), int.Parse(ReadCoordinates[1]));
        }

        public static Rovers CreateRover()
        {
            var RoverDetail = General.ReadAndSplit("Enter Rover Coordinates and Direction (x y N) : ");

            if (RoverDetail.Length != 3)
                WriteAndInvoke("Error Rover Detail!!!!", "CreateRover");

            if (!int.TryParse(RoverDetail[0], out int n) || !int.TryParse(RoverDetail[1], out int m))
                WriteAndInvoke("Error Rover Coordinates!!!!", "CreateRover");


            Directions roverDirection = Directions.N;
            try
            {
                roverDirection = Enum.Parse<Directions>(RoverDetail[2].ToUpper());
            }
            catch
            {
                WriteAndInvoke("Error Rover Direction!..Undefined Direction", "CreateRover");
            }

            Rovers Rover = new Rovers(int.Parse(RoverDetail[0]), int.Parse(RoverDetail[1]), roverDirection);

            return Rover;
        }

        public static string ReadSteps()
        {
            var steps = General.ReadAndSplit("Enter Simple String For Rover Control(LMLMLMLMM) :");

            isValidGoOnSteps(steps[0]);
            return steps[0];

        }

    }
}
