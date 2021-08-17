using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.BL;
using ToyRobot.Configurables;
using ToyRobot.Models;

namespace ToyRobot.Services
{
	internal class MovementService : IMovement<Robot>
	{
		private readonly int _maxX;
		private readonly int _maxY;

		public MovementService(int maxX, int maxY)
		{
			this._maxX = maxX;
			this._maxY = maxY;
		}

		public bool Place(Robot robot, int x, int y, string direction)
		{
			//for first command check if direction is provided, else can work
			//also check if point is in the bounds
			if (Validations.ValidateCoordinates(x.ToString(), y.ToString(), this._maxX, this._maxY))
			{
				robot.XCoordinate = x;
				robot.YCoordinate = y;
				if (direction != "")
				{
					robot.Direction = direction;
				}
				return true;
			}
			else
			{
				return false;
			}
		}
		public bool Move(Robot robot)
		{
			//validate if it is not a deadend , if not move
			//increase the robot step by 1 based on the direction
			Robot tempRobot = new Robot() { XCoordinate = robot.XCoordinate, YCoordinate = robot.YCoordinate, Direction = robot.Direction };

			if (tempRobot.Direction.ToLower() == AllowedDirections.north.ToString())
			{
				tempRobot.YCoordinate++;
			}
			else if (tempRobot.Direction.ToLower() == AllowedDirections.south.ToString())
			{
				tempRobot.YCoordinate--;
			}
			else if (tempRobot.Direction.ToLower() == AllowedDirections.east.ToString())
			{
				tempRobot.XCoordinate++;
			}
			else if (tempRobot.Direction.ToLower() == AllowedDirections.west.ToString())
			{
				tempRobot.XCoordinate--;
			}
			else
			{
				return false;
			}			
			if (Validations.ValidateCoordinates(tempRobot.XCoordinate.ToString(), tempRobot.YCoordinate.ToString(), this._maxX, this._maxY)) 
			{
				robot.XCoordinate = tempRobot.XCoordinate;
				robot.YCoordinate = tempRobot.YCoordinate;
				return true;
			}
			else
			{
				return false;
			}
		}	

		public void TurnLeft(Robot robot)
		{
			//change direction of the bot
			if (robot.Direction.ToLower() == AllowedDirections.north.ToString())
			{
				robot.Direction = Formatter.CapitaliseFirstLetter(AllowedDirections.west.ToString());
			}
			else if (robot.Direction.ToLower() == AllowedDirections.south.ToString())
			{
				robot.Direction = Formatter.CapitaliseFirstLetter(AllowedDirections.east.ToString());
			}
			else if (robot.Direction.ToLower() == AllowedDirections.east.ToString())
			{
				robot.Direction = Formatter.CapitaliseFirstLetter(AllowedDirections.north.ToString());
			}
			else if (robot.Direction.ToLower() == AllowedDirections.west.ToString())
			{
				robot.Direction = Formatter.CapitaliseFirstLetter(AllowedDirections.south.ToString());
			}			
		}

		public void TurnRight(Robot robot)
		{
			//change direction of the bot
			if (robot.Direction.ToLower() == AllowedDirections.north.ToString())
			{
				robot.Direction = Formatter.CapitaliseFirstLetter(AllowedDirections.east.ToString());
			}
			else if (robot.Direction.ToLower() == AllowedDirections.south.ToString())
			{
				robot.Direction = Formatter.CapitaliseFirstLetter(AllowedDirections.west.ToString());
			}
			else if (robot.Direction.ToLower() == AllowedDirections.east.ToString())
			{				
				robot.Direction = Formatter.CapitaliseFirstLetter(AllowedDirections.south.ToString());
			}
			else if (robot.Direction.ToLower() == AllowedDirections.west.ToString())
			{
				robot.Direction = Formatter.CapitaliseFirstLetter(AllowedDirections.north.ToString());				
			}
		}
		public void Report(Robot robot)
		{
			Console.WriteLine(robot.GetDetails);			
		}		
	}
}
