using System;
using System.Linq;
using System.Runtime.CompilerServices;
using MasterMind.Logic.Models;

[assembly: InternalsVisibleTo("MasterMind.Logic.Tests")]

namespace MasterMind.Logic
{
	internal class ScoreAttempt : IScoreAttempt
	{
		public Guess Score(int[] masterCode, int[] code)
		{
			var size = masterCode.Length;
			if(code.Length != size)
			{
				throw new InvalidOperationException("Master Code and guess code length are not the same.");
			}

			var guess = new Guess {Code = code, Score = new Score[size]};

			for(var i = 0; i < size; i++)
			{
				if(masterCode[i] == code[i])
				{
					guess.Score[i] = Models.Score.Correct;
					continue;
				}

				if(masterCode.Any(d => d == code[i]))
				{
					guess.Score[i] = Models.Score.IncorrectPosition;
					continue;
				}

				guess.Score[i] = Models.Score.NotInCode;
			}

			return guess;
		}
	}
}