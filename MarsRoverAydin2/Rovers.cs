using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverAydin2
{
    class Rovers : Coordinate
    {
        public General.Directions Direction { get; set; }
        public bool OutPlateau=false;
        public bool PassedOutPlateau = false;

        public Rovers()
        {

        }
        public Rovers(int X,int Y, General.Directions directions)
        {
            this.X = X;
            this.Y = Y;
            this.Direction = directions;
        }



        public void GoOn(string steps)
        {
            for (int i = 0; i < steps.Length; i++)
            {
                if (steps[i] == 'M')
                {
                    if (!Move())
                    {
                        OutPlateau = true;
                        return;
                    }

                    if (General.PlateauOuts.Contains(GetDetail()))
                    {
                        PassedOutPlateau = true;
                        return;
                    }
                }
                else
                    Spin(steps[i]);
            }
        }

        public string GetDetail()
        {
            return X.ToString() + " " + Y.ToString() + " " + Direction.ToString();
        }

        private bool Move()
        {
            int Available_X = this.X;
            int Available_Y = this.Y;

            switch (Direction)
            {
                case General.Directions.N:
                    Available_Y++;
                    break;
                case General.Directions.S:
                    Available_Y--;
                    break;
                case General.Directions.W:
                    Available_X--;
                    break;
                case General.Directions.E:
                    Available_X++;
                    break;
            }

            if (Available_X < 0 || Available_Y < 0 || Available_X > General.Plateau.Get("X") || Available_Y > General.Plateau.Get("Y"))
                return false;

            X = Available_X;
            Y = Available_Y;
            return true;

        }

        private void Spin(Char step)
        {
            int NumDirection = (int)Direction;

            if (step == 'L')
                NumDirection--;
            else
                NumDirection++;

            if (NumDirection == -1)
                NumDirection = 3;

            if (NumDirection == 4)
                NumDirection = 0;

            Direction = (General.Directions)NumDirection;
        }

        
    }


}
