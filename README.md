# EntityFrameworkWebAPI

## How to run this ??
### (For Windows/VisualStudio/VisualStudioForMac) Open Package Manager Console 
#### * run
```bash
Update-Database
```


### (For MacOS/VSCode) Make sure you have EF CLI installed on your machine, learn more at: https://www.nuget.org/packages/dotnet-ef/7.0.7
#### * run
```bash
dotnet ef database update
```
### In case of ERROR applying database update:
#### Delete all migrations in the Migrations folder and run the applying db command again.
