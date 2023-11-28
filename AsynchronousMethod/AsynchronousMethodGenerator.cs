using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.AsynchronousMethod
{
    /// <summary>
    /// Class which generates source code for asynchronous methods.
    /// </summary>
    [Generator]
    public class AsynchronousMethodGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            // Load required types
            INamedTypeSymbol attributeSymbol = context.Compilation.GetTypeByMetadataName("SemestralProject.AsynchronousMethod.AsynchronousMethodAttribute");
            INamedTypeSymbol taskSymbol = context.Compilation.GetTypeByMetadataName("System.Threading.Tasks.Task");

            if (attributeSymbol is null || taskSymbol is null)
                return;

#pragma warning disable RS1024 // Compare symbols correctly
            IDictionary<INamedTypeSymbol, IList<IMethodSymbol>> classMethods = new Dictionary<INamedTypeSymbol, IList<IMethodSymbol>>();
#pragma warning restore RS1024 // Compare symbols correctly

            foreach(SyntaxTree st in context.Compilation.SyntaxTrees)
            {
                SemanticModel sm = context.Compilation.GetSemanticModel(st, true);
                SyntaxNode root = st.GetRoot();
                IList<MethodDeclarationSyntax> methods = root.DescendantNodes().OfType<MethodDeclarationSyntax>().ToList();
                foreach(MethodDeclarationSyntax method in methods)
                {
                    IMethodSymbol methodSymbol = sm.GetDeclaredSymbol(method);
                    if (methodSymbol != null && methodSymbol.GetAttributes().Any((ad => ad.AttributeClass.Equals(attributeSymbol, SymbolEqualityComparer.Default))))
                    {
                        INamedTypeSymbol containingClass = methodSymbol.ContainingType;
                        if (classMethods.ContainsKey(containingClass) == false)
                        {
                            classMethods[containingClass] = new List<IMethodSymbol>();
                        }
                        classMethods[containingClass].Add(methodSymbol);
                    }
                }
                
            }

            foreach(INamedTypeSymbol classEntry in classMethods.Keys)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendLine("using System.Threading.Tasks;");
                stringBuilder.Append("namespace ");
                stringBuilder.AppendLine(classEntry.ContainingNamespace.ToString());
                stringBuilder.AppendLine("{");
                stringBuilder.Append("    ");
                stringBuilder.Append(SyntaxFacts.GetText(classEntry.DeclaredAccessibility));
                stringBuilder.Append(" partial class ");
                stringBuilder.AppendLine(classEntry.Name);
                stringBuilder.Append("    ");
                stringBuilder.AppendLine("{");
                foreach (IMethodSymbol method in classMethods[classEntry])
                { 
                    stringBuilder.Append("    ");
                    stringBuilder.Append("    ");
                    stringBuilder.Append(SyntaxFacts.GetText(method.DeclaredAccessibility));
                    stringBuilder.Append(" ");
                    if (method.IsStatic)
                    {
                        stringBuilder.Append("static ");
                    }
                    stringBuilder.Append(taskSymbol);
                    if (method.ReturnsVoid == false)
                    {
                        stringBuilder.Append("<");
                        stringBuilder.Append(method.ReturnType);
                        stringBuilder.Append(">");
                    }
                    stringBuilder.Append(" ");
                    stringBuilder.Append(method.Name);
                    stringBuilder.Append("Async(");
                    ImmutableArray<IParameterSymbol> parameters = method.Parameters;
                    string parameterList = string.Join(", ", parameters.Select(p => $"{p.Type} {p.Name}"));
                    stringBuilder.Append(parameterList);
                    stringBuilder.AppendLine(")");
                    stringBuilder.Append("    ");
                    stringBuilder.Append("    ");
                    stringBuilder.AppendLine("{");
                    if (method.ReturnsVoid)
                    {
                        stringBuilder.Append("    ");
                        stringBuilder.Append("    ");
                        stringBuilder.Append("    ");
                        stringBuilder.AppendLine("return Task.Run(() => {");
                        stringBuilder.Append("    ");
                        stringBuilder.Append("    ");
                        stringBuilder.Append("    ");
                        stringBuilder.Append("    ");
                        if (method.IsStatic)
                        {
                            stringBuilder.Append(classEntry.Name);
                            stringBuilder.Append(".");
                        }
                        else
                        {
                            stringBuilder.Append("this.");
                        }
                        stringBuilder.Append(method.Name);
                        stringBuilder.Append("(");
                        stringBuilder.Append(string.Join(", ", parameters.Select(p => p.Name)));
                        stringBuilder.AppendLine(");");
                        stringBuilder.Append("    ");
                        stringBuilder.Append("    ");
                        stringBuilder.AppendLine("});");
                    }
                    else
                    {
                        stringBuilder.Append("    ");
                        stringBuilder.Append("    ");
                        stringBuilder.Append("    ");
                        stringBuilder.Append("return Task<");
                        stringBuilder.Append(method.ReturnType);
                        stringBuilder.AppendLine(">.Run(() => {");
                        stringBuilder.Append("    ");
                        stringBuilder.Append("    ");
                        stringBuilder.Append("    ");
                        stringBuilder.Append("    ");
                        stringBuilder.Append("return ");
                        if (method.IsStatic)
                        {
                            stringBuilder.Append(classEntry.Name);
                            stringBuilder.Append(".");
                        }
                        else
                        {
                            stringBuilder.Append("this.");
                        }
                        stringBuilder.Append(method.Name);
                        stringBuilder.Append("(");
                        stringBuilder.Append(string.Join(", ", parameters.Select(p => p.Name)));
                        stringBuilder.AppendLine(");");
                        stringBuilder.Append("    ");
                        stringBuilder.Append("    ");
                        stringBuilder.Append("    ");
                        stringBuilder.AppendLine("});");
                    }
                    stringBuilder.Append("    ");
                    stringBuilder.Append("    ");
                    stringBuilder.AppendLine("}");
                    stringBuilder.AppendLine();
                }
                stringBuilder.Append("    ");
                stringBuilder.AppendLine("}");
                stringBuilder.AppendLine("}");
                string generatedSource = stringBuilder.ToString();
                SourceText source = SourceText.From(generatedSource, Encoding.UTF8);
                context.AddSource($"{classEntry.Name}.g.cs", source);
            }
        }

        public void Initialize(GeneratorInitializationContext context) { }
    }
}