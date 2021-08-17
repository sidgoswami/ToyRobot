using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.BL
{
	public static class Formatter
	{
		public static string CapitaliseFirstLetter(string text) 
		{
			if (text != null && text.Length != 0 )
			{
				if (text.Length == 1)
				{
					return text.ToUpper();
				}
				else
				{
					return text.First().ToString().ToUpper() + text.Substring(1);
				}
			}
			return "";
		}
	}
}
