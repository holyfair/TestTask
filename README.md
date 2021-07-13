# TestTask
# Start project
Need to build project and start it from Visual Studio IDE.
Project starts from swagger page where you can test API.

# Project structure
1. Database - was chosen unralational database (Mongo) to store polymorphyc data in one collection
2. Swagger - to test API
3. Test library - xUnit
4. Automapper - to map polymorpyc types
5. AspNetCoreRateLimit - to implement limit of requests

# Polymorphyc data binding
Polymorphyc data binding was implemented regarding
[MS documantation] (https://docs.microsoft.com/en-us/aspnet/core/mvc/advanced/custom-model-binding?view=aspnetcore-5.0) -
 file in project (CustomerModelBinderProvider.cs).
 To create a specific type of customer you should choose a brand type what is an enum.
 0 - MrGreenCustomer.
 1 - RedBetCustomer.

# Limit of requests
To change the limit of requests to one minute you should change the "Limit" field in the appsettings.json file

# Future improvements
1. Replace integers into strings in post parameter brand type in the body.
2. Add business logic to operate with customer models.
