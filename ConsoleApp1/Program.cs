using NUnit.Framework;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using static OpenQA.Selenium.BiDi.Modules.BrowsingContext.Locator;

namespace ConsoleApp1
{
    public class Tests
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        [SetUp]
        public void Setup()
        {
            _driver = new EdgeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void TestPageTitle()
        {
            _driver.Navigate().GoToUrl("https://kinosfera.info/");

            string expectedTitle = "Главная";
            string actualTitle = _driver.Title;
            Assert.That(actualTitle, Is.EqualTo(expectedTitle), "Заголовок страницы не равен ожидаемому");
        }

        [Test]
        public void TestElementVisibility()
        {
            _driver.Navigate().GoToUrl("https://kinosfera.info/");

            

            IWebElement element = _driver.FindElement(By.XPath("/html/body/div[1]/header/div[2]/nav/div/div/div/ul/li[2]"));

            Assert.That(element.Displayed, Is.True, "Элемент на странице не видим");

        }

        [Test]
        public void TestNavigation()
        {
            _driver.Navigate().GoToUrl("https://kinosfera.info/");

            IWebElement link = _driver.FindElement(By.XPath("/html/body/div[1]/main/div[2]/div/div/div[2]/div[5]/div/div[3]/div/a/h3"));
            link.Click();

            Assert.That(_driver.Url, Does.Contain("projects"), "Переход по ссылке не выполнен.");
        }

        [Test]
        public void TestButtonClick()
        {
            _driver.Navigate().GoToUrl("https://kinosfera.info/");

            IWebElement button = _driver.FindElement(By.XPath("/html/body/div[1]/header/div[1]/div/div/div[2]/div[1]/ul/li[2]/button"));

            button.Click();

            Assert.Throws<NoSuchElementException>(() => _driver.FindElement(By.XPath("/html/body")));
        }


        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
