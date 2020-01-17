using System;
using System.Collections.Generic;
using System.Linq;
using CommandLine;
using SqlToSharp.Core;
using SqlToSharp.Core.SchemaReaders;

namespace SqlToSharp
{
    static class Program
    {
        private static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<Args>(args)
                .WithParsed<Args>(a => Run(a))
                .WithNotParsed<Args>((errs) => HandleParseError(errs));  
        }
        
        private static void Run(Args args)
        {
            var schemaReader = DatabaseSchemaReaderFactory.Create(args.Dbms, args.ConnectionString);

            var tables = schemaReader
                .GetTableNames()
                .Select(tName => new
                {
                    Name = tName,
                    Columns = schemaReader.GetTableColumns(tName)
                })
                .ToList();

            foreach (var table in tables)
            {
                var result = ClassGenerator.Generate(
                    table.Name,
                    table.Columns,
                    args.OutputDirectory,
                    args.Namespace);

                Console.WriteLine(result.isSuccess
                    ? $"Model class for table {table.Name} generated successfully."
                    : $"Model class for table {table.Name} can't be generated. Error: \n\t {result.message}");
            }

            Console.WriteLine("Done!");
        }

        private static void HandleParseError(IEnumerable<Error> errs)
        {
            foreach (var err in errs)
            {
                Console.WriteLine(err.ToString());
            }
        }        
    }
}
