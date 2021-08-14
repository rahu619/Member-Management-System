# Member Management System API

A basic Member Management System - Web API project developed in .NET Core 3.0 and SQL Server. 

# Usage

To replicate the database, execute the following code snippet. 
Please make sure to update the connectionstring value in the appsettings file before applying the migration.

```cmd 
 cd LoyaltyPrime.API 

 dotnet ef database update / dotnet ef migrations script
```

 And to build and run the application,

```cmd
dotnet build

dotnet run
```

The index page will give an overview of the exposed APIs.

Also, a Postman collection could also be found in the API project - **LoyaltyPrime API Collection.postman_collection.json**. 





