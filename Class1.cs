using Microsoft.CodeAnalysis;
using System;
using System.IO;

namespace LunyScript.Analyzers
{
	[Generator]
	public sealed class ExampleSourceGen : ISourceGenerator
	{
		public void Execute(GeneratorExecutionContext context)
		{
			var message = $"{DateTime.Now}: LUNYSCRIPT ROSLYN: {context.Compilation.AssemblyName}";
			Console.WriteLine(message);

			File.AppendAllText("U:\\roslyntest.txt", message + "\n");

		}

		public void Initialize(GeneratorInitializationContext context) {}
	}
}
