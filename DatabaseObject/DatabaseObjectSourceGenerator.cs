using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace DatabaseObject
{
    /// <summary>
    /// Class which performs generation of source code for database objects.
    /// </summary>
    [Generator]
    public class DatabaseObjectSourceGenerator : ISourceGenerator
    {
        /// <summary>
        /// Index of name of property in array.
        /// </summary>
        private const int Name = 0;

        /// <summary>
        /// Index of type of property in array.
        /// </summary>
        private const int Type = 1;

        /// <summary>
        /// Index of comment of property in array.
        /// </summary>
        private const int Comment = 2;

        /// <summary>
        /// Index of column name of property in array.
        /// </summary>
        private const int Column = 3;

        /// <inheritdoc/>
        public void Execute(GeneratorExecutionContext context)
        {
            var syntaxTrees = context.Compilation.SyntaxTrees;
            foreach(var syntaxTree in syntaxTrees)
            {
                var root = syntaxTree.GetRoot();
                var semanticModel = context.Compilation.GetSemanticModel(syntaxTree);

                var databaseClasses = root.DescendantNodes()
                    .OfType<ClassDeclarationSyntax>()
                    .Where(classSyntax => semanticModel.GetDeclaredSymbol(classSyntax)?.GetAttributes()
                            .Any(attr => attr.AttributeClass?.Name == "DatabaseClassAttribute") == true);

                foreach (var classSyntax in databaseClasses)
                {
                    var classSymbol = semanticModel.GetDeclaredSymbol(classSyntax);
                    var classAtribute = classSymbol.GetAttributes()
                        .FirstOrDefault(attr => attr.AttributeClass?.Name == "DatabaseClassAttribute");
                    var dbClassProperties = this.GetDatabaseClassProperties(classAtribute);
                    var classProperties = classSyntax.Members.OfType<PropertyDeclarationSyntax>()
                                                             .Where(propertySyntax => semanticModel.GetDeclaredSymbol(propertySyntax).GetAttributes()
                                                                    .Any(attr => attr.AttributeClass?.Name == "DatabaseColumnAttribute")
                                                                    );
                    int arrLen = Math.Max(DatabaseObjectSourceGenerator.Name, Math.Max(DatabaseObjectSourceGenerator.Type, Math.Max(DatabaseObjectSourceGenerator.Comment, DatabaseObjectSourceGenerator.Column))) + 1;
                    string[][] properties = new string[classProperties.Count()][];
                    int idx = 0;
                    foreach(var property in classProperties)
                    {
                        properties[idx] = new string[arrLen];
                        properties[idx][DatabaseObjectSourceGenerator.Name] = property.Identifier.Text;
                        properties[idx][DatabaseObjectSourceGenerator.Type] = property.Type.ToString();
                        properties[idx][DatabaseObjectSourceGenerator.Comment] = this.GetPropertyComments(property, syntaxTree);
                        var propertySymbol = semanticModel.GetDeclaredSymbol(property);
                        var attributeColumn = propertySymbol.GetAttributes()
                                                            .First(ad => ad.AttributeClass?.Name == "DatabaseColumnAttribute")
                                                            .ConstructorArguments.FirstOrDefault().Value?.ToString();
                        properties[idx][DatabaseObjectSourceGenerator.Column] = attributeColumn;
                        idx++;
                    }
                    StringBuilder content = new StringBuilder();
                    content.Append(this.GetConstructorComment(properties, classSymbol.Name));
                    content.AppendLine(this.GetConstructor(properties, classSymbol.Name));
                    content.Append(this.GetCreateComment(properties, classSymbol.Name));
                    content.AppendLine(this.GetCreateFunction(properties, classSymbol.Name, classAtribute.ConstructorArguments[0].Value.ToString(), classAtribute.ConstructorArguments[4].Value.ToString()));
                    content.Append(this.GetCreateAsyncComment(properties, classSymbol.Name));
                    content.AppendLine(this.GetCreateAsyncFunction(properties, classSymbol.Name));
                    content.Append(this.GetGetAllComment(classSymbol.Name, classAtribute.ConstructorArguments[1].Value.ToString()));
                    content.AppendLine(this.GetGetAllFunction(classSymbol.Name, classAtribute.ConstructorArguments[1].Value.ToString()));
                    content.Append(this.GetGetAllAsyncComment(classSymbol.Name));
                    content.AppendLine(this.GetGetAllAsyncFunction(classSymbol.Name));
                    content.Append(this.GetGetByIdComment(classSymbol.Name));
                    content.AppendLine(this.GetGetByIdFunction(classSymbol.Name, classAtribute.ConstructorArguments[1].Value.ToString()));
                    content.Append(this.GetGetByIdAsyncComment(classSymbol.Name));
                    content.AppendLine(this.GetGetByIdAsyncFunction(classSymbol.Name));
                    content.Append(this.GetParseComment(classSymbol.Name));
                    content.AppendLine(this.GetParseFunction(classSymbol.Name, properties, classAtribute.ConstructorArguments[5].Value.ToString()));
                    content.AppendLine(this.GetUpdateFunction(classSymbol.Name, classAtribute.ConstructorArguments[2].Value.ToString(), properties));
                    content.AppendLine(this.GetDeleteFunction(classSymbol.Name, classAtribute.ConstructorArguments[3].Value.ToString()));
                    string generatedCode = this.GenerateCodeForClass(classSymbol, content.ToString());
                    SourceText sourceText = SourceText.From(generatedCode, Encoding.UTF8);
                    context.AddSource(classSymbol.Name + ".g.cs", sourceText);
                }
            }
        }

        /// <summary>
        /// Gets body of delete function.
        /// </summary>
        /// <param name="className">Name of database object which will be deleted.</param>
        /// <param name="deleteFunction">Name of database function which performs data object deletion.</param>
        /// <returns>String representing body of delete function.</returns>
        private string GetDeleteFunction(string className, string deleteFunction)
        {
            StringBuilder reti = new StringBuilder();
            reti.AppendLine(this.Insets(2, "/// <inheritdoc/>"));
            reti.AppendLine(this.Insets(2, "public override bool Delete()"));
            reti.AppendLine(this.Insets(2, "{"));
            reti.AppendLine(this.Insets(3, $"string sql = $\"sempr_crud.{deleteFunction}({{this.Id}})\";"));
            reti.AppendLine(this.Insets(3, $"return {className}.Delete(sql);"));
            reti.AppendLine(this.Insets(2, "}"));
            return reti.ToString();
        }

        /// <summary>
        /// Gets body of update function.
        /// </summary>
        /// <param name="className">Name of database object which will be updated.</param>
        /// <param name="updateFunction">Name of database function which will perform data update.</param>
        /// <param name="properties">Properties which will participate in database objecft update.</param>
        /// <returns></returns>
        private string GetUpdateFunction(string className, string updateFunction, string[][] properties)
        {
            StringBuilder reti = new StringBuilder();
            reti.AppendLine(this.Insets(2, "/// <inheritdoc/>"));
            reti.AppendLine(this.Insets(2, "public override bool Update()"));
            reti.AppendLine(this.Insets(2, "{"));
            reti.Append(this.Insets(3, $"string sql = $\"sempr_crud.{updateFunction}({{this.Id}}, "));
            for (int i = 0; i < properties.Length; i++)
            {
                string type = properties[i][DatabaseObjectSourceGenerator.Type];
                if (type == "string")
                {
                    reti.Append("'{");
                    reti.Append("this.");
                    reti.Append(properties[i][DatabaseObjectSourceGenerator.Name]);
                    reti.Append("}'");
                }
                else if (type == "int" || type == "double" || type == "float")
                {
                    reti.Append("{");
                    reti.Append("this.");
                    reti.Append(properties[i][DatabaseObjectSourceGenerator.Name]);
                    reti.Append("}");
                }
                else if (type == "bool")
                {
                    reti.Append("{");
                    reti.Append("BoolUtils.ToQuery(this.");
                    reti.Append(properties[i][DatabaseObjectSourceGenerator.Name]);
                    reti.Append(")");
                    reti.Append("}");
                }
                else if (type == "DateTime")
                {
                    reti.Append("{DateUtils.ToSQL(");
                    reti.Append("this.");
                    reti.Append(properties[i][DatabaseObjectSourceGenerator.Name]);
                    reti.Append(")}");
                }
                else
                {
                    reti.Append("{");
                    reti.Append("this.");
                    reti.Append(properties[i][DatabaseObjectSourceGenerator.Name]);
                    reti.Append(".Id}");
                }
                if (i < properties.Length - 1)
                {
                    reti.Append(", ");
                }
            }
            reti.AppendLine(")\";");
            reti.AppendLine(this.Insets(3, $"return {className}.Update(sql);"));
            reti.AppendLine(this.Insets(2, "}"));
            return reti.ToString();
        }

        /// <summary>
        /// Gets body of function get by id asynchronously.
        /// </summary>
        /// <param name="className">Name of database object which will be searched.</param>
        /// <returns>String representing body of function get by id asynchronously.</returns>
        private string GetGetByIdAsyncFunction(string className)
        {
            StringBuilder reti = new StringBuilder();
            reti.AppendLine(this.Insets(2, $"public static Task<{className}?> GetByIdAsync(int id)"));
            reti.AppendLine(this.Insets(2, "{"));
            reti.AppendLine(this.Insets(3, $"return Task<{className}?>.Run(() => "));
            reti.AppendLine(this.Insets(3, "{"));
            reti.AppendLine(this.Insets(4, $"return {className}.GetById(id);"));
            reti.AppendLine(this.Insets(3, "});"));
            reti.AppendLine(this.Insets(2, "}"));
            return reti.ToString();
        }

        /// <summary>
        /// Gets documentation comment for get by id asynchronous function.
        /// </summary>
        /// <param name="className">Name of database object which will be searched.</param>
        /// <returns>String representing documentation comment for get by id asynchronous function.</returns>
        private string GetGetByIdAsyncComment(string className)
        {
            StringBuilder reti = new StringBuilder();
            reti.AppendLine(this.Insets(2, "/// <summary>"));
            reti.AppendLine(this.Insets(2, $"/// Gets {className.ToLower()} by its identifier asynchronously."));
            reti.AppendLine(this.Insets(2, "/// </summary>"));
            reti.AppendLine(this.Insets(2, $"/// <param name=\"id\"> Identifier of searched {className.ToLower()}. </param>"));
            reti.AppendLine(this.Insets(2, "/// <returns>"));
            reti.AppendLine(this.Insets(2, "/// Task which resolves into:"));
            reti.AppendLine(this.Insets(2, $"/// {className.ToLower()} with searched identifier,"));
            reti.AppendLine(this.Insets(2, $"/// or NULL if there is no such {className.ToLower()}."));
            reti.AppendLine(this.Insets(2, "/// </returns>"));
            return reti.ToString();
        }

        /// <summary>
        /// Gets body of get by identifier function.
        /// </summary>
        /// <param name="className">Name of database object which will be searched.</param>
        /// <param name="readFunction">Name of function which performs searching in database.</param>
        /// <returns>String representing body of function.</returns>
        private string GetGetByIdFunction(string className, string readFunction)
        {
            StringBuilder reti = new StringBuilder();
            reti.AppendLine(this.Insets(2, $"public static {className}? GetById(int id)"));
            reti.AppendLine(this.Insets(2, "{"));
            reti.AppendLine(this.Insets(3, $"{className}? reti = null;"));
            reti.AppendLine(this.Insets(3, $"string sql = $\"sempr_crud.{readFunction}({{id}})\";"));
            reti.AppendLine(this.Insets(3, $"IDictionary<string, object?>[] results = {className}.Read(sql);"));
            reti.AppendLine(this.Insets(3, "if (results.Length > 0)"));
            reti.AppendLine(this.Insets(3, "{"));
            reti.AppendLine(this.Insets(4, $"reti = {className}.Parse(results[0]);"));
            reti.AppendLine(this.Insets(3, "}"));
            reti.AppendLine(this.Insets(3, "return reti;"));
            reti.AppendLine(this.Insets(2, "}"));
            return reti.ToString();
        }

        /// <summary>
        /// Gets documentation comment for get by id function.
        /// </summary>
        /// <param name="className">Name of database object which will be searched.</param>
        /// <returns>String representing documentation comment for get by id function.</returns>
        private string GetGetByIdComment(string className)
        {
            StringBuilder reti = new StringBuilder();
            reti.AppendLine(this.Insets(2, "/// <summary>"));
            reti.AppendLine(this.Insets(2, $"/// Gets {className.ToLower()} by its identifier."));
            reti.AppendLine(this.Insets(2, "/// </summary>"));
            reti.AppendLine(this.Insets(2, $"/// <param name=\"id\"> Identifier of searched {className.ToLower()}. </param>"));
            reti.AppendLine(this.Insets(2, "/// <returns>"));
            reti.AppendLine(this.Insets(2, $"/// {className} with searched identifier,"));
            reti.AppendLine(this.Insets(2, $"/// or NULL if there is no such {className.ToLower()}."));
            reti.AppendLine(this.Insets(2, "/// </returns>"));
            return reti.ToString();
        }

        /// <summary>
        /// Gets body of parsing function.
        /// </summary>
        /// <param name="className">Name of class which will be parsed.</param>
        /// <param name="properties">Properties which will participate on parsing.</param>
        /// <param name="idCol">Name of column with identifier of database object.</param>
        /// <returns>String representing parsing function.</returns>
        private string GetParseFunction(string className, string[][] properties, string idCol)
        {
            StringBuilder reti = new StringBuilder();
            reti.Append(this.Insets(2, "private static "));
            reti.Append(className);
            reti.AppendLine("? Parse(IDictionary<string, object?> data)");
            reti.AppendLine(this.Insets(2, "{"));
            reti.Append(this.Insets(3, className));
            reti.AppendLine("? reti = null;");
            reti.AppendLine(this.Insets(3, $"int id = (int)(data[\"{idCol}\"] ?? int.MinValue);"));
            StringBuilder nullables = new StringBuilder();
            foreach (string[] prop in properties)
            {
                if (prop[DatabaseObjectSourceGenerator.Type] == "int" || prop[DatabaseObjectSourceGenerator.Type] == "string" || prop[DatabaseObjectSourceGenerator.Type] == "double" || prop[DatabaseObjectSourceGenerator.Type] == "float")
                {
                    reti.Append(this.Insets(3, $"{prop[DatabaseObjectSourceGenerator.Type]} {prop[DatabaseObjectSourceGenerator.Name].ToLower()} = ({prop[DatabaseObjectSourceGenerator.Type]})(data[\"{prop[DatabaseObjectSourceGenerator.Column]}\"] ?? "));
                    switch(prop[DatabaseObjectSourceGenerator.Type])
                    {
                        case "int": reti.Append("int.MinValue"); break;
                        case "string": reti.Append("string.Empty"); break;
                        case "double": reti.Append("double.NaN"); break;
                        case "float": reti.Append("float.NaN"); break;                        
                    }
                    reti.AppendLine(");");
                }
                else if (prop[DatabaseObjectSourceGenerator.Type] == "bool")
                {
                    reti.Append(this.Insets(3));
                    reti.Append($"{prop[DatabaseObjectSourceGenerator.Type]} {prop[DatabaseObjectSourceGenerator.Name].ToLower()} = ");
                    reti.AppendLine($"BoolUtils.FromQuery(data[\"{prop[DatabaseObjectSourceGenerator.Column]}\"]);");
                }
                else if (prop[DatabaseObjectSourceGenerator.Type] == "DateTime")
                {
                    reti.AppendLine(this.Insets(3, $"DateTime {prop[DatabaseObjectSourceGenerator.Name].ToLower()} = (DateTime)(DateUtils.FromQuery(data[\"{prop[DatabaseObjectSourceGenerator.Column]}\"]) ?? DateTime.Now);"));
                    
                }
                else
                {
                    reti.Append(this.Insets(3, prop[DatabaseObjectSourceGenerator.Type]));
                    reti.Append("? ");
                    reti.Append(prop[DatabaseObjectSourceGenerator.Name].ToLower());
                    if (nullables.Length == 0)
                    {
                        nullables.Append(this.Insets(3, $"if ({prop[DatabaseObjectSourceGenerator.Name].ToLower()} != null"));
                    }
                    else
                    {
                        nullables.Append($" && {prop[DatabaseObjectSourceGenerator.Name].ToLower()} != null");
                    }
                    reti.Append(" = ");
                    reti.Append(prop[DatabaseObjectSourceGenerator.Type]);
                    reti.AppendLine($".GetById((int)(data[\"{prop[DatabaseObjectSourceGenerator.Column]}\"] ?? int.MinValue));");
                }
            }
            if (nullables.Length > 0)
            {
                reti.Append(nullables.ToString());
                reti.AppendLine(")");
                reti.AppendLine(this.Insets(3, "{"));
                reti.Append(this.Insets(4, "reti = new "));
                reti.Append(className);
                reti.Append("(id, ");
                reti.Append(string.Join(", ", properties.Select(p => p[DatabaseObjectSourceGenerator.Name].ToLower())));
                reti.AppendLine(");");
                reti.AppendLine(this.Insets(3, "}"));
            }
            else
            {
                reti.Append(this.Insets(3, "reti = new "));
                reti.Append(className);
                reti.Append("(id, ");
                reti.Append(string.Join(", ", properties.Select(p => p[DatabaseObjectSourceGenerator.Name].ToLower())));
                reti.AppendLine(");");
            }
            reti.AppendLine(this.Insets(3, "return reti;"));
            reti.AppendLine(this.Insets(2, "}"));
            return reti.ToString();
        }

        

        /// <summary>
        /// Gets comment for parsing function.
        /// </summary>
        /// <param name="className">Name of class which will be parsed.</param>
        /// <returns>String representing comment for parsing function.</returns>
        private string GetParseComment(string className)
        {
            StringBuilder reti = new StringBuilder();
            reti.Append(this.Insets(2));
            reti.AppendLine("/// <summary>");
            reti.Append(this.Insets(2));
            reti.Append("/// Parses ");
            reti.Append(className.ToLower());
            reti.AppendLine(" from result of database query.");
            reti.Append(this.Insets(2));
            reti.AppendLine("/// </summary>");
            reti.Append(this.Insets(2));
            reti.AppendLine("/// <param name=\"data\">Source of data for entity.</param>");
            return reti.ToString();
        }

        /// <summary>
        /// Gets body of get all asynchronously function.
        /// </summary>
        /// <param name="className">Name of class which will be get asynchronously.</param>
        /// <returns>String representing body of function to get all database objects asynchronously.</returns>
        private string GetGetAllAsyncFunction(string className)
        {
            StringBuilder reti = new StringBuilder();
            reti.AppendLine(this.Insets(2, $"public static Task<{className}[]> GetAllAsync()"));
            reti.AppendLine(this.Insets(2, "{"));
            reti.AppendLine(this.Insets(3, $"return Task<{className}[]>.Run(() => "));
            reti.AppendLine(this.Insets(3, "{"));
            reti.AppendLine(this.Insets(4, $"return {className}.GetAll();"));
            reti.AppendLine(this.Insets(3, "});"));
            reti.AppendLine(this.Insets(2, "}"));
            return reti.ToString();
        }

        /// <summary>
        /// Gets documentation comment for get all asynchronously function.
        /// </summary>
        /// <param name="className">Name of class which will be get asynchronously.</param>
        /// <returns>String representing documentation comment for get all asynchronously function.</returns>
        private string GetGetAllAsyncComment(string className)
        {
            StringBuilder reti = new StringBuilder();
            reti.AppendLine(this.Insets(2, "/// <summary>"));
            reti.AppendLine(this.Insets(2, $"/// Gets all available {className.ToLower()}s asynchronously."));
            reti.AppendLine(this.Insets(2, "/// </summary>"));
            reti.AppendLine(this.Insets(2, "/// <returns>"));
            reti.AppendLine(this.Insets(2, $"/// Task which resolves into array with all available {className.ToLower()}s."));
            reti.AppendLine(this.Insets(2, "/// </returns>"));
            return reti.ToString();
        }

        /// <summary>
        /// Generates body for get all function.
        /// </summary>
        /// <param name="className">Name of class which entities will be returned.</param>
        /// <param name="readFunction">Name of database function which will be called.</param>
        /// <returns>String representing body of get all function.</returns>
        private string GetGetAllFunction(string className, string readFunction)
        {
            StringBuilder reti = new StringBuilder();
            reti.Append(this.Insets(2));
            reti.Append("public static ");
            reti.Append(className);
            reti.AppendLine("[] GetAll()");
            reti.Append(this.Insets(2));
            reti.AppendLine("{");
            reti.Append(this.Insets(3));
            reti.Append("IList<");
            reti.Append(className);
            reti.Append("> reti = new List<");
            reti.Append(className);
            reti.AppendLine(">();");
            reti.AppendLine(this.Insets(3, $"IDictionary<string, object?>[] results = {className}.Read(\"sempr_crud.{readFunction}()\");"));
            reti.AppendLine(this.Insets(3, "foreach(IDictionary<string, object?> row in results)"));
            reti.AppendLine(this.Insets(3, "{"));
            reti.AppendLine(this.Insets(4, $"{className}? {className.ToLower()} = {className}.Parse(row);"));
            reti.AppendLine(this.Insets(4, $"if ({className.ToLower()} != null)"));
            reti.AppendLine(this.Insets(4, "{"));
            reti.AppendLine(this.Insets(5, $"reti.Add({className.ToLower()});"));
            reti.AppendLine(this.Insets(4, "}"));
            reti.AppendLine(this.Insets(3, "}"));
            reti.Append(this.Insets(3));
            reti.AppendLine("return reti.ToArray();");
            reti.Append(this.Insets(2));
            reti.AppendLine("}");
            return reti.ToString();
        }

        /// <summary>
        /// Generates comment for get all function.
        /// </summary>
        /// <param name="className">Name of class which entities will be returned.</param>
        /// <param name="readFunction">Name of database function which will be called.</param>
        /// <returns>String representing comment for get all function.</returns>
        private string GetGetAllComment(string className, string readFunction)
        {
            StringBuilder reti = new StringBuilder();
            reti.Append(this.Insets(2));
            reti.AppendLine("/// <summary>");
            reti.Append(this.Insets(2));
            reti.Append("/// Gets all available ");
            reti.Append(className.ToLower());
            reti.AppendLine("s.");
            reti.Append(this.Insets(2));
            reti.AppendLine("/// </summary>");
            reti.Append(this.Insets(2));
            reti.AppendLine("/// <returns>");
            reti.Append(this.Insets(2));
            reti.Append("/// All available ");
            reti.Append(className.ToLower());
            reti.AppendLine("s.");
            reti.Append(this.Insets(2));
            reti.AppendLine("/// </returns>");
            return reti.ToString();
        }

        /// <summary>
        /// Generates creation function.
        /// </summary>
        /// <param name="properties">Properties used to create entity.</param>
        /// <param name="className">Class name of entity which will be crated.</param>
        /// <param name="createFunction">Name of creation function.</param>
        /// <param name="sequence">Name of sequence responsible for creating identifiers.</param>
        /// <returns>String representing body of creation function.</returns>
        private string GetCreateFunction(string[][] properties, string className, string createFunction, string sequence)
        {
            StringBuilder reti = new StringBuilder();
            reti.Append(this.Insets(2));
            reti.Append("public static ");
            reti.Append(className);
            reti.Append(" Create(");
            reti.Append(string.Join(", ", properties.Select(x => x[DatabaseObjectSourceGenerator.Type] + " " + x[DatabaseObjectSourceGenerator.Name].ToLower())));
            reti.AppendLine(")");
            reti.Append(this.Insets(2));
            reti.AppendLine("{");
            reti.Append(this.Insets(3));
            reti.Append("string sql = $\"sempr_crud.");
            reti.Append(createFunction);
            reti.Append("(");
            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i][DatabaseObjectSourceGenerator.Type].Trim().ToLower() == "string")
                {
                    reti.Append("'{");
                    reti.Append(properties[i][DatabaseObjectSourceGenerator.Name].ToLower());
                    reti.Append("}'");
                }
                else if (properties[i][DatabaseObjectSourceGenerator.Type].Trim().ToLower() == "datetime")
                {
                    reti.Append("{DateUtils.ToSQL(");
                    reti.Append(properties[i][DatabaseObjectSourceGenerator.Name].ToLower());
                    reti.Append(")}");
                }
                else if (properties[i][DatabaseObjectSourceGenerator.Type].Trim().ToLower() == "bool")
                {
                    reti.Append("{BoolUtils.ToQuery(");
                    reti.Append(properties[i][DatabaseObjectSourceGenerator.Name].ToLower());
                    reti.Append(")}");
                }
                else
                {
                    reti.Append("{");
                    reti.Append(properties[i][DatabaseObjectSourceGenerator.Name].ToLower());
                    reti.Append("}");
                }
                if (i < properties.Length - 1)
                {
                    reti.Append(", ");
                }
            }
            reti.AppendLine(")\";");
            reti.Append(this.Insets(3));
            reti.AppendLine($"int id = {className}.Create(sql, \"{sequence}\");");
            reti.Append(this.Insets(3));
            reti.Append("return new ");
            reti.Append(className);
            reti.Append("(id");
            if (properties.Length > 0) reti.Append(", ");
            reti.Append(string.Join(", ", properties.Select(x => x[DatabaseObjectSourceGenerator.Name].ToLower())));
            reti.AppendLine(");");
            reti.Append(this.Insets(2));
            reti.AppendLine("}");
            return reti.ToString();
        }

        /// <summary>
        /// Gets body of function for creation asynchronously.
        /// </summary>
        /// <param name="properties">Properties used to create entity.</param>
        /// <param name="className">Class name of entity which will be crated.</param>
        /// <returns>String which represents body of function for creation asynchronously.</returns>
        private string GetCreateAsyncFunction(string[][] properties, string className)
        {
            StringBuilder reti = new StringBuilder();
            reti.Append(this.Insets(2));
            reti.Append("public static Task<");
            reti.Append(className);
            reti.Append("> CreateAsync(");
            reti.Append(string.Join(", ", properties.Select(x => x[DatabaseObjectSourceGenerator.Type] + " " + x[DatabaseObjectSourceGenerator.Name].ToLower())));
            reti.AppendLine(")");
            reti.Append(this.Insets(2));
            reti.AppendLine("{");
            reti.Append(this.Insets(3));
            reti.Append("return Task<");
            reti.Append(className);
            reti.AppendLine(">.Run(() =>");
            reti.Append(this.Insets(3));
            reti.AppendLine("{");
            reti.Append(this.Insets(4));
            reti.Append("return ");
            reti.Append(className);
            reti.Append(".Create(");
            reti.Append(string.Join(", ", properties.Select(x => x[DatabaseObjectSourceGenerator.Name].ToLower())));
            reti.AppendLine(");");
            reti.Append(this.Insets(3));
            reti.AppendLine("});");
            reti.Append(this.Insets(2));
            reti.AppendLine("}");

            return reti.ToString();
        }

        /// <summary>
        /// Gets comment for asynchronous creation function.
        /// </summary>
        /// <param name="properties">Properties used to create entity.</param>
        /// <param name="className">Class name of entity which will be crated.</param>
        /// <returns>String representing comment for asynchronous creation function.</returns>
        private string GetCreateAsyncComment(string[][] properties, string className)
        {
            StringBuilder reti = new StringBuilder();
            reti.Append(this.Insets(2));
            reti.AppendLine("/// <summary>");
            reti.Append(this.Insets(2));
            reti.Append("/// Creates new ");
            reti.Append(className.ToLower());
            reti.AppendLine(" asynchronously.");
            reti.Append(this.Insets(2));
            reti.AppendLine("/// </summary>");
            reti.Append(this.GetParamsComment(properties));
            reti.Append(this.Insets(2));
            reti.Append("/// <returns>");
            reti.Append("Task which resolves into newly created ");
            reti.Append(className.ToLower());
            reti.AppendLine(". </returns>");
            return reti.ToString();
        }

        /// <summary>
        /// Gets comment for creation function.
        /// </summary>
        /// <param name="properties">Properties used to create entity.</param>
        /// <param name="className">Class name of entity which will be crated.</param>
        /// <returns>String representing comment for creation function.</returns>
        private string GetCreateComment(string[][] properties, string className)
        {
            StringBuilder reti = new StringBuilder();
            reti.Append(this.Insets(2));
            reti.AppendLine("/// <summary>");
            reti.Append(this.Insets(2));
            reti.Append("/// Creates new ");
            reti.Append(className.ToLower());
            reti.AppendLine(".");
            reti.Append(this.Insets(2));
            reti.AppendLine("/// </summary>");
            reti.Append(this.GetParamsComment(properties));
            reti.Append(this.Insets(2));
            reti.Append("/// <returns>");
            reti.Append("Newly created ");
            reti.Append(className.ToLower());
            reti.AppendLine(". </returns>");
            return reti.ToString();
        }

        /// <summary>
        /// Gets comment which describes parameters of function.
        /// </summary>
        /// <param name="properties">Properties which will be participiating in function.</param>
        /// <returns>String representing comment which describes paramaters of function.</returns>
        private string GetParamsComment(string[][] properties)
        {
            StringBuilder reti = new StringBuilder();
            for (int i = 0; i < properties.Length; i++)
            {
                reti.Append(this.Insets(2));
                reti.AppendLine($"/// <param name=\"{properties[i][DatabaseObjectSourceGenerator.Name].ToLower()}\"> {properties[i][DatabaseObjectSourceGenerator.Comment]} </param>");
            }
            return reti.ToString();
        }

        /// <summary>
        /// Generates comment for constructor.
        /// </summary>
        /// <param name="properties">Properties which will be passed to constructor.</param>
        /// <param name="className">Name of class which constructor will be created.</param>
        /// <returns>String representing comment of constructor.</returns>
        private string GetConstructorComment(string[][] properties, string className)
        {
            StringBuilder reti = new StringBuilder();
            reti.Append(this.Insets(2));
            reti.AppendLine("/// <summary>");
            reti.Append(this.Insets(2));
            reti.AppendLine($"/// Creates new {className.ToLower()}.");
            reti.Append(this.Insets(2));
            reti.AppendLine("/// </summary>");
            reti.Append(this.Insets(2));
            reti.AppendLine($"/// <param name=\"id\"> Identifier of {className.ToLower()}. </param>");
            reti.Append(this.GetParamsComment(properties));
            return reti.ToString();
        }

        /// <summary>
        /// Generates constructor for class.
        /// </summary>
        /// <param name="properties">Properties of class which will be initialized by constructor.</param>
        /// <param name="className">Name of class which will be created.</param>
        /// <returns>String representing body of constructor.</returns>
        private string GetConstructor(string[][] properties, string className)
        {
            StringBuilder reti = new StringBuilder();
            reti.Append(this.Insets(2));
            reti.Append("private ");
            reti.Append(className);
            reti.Append("(int id");
            if (properties.Length > 0) reti.Append(", ");
            reti.Append(string.Join(", ", properties.Select(x => x[DatabaseObjectSourceGenerator.Type] + " " + x[DatabaseObjectSourceGenerator.Name].ToLower())));
            reti.AppendLine(")");
            reti.Append(this.Insets(2));
            reti.AppendLine("{");
            reti.Append(this.Insets(3));
            reti.AppendLine("this.Id = id;");
            foreach (string[] prop in properties)
            {
                reti.Append(this.Insets(3));
                reti.Append("this.");
                reti.Append(prop[DatabaseObjectSourceGenerator.Name]);
                reti.Append(" = ");
                reti.Append(prop[DatabaseObjectSourceGenerator.Name].ToLower());
                reti.AppendLine(";");
            }
            reti.Append(this.Insets(2));
            reti.AppendLine("}");
            return reti.ToString(); ;
        }

        /// <summary>
        /// Gets comment associated with property.
        /// </summary>
        /// <param name="property">Property which comment will be returned.</param>
        /// <param name="syntaxTree">Syntax tree in which is property defined.</param>
        /// <returns>String representing comment associated with property.</returns>
        private string GetPropertyComments(PropertyDeclarationSyntax property, SyntaxTree syntaxTree)
        {
            StringBuilder reti = new StringBuilder();
            var leadingTrivia = property.GetLeadingTrivia();
            if (leadingTrivia != null)
            {
                foreach (var trivia in leadingTrivia)
                {
                    string line = trivia.ToString();
                    if (line.Contains("summary>") == false)
                    {
                        line = line.Replace("/// ", "");
                        if (line.StartsWith(Environment.NewLine))
                        {
                            line = line.Remove(0, Environment.NewLine.Length);
                        }
                        if (line.EndsWith(Environment.NewLine))
                        {
                            line = line.Remove(line.Length - Environment.NewLine.Length, Environment.NewLine.Length);
                        }
                        line = line.Trim();
                        reti.Append(line);
                    }
                }
            }
            string str = reti.ToString();
            if (str.EndsWith(Environment.NewLine))
            {
                str = str.Remove(reti.Length - Environment.NewLine.Length, Environment.NewLine.Length);
            }
            return str;
        }

        /// <summary>
        /// Gets properties of database class anotation.
        /// </summary>
        /// <param name="attributeData">Data containing property values.</param>
        /// <returns>Dictionary with property values of database class anotation.</returns>
        private IDictionary<string, object> GetDatabaseClassProperties(AttributeData attributeData)
        {
            IDictionary<string, object> reti = new Dictionary<string, object>();
            foreach(var arg in attributeData.NamedArguments)
            {
                reti.Add(arg.Key, arg.Value);
            }
            return reti;
        }

        /// <summary>
        /// Generates source code for class.
        /// </summary>
        /// <param name="classSymbol">Symbol defining class.</param>
        /// <param name="content">Content of the class.</param>
        /// <returns>String reperesenting source code generated for class.</returns>
        private string GenerateCodeForClass(ISymbol classSymbol, string content)
        { 
            StringBuilder reti = new StringBuilder();
            reti.AppendLine("/// <auto-generated/>");
            reti.AppendLine("#pragma warning disable");
            reti.AppendLine("#nullable enable");
            reti.AppendLine();
            reti.AppendLine("using System;");
            reti.AppendLine("using System.Linq;");
            reti.AppendLine("using System.Collections.Generic;");
            reti.AppendLine("using System.Threading.Tasks;");
            reti.AppendLine("using SemestralProject.Utils;");
            reti.AppendLine();
            reti.Append("namespace ");
            reti.AppendLine(classSymbol.ContainingNamespace.ToDisplayString());
            reti.AppendLine("{");
            reti.Append(this.Insets(1));
            reti.Append(SyntaxFacts.GetText(classSymbol.DeclaredAccessibility));
            reti.Append(" ");
            if (classSymbol.IsAbstract)
            {
                reti.Append("abstract ");
            }
            if (classSymbol.IsStatic)
            {
                reti.Append("static ");
            }
            reti.Append("partial class ");
            reti.Append(classSymbol.Name);
            reti.AppendLine(" : AsynchronousEntity");
            reti.Append(this.Insets(1));
            reti.AppendLine("{");
            reti.Append(content);
            reti.Append(this.Insets(1));
            reti.AppendLine("}");
            reti.AppendLine("}");
            return reti.ToString();
        }

        /// <summary>
        /// Generates insets.
        /// </summary>
        /// <param name="i">Size of insets.</param>
        /// <returns>String representing insets.</returns>
        private string Insets(int i)
        {
            StringBuilder reti = new StringBuilder();
            for (int c = 0; c < i; c++)
            {
                for (int j = 0; j < 4; j++)
                {
                    reti.Append(" ");
                }
            }
            return reti.ToString();
        }

        /// <summary>
        /// Generates string with left side insets.
        /// </summary>
        /// <param name="i">Size of insets in base units.</param>
        /// <param name="str">String which will be inset.</param>
        /// <returns>String with left insets.</returns>
        private string Insets(int i, string str)
        {
            StringBuilder reti = new StringBuilder();
            reti.Append(this.Insets(i));
            reti.Append(str);
            return reti.ToString();
        }

        /// <inheritdoc/>
        public void Initialize(GeneratorInitializationContext context) { }
    }
}
