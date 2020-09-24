using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SqlToSharp.Core.Models;
using SqlToSharp.Logging;

namespace SqlToSharp.Core
{
    public static class ClassGenerator
    {
        public static (bool isSuccess, string message) Generate(
            TableClassModel table,
            string outputDirPath,
            string classNamespace)
        {
            try
            {
                var propertyLines = table.Properties
                    .Select(prop => $"public {prop.Name} {prop.Type} {{ get; set; }}")
                    .ToList();

                var output = ClassTemplate
                    .Replace("__PROPS__", string.Join("\n\t\t", propertyLines))
                    .Replace("__NAMESPACE__", classNamespace)
                    .Replace("__CLASS_NAME__", table.Name);

                if(!Directory.Exists(outputDirPath))
                {
                    Directory.CreateDirectory(outputDirPath);
                }

                File.WriteAllText(Path.Combine(outputDirPath, table.Name + ".cs"), output);

                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                Logger.Exception(ex);
                return (false, ex.Message);
            }
        }

        private const string ClassTemplate = @"
using System;

namespace __NAMESPACE__
{
    public class __CLASS_NAME__
    {
        __PROPS__
    }
}"; 
    }
}