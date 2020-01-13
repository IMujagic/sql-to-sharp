using CommandLine;
using SqlToSharp.Common;

namespace SqlToSharp
{
    public class Args
    {
        [Option("dbms", Required = true, HelpText = "Target database type.")]
        public Dbms Dbms { get; set; }

        [Option("conn-string", Required = true, HelpText = "Target database connection string.")]
        public string ConnectionString { get; set; }

        [Option("output-dir", Required = true, HelpText = "Path where the generated model classes will be placed.")]
        public string OutputDirectory { get; set; }
        
        [Option("namespace", Required = true, HelpText = "Namespace for the generated model classes.")]
        public string Namespace { get; set; }
    }
}