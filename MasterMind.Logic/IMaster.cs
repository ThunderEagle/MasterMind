using MasterMind.Logic.Models;

namespace MasterMind.Logic
{
	public interface IMaster
	{
		Game StartGame();
		void SubmitGuess(Game game, int[] code);
	}
}