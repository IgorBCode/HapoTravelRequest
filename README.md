Requirements:
- Microsoft .NET 8.0 SDK
- Microsoft SQL Server
- ASP.NET Core Runtime version 8.0+ (if needed)

To run with Visual Studio: 
1. Download the GitHub repository and open the project in Visual Studio
2. In appsettings.json, update the DefaultConnection: Server field with your server computer's name
3. Open Tools -> NuGet Package Manager -> Package Manager Console
4. In the console, run the command "update-database". This will set up the database for the application
5. Run the application

To run with Visual Studio Code:
1. Download repo and open the folder in Visual Studio Code
2. Open a Powershell/Command Prompt terminal in the 'HapoTravelRequest' directory of your repository folder
3. Install dotnet-ef (if not already installed) with the command 'dotnet tool install --global dotnet-ef'
4. Run the command 'dotnet ef database update'. This will set up the database for the application
5. Run the application with 'dotnet watch run'