
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.Events;
using System.Net.NetworkInformation;

namespace AppiumDesktopTests
{
    public class AppiumDesktopTests
    {

        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";
        private const string appLocation = @"D:\QA_Automation\Exam\Contactbook-Exam-Resources\ContactBook-DesktopClient.NET6\ContactBook-DesktopClient.exe";
        private WindowsDriver<WindowsElement> driver;
        private WindowsDriver<WindowsElement> driver2;
        private AppiumOptions appiumOptions;
        private AppiumOptions appiumOptions2;

        [SetUp]
        public void Setup()
        {
            this.appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("app", "Root");
            appiumOptions.AddAdditionalCapability("platformName", "Windows");
            this.driver = new WindowsDriver<WindowsElement>(new Uri(appiumServer), appiumOptions);

            driver = new WindowsDriver<WindowsElement>(new Uri(appiumServer), appiumOptions);

            this.appiumOptions2 = new AppiumOptions();
            appiumOptions2.AddAdditionalCapability("app", appLocation);
            appiumOptions2.AddAdditionalCapability("platformName", "Windows");
            this.driver2 = new WindowsDriver<WindowsElement>(new Uri(appiumServer), appiumOptions2);

            driver2 = new WindowsDriver<WindowsElement>(new Uri(appiumServer), appiumOptions);


        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
        [Test]
        public void SearchContact()
        {
      
            driver2.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            var firstField = driver.FindElementByAccessibilityId("textBoxApiUrl");
            firstField.SendKeys("https://contactbook-1.desirad.repl.co/api");
            var connectButton = driver.FindElementByAccessibilityId("buttonConnect");
            connectButton.Click();

            var secondWindow = driver2.FindElementByName("Search Contacts");
            var searchField = driver2.FindElementByAccessibilityId("textBoxSearch");
            searchField.SendKeys("steve");
            var searchBtn = driver2.FindElementByAccessibilityId("buttonSearch");
            searchBtn.Click();

            var firstName = driver2.FindElementByName("FirstName Row 0, Not sorted.").Text;
            var lastName = driver2.FindElementByName("LastName Row 0, Not sorted.").Text;

            Assert.That(firstName, Is.EqualTo("Steve"));
            Assert.That(lastName, Is.EqualTo("Jobs"));
        }
    }
}