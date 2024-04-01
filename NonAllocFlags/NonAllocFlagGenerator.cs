using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

[Generator]
public class NonAllocFlagGenerator : ISourceGenerator
{
    public void Initialize(GeneratorInitializationContext context)
    {
    }

    public void Execute(GeneratorExecutionContext context)
    {
        var processed = false;

        var sourceBuilder = new StringBuilder();
        sourceBuilder.AppendLine($"public static class NonAllocExtensionGenerated");
        sourceBuilder.AppendLine("{");

        foreach (var tree in context.Compilation.SyntaxTrees)
        {
            var model = context.Compilation.GetSemanticModel(tree);
            var root = tree.GetRoot();

            foreach (var enumDeclaration in root.DescendantNodes().OfType<EnumDeclarationSyntax>())
            {
                var enumSymbol = model.GetDeclaredSymbol(enumDeclaration);
                if (enumSymbol == null ||
                    !enumSymbol.GetAttributes().Any(ad => ad.AttributeClass?.Name == "FlagsAttribute"))
                    continue;

                var accessibility = GetAccessModifier(enumSymbol);

                if (accessibility != Accessibility.Public &&
                    accessibility != Accessibility.Internal)
                    continue;

                var enumPath = enumSymbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);

                var accessModifier = accessibility == Accessibility.Public ? "public" : "internal";

                sourceBuilder.AppendLine(
                    $"    {accessModifier} static bool HasFlagNonAlloc(this {enumPath} value, {enumPath} flag)");
                sourceBuilder.AppendLine("    {");
                sourceBuilder.AppendLine($"        return (value & flag) == flag;");
                sourceBuilder.AppendLine("    }");

                processed = true;
            }
        }

        sourceBuilder.AppendLine("}");
        sourceBuilder.AppendLine();

        if (processed)
            context.AddSource($"{context.Compilation.AssemblyName}NonAllocFlagExtensions.g.cs",
                sourceBuilder.ToString());
    }

    private Accessibility GetAccessModifier(ISymbol symbol)
    {
        var current = symbol;
        var accessibility = current.DeclaredAccessibility;

        while (current.ContainingSymbol != null)
        {
            current = current.ContainingSymbol;

            if (current.DeclaredAccessibility == Accessibility.NotApplicable)
                continue;

            accessibility = accessibility < current.DeclaredAccessibility
                ? accessibility
                : current.DeclaredAccessibility;
        }

        return accessibility;
    }
}