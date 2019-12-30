using MasterMind.Logic.Models;

namespace MasterMind.Logic
{
	public interface IScoreAttempt
	{
		Guess Score(int[] masterCode, int[] code);
	}
}