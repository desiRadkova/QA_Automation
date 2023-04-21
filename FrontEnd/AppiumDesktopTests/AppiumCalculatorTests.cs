using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace AppiumDesktopTests
{
    public class AppiumCalculatorTests
    {
        private const string appiumServer = "http://127.0.0.1:4723/wd/hub";
        private const string appLocation = @"D:\QA_Automation\QA_Automation\FrontEnd\AppiumDesktopTests\SummatorDesktopApp.exe";
        private WindowsDriver<WindowsElement> driver;
        private AppiumOptions appiumOptions;
        private WindowsElement firstNumberInput;
        private WindowsElement secondNumberInput;
        private WindowsElement calcResultBtn;
        private WindowsElement result;

        [SetUp]
        public void Setup()
        {
            this.appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("app", appLocation);
            appiumOptions.AddAdditionalCapability("platformName", "Windows");
            this.driver = new WindowsDriver<WindowsElement>(new Uri(appiumServer), appiumOptions);

            driver = new WindowsDriver<WindowsElement>(new Uri(appiumServer), appiumOptions);

            this.firstNumberInput = driver.FindElementByAccessibilityId("textBoxFirstNum");
            this.secondNumberInput = driver.FindElementByAccessibilityId("textBoxSecondNum");
            this.calcResultBtn = driver.FindElementByAccessibilityId("buttonCalc");
            this.result = driver.FindElementByAccessibilityId("textBoxSum");

        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void SumTwoNumbers_AppiumTest()
        {
            var firstNumberField = driver.FindElementByAccessibilityId("textBoxFirstNum");
            var secondNumberField = driver.FindElementByAccessibilityId("textBoxSecondNum");
            var resultField = driver.FindElementByAccessibilityId("textBoxSum");
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");

            firstNumberField.SendKeys("5");
            secondNumberField.SendKeys("5");
            calcButton.Click();
            var actual = resultField.Text;

            Assert.That(actual, Is.EqualTo("10"));

        }
        [Test]
        public void SumTwoNegativeNumbers_AppiumTest()
        {
            var firstNumberField = driver.FindElementByAccessibilityId("textBoxFirstNum");
            var secondNumberField = driver.FindElementByAccessibilityId("textBoxSecondNum");
            var resultField = driver.FindElementByAccessibilityId("textBoxSum");
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");

            firstNumberField.SendKeys("-5");
            secondNumberField.SendKeys("-5");
            calcButton.Click();
            var actual = resultField.Text;

            Assert.That(actual, Is.EqualTo("-10"));

        }
        [Test]
        public void SumIllegalNumbers_AppiumTest()
        {
            var firstNumberField = driver.FindElementByAccessibilityId("textBoxFirstNum");
            var secondNumberField = driver.FindElementByAccessibilityId("textBoxSecondNum");
            var resultField = driver.FindElementByAccessibilityId("textBoxSum");
            var calcButton = driver.FindElementByAccessibilityId("buttonCalc");

            firstNumberField.SendKeys("qwerty");
            secondNumberField.SendKeys("-5");
            calcButton.Click();
            var actual = resultField.Text;

            Assert.That(actual, Is.EqualTo("error"));

        }
        //Data Driven Tests
        [TestCase("5","4","9")]
        [TestCase("-5", "-4", "-9")]
        [TestCase("qwerty", "4", "error")]
        public void SumTwoNumbersAllCases_AppiumTest(string firstNum, string secondNum, string expectedResult)
        {
            firstNumberInput.SendKeys(firstNum);
            secondNumberInput.SendKeys(secondNum);
            calcResultBtn.Click();

            Assert.That(result.Text, Is.EqualTo(expectedResult));
        }
    }
}