# ABCCollege
.Net Core-Angular


# Clone the repo
git clone https://github.com/rajitharumesh/ABCCollege.git

# Prerequisites

Visual Studio 2019 16.4.0 or later
ASP.NET Core 3.1
SQL Server 2017 or later

# How to run the project
Checkout this project to a location in your disk.
Open the solution file using the Visual Studio 2019.
Restore the NuGet packages by rebuilding the solution.

# Database 
Create database in Sql Server Object Explorar as ABCCollege

# Open the Package Manager Console from the menu Tools -> NuGet Package Manager -> Package Manager Console in Visual Studio and execute the following command to add a migration.

Step 1:  dotnet ef migrations add MyFirstMigration
Step 2: Update-Database

Change the connection string in the appsettings.json file that points to your SQL Server
Run the project.

This is using https://github.com/rajitharumesh/collage as a client project
