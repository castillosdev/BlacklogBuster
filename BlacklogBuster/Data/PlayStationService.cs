namespace BlacklogBuster.Data
{
    using BlacklogBuster.Data.Models;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    public class PlayStationService
    {
        public async Task<List<Game>> GetGamesAsync(string username, string password, string userId)
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            using var driver = new ChromeDriver(options);
            //login
            driver.Navigate().GoToUrl("https://store.playstation.com/en-us/home/games");
            driver.FindElement(By.ClassName("web-toolbar__signin-button")).Click();
            driver.FindElement(By.Id("signin-entrance-input-signinId")).SendKeys(username);
            driver.FindElement(By.Id("signin-entrance-button")).Click();
            driver.FindElement(By.Id("signin-password-input-password")).SendKeys(password);
            driver.FindElement(By.Id("signin-password-button")).Click();
            var gameLibraryElement = driver.FindElements(By.TagName("span")).FirstOrDefault(static e => e.Text.Contains("Game Library"));
            if (gameLibraryElement != null)
            {
                gameLibraryElement.Click();
            }
            else
            {
                throw new Exception("Game Library element not found.");
            }

            //if user has 2fa enabled
            //await HandleTwoFactorAuthAsync(driver);
            //await Task.Delay(5000);
            //get games
            var games = new List<Game>();
            var gameElements = driver.FindElements(By.CssSelector(".psw-l-anchor-center")); // Adjust the selector as needed
            foreach (var gameElement in gameElements)
            {
                try
                {
                    // Extract the title
                    var titleElement = gameElement.FindElement(By.CssSelector("div[data-qa='collection-game-list-product#title'] span"));
                    var title = titleElement.Text;

                    // Extract the platform
                    var platformElement = gameElement.FindElement(By.CssSelector("span[data-qa='collection-game-list-product#platform-tags#tag0']"));
                    var platform = platformElement.Text;

                    // Extract the image URL
                    var imageElement = gameElement.FindElement(By.CssSelector("img[data-qa='collection-game-list-product#game-art#image#image']"));
                    var imageUrl = imageElement.GetDomAttribute("src");

                    games.Add(new Game
                    {
                        Title = title,
                        Platform = platform,
                        Status = "Unplayed",
                        AddedDate = DateTime.Now,
                        UserId = userId
                    });

                }
                catch (NoSuchElementException)
                {

                    Console.WriteLine("Could not find all elements for a game entry.");
                }
            }
            return games;

        }

        //public async Task HandleTwoFactorAuthAsync(ChromeDriver driver)
        //{
        //    var twoFactorElement = driver.FindElements(By.CssSelector("div[data-qa='mfa-verification#code']")).FirstOrDefault();
        //    if (twoFactorElement != null)
        //    {
        //        Console.WriteLine("Two-factor authentication required. Please enter the code sent to your device.");
        //        var code = Console.ReadLine();
        //        twoFactorElement.SendKeys(code);
        //        driver.FindElement(By.CssSelector("button[data-qa='mfa-verification#submit']")).Click();
        //    }
        //}
    }
}
