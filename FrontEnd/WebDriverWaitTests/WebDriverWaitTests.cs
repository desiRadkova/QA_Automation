using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebDriverWaitTests
{
    public class WebDriverWaitTests
    {
        private WebDriver driver;
        private WebDriverWait wait;
        //private IWebElement firstNumberInput;
        //private IWebElement operationInput;
        //private IWebElement secondNumberInput;
        //private IWebElement calcResultBtn;
        //private IWebElement result;

        [SetUp]
        public void OpenBrowser()
        {
            //Workaround for ChromeDriver Vesrion
            //===============================================================================
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--start-maximized"); //Maximize the window
            // When you have Wait elements in tests this will fail them
            //chromeOptions.AddArguments("--headless"); //Don't show the browser
            chromeOptions.AddArguments("--remote-allow-origins=*"); //<-this is the fix for different versions
            //===============================================================================
            this.driver = new ChromeDriver(chromeOptions);

            //Open Wikipedia
            driver.Url = "http://www.uitestpractice.com/";
            //this.firstNumberInput = driver.FindElement(By.Id("number1"));
            //this.operationInput = driver.FindElement(By.Id("operation"));
            //this.secondNumberInput = driver.FindElement(By.Id("number2"));
            //this.calcResultBtn = driver.FindElement(By.Id("calcButton"));
            //this.result = driver.FindElement(By.Id("result"));
        }

        [TearDown]
        public void CloseBrowser()
        {
            //Close Browser
            this.driver.Quit();

        }

        [Test]
        public void TestWait_TreadSleeep()
        {
            var link = driver.FindElement(By.LinkText("AjaxCall"));
            link.Click();

            var intLink = driver.FindElement(By.LinkText("This is a Ajax link"));
            intLink.Click();

            Thread.Sleep(10000); //This is bad practice

            var textElement = driver.FindElement(By.ClassName("ContactUs")).Text;

            Assert.That(textElement.Contains("Selenium is a portable software testing framework for web applications."));
        }
        [Test]
        public void TestWait_ImplicitWait()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20); //This makes test run faster and it is better that Thread.Slee. It could be put only in SetUp and it will be valid for all tests

            var link = driver.FindElement(By.LinkText("AjaxCall"));
            link.Click();

            var intLink = driver.FindElement(By.LinkText("This is a Ajax link"));
            intLink.Click();

            var textElement = driver.FindElement(By.ClassName("ContactUs")).Text;

            Assert.That(textElement.Contains("Selenium is a portable software testing framework for web applications."));
        }
        [Test]
        public void TestWait_ExplicitWait()
        {
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            var link = driver.FindElement(By.LinkText("AjaxCall"));
            link.Click();

            var intLink = driver.FindElement(By.LinkText("This is a Ajax link"));
            intLink.Click();

            var textElement = wait.Until(d => {
                return driver.FindElement(By.ClassName("ContactUs"));
            }
            );

            Assert.That(textElement.Text.Contains("Selenium is a portable software testing framework for web applications."));
        }
        [Test]
        public void TestWait_MultipleWaits()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));

            var link = driver.FindElement(By.LinkText("AjaxCall"));
            link.Click();

            var intLink = driver.FindElement(By.LinkText("This is a Ajax link"));
            intLink.Click();

            var textElement = wait.Until(d => {
                return driver.FindElement(By.ClassName("ContactUs"));
            }
            );

            Assert.That(textElement.Text.Contains("Selenium is a portable software testing framework for web applications."));
        }
    }
}