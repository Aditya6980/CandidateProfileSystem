#Candidate & Technology Management System
Project Description
This is a .NET Core web application that performs CRUD operations using Entity Framework Core and SQL Server.
It allows managing candidate information along with their technology interests.

#Technologies Used in this Project
.NET Core 
Entity Framework Core
SQL Server
ASP.NET MVC
Bootstrap (for UI responsiveness)

#Step to Configure the Database with Entity Framework Core
Install Necessary Packages
Install Entity Framework Core and SQL Server support using NuGet Package Manager.
Set Up the Database Connection
Modify the appsettings.json file to include the database connection string.
Define Database Models
Create a Candidate model with fields like Name, Email, Contact Number, Degree, and Technology.
Create a Technology model with fields for Technology Name.
Create the Database Context
Set up a class that interacts with the database using Entity Framework Core.
Run Migrations to Create the Database
Generate migration files and apply them to create the database schema.

#Features Implemented
CRUD Operations for Candidate
✅ Create a new candidate entry
✅ View all candidates
✅ Update candidate details
✅ Delete a candidate

CRUD Operations for Technology
✅ Add new technology if it doesn’t exist
✅ View available technologies
✅ Update and delete technologies

Additional Features
✅ Dropdown list for selecting technology in the candidate form
✅ Option to add a new technology if not available in the dropdown

#Implemented more Additional Features like,
Validation
Ensure required fields are filled using validation attributes.
Error Handling
Display user-friendly error messages if an issue occurs.
AJAX for Dynamic Content 
Load technologies dynamically in the dropdown list without refreshing the page.
Search Functionality 
Implement a search bar to filter candidates by name or technology.

#Finally Run And Test the application in the visual studio along with ,
Verify that changes reflect correctly in the SQL Server database.
