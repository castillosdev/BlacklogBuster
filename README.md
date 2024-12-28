BlacklogBuster 🎮✨🎉

BlacklogBuster is a Blazor Server application designed to help users manage and synchronize their game backlogs across multiple platforms, including Steam and PlayStation. It provides a streamlined way to track game ownership and progress while integrating data from third-party APIs and services. 🎯🌟📚

![explosion](https://github.com/user-attachments/assets/b6878053-798f-4aa9-8bf4-ace5b8419a50)


Features 🚀🌈🕹️

Game Synchronization:

Sync games from Steam using the Steam API.

Sync games from PlayStation using Selenium for scraping data.

User Authentication:

Secure user accounts with ASP.NET Identity.

Requires email confirmation for account activation.

Game Backlog Management:

Add, update, and delete games.

View games grouped by platform.

Responsive User Interface:

Built with Blazor Server for real-time interactivity. ⚡🖥️🌐

Technologies Used 🛠️💻📊

Frontend: Blazor Server

Backend:

ASP.NET Core

Entity Framework Core

ASP.NET Identity

Database: SQL Server

Third-Party Integrations:

Steam API

Selenium WebDriver (for PlayStation scraping)

API Documentation: Swagger UI 📖📡🖊️

Prerequisites 📋✅🔧

.NET SDK 7.0 or later

SQL Server

ChromeDriver (for Selenium)

Steam API Key (get it from Steam Community API) 🔑🌐🎲

Installation ⚙️💾✨

Clone the Repository: 🖨️📂🔗

git clone https://github.com/your-username/BlacklogBuster.git
cd BlacklogBuster

Set Up the Database: 🗄️🔗🛠️

Update the connection string in appsettings.json:

"ConnectionStrings": {
    "DefaultConnection": "Your SQL Server Connection String"
}

Run the following command to apply migrations:

dotnet ef database update

Configure Steam API Key: 🔐🎮🌟

Add your Steam API key to appsettings.json:

"SteamApiKey": "Your Steam API Key"

Install ChromeDriver: 🌐🚗🔧

Ensure ChromeDriver is installed and added to your system's PATH.

Run the Application: 🚀💡📊

dotnet run

Open your browser and navigate to https://localhost:5001 (or the specified port). 🌎🔒🖥️

API Endpoints 🔗📝⚙️

Swagger UI 🎛️📜🎨

Access the Swagger UI at https://localhost:5001/swagger for interactive API testing. 🧪🌐📑

Sync Backlog 🔄🎮🕹️

POST /api/BacklogSync/sync

Request Body:

{
  "steamId": "Steam ID",
  "psnUsername": "PlayStation Username",
  "psnPassword": "PlayStation Password",
  "userId": "Logged-in User ID"
}

Response:

{
  "message": "Backlog sync completed successfully."
}
``` 🌟✅📩

Development 🛠️💡📚

Adding a New Migration 🎉🛠️📋

To create a new migration:

dotnet ef migrations add MigrationName

Updating the Database 🗄️🔄✨

dotnet ef database update

Future Enhancements 🔮🚀✨

Support for Additional Platforms:

Nintendo and Xbox integration.

Progress Tracking:

Track completion and playtime for games.

Improved Analytics:

Generate insights on gaming habits.

Offline Mode:

Allow offline backlog management with synchronization. 📈📊📲

Contributing 🤝📬🌟

Contributions are welcome! Please fork the repository and submit a pull request. 🛠️🎉🌐

License 📜⚖️💡

This project is licensed under the MIT License. See the LICENSE file for details. 🏷️📖✅

Acknowledgments 🎉👏💡

Steam API for game data.

Selenium WebDriver for PlayStation scraping.

Microsoft for the Blazor Server framework. 🎮✨🔧

