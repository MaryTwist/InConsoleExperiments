using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InConsoleExperiments
{
	class MainClass
	{
		delegate Task aMap(List<DummyModel> l);

		public static void Main(string[] args)
		{
			Console.WriteLine("New population!");
			Console.WriteLine("Walking through it...");

			var population = DummyModel.Populate(5, 2, 6);

			/*Func<List<DummyModel>, Task>*/aMap walkThrough = null;

			walkThrough = async (l) =>
			{
				await Task.Run(async () =>
				{
					foreach (var d in l)
					{
						var ofst = int.Parse(d.Value.Split('-')[0]);

						Console.WriteLine(string.Empty.PadLeft(ofst, '-') + "> " + d.Value);

						if (d.HasChildrens)
							await walkThrough(d.Childrens);
					}
				});
			};

			walkThrough(population).Wait();

			Console.WriteLine("Done");
		}
	}
}
