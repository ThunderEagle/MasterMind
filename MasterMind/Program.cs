using System;
using ColoredConsole;
using MasterMind.Logic;
using Microsoft.Extensions.DependencyInjection;

namespace MasterMind
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var container = SetupContainer();

			var gameControl = container.GetRequiredService<IGameControl>();
			gameControl.ExecuteGame();

			ColorConsole.WriteLine("Press ENTER to terminate program.");
			Console.ReadLine();
		}


		private static ServiceProvider SetupContainer()
		{
			var container = new ServiceCollection();

			ConfigureServices.Configure(container);

			container.AddTransient<IGameControl, GameControl>();

			return container.BuildServiceProvider();
		}
	}
}