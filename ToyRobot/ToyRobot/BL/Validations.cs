using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Configurables;

namespace ToyRobot.BL
{
	public static class Validations
	{
		internal static bool ValidateInput(string input, int xMax, int yMax, bool freshRequest = false)
		{
			try
			{
				if (input != null && input.Length == 0)
				{
					Console.WriteLine("No string was provided. Please enter a valid input.");
					return false;
				}
				input = input.ToLower();
				if (freshRequest)
				{
					if (!input.StartsWith(AllowedCommands.place.ToString()))
					{
						Console.WriteLine("Please use the 'Place' command to first place the robot on the board.");
						return false;
					}
					else
					{
						string[] arrPlace = input.Replace($"{AllowedCommands.place.ToString()} ", "").Split(',');
						if (arrPlace.Length != 3)
						{
							Console.WriteLine("First place should have x-coordinate, y-coordinate and the direction as the parameters with the input.");
							return false;
						}
						else
						{
							if (!ValidateDirection(arrPlace[2]))
							{
								Console.WriteLine("Please check the direction provided in the input.");
								return false;
							}
							else if (!ValidateCoordinates(arrPlace[0], arrPlace[1], xMax, yMax))
							{
								Console.WriteLine("Please check the coordinated provided in the input.");
								return false;
							}
							return true;
						}
					}
				}
				else
				{
					var temp = input.Split(' ');
					if (!ValidateCommand(temp[0]))
					{
						Console.WriteLine("Please enter a valid command.");
						return false;
					}
					if (temp[0] == AllowedCommands.place.ToString())
					{
						string[] arrPlace = temp[1].Split(',');
						if (arrPlace.Length == 2)
						{
							if (!ValidateCoordinates(arrPlace[0], arrPlace[1], xMax, yMax))
							{
								Console.WriteLine("Please check the coordinates provided in the input.");
								return false;
							}
							return true;
						}
						else if (arrPlace.Length == 3)
						{
							if (!ValidateDirection(arrPlace[2]))
							{
								Console.WriteLine("Please check the value of direction provided in the input.");
								return false;
							}
							else if (!ValidateCoordinates(arrPlace[0], arrPlace[1], xMax, yMax))
							{
								Console.WriteLine("Please check the coordinated provided in the input.");
								return false;
							}
							return true;
						}
						else
						{
							Console.WriteLine("Please provide the required parameters with the 'Place' command.");
							return false;
						}
					}
					else if (temp[0] == AllowedCommands.move.ToString())
					{
						return true;
					}
					else if (temp[0] == AllowedCommands.left.ToString())
					{
						return true;
					}
					else if (temp[0] == AllowedCommands.right.ToString())
					{
						return true;
					}
					else if (temp[0] == AllowedCommands.report.ToString())
					{
						return true;
					}
					else
					{
						return false;
					}
				}

			}
			catch (Exception)
			{
				Console.WriteLine("Please enter a valid input.");
				return false;
			}

		}

		internal static bool ValidateCommand(string command)
		{
			if (Enum.IsDefined(typeof(AllowedCommands), command.ToLower()))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		internal static bool ValidateDirection(string direction)
		{
			if (Enum.IsDefined(typeof(AllowedDirections), direction.ToLower()))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		internal static bool ValidateCoordinates(string x, string y, int xMax, int yMax)
		{
			try
			{
				int x_int = Convert.ToInt32(x);
				int y_int = Convert.ToInt32(y);
				if (x_int >= 0 && x_int < xMax && y_int >= 0 && y_int < yMax)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception ex)
			{
				return false;
			}
		}
	}
}
