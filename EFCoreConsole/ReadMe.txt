## using dotnet cli, how to migrate, update database etc

0. Make sure SQL server is accessbile

1. preparation: to create the database from the model (entities and context) by adding a migration.
dotnet ef migrations add CreateSchoolDB

2. Applying migration 
dotnet ef database update

3. NOTE: After upgrading to .net core 3.*, dotnet ef is missing  (from CLI)
Therefore, we added global.json based on following url recommendation: https://github.com/dotnet/efcore/issues/18282

4. confirm database table whether it is created

5. then do exercise of Entity Framework in Program.cs

6. refer to https://www.entityframeworktutorial.net/efcore/working-with-stored-procedure-in-ef-core.aspx to work with stored proc

7. after code analysis (Program.cs), then exercise of migrations (using dotnet CLI) with "data seed" OnModelCreating(ModelBuilder modelBuilder)