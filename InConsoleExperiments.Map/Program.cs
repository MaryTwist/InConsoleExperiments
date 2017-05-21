using System;
using System.Text;

using InConsoleExperiments.Common;

namespace InConsoleExperiments.Map
{
	class MainClass
	{
		public static void HR(string subject)
		{
			Console.WriteLine();
			Console.WriteLine("{0} ({1}) {0}",
				string.Empty.PadLeft(20, '-'),
				subject);
		}

		public static void Main(string[] args)
		{
			HR("Map");

			var a = new int[] { 2, 4, 6, 7, 8, 10, 67 };

			var b = new StringBuilder[]
			{
				new StringBuilder(),
				new StringBuilder()
			};

			var c = (a.Map(i => b[0].AppendFormat("{0} ", i))
				      .Map(i => ++i)
				      .Map(i => b[1].AppendFormat("{0} ", i))
			          .Convert(i => (double)i));

			b.Map((o) => Console.WriteLine(o));

			c.Map(i => i * 2.1)
			 .Map(i => Console.Write("{0} ", i));

			HR("Convert, Map");

			DummyModel.Populate(20, 0, 0)
			          .Convert(m => new
						{
							id = int.Parse(m.Value.Split('-')[1]) + 1
						})
			          .Map(o => Console.Write("{0} ", o.id));

			HR("Req");

			DummyModel.Populate(4, 1, 3)
			          .Recursion(m =>
			{
				var ofst = int.Parse(m.Value.Split('-')[0]);
				Console.WriteLine(string.Empty.PadLeft(ofst, '-') + "> " + m.Value);
				return m.Childrens;
			});

			HR("ToDictionary");

			CreepyModel.Populate(10)
					   .Map(o => o.ToDictionary()
							.Map(p => Console.WriteLine("Creepy.{0} = {1}",
			                                            p.Key, p.Value)));

			HR("ToDictionary.Selector");

			CreepyModel.Populate(12)
					   .Map(o => o.ToDictionary(s => new
					   {
						   Id = s.IntProp,
						   Value = s.TextProp
					   })
					   .Map(n => Console.WriteLine("New.{0} = {1}",
												n.Key, n.Value)));
		}
	}
}