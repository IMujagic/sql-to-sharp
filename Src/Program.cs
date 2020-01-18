using System;
using System.Collections.Generic;
using System.Linq;
using CommandLine;
using SqlToSharp.Core;
using SqlToSharp.Core.SchemaReaders;
using SqlToSharp.Logging;
using SqlToSharp.Logging.Providers;

namespace SqlToSharp
{
    static class Program
    {
        private static void Main(string[] args)
        {
            Configure();

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
                    Properties = schemaReader.GetTableColumnsAsProps(tName)
                })
                .ToList();

            if (tables.Any())
            {
                Logger.Error("No table has been found!");
                return;
            }

            foreach (var table in tables)
            {
                var result = ClassGenerator.Generate(
                    table.Name,
                    table.Properties,
                    args.OutputDirectory,
                    args.Namespace);

                if(result.isSuccess) 
                    Logger.Info($"Model class for table {table.Name} generated successfully.");
                else
                    Logger.Error($"Model class for table {table.Name} can't be generated. Error: \n\t {result.message}");
            }

            Logger.Info("Done!");
        }

        private static void HandleParseError(IEnumerable<Error> errs)
        {
            foreach (var err in errs)
            {
                Logger.Error(err.ToString());
            }
        }

        private static void Configure()
        {
            Logger.SetProvider(new ConsoleLogProvider());
        }        
    }
}
