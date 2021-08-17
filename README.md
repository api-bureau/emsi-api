# Emsi Client

The purpose of this project is to help you exploring Emsi APIs and speed up your Emsi APIs C# and .NET Core implementation.

## To Do 

- [x] Check Emsi Endpoints https://api.emsidata.com/apis/skills
- [x] Create Postman collection
- [x] Create Console Application to access APIs
- [x] Create Emsi.Api Library to access APIs
- [ ] Add Emsi.Api Library to NuGet by using Github Actions - CI/CD (Deployment)
- [ ] Add ErrorDto parsing
- [x] Add Logging
- [x] Create Console Application which uses the library
- [ ] Create Database Layer / Library to store data by using the Library above (SQLite)
  - Entity Framework SQL Server, MySQL 
- [x] Create Website 
   - [ ] Add Razor
   - [ ] Add Blazor
   - [ ] Add Angular
   - [ ] Add Azure App Service 
   - [ ] OData
- [ ] Website - Add Emsi API calls
- [ ] Website - Add Local database SQLite
- [ ] Website - Implement CI/CD (Deployment) 
- [ ] Website - Add Search Skill
- [ ] Website - Add Search Skill by Type
- [ ] Website - Show stats
- [ ] CI/CD (Deployment)
- [ ] Add some documentation
- [ ] Migrate to .NET 6

## Projects
- [x] Emsi.Playground (Console App)
- [x] Emsi.Api.Client (Library, NuGet)
- [ ] Emsi.Api.Console (Console App)
- [ ] Emsi.Database (Library, SQLite)
- [ ] Emsi.Api.Sync.Console (Console App) 
- [ ] Azure Functions (Time Triggered)
- [x] Emsi.Web (Web)

## Web Example
![image](https://user-images.githubusercontent.com/4528464/129445210-96d5e942-6218-4da4-8056-db4cd2eb17a1.png)

## Emsi Api Console
You can run emsibg.exe to get the following

- `emsibg skills status` - get status
- `emsibg skills meta` - get meta
- `emsibg skills versions` - lists versions
- `emisbg skills --id "id" --version "7.23"` - list specific skill, version is optional, default is latest

## Contributors
This project adheres following guidelines.
- https://github.com/dotnet/runtime/blob/main/docs/coding-guidelines/coding-style.md
- https://github.com/dotnet/runtime/tree/main/docs#coding-guidelines

## Code of Conduct
This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/).

## References
- Request API Key https://www.economicmodeling.com/open-titles-api-contact/
- Emsi Skills API https://api.emsidata.com/apis/skills


