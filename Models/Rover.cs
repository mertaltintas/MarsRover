using MarsRover.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Models
{
    public class Rover : IRoverService
    {
        public Directions direction { get; set; }
        public (int x, int y) coord { get; set; }
        public string pendingInstructions { get; set; }
        public Rover(int startingX, int startingY, Directions startingDirection)
        {
            coord = (startingX, startingY);
            direction = startingDirection;
        }
        private void RotateLeft()
        {
            if (direction == Directions.N)
                direction = Directions.W;
            else
                direction = --direction;
        }
        private void RotateRight()
        {
            if (direction == Directions.W)
                direction = Directions.N;
            else
                direction = ++direction;
        }
        private void MoveForward(Plateau plateau)
        {
            switch (direction)
            {
                case Directions.N:
                    coord = (coord.x, coord.y + 1);
                    break;
                case Directions.E:
                    coord = (coord.x + 1, coord.y);
                    break;
                case Directions.S:
                    coord = (coord.x, coord.y - 1);
                    break;
                case Directions.W:
                    coord = (coord.x - 1, coord.y);
                    break;
                default:
                    break;
            }
        }
        public void StartAction(Plateau plateau)
        {
            if (string.IsNullOrEmpty(pendingInstructions))
                throw new Exception($"Pending instructions not found;");

            foreach (var command in pendingInstructions)
            {
                switch (command)
                {
                    case 'L':
                        RotateLeft();
                        break;
                    case 'R':
                        RotateRight();
                        break;
                    case 'M':
                        MoveForward(plateau);
                        break;
                    default:
                        Console.WriteLine($"Unexpected command {command}");
                        break;
                }

                if (coord.x < plateau.left_X ||
                    coord.x > plateau.right_X ||
                    coord.y < plateau.lower_Y ||
                    coord.y > plateau.upper_Y)
                    throw new Exception($"The command is out of plateau coordinates.");
            }

            pendingInstructions = String.Empty;
        }
        public (int x, int y, char direction) GetFinalState()
        {
            return (coord.x, coord.y, direction.ToString().First());
        }
    }
}
