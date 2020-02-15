using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Model
{
    public interface IRover
    {
        Location RoverLocation { get; set; }
        string RoverCommands { get; set; }
        void TurnLeft();
        void TurnRight();
        void Move();
    }
    public class Rover : IRover
    {
        public Location RoverLocation { get; set; }
        public string RoverCommands { get; set; }

        public Rover(Location location,string commands)
        {
            RoverLocation = location;
            RoverCommands = commands;
        }

        public void Move()
        {
            switch (RoverLocation.CurrentDirection)
            {
                case eDirection.E:
                    RoverLocation.XPosition += 1;
                    break;
                case eDirection.W:
                    RoverLocation.XPosition -= 1;
                    break;
                case eDirection.S:
                    RoverLocation.YPosition -= 1;
                    break;
                case eDirection.N:
                    RoverLocation.YPosition += 1;
                    break;
                default:
                    throw new SystemException("Incorrect Direction");

            }       
        }

        public void TurnLeft()
        {
            switch (RoverLocation.CurrentDirection)
            {
                case eDirection.E:
                    RoverLocation.CurrentDirection = eDirection.N;
                    break;
                case eDirection.W:
                    RoverLocation.CurrentDirection = eDirection.S;
                    break;
                case eDirection.S:
                    RoverLocation.CurrentDirection = eDirection.E;
                    break;
                case eDirection.N:
                    RoverLocation.CurrentDirection = eDirection.W;
                    break;
                default:
                    throw new SystemException("Incorrect Direction");

            }
        }

        public void TurnRight()
        {
            switch (RoverLocation.CurrentDirection)
            {
                case eDirection.E:
                    RoverLocation.CurrentDirection = eDirection.S;
                    break;
                case eDirection.W:
                    RoverLocation.CurrentDirection = eDirection.N;
                    break;
                case eDirection.S:
                    RoverLocation.CurrentDirection = eDirection.W;
                    break;
                case eDirection.N:
                    RoverLocation.CurrentDirection = eDirection.E;
                    break;
                default:
                    throw new SystemException("Incorrect Direction");
            }
        }
    }
}
