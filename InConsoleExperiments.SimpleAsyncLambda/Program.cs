using System;
using System.Threading.Tasks;

namespace InConsoleExperiments.SimpleAsyncLambda
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			var a = new int[] { 1, 2, 3, 4 };

			Func<int, Task<int>> op = async x => await Task.Run(() => x++);

			Func<Task> ainc = async () =>
			{
				for (int i = 0; i < a.Length; i++)
				{
					await op(a[i]);
				}
			};

			ainc();
		}
	}
}