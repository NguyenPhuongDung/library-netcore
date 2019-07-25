# Git
git pull --allow-unrelated-histories
# Visual Studio Code cli
## Init solution 
### new solution
dotnet new sln -o Library
### new project
dotnet new classlib -o Library.Entities
### add project into solution
dotnet sln Library.sln add .\Library.Entities\Library.Entities.csproj
### add reference 
dotnet add reference ../Library.Entities/Library.Entities.csproj
## Code first migration Cli
### migration database
1. dotnet ef migrations add InitialModel -s Library.Api -p Library.Entities -o ./Migrations
2. dotnet ef database update -s Library.Api -p Library.Entities 
## Add angular into solution
ng new Library-Angular --directory Library.Angular
# Package
## codegenerate
1. Microsoft.EntityFrameworkCore;
1. Microsoft.VisualStudio.Web.CodeGeneration.Tools
2. Microsoft.VisualStudio.Web.CodeGeneration.Design

