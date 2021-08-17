using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.BL;
using ToyRobot.Configurables;
using ToyRobot.Models;

namespace ToyRobot
{
	internal class MovingRobot
	{		
		internal int xMax;
		internal int yMax;
		private IMovement<Robot> _movement;
		public MovingRobot(IMovement<Robot> movement, int xMax, int yMax)
		{
			_movement = movement;
			this.xMax = xMax;
			this.yMax = yMax;
		}

		public void Process() 
		{
			bool continueLoop = true;
			Robot robot = null;			
			while (continueLoop)
			{
				var input = Console.ReadLine();
				var isFirstRequest = robot == null ? true : false;
				if (!Validations.ValidateInput(input, xMax, yMax, isFirstRequest))
				{
					continue;
				}
				if (isFirstRequest)
				{
					robot = new Robot();
				}
				if (input.ToLower().StartsWith(AllowedCommands.place.ToString()))
				{
					string[] arrInput = input.Replace($"{AllowedCommands.place.ToString() }", "").Split(',');
					if (arrInput.Length == 3)
					{
						if (!_movement.Place(robot, Convert.ToInt32(arrInput[0]), Convert.ToInt32(arrInput[1]), arrInput[2]))
						{
							Console.WriteLine("Please place the robot inside the designated boundaries.");	
						}						
					}
					else
					{
						if (!_movement.Place(robot, Convert.ToInt32(arrInput[0]), Convert.ToInt32(arrInput[1]), ""))
						{
							Console.WriteLine("Please place the robot inside the designated boundaries.");
						}
					}
				}
				else if(input.ToLower().StartsWith(AllowedCommands.move.ToString()))
				{
					if (!_movement.Move(robot))
					{
						Console.WriteLine("This movement is not allowed as the robot is facing towards the end of the boundary.");
					}
				}
				else if (input.ToLower().StartsWith(AllowedCommands.left.ToString()))
				{
					_movement.TurnLeft(robot);					
				}
				else if (input.ToLower().StartsWith(AllowedCommands.right.ToString()))
				{
					_movement.TurnRight(robot);
				}
				else if (input.ToLower().StartsWith(AllowedCommands.report.ToString()))
				{
					_movement.Report(robot);
				}
			}
		}		
	}
}
