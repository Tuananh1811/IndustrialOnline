# ASP.NET Core 3.1 project from Tuan Anh
## Technologies
- ASP.NET Core 3.1
- Entity Framework Core 3.1
## How to configure and run
- Clone code from Github: git clone https://github.com/Tuananh1811/IndustrialOnline.git
- Open solution eShopSolution.sln in Visual Studio 2019
- Set startup project is Industrial.Data
- Change connection string in Appsetting.json in Industrial.Data project
- Open Tools --> Nuget Package Manager --> Package Manager Console in Visual Studio
- Run Update-database and Enter.
- After migrate database successful, set Startup Project is eShopSolution.WebApp
- Change database connection in appsettings.Development.json in eShopSolution.WebApp project.
- You need to change 3 projects to self-host profile.
- Set multiple run project: Right click to Solution and choose Properties and set Multiple Project, choose Start for 3 Projects: BackendApi, WebApp and AdminApp.
Choose profile to run or press F5
