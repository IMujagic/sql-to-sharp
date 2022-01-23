This tool lets you generate the C# model classes from existing SQL Database. 

[![Actions Status](https://github.com/imujagic/sql-to-sharp/workflows/build/badge.svg)](https://github.com/imujagic/sql-to-sharp/actions)

### Parameters

Following parameters are required in order to run the generator successfully:

- `--dbms` Specifies the DBMS type, e.g. SqlServer, Postgres (Currently only SqlServer is supported)
- `--conn-string` Specifies the target database connection string
- `--output-dir` Path to the directory where the classes will be generated
- `--namespace` Namespace under which the classes will be generated
- `--ignore` Optional argument that gives option to ignore specific tables

### Installation

Install as a NuGet global tool: `dotnet tool install --global SqlToSharp`

### Usage

Tool can be started from the project or published and installed as the `.NET Core Global Tool`.

If the Global Tool is installed then the generator can be invoked by `sql2sharp` command together with required arguments.

Command example

```bash
sql2sharp \
    --dbms "SqlServer" \
    --conn-string "Data Source=.;Initial Catalog=SampleDB;Integrated Security=true" \
    --output-dir "./Output" \
    --namespace "Sample.DbModel"
```

If you want to start it from source, first clone this repository, position yourself inside `./Src` folder and run following command

Command example

```bash
dotnet run \
    --dbms "SqlServer" \
    --conn-string "Data Source=.;Initial Catalog=SampleDB;Integrated Security=true" \
    --output-dir "./Output" \
    --namespace "Sample.DbModel"
```
