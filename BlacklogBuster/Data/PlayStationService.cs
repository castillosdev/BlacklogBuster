using BlacklogBuster.Data.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.Json;

namespace BlacklogBuster.Data
{
    public class PlayStationService
    {
        private readonly IWebDriver driver;

        public PlayStationService(IWebDriver driver)
        {
            this.driver = driver;
        }

        public async Task<List<Game>> GetGamesAsync(string username, string password, string userId)
        {
            var games = new List<Game>();

            try
            {
                // Navigate to PlayStation Store
                driver.Navigate().GoToUrl("https://store.playstation.com/en-us/home/games");

                // Login
                LoginToPlayStation(username, password);

                // Navigate to "Game Library"
                NavigateToGameLibrary();

                // Extract games
                games = ExtractGameLibrary(userId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                driver.Quit();
            }

            return games;
        }

        private void LoginToPlayStation(string username, string password)
        {
            driver.FindElement(By.ClassName("web-toolbar__signin-button")).Click();
            driver.FindElement(By.Id("signin-entrance-input-signinId")).SendKeys(username);
            driver.FindElement(By.Id("signin-entrance-button")).Click();
            driver.FindElement(By.Id("signin-password-input-password")).SendKeys(password);
            driver.FindElement(By.Id("signin-password-button")).Click();
        }

        private void NavigateToGameLibrary()
        {
            var gameLibraryElement = driver.FindElements(By.TagName("span"))
                .FirstOrDefault(e => e.Text.Contains("Game Library"));

            if (gameLibraryElement == null)
            {
                throw new Exception("Game Library element not found.");
            }

            gameLibraryElement.Click();
        }

        private List<Game> ExtractGameLibrary(string userId)
        {
            var games = new List<Game>();

            var gameElements = driver.FindElements(By.CssSelector(".psw-l-anchor-center"));
            foreach (var gameElement in gameElements)
            {
                try
                {
                    var title = gameElement.FindElement(By.CssSelector("div[data-qa='collection-game-list-product#title'] span")).Text;
                    var platform = gameElement.FindElement(By.CssSelector("span[data-qa='collection-game-list-product#platform-tags#tag0']")).Text;
                    var imageUrl = gameElement.FindElement(By.CssSelector("img[data-qa='collection-game-list-product#game-art#image#image']")).GetDomAttribute("src");

                    games.Add(new Game
                    {
                        Name = title,
                        Platform = new Models.Platform { Name = platform },
                        Metadata = "Unplayed",
                        ReleaseDate = DateTime.Now,
                        UserGames = new List<UserGame> { new UserGame { UserId = userId } }
                    });
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("Could not find all elements for a game entry.");
                }
            }

            return games;
        }
    }
}
