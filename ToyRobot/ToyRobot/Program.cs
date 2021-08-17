using System;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using ToyRobot.Models;
using ToyRobot.Services;

namespace ToyRobot
{
	class Program
	{
		static void Main(string[] args)
		{				
			Initialise();
		}

		static void Initialise() 
		{
			int xMax = 6;
			int yMax = 6;
			Console.WriteLine("Welcome to ToyRobot!!!");
			Console.WriteLine($"To begin, please place the robot to the desired location within x-coordinates (0,{xMax}) and y-coordinates (0,{yMax})");			
			IMovement<Robot> robotMovement = new MovementService(xMax,yMax);
			MovingRobot obj = new MovingRobot(robotMovement, xMax, yMax);
			obj.Process();
		}		
	}
}
