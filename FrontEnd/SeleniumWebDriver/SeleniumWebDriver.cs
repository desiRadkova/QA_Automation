using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SeleniumWebDriver
{
    public class SeleniumWebDriver
    {
        static void Main()
        {
            //Workaround for ChromeDriver Vesrion
            //===============================================================================
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--start-maximized");
            chromeOptions.AddArguments("--remote-allow-origins=*"); //<-this is the fix
                                                                    // Configuration.browserCapabilities = chromeOptions; //(for Selenide, for example)
            var driver = new ChromeDriver(chromeOptions);
            //===============================================================================

            //Open Wikipedia
            driver.Url = "https://wikipedia.org";
            Console.WriteLine("Browser has been opened successfully!");

            var pageName = driver.Title;
            Console.WriteLine("The Page Title is: " + $"{pageName}");

            if (pageName == "Wikipedia")
            {
                Console.WriteLine("Test for title PASS");
            }
            else
            {
                Console.WriteLine("Test for title FAIL");

            }

            //Close Browser
            driver.Quit();
            Console.WriteLine("Browser has been closed successfully!");




            //var driverFirefox = new FirefoxDriver();

            ////Open Wikipedia
            //driverFirefox.Url = "https://wikipedia.org";
            //Console.WriteLine("Browser has been opened successfully!");

            //var pageNameFireFox = driverFirefox.Title;
            //Console.WriteLine("The Page Title is: " + $"{pageNameFireFox}");

            //if (pageNameFireFox == "Wikipedia")
            //{
            //    Console.WriteLine("Test for title PASS");
            //}
            //else
            //{
            //    Console.WriteLine("Test for title FAIL");

            //}

            ////Close Browser
            //driverFirefox.Quit();
            //Console.WriteLine("Browser has been closed successfully!");

            //System.Environment.SetEnvironmentVariable("webdriver.opera.driver", "D:\\QA_Automation\\QA_Automation\\FrontEnd\\SeleniumWebDriver\\bin\\Debug\\net6.0operadriver.exe");
            //WebDriver driverOpera = new OperaDriver();



        }
    }
}