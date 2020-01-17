using System.Collections.Generic;

namespace SqlToSharp.Core.Interfaces
{
    public interface IDatabaseSchemaReader
    {
        IEnumerable<string> GetTableNames();
        IEnumerable<(string PropertyName, string PropertyTypeName)> GetTableColumnsAsProps(string tableName);
    }
}