using System.Collections.Generic;

namespace SqlToSharp.Core.Models
{
    public class TableDbModel
    {
        public string Name { get; set; }
        public List<(string Name, string Type, bool isNullable)> Columns { get; set; }
    }
}