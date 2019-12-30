using MasterMind.Logic.Models;
using NUnit.Framework;

namespace MasterMind.Logic.Tests
{
	[TestFixture]
	public class GameTests
	{
		private readonly int[] _badCode = {1, 6, 2, 4};
		private readonly int[] _correctCode = {1, 2, 3, 4};
		private readonly Score[] _crackedScore = {Score.Correct, Score.Correct, Score.Correct, Score.Correct};
		private readonly Score[] _notCrackedScore = {Score.Correct, Score.NotInCode, Score.IncorrectPosition, Score.Correct};

		private Game GetObject() => new Game {MasterCode = _correctCode};

		[Test]
		public void IsGameOver_CodeIsCracked_True()
		{
			var sut = GetObject();
			for(var i = 0; i < 5; i++)
			{
				sut.Attempts.Add(new Guess {Code = _badCode, Score = _notCrackedScore});
			}

			sut.Attempts.Add(new Guess {Code = _correctCode, Score = _crackedScore});

			var actual = sut.IsGameOver;
			Assert.True(actual);
		}

		[Test]
		public void IsGameOver_CodeNotCrackedUnderMaxAttempts_False()
		{
			var sut = GetObject();
			for(var i = 0; i < 5; i++)
			{
				sut.Attempts.Add(new Guess {Code = _badCode, Score = _notCrackedScore});
			}

			var actual = sut.IsGameOver;
			Assert.False(actual);
		}

		[Test]
		public void IsGameOver_GreaterOrEqualMaxAttempts_True()
		{
			var sut = GetObject();
			for(var i = 0; i < 10; i++)
			{
				sut.Attempts.Add(new Guess {Code = _badCode, Score = _notCrackedScore});
			}


			var actual = sut.IsGameOver;
			Assert.True(actual);
		}

		[Test]
		public void IsTheCodeCracked_Cracked_True()
		{
			var sut = GetObject();
			sut.Attempts.Add(new Guess {Code = _correctCode, Score = _crackedScore});

			var actual = sut.IsTheCodeCracked;
			Assert.True(actual);
		}

		[Test]
		public void IsTheCodeCracked_NotCracked_False()
		{
			var sut = GetObject();
			sut.Attempts.Add(new Guess {Code = _badCode, Score = _notCrackedScore});

			var actual = sut.IsTheCodeCracked;
			Assert.False(actual);
		}

		[Test]
		public void IsTheCodeCracked_OverMaxAttempts_False()
		{
			var sut = GetObject();
			for(var i = 0; i < 10; i++)
			{
				sut.Attempts.Add(new Guess {Code = _badCode, Score = _notCrackedScore});
			}

			sut.Attempts.Add(new Guess {Code = _correctCode, Score = _crackedScore});

			var actual = sut.IsTheCodeCracked;
			Assert.False(actual);
		}
	}
}