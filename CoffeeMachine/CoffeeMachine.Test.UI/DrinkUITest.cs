using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CoffeeMachine.Test.UI
{
    public class DrinkUITest
    {
        // Ambiente di DEV
        Uri baseAddressCoffeeMachine = new Uri("https://k6loadtesting.azurewebsites.net/machine");
       
        [Fact]
        public void BuyCoffee()
        {
            IWebDriver driver = new ChromeDriver(System.IO.Directory.GetCurrentDirectory());
            driver.Navigate().GoToUrl(baseAddressCoffeeMachine);
            Task.Delay(2000).Wait();
            // Seleziono il caffè
            var drinks = driver.FindElements(By.ClassName("card"));
            drinks[0].Click();

            // inserisco la moneta
            var coinInserted = driver.FindElement(By.Id("coinInserted"));
            coinInserted.Clear();
            coinInserted.SendKeys("1");
            // Acquisto
            var confirm = driver.FindElement(By.TagName("form"));
            confirm.Submit();

            driver.Close();
            driver.Quit();
        }

        [Fact]
        public void BuyThe()
        {
            IWebDriver driver = new ChromeDriver(System.IO.Directory.GetCurrentDirectory());
            driver.Navigate().GoToUrl(baseAddressCoffeeMachine);
            Task.Delay(2000).Wait();
            // Seleziono il caffè
            var drinks = driver.FindElements(By.ClassName("card"));
            drinks[1].Click();

            // inserisco la moneta
            var coinInserted = driver.FindElement(By.Id("coinInserted"));
            coinInserted.Clear();
            coinInserted.SendKeys("0.8");
            // Acquisto
            var confirm = driver.FindElement(By.TagName("form"));
            confirm.Submit();

            driver.Close();
            driver.Quit();
        }

        [Fact]
        public void BlockCappuccino()
        {
            IWebDriver driver = new ChromeDriver(System.IO.Directory.GetCurrentDirectory());
            driver.Navigate().GoToUrl(baseAddressCoffeeMachine);
            Task.Delay(2000).Wait();
            // Seleziono il caffè
            var drinks = driver.FindElements(By.ClassName("card"));
            drinks[2].Click();

            // inserisco la moneta
            var coinInserted = driver.FindElement(By.Id("coinInserted"));
            coinInserted.Clear();
            coinInserted.SendKeys("1");
            coinInserted.SendKeys(Keys.Tab);

            // Verifico quanti soldi mancano
            var coinDifference = driver.FindElement(By.Id("coinDifference"));
            var value = coinDifference.GetAttribute("value");
            Assert.Equal("-0.2", value);

            // Verifico blocco confirm
            var confirmButton = driver.FindElement(By.ClassName("btn-primary"));
            Assert.False(confirmButton.Enabled);

            driver.Close();
            driver.Quit();
        }
    }
}
