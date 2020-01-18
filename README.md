This tool lets you generate the C# model classes or the whole EF Model from existing SQL Database. 

[![Actions Status](https://github.com/imujagic/sql-to-sharp/workflows/build/badge.svg)](https://github.com/imujagic/sql-to-sharp/actions)

### TODOs

- [x] Generate mmodel classes from `SQL Server` database tables 
- [ ] Generate model classes from `Postgres` database tabless
- [ ] Provide the argument for ignore table list
- [ ] EF support
    - [ ] Scaffold entity type classes and a DbContext class based on a `Sql Server` database schema
    - [ ] Scaffold entity type classes and a DbContext class based on a `Postgres` database schema

### Parameters

Following parameters are required in order to run the generator successfully:

- `--dbms` Specifies the DBMS type, e.g. SqlServer, Postgres (Currently only SqlServer is supported)
- `--conn-string` Specifies the target database connection string
- `--output-dir` Path to the directory where the classes will be generated
- `--namespace` Namespace under which the classes will be generated

### Usage

Tool can be started from the project or published and installed as the `.NET Core Global Tool`.

If the Global Tool is installed then the generator can be invoked by `sql2sharp` command together with required arguments.

Command example

```bash
sql2sharp \
    --dbms "SqlServer" \
    --conn-string "Server=localhost;Database=DModelSample;User Id=db_model_generator_user;Password=MyStrongPass123#;" \
    --output-dir "./Output" \
    --namespace "Sample.DbModel"
```