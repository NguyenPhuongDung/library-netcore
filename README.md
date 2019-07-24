# Git
# Visual Studio Code cli
## Init solution 
//new solution
dotnet new sln -o Library
//new project
dotnet new classlib -o Library.Entities
//add project into solution
dotnet sln Library.sln add .\Library.Entities\Library.Entities.csproj
//add reference 
dotnet add reference ../Library.Entities/Library.Entities.csproj
example about dependency injection by C#
