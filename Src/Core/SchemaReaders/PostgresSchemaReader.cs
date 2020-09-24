using System;
using System.Collections.Generic;
using SqlToSharp.Core.Interfaces;
using SqlToSharp.Core.Models;

namespace SqlToSharp.Core.SchemaReaders
{
    public class PostgresSchemaReader : IDatabaseSchemaReader
    {
        private readonly string _connString;

        public PostgresSchemaReader(string connString)
        {
            _connString = connString;
        }

        public IEnumerable<TableClassModel> GetTables()
        {
            throw new NotImplementedException();
        }
    }
}
