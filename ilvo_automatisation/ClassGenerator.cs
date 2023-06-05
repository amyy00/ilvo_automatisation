using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ilvo_automatisation
{
    public class ClassGenerator
    {
        private readonly DbContext dbContext;

        public ClassGenerator(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void GenerateClasses(string outputPath)
        {
            var entityTypes = dbContext.Model.GetEntityTypes();

            var classDefinitions = entityTypes.Select(entityType =>
            {
                var tableName = entityType.GetTableName();
                var className = entityType.Name;

                var properties = entityType.GetProperties()
                    .Select(property => $"    public {property.ClrType} {property.Name} {{ get; set; }}")
                    .ToList();

                var classDefinition = $"public class {className}\n" +
                    "{{\n" +
                    string.Join("\n", properties) +
                    "\n}}\n";

                return classDefinition;
            }).ToList();

            var outputText = $"using System;\n\nnamespace DatabaseClasses\n{{\n{string.Join("\n", classDefinitions)}}}";

            string outputFilePath = Path.Combine(outputPath, "DatabaseClasses.cs");
            File.WriteAllText(outputFilePath, outputText);
            Console.WriteLine($"Classes generated successfully. Output file: {outputFilePath}");
        }
    }
}
