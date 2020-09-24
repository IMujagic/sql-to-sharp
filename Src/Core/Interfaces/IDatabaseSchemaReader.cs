using System.Collections.Generic;
using SqlToSharp.Core.Models;

namespace SqlToSharp.Core.Interfaces
{
    public interface IDatabaseSchemaReader
    {
        IEnumerable<TableClassModel> GetTables();
    }
}