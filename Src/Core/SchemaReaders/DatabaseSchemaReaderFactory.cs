using System;
using SqlToSharp.Common;
using SqlToSharp.Core.Interfaces;

namespace SqlToSharp.Core.SchemaReaders
{
    public static class DatabaseSchemaReaderFactory
    {
        public static IDatabaseSchemaReader Create(Dbms type, string connString)
        {
            return type switch
            {
                Dbms.SqlServer => new SqlServerSchemaReader(connString),
                Dbms.Postgres => new PostgresSchemaReader(connString),
                _ => throw new NotImplementedException()
            };
        }
    }
}