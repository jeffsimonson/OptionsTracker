# OptionsTracker - C#/ASP.Net Core

During my absence from the software development industry, I was self-employed as futures/commodities options trader. Since I was a bit short on project ideas, I decided to draw upon my knowledge and experiences as an options trader in order to create an application that would be useful for keeping track of my options trade positions.

OptionsTracker was built using the ASP.NET Core project template for a Web Application with Razor pages. The app's main trade model class uses Entity Framework Core (EF Core) to interact with the app's MS SQL database.

The primary purpose of this project is to demonstrate basic "CRUD" actions with the database as well as some more complicated SQL queries with the help of LINQ. Since that is the primary focus, a more minimalist approach was taken for the initial styling of the application and was not developed for real world purposes beyond that of a single user with no security built in.

Planned enhancements include login/authentication, a user-profile setup, automatic retrieval the current price from an on-line source, and a historical archive of closed trades
