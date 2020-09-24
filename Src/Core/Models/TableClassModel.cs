using System.Collections.Generic;

namespace SqlToSharp.Core.Models
{
    public class TableClassModel
    {
        public string Name { get; set; }
        public IEnumerable<(string Name, string Type)> Properties { get; set; }
    }
}