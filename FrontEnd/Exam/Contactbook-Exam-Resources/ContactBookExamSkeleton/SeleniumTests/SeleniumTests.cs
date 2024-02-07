

using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SeleniumTests
{
    public class SeleniumTests
    {

        private WebDriver driver;


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

            driver.Url = "https://contactbook-1.desirad.repl.co";

        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            //Close Browser
            this.driver.Quit();

        }
        [Test]
        public void ContactPage()
        {
            var contactButton = driver.FindElement(By.PartialLinkText("Contacts"));
            contactButton.Click();
            var fnameElemetsList = driver.FindElements(By.ClassName("fname"));
            var firstContact = fnameElemetsList[0].Text;
            var lnameElemetsList = driver.FindElements(By.ClassName("lname"));
            var firstContactLastName = lnameElemetsList[0].Text;
            Assert.That(firstContact, Is.EqualTo("First Name Steve"));
            Assert.That(firstContactLastName, Is.EqualTo("Last Name Jobs"));
        }
        [Test]
        public void SearchContact()
        {
            var searchButton = driver.FindElement(By.PartialLinkText("Search"));
            searchButton.Click();
            var inputField = driver.FindElement(By.Id("keyword"));
            inputField.SendKeys("albert");
            var findButton = driver.FindElement(By.Id("search"));
            findButton.Click();
            var fnameElemetsList = driver.FindElements(By.ClassName("fname"));
            var createdContact = fnameElemetsList[0].Text;
            var lnameElemetsList = driver.FindElements(By.ClassName("lname"));
            var createdContactLastName = lnameElemetsList[0].Text;

            Assert.That(createdContact, Is.EqualTo("First Name Albert"));
            Assert.That(createdContactLastName, Is.EqualTo("Last Name Einstein"));
        }
        [Test]
        public void SearchInvalidContact()
        {
            var searchButton = driver.FindElement(By.PartialLinkText("Search"));
            searchButton.Click();
            var inputField = driver.FindElement(By.Id("keyword"));
            inputField.SendKeys("missing{randnum}");
            var findButton = driver.FindElement(By.Id("search"));
            findButton.Click();
            var searchRes = driver.FindElement(By.Id("searchResult")).Text;
            Assert.That(searchRes, Is.EqualTo("No contacts found."));
        }
        [Test]
        public void CreateInvalidContact()
        {
            var createButton = driver.FindElement(By.PartialLinkText("Create"));
            createButton.Click();
            var createBtn = driver.FindElement(By.Id("create"));
            createBtn.Click();
            var errorText = driver.FindElement(By.ClassName("err")).Text;
            Assert.That(errorText, Is.EqualTo("Error: First name cannot be empty!"));
        }
        [Test]
        public void CreateValidContact()
        {
            var createButton = driver.FindElement(By.PartialLinkText("Create"));
            createButton.Click();
            var firstName = driver.FindElement(By.Id("firstName"));
            firstName.SendKeys("Svetlin");
            var lastName = driver.FindElement(By.Id("lastName"));
            lastName.SendKeys("Nakov");
            var email = driver.FindElement(By.Id("email"));
            email.SendKeys("svetlin.nakov@softuni.com");
            var phone = driver.FindElement(By.Id("phone"));
            phone.SendKeys("0886518173");
            var comments = driver.FindElement(By.Id("comments"));
            comments.SendKeys("The creator of SoftUni Academy.");
            var createBtn = driver.FindElement(By.Id("create"));
            createBtn.Click();
            var fnameElemetsList = driver.FindElements(By.ClassName("fname"));
            var createdContact = fnameElemetsList.Last().Text;
            var lnameElemetsList = driver.FindElements(By.ClassName("lname"));
            var createdContactLastName = lnameElemetsList.Last().Text;

            Assert.That(createdContact,Is.EqualTo("First Name Svetlin"));
            Assert.That(createdContactLastName, Is.EqualTo("Last Name Nakov"));
        }
    }
}