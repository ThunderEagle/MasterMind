using Microsoft.Extensions.DependencyInjection;

namespace MasterMind.Logic
{
	public static class ConfigureServices
	{
		public static void Configure(IServiceCollection serviceCollection)
		{
			serviceCollection.AddTransient<IMaster, Master>();
			serviceCollection.AddTransient<ICodeGeneration, CodeGeneration>();
			serviceCollection.AddTransient<IScoreAttempt, ScoreAttempt>();
		}
	}
}