using System;

namespace MasterMind.Logic
{
	internal class CodeGeneration : ICodeGeneration
	{
		private const int SEQUENCE_LENGTH = 4;
		private const int MIN_VALUE = 1;
		private const int MAX_VALUE = 6;

		public int[] GenerateCode()
		{
			var random = new Random();
			var code = new int[SEQUENCE_LENGTH];
			for(var i = 0; i < SEQUENCE_LENGTH; i++)
			{
				//exclusive upper bound
				code[i] = random.Next(MIN_VALUE, MAX_VALUE + 1);
			}

			return code;
		}
	}
}