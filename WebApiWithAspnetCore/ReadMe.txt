# Study in sequence

1. Pipeline
2. Value (basic flow)
3. Products (no database, action method)
4. Code First 
	dotnet ef migrations add init
	dotnet ef database update
5. Products (database, codefirst, DI, repository pattern)
6. Customers (Validation with dataAnnotation)
7. MovieV1, MovieV2 (Versioning)

NOTE: After practising, #1 should be reviewed. Review launchSettings.json (aspnet-web-api-poster.pdf)
ref: https://exceptionnotfound.net/the-asp-net-web-api-2-http-message-lifecycle-in-43-easy-steps-2/  (this referential web site explains above pdf)

NOTE: Also look at https://docs.microsoft.com/en-us/aspnet/core/fundamentals/servers/kestrel?view=aspnetcore-3.1

Testing should be always with POST MAN or Swagger

(TIP) For swagger testing, exclude MovieV2Controller.cs (same functions), then http://localhost:5000/swagger/
