using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SeleniumWebDriverCalculatorTests
{
    public class SeleniumCalculatorTests
    {
        private WebDriver driver;
        private IWebElement firstNumberInput;
        private IWebElement operationInput;
        private IWebElement secondNumberInput;
        private IWebElement calcResultBtn;
        private IWebElement result;

        [OneTimeSetUp]
        public void OpenBrowser()
        {
            //Workaround for ChromeDriver Vesrion
            //===============================================================================
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--start-maximized"); //Maximize the window
            chromeOptions.AddArguments("--headless"); //Don't show the browser
            chromeOptions.AddArguments("--remote-allow-origins=*"); //<-this is the fix for different versions
            //===============================================================================
            this.driver = new ChromeDriver(chromeOptions);

            //Open Wikipedia
            driver.Url = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";
            this.firstNumberInput = driver.FindElement(By.Id("number1"));
            this.operationInput = driver.FindElement(By.Id("operation"));
            this.secondNumberInput = driver.FindElement(By.Id("number2"));
            this.calcResultBtn = driver.FindElement(By.Id("calcButton"));
            this.result = driver.FindElement(By.Id("result"));
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            //Close Browser
            this.driver.Quit();

        }
        [TestCase("1", "+", "2", "3")]
        [TestCase("-1", "+", "-2", "3")]
        [TestCase("-1", "*", "-2", "2")]
        [TestCase("1", "*", "2", "2")]
        [TestCase("-1", "-", "-2", "-1")]
        [TestCase("10", "-", "11", "-1")]
        [TestCase("2", "-", "1", "-1")]
        public void OperationsTests(string firstNum, string operation, string secondNum, string expectedResult)
        {
            firstNumberInput.SendKeys(firstNum);
            operationInput.SendKeys(operation);
            secondNumberInput.SendKeys(secondNum);
            calcResultBtn.Click();

            Assert.That(result.Text, Is.EqualTo("Result: " + expectedResult));
        }
        [Test]
        public void SumPositiveNumbers()
        {
            var firstNumber = driver.FindElement(By.Id("number1"));
            firstNumber.SendKeys("1");

            var operationSum = driver.FindElement(By.Id("operation"));
            operationSum.SendKeys("+");

            var secondNumber = driver.FindElement(By.Id("number2"));
            secondNumber.SendKeys("2");

            var resultButton = driver.FindElement(By.Id("calcButton"));
            resultButton.Click();

            var result = driver.FindElement(By.Id("result"));

            Assert.That(result.Text, Is.EqualTo("Result: 3"));
        }
        [Test]
        public void SumNegativeNumbers()
        {
            var firstNumber = driver.FindElement(By.Id("number1"));
            firstNumber.SendKeys("-1");

            var operationSum = driver.FindElement(By.Id("operation"));
            operationSum.SendKeys("+");

            var secondNumber = driver.FindElement(By.Id("number2"));
            secondNumber.SendKeys("-2");

            var resultButton = driver.FindElement(By.Id("calcButton"));
            resultButton.Click();

            var result = driver.FindElement(By.Id("result"));

            Assert.That(result.Text, Is.EqualTo("Result: -3"));
        }
        [Test]
        public void MultiplyPositiveNumbers()
        {
            var firstNumber = driver.FindElement(By.Id("number1"));
            firstNumber.SendKeys("1");

            var operationSum = driver.FindElement(By.Id("operation"));
            operationSum.SendKeys("*");

            var secondNumber = driver.FindElement(By.Id("number2"));
            secondNumber.SendKeys("2");

            var resultButton = driver.FindElement(By.Id("calcButton"));
            resultButton.Click();

            var result = driver.FindElement(By.Id("result"));

            Assert.That(result.Text, Is.EqualTo("Result: 2"));
        }
        [Test]
        public void MultiplyNegativeNumbers()
        {
            var firstNumber = driver.FindElement(By.Id("number1"));
            firstNumber.SendKeys("-1");

            var operationSum = driver.FindElement(By.Id("operation"));
            operationSum.SendKeys("*");

            var secondNumber = driver.FindElement(By.Id("number2"));
            secondNumber.SendKeys("-2");

            var resultButton = driver.FindElement(By.Id("calcButton"));
            resultButton.Click();

            var result = driver.FindElement(By.Id("result"));

            Assert.That(result.Text, Is.EqualTo("Result: 2"));
        }
        [Test]
        public void SubstractPositiveNumbers()
        {
            var firstNumber = driver.FindElement(By.Id("number1"));
            firstNumber.SendKeys("1");

            var operationSum = driver.FindElement(By.Id("operation"));
            operationSum.SendKeys("-");

            var secondNumber = driver.FindElement(By.Id("number2"));
            secondNumber.SendKeys("2");

            var resultButton = driver.FindElement(By.Id("calcButton"));
            resultButton.Click();

            var result = driver.FindElement(By.Id("result"));

            Assert.That(result.Text, Is.EqualTo("Result: -1"));
        }
        [Test]
        public void SubstractNegativeNumbers()
        {
            var firstNumber = driver.FindElement(By.Id("number1"));
            firstNumber.SendKeys("-1");

            var operationSum = driver.FindElement(By.Id("operation"));
            operationSum.SendKeys("-");

            var secondNumber = driver.FindElement(By.Id("number2"));
            secondNumber.SendKeys("-2");

            var resultButton = driver.FindElement(By.Id("calcButton"));
            resultButton.Click();

            var result = driver.FindElement(By.Id("result"));

            Assert.That(result.Text, Is.EqualTo("Result: 1"));
        }
    }
}