Small .NET Core Global Tool for generating the C# model classes from SQL tables.

[![Actions Status](https://github.com/imujagic/sql-to-sharp/workflows/build-on-push/badge.svg)](https://github.com/imujagic/sql-to-sharp/actions)

Following parameters are required in order to run the generator successfully:

- `--dbms` Specifies the DBMS type, e.g. SqlServer, Postgres (Currently only SqlServer is supported)
- `--conn-string` Specifies the target database connection string
- `--output-dir` Path to the directory where the classes will be generated
- `--namespace` Namespace under which the classes will be generated

Tool can be started from the project or published and installed as the .NET Core Global Tool.

If the Global Tool is installed then the generator can be invoked by `sql2sharp` command together with required arguments.

Command example

```bash
sql2sharp \
    --dbms "SqlServer" \
    --conn-string "Server=localhost;Database=DModelSample;User Id=db_model_generator_user;Password=DbModelGen123#;" \
    --output-dir "./Output" \
    --namespace "Sample.DbModel"
```