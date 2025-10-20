# Book API

## Database migrations
In order to configure the database with the migrations run those two commands bellow:
- dotnet ef migrations add InitialCreate --project BookAPI.Data --startup-project BookAPI
- dotnet ef database update --project BookAPI.Data --startup-project BookAPI