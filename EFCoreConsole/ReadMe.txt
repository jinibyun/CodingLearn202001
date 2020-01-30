## using dotnet cli, how to migrate, update database etc

1. preparation: to create the database from the model (entities and context) by adding a migration.
dotnet ef migrations add CreateSchoolDB

2. Applying migration 
dotnet ef database update

3. NOTE: After upgrading to .net core 3.*, dotnet ef is missing  (from CLI)
Therefore, we added global.json based on following url recommendation: https://github.com/dotnet/efcore/issues/18282