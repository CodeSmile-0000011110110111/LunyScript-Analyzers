using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.IO;

namespace LunyScript.Analyzers
{
	[Generator]
	public sealed class LunyScriptGenerator : IIncrementalGenerator
	{
		public void Initialize(GeneratorInitializationContext context) {}
		public void Initialize(IncrementalGeneratorInitializationContext context)
		{
			var provider = context.SyntaxProvider.CreateSyntaxProvider(
				predicate: (node, _) => node is ClassDeclarationSyntax c /*&& c.Identifier.Text == "MyTargetClass"*/,
				transform: (ctx, _) => ctx.Node.ToString() // Or extract specific data
			);

			context.RegisterSourceOutput(provider, (productionContext, className) =>
			{
				var message = $"{DateTime.Now}: LUNYSCRIPT ROSLYN: {className}";
				File.AppendAllText("U:\\roslyntest.txt", message + "\n");

				//productionContext.AddSource("GeneratedProperty.g.cs", $@"partial class MyTargetClass {{ public int MyInjectedProperty => 42; }}");
			});
		}
	}
}
