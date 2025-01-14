using BlacklogBuster.Areas.Identity;
using BlacklogBuster.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddScoped<GameService>();
builder.Services.AddScoped<IWebDriver>(sp =>
{
    var options = new ChromeOptions();
    options.AddArgument("--headless");
    return new ChromeDriver(options);
});
builder.Services.AddScoped<PlayStationService>();
builder.Services.AddHttpClient<SteamService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

// TODO: Define new database models to align with Steam's game data structure.
// TODO: Add "SteamGame" table with the following fields:
//       - AppId (int)
//       - Name (string)
//       - PlaytimeForever (int)
//       - ImgIconUrl (string)
//       - HasCommunityVisibleStats (bool)
//       - PlaytimeWindowsForever (int)
//       - PlaytimeMacForever (int)
//       - PlaytimeLinuxForever (int)
//       - PlaytimeDeckForever (int)
//       - RtimeLastPlayed (DateTime)
//       - PlaytimeDisconnected (int)
// TODO: Add "SteamGameMetadata" table to hold additional metadata.
// TODO: Add "UserSteamGames" table to establish relationships between users and Steam games.

// TODO: Create migrations for the new tables and update the database schema.
// TODO: Write seed data for testing the new structure.

// TODO: Update the "SteamService" class to map API data to the new database structure.
// TODO: Modify the "GetSteamGamesAsync" method to:
//       - Retrieve game data from the Steam API.
//       - Map the data to the new model.
//       - Save or update game records in the database.

// TODO: Update the "GameService" class to:
//       - Manage CRUD operations for Steam games.
//       - Link Steam games to users.

// TODO: Update the database context to include new DbSet properties for the new tables.

// TODO: Test all CRUD operations for the new tables.
// TODO: Validate that data is correctly mapped and stored in the database.

// TODO: Update the UI to display Steam-specific game data:
//       - Show playtime, icons, and last played timestamps.
// TODO: Implement a way to differentiate Steam games from other platforms in the UI.

// TODO: Write unit tests for the new database models.
// TODO: Write integration tests for the SteamService and GameService updates.
