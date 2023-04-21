using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumWebDriverTests
{
    public class SeleniumWebDriverTests
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

            //Open Wikipedia
            driver.Url = "https://wikipedia.org";
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            //Close Browser
            this.driver.Quit();

        }

        [Test]
        public void WikipediaTitleTest()
        {
            
            var siteName = driver.Title;

            Assert.That(siteName, Is.EqualTo("Wikipedia"));
        }
        [Test]
        public void SearchFunctionalityTest()
        {
           //Get element by Id
            var searchBar = driver.FindElement(By.Id("searchInput"));
            searchBar.SendKeys("QA" + Keys.Enter);
            var pageTitle = driver.Title;
            Assert.That(pageTitle, Is.EqualTo("QA - Wikipedia"));

        }
        [Test]
        public void SearchFunctionalityByNameTest()
        {
            //Get element by Name
            var searchBar = driver.FindElement(By.Name("search"));
            searchBar.SendKeys("QA" + Keys.Enter);
            var pageTitle = driver.Title;
            Assert.That(pageTitle, Is.EqualTo("QA - Wikipedia"));

        }
        [Test]
        public void DeutschFindTest()
        {
           //Get element by TagName
            var strongElemetsList = driver.FindElements(By.TagName("strong"));
            var deutschLink = strongElemetsList[5].Text;
            Assert.That(deutschLink, Is.EqualTo("Deutsch"));
        }
        [Test]
        public void DeutschTitleTest()
        {
            //Get element by TagName
            var strongElementsList = driver.FindElements(By.TagName("strong"));
            var deutschLink = strongElementsList[5];
            deutschLink.Click();
            var pageName = driver.Title;
            Assert.That(pageName, Is.EqualTo("Wikipedia – Die freie Enzyklopädie"));
        }
        [Test]
        public void DeutschFindLinkTest()
        {
            //Get element by PartialLinkText
            var findElement = driver.FindElement(By.PartialLinkText("Deutsch"));
            findElement.Click();
            var deutschLink = driver.Title;
            Assert.That(deutschLink, Is.EqualTo("Wikipedia – Die freie Enzyklopädie"));
        }
        //Maria von Ungarn
        [Test]
        public void FindByLinkTextTest()
        {
            //Get element by LinkText
            var findElement = driver.FindElement(By.PartialLinkText("Deutsch"));
            findElement.Click();
            findElement = driver.FindElement(By.LinkText("Maria von Ungarn"));
            findElement.Click();
            var pageName = driver.Title;
            Assert.That(pageName, Is.EqualTo("Maria von Ungarn (1257–1323) – Wikipedia"));
        }
    }
}