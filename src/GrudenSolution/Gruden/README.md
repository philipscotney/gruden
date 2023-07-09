# gruden
Interview Demo - Philip Scotney
 
# localhost Developement Certs

Run In powershell run "dotnet dev-certs https --trust" to create and install a new one.


# install latest node version

Using NPM:
To update Node using NPM, do the following:

Open the Terminal and check your current Node version: 
node -v 
Install n package using the following command:
npm install -g n   
This command will install a tool called "n" which you can use to update Node easily.
To update Node, run the following command in your terminal:           
n latest
This command will install the latest version of Node on your system.
Now you can verify that your update is complete by rechecking your Node version:  
node -v
You can also manually download and install the latest Node version from the official website https://nodejs.org/en/download/current/.

# install angular
In ClientApp install angular cli

npm install -g @angular/cli

# .NET Core 6 packages

# Microsoft.EntityFrameworkCore
Entity Framework (EF) Core is a lightweight, extensible, open source and cross-platform version of the popular Entity Framework data access technology.

EF Core can serve as an object-relational mapper (O/RM), which:

Enables .NET developers to work with a database using .NET objects.
Eliminates the need for most of the data-access code that typically needs to be written.

 run the following command in the Package Manager Console in Gruden folder:

Install-Package Microsoft.EntityFrameworkCore 6.0.19

# Microsoft.EntityFrameworkCore.InMemory
This database provider allows Entity Framework Core to be used with an in-memory database.
While some users use the in-memory database for testing, this is discouraged. For more information on how to test EF Core applications, see the Testing EF Core Applications.
The provider is maintained by Microsoft as part of the Entity Framework Core Project

Install-Package Microsoft.EntityFrameworkCore.InMemory -Version 6.0.19

# Microsoft.AspNetCore.SpaProxy

Helpers for launching the SPA CLI proxy automatically when the application starts in ASP.NET MVC Core.
  
Install-Package Microsoft.AspNetCore.SpaProxy -Version 6.0.19


# Serilog.Extensions.Logging.File

Add file logging to ASP.NET Core apps

Install-Package Serilog.Extensions.Logging.File -Version 3.0.0


