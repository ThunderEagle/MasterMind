using MasterMind.Logic.Models;

namespace MasterMind.Logic
{
	public class Master : IMaster
	{
		private readonly ICodeGeneration _codeGeneration;
		private readonly IScoreAttempt _scoreAttempt;

		public Master(ICodeGeneration codeGeneration, IScoreAttempt scoreAttempt)
		{
			_codeGeneration = codeGeneration;
			_scoreAttempt = scoreAttempt;
		}

		public Game StartGame()
		{
			var game = new Game {MasterCode = _codeGeneration.GenerateCode()};
			return game;
		}

		public void SubmitGuess(Game game, int[] code)
		{
			game.Attempts.Add(_scoreAttempt.Score(game.MasterCode, code));
		}
	}
}