

## using dotnet cli, how to migrate, update database etc

1. preparation: to create the database from the model (entities and context) by adding a migration.
dotnet ef migrations add CreateSchoolDB

2. Applying migration 
dotnet ef database update