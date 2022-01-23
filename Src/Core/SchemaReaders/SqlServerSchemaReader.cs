using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using SqlToSharp.Common;
using SqlToSharp.Core.Interfaces;
using SqlToSharp.Core.Models;
using SqlToSharp.Logging;

namespace SqlToSharp.Core.SchemaReaders
{
    public class SqlServerSchemaReader : IDatabaseSchemaReader
    {
        private readonly string _connString;

        private const string SelectTablesQuery =
            "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";

        private const string SelectTableColumns =
            "SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{0}'";

        public SqlServerSchemaReader(string connString)
        {
            _connString = connString;
        }

        public IEnumerable<TableClassModel> GetTables(string[] ignoredTableNames = null)
        {
            return GetTableNames()
                .Where(x => ignoredTableNames == null || !ignoredTableNames.Contains(x))
                .Select(tName => new TableClassModel
                {
                    Name = tName,
                    Properties = GetTableColumnsAsProps(tName)
                })
                .ToList();
        }

        private IEnumerable<string> GetTableNames()
        {
            using var dbConnection = new SqlConnection(_connString);
            var command = new SqlCommand(SelectTablesQuery, dbConnection);

            dbConnection.Open();

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                yield return reader[0].ToString();
            }
        }

        private IEnumerable<(string Name, string Type)> GetTableColumnsAsProps(string tableName)
        {
            using var dbConnection = new SqlConnection(_connString);
            var command = new SqlCommand(string.Format(SelectTableColumns, tableName), dbConnection);

            dbConnection.Open();

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                yield return
                (
                    reader[0].ToString(), 
                    MapToPropertyType(
                        columnType: reader[1].ToString(), 
                        nullable: reader[2].ToString() == "YES")
                );
            }
        }

        private static string MapToPropertyType(string columnType, bool nullable)
        {
            return columnType switch
            {
                "varchar" => "string",
                "nvarchar" => "string",
                "char" => "string",
                "nchar" => "string",
                "int" => nullable ? "int?" : "int",
                "bigint" => nullable ? "long?" : "long",
                "bit" => nullable ? "bool?" : "bool",
                "uniqueidentifier" => nullable ? "Guid?" : "Guid",
                var x when 
                    x == "datetime" || 
                    x == "datetime2" => nullable ? "DateTime?" : "DateTime",
                _ => $"___{columnType}___"
            };
        }
    }
}
