using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SqlToSharp.Core
{
    public static class ClassGenerator
    {
        public static (bool isSuccess, string message) Generate(
            string className,
            IEnumerable<(string PropertyName, string PropertyTypeName)> properties,
            string outputDirPath,
            string classNamespace)
        {
            try
            {
                var propertyLines = properties
                    .Select(prop => $"public {prop.PropertyTypeName} {prop.PropertyName} {{ get; set; }}")
                    .ToList();

                var output = ClassTemplate
                    .Replace("__PROPS__", string.Join("\n\t\t", propertyLines))
                    .Replace("__NAMESPACE__", classNamespace)
                    .Replace("__CLASS_NAME__", className);

                if(!Directory.Exists(outputDirPath))
                {
                    Directory.CreateDirectory(outputDirPath);
                }

                File.WriteAllText(Path.Combine(outputDirPath, className + ".cs"), output);

                return (true, string.Empty);
            }
            catch (Exception ex)
            {
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