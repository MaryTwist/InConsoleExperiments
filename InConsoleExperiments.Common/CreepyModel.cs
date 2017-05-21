using System;
using System.Collections.Generic;

namespace InConsoleExperiments.Common
{
	public class CreepyModel
	{
		private static Random rand = new Random();

		public int IntProp { get; set; }
		public string TextProp { get; set; }
		public bool BoolProp { get; set; }

		public CreepyModel()
		{ }

		private static string generateDummyStr()
		{
			var chars = "abcdefghigklmnopqrstuvwxyz0123456789";
			var lenght = rand.Next(10, 50);
			var b = new System.Text.StringBuilder();
			for (int i = 0; i < lenght; i++)
				b.Append(chars[rand.Next(0, chars.Length)]);

			return b.ToString();
		}

		public static List<CreepyModel> Populate(int size)
		{
			var l = new List<CreepyModel>();

			for (int i = 0; i < size; i++)
			{
				l.Add(new CreepyModel
				{
					IntProp = rand.Next(),
					TextProp = generateDummyStr(),
					BoolProp = rand.Next(0, 2) > 0
				});
			}

			return l;
		}
	}
}
