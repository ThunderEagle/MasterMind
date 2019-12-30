using System;
using System.Linq;
using ColoredConsole;
using MasterMind.Logic;
using MasterMind.Logic.Models;

namespace MasterMind
{
	internal class GameControl : IGameControl
	{
		private readonly IMaster _master;

		public GameControl(IMaster master) => _master = master;

		public void ExecuteGame()
		{
			var game = StartGame();

			while(!game.IsGameOver)
			{
				ColorConsole.WriteLine("You have".White(), $" {game.MaximumAttempts - game.AttemptCount} ".Green(),
				                       "attempts left.".White());
				int[] code;
				do
				{ } while(!GetGuess(out code));

				_master.SubmitGuess(game, code);
				DisplayResults(game);
			}

			if(game.IsTheCodeCracked)
			{
				ColorConsole.WriteLine("Congratulations, you cracked the code!".White().OnDarkRed());
			}
			else
			{
				ColorConsole.WriteLine("Sorry, you failed to crack the code.".DarkRed().OnWhite());
			}
		}

		private void DisplayResults(Game game)
		{
			foreach(var guess in game.Attempts)
			{
				var code = string.Join(' ', guess.Code);
				ColorConsole.WriteLine(code.Magenta());
				foreach(var score in guess.Score)
				{
					switch(score)
					{
						case Score.Correct:
							ColorConsole.Write("+ ".Green());
							break;
						case Score.IncorrectPosition:
							ColorConsole.Write("- ".Yellow());
							break;

						default:
							ColorConsole.Write("  ".White());
							break;
					}
				}

				ColorConsole.WriteLine();
			}
		}

		private bool GetGuess(out int[] code)
		{
			var validDigits = new[] {1, 2, 3, 4, 5, 6};
			code = new int[4];
			ColorConsole.WriteLine("Enter 4 digits between 1-6 and press enter.".Cyan());
			var input = Console.ReadLine();
			var digits = StripInput(input);
			if(digits.Length != 4)
			{
				ColorConsole.WriteLine("You must only enter 4 digits".Red());
				return false;
			}

			for(var i = 0; i < 4; i++)
			{
				var digit = int.Parse(digits[i].ToString());
				if(!validDigits.Contains(digit))
				{
					ColorConsole.WriteLine("Digits must be between 1-6.".Red());
					return false;
				}

				code[i] = digit;
			}

			return true;
		}

		private char[] StripInput(string input)
		{
			var stripped = input.Where(char.IsDigit).ToArray();
			return stripped;
		}

		private Game StartGame()
		{
			ColorConsole.WriteLine("Generating New Code...".Green());
			return _master.StartGame();
		}
	}
}