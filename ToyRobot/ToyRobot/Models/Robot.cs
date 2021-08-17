﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.Models
{
	internal class Robot
	{
		public int XCoordinate { get; set; }
		public int YCoordinate { get; set; }
		public string Direction { get; set; }
		
		public string GetDetails {
			get {
				return $"{XCoordinate},{YCoordinate},{Direction}";
			}
		}
	}
}
