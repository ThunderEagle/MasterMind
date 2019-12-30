using System;
using MasterMind.Logic.Models;
using NUnit.Framework;

namespace MasterMind.Logic.Tests
{
	[TestFixture]
	public class ScoreAttemptTests
	{
		private ScoreAttempt GetObject() => new ScoreAttempt();

		[Test]
		public void Score_CodeLengthDoesNotMatchMasterLength_Exception()
		{
			var masterCode = new[] {1, 2, 3, 4};
			var code = new[] {1, 2, 3, 4, 5};
			var sut = GetObject();

			Assert.Throws<InvalidOperationException>(() => sut.Score(masterCode, code));
		}

		[Test]
		public void Score_DigitInCorrectPosition_ScoreIsNotInCode()
		{
			var masterCode = new[] {1, 2, 3, 4};
			var code = new[] {1, 2, 3, 4};
			var sut = GetObject();

			var expected = new[] {Score.Correct, Score.Correct, Score.Correct, Score.Correct};

			var actual = sut.Score(masterCode, code);

			CollectionAssert.AreEquivalent(expected, actual.Score);
		}

		[Test]
		public void Score_DigitInWrongPosition_ScoreIsIncorrectPosition()
		{
			var masterCode = new[] {1, 2, 3, 4};
			var code = new[] {2, 5, 5, 5};
			var sut = GetObject();

			var expected = new[] {Score.IncorrectPosition, Score.NotInCode, Score.NotInCode, Score.NotInCode};

			var actual = sut.Score(masterCode, code);

			CollectionAssert.AreEquivalent(expected, actual.Score);
		}

		[Test]
		public void Score_DigitNotInMaster_ScoreIsNotInCode()
		{
			var masterCode = new[] {1, 2, 3, 4};
			var code = new[] {6, 6, 6, 6};
			var sut = GetObject();

			var expected = new[] {Score.NotInCode, Score.NotInCode, Score.NotInCode, Score.NotInCode};

			var actual = sut.Score(masterCode, code);

			CollectionAssert.AreEquivalent(expected, actual.Score);
		}
	}
}