# BookApiMvc
Library Catalogue Console App written in C#

The database is SQL Server local server (or your choice):
using connectionstring in appsettings.json:
  "connectionStrings": {
    "bookDbConnectionString": "Server=(localdb)\\mssqllocaldb;Database=BookDb;Trusted_Connection=True;"
    
database creation can be done by migration or by restoring the database (received in your email)

migration method:
---------
1) create database it through migration (as specified in the BookDbContext)
2) in the Startup.cs, uncomment context.SeedDataContext(); 
  this will seed the database with data.
3) after seeding, remember to comment out the seed method before running the app again otherwise the data will be duplicated
