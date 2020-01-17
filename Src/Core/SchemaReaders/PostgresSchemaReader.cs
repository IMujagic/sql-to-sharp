using System;
using System.Collections.Generic;
using SqlToSharp.Core.Interfaces;

namespace SqlToSharp.Core.SchemaReaders
{
    public class PostgresSchemaReader : IDatabaseSchemaReader
    {
        private readonly string _connString;

        public PostgresSchemaReader(string connString)
        {
            _connString = connString;
        }

        public IEnumerable<(string PropertyName, string PropertyTypeName)> GetTableColumnsAsProps(string tableName)
        {
            //TODO
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetTableNames()
        {
            //TODO
            throw new NotImplementedException();
        }
    }
}
