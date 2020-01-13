Small CLI tool for generating the C# model classes.


## Prepare SQL Server Sample Database

` sqlcmd -S SERVER_NAME -U ADMIN_USERNAME -P 'ADMIN_PASSWORD' -i ./DBScripts/sql-server-sample.sql`

Run generate command:

`dotnet run --dbms "SqlServer" --conn-string "Server=localhost;Database=DModelSample;User Id=db_model_generator_user;Password=DbModelGen123#;" --output-dir "./Output" --namespace "Sample.DbModel"`
