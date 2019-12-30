using System.Collections.Generic;
using System.Linq;

namespace MasterMind.Logic.Models
{
	public sealed class Game
	{
		private const int MAX_ATTEMPTS = 10;

		public Game() => Attempts = new List<Guess>();

		public int[] MasterCode { get; internal set; }

		public List<Guess> Attempts { get; internal set; }

		public int AttemptCount => Attempts.Count;

		public int MaximumAttempts => MAX_ATTEMPTS;

		public bool IsTheCodeCracked
		{
			get
			{
				if(Attempts != null && Attempts.Any() && AttemptCount <= MAX_ATTEMPTS)
				{
					var currentAttempt = Attempts[AttemptCount - 1];
					return currentAttempt.Score.All(s => s == Score.Correct);
				}

				return false;
			}
		}

		public bool IsGameOver
		{
			get
			{
				if(IsTheCodeCracked)
				{
					return true;
				}

				return AttemptCount >= MAX_ATTEMPTS;
			}
		}
	}
}