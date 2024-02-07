using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.Events;
using System.Net.NetworkInformation;
using System.Linq;
using OpenQA.Selenium;
using System.Drawing;
using System;

namespace Progress_FiddlerEverywhere
{
    public class Progress_FiddlerEverywhere_Tests
    {
        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";
        private const string appLocation = @"C:\Users\Desi_Asus\AppData\Local\Programs\Fiddler Everywhere\Fiddler Everywhere.exe";
        private WindowsDriver<WindowsElement> driver;
        private WindowsDriver<WindowsElement> driver2;
        private WindowsDriver<WindowsElement> driver3;
        private AppiumOptions appiumOptions;
        private AppiumOptions appiumOptions2;
        private AppiumOptions appiumOptions3;

        [SetUp]
        public void Setup()
        {
            this.appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("app", "Root");
            appiumOptions.AddAdditionalCapability("platformName", "Windows");
            this.driver = new WindowsDriver<WindowsElement>(new Uri(appiumServer), appiumOptions);

            driver = new WindowsDriver<WindowsElement>(new Uri(appiumServer), appiumOptions);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
           
            this.appiumOptions2 = new AppiumOptions();
            appiumOptions2.AddAdditionalCapability("app", appLocation);
            appiumOptions2.AddAdditionalCapability("platformName", "Windows");
            this.driver2 = new WindowsDriver<WindowsElement>(new Uri(appiumServer), appiumOptions2);

            driver2 = new WindowsDriver<WindowsElement>(new Uri(appiumServer), appiumOptions2);

            this.appiumOptions3 = new AppiumOptions();
            appiumOptions3.AddAdditionalCapability("app", appLocation);
            appiumOptions3.AddAdditionalCapability("platformName", "Windows");
            this.driver3 = new WindowsDriver<WindowsElement>(new Uri(appiumServer), appiumOptions3);

            driver3 = new WindowsDriver<WindowsElement>(new Uri(appiumServer), appiumOptions3);


        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver2.Quit();
        }
        [Test]
        public void CheckLogin()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver2.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            var signInBtn = driver2.FindElementByName("SIGN IN OR CREATE AN ACCOUNT");
            signInBtn.Click();

            var emailField = driver3.FindElementByAccessibilityId("email");
            emailField.SendKeys("desi.radkova.97@gmail.com");
            var nextBtn = driver3.FindElementByClassName("btn btn-accent u-w100 loader-button");
            nextBtn.Click();
            var passField = driver3.FindElementByAccessibilityId("password");
            passField.SendKeys("write here your password");
            var loginBtn = driver3.FindElementByLinkText("Log in Now");
            loginBtn.Click();
            var successText = driver3.FindElement(By.TagName("h2")).Text;


            Assert.That(successText, Is.EqualTo("You have successfully signed in!"));
        }
        [Test]
        public void CheckFiltersFunctionality()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver2.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);


            var filterBtn = driver2.FindElementByName("Filters");
            filterBtn.Click();
            var comboBox = driver2.FindElementByName("http://www.example.com/");
            comboBox.SendKeys(Keys.Control + "a");
            comboBox.Clear();
            comboBox.SendKeys("Facebook.com");
            var applyBtn = driver2.FindElementByName("APPLY");
            applyBtn.Click();

            var listOfItems = driver2.FindElementByName("http://www.facebook.com:443");
            Boolean actualResult = true;
            if (listOfItems.ToString() == null)
            {
                actualResult = false;
            }

            Assert.That(actualResult, Is.True);
        }
        [Test]
        public void CheckRuleFunctionality()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver2.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            var filterBtn = driver2.FindElementByName("Filters");
            filterBtn.Click();
            var comboBox = driver2.FindElementByName("http://www.example.com/");
            comboBox.SendKeys(Keys.Control + "a");
            comboBox.Clear();
            var applyBtn = driver2.FindElementByName("APPLY");
            applyBtn.Click();

            var addRule = driver2.FindElementByName("Add Rule");
            addRule.Click();
            var ruleNameField = driver2.FindElementByName("ruleNameInput");
            ruleNameField.SendKeys(Keys.Control + "a");
            ruleNameField.Clear();
            ruleNameField.SendKeys("Color Pink Facebook");
            var ruleAddress = driver2.FindElementByName("http://www.example.com/");
            ruleAddress.SendKeys(Keys.Control + "a");
            ruleAddress.Clear();
            ruleAddress.SendKeys("http://www.facebook.com:443");
            var colorPick = driver2.FindElementByName("Background -");
            colorPick.Click();
            var selectColor = driver2.FindElementByName("Fuchsia");
            selectColor.Click();
            var saveBtn = driver2.FindElementByName("SAVE");
            saveBtn.Click();

            var listOfItems = driver2.FindElementByName("http://www.facebook.com:443");
            string cssProperty = listOfItems.GetCssValue("color");
            string expectedColor = "Fuchsia";

            Assert.That(cssProperty, Is.EqualTo(expectedColor));


        }

        [Test]
        public void CheckGetRequests()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver2.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            var newRequest = driver2.FindElementByName("New Request");
            newRequest.Click();

            var urlEdit = driver2.FindElementByAccessibilityId("url");
            urlEdit.SendKeys("https://www.facebook.com");
            var executeBtn = driver2.FindElementByName("EXECUTE");
            executeBtn.Click();

            //var findField = driver2.FindElementByAccessibilityId("k-tabstrip-tabpanel-");
            //findField = (WindowsElement)findField.FindElementByName("");
            //findField.SendKeys("id=\"facebook\"");
            //findField.SendKeys(Keys.Enter);

            Boolean responseCode = false;

            try
            {
                driver2.FindElementByName("200");
                responseCode = true;
            }
            catch (NoSuchElementException e)
            {
                responseCode = false;
            }

            Assert.That(responseCode, Is.True);


        } 
    [Test]
    public void CheckSaveRequest()
    {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver2.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            var newRequest = driver2.FindElementByName("New Request");
            newRequest.Click();

            var urlEdit = driver2.FindElementByAccessibilityId("url");
            urlEdit.SendKeys("https://www.facebook.com");
            var executeBtn = driver2.FindElementByName("EXECUTE");
            executeBtn.Click();

            //var findField = driver2.FindElementByAccessibilityId("k-tabstrip-tabpanel-");
            //findField = (WindowsElement)findField.FindElementByName("");
            //findField.SendKeys("id=\"facebook\"");
            //findField.SendKeys(Keys.Enter);

            var saveBtn = driver2.FindElementByName("SAVE");
            saveBtn.Click();
            var nameField = driver2.FindElementByAccessibilityId("aazwqzlsa");
            nameField.SendKeys("Facebook Get Request");
            var createFolder = driver2.FindElementByName("Create New Folder");
            createFolder.Click();
            var nameFolder = driver2.FindElementByAccessibilityId("autdzsm7ics");
            nameFolder.SendKeys(Keys.Control + "a");
            nameFolder.SendKeys("Facebook Requests");
            nameFolder.SendKeys(Keys.Enter);
            var saveBtn2 = driver2.FindElementByName("SAVE");
            saveBtn2.Click();

            Boolean requestSaved = false;

            try
            {
                driver2.FindElementByName("Facebook Get Request");
                requestSaved = true;
            }
            catch (NoSuchElementException e)
            {
                requestSaved = false;
            }

            Assert.That(requestSaved, Is.True);
        }
    }
}