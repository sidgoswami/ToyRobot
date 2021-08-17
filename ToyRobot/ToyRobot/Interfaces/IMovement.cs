using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Models;

namespace ToyRobot
{
	internal interface IMovement<T>
	{
		bool Place(T selectedItem, int x, int y, string direction);
		bool Move(T selectedItem);
		void TurnLeft(T selectedItem);
		void TurnRight(T selectedItem);
		void Report(T selectedItem);
	}
}
