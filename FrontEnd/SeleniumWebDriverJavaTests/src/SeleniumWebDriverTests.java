import org.openqa.selenium.By;
import org.openqa.selenium.Keys;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.firefox.FirefoxDriver;
import org.openqa.selenium.support.ui.WebDriverWait;
import org.testng.Assert;
import org.testng.annotations.AfterSuite;
import org.testng.annotations.BeforeSuite;
import org.testng.annotations.Test;

import java.time.Duration;

public class SeleniumWebDriverTests {
    private static WebDriver driver;
    private WebDriverWait wait;


    @BeforeSuite (alwaysRun=true)

    public void openBrowser() throws Exception {

        driver = new FirefoxDriver();
        driver.get("https://www.fb.com");
        driver.manage().timeouts();
    }
   @AfterSuite
   public void closeBrowser(){
        driver.close();
   }

    @Test
    public void getTitle(){
        //driver = new FirefoxDriver();
        driver.manage().window().maximize();
        driver.get("https://www.google.com");
        var titleName = driver.getTitle();
        //driver.close();
        Assert.assertEquals(titleName,"Google");
    }
    @Test
    public void searchFunc(){
        //waiting test
        driver.manage().timeouts().implicitlyWait(Duration.ofSeconds(20));
        this.wait = new WebDriverWait(driver, Duration.ofSeconds(2));

        var acceptCoockies = driver.findElement(By.id("L2AGLb"));
        acceptCoockies.click();
        var searchField = driver.findElement(By.id("APjFqb"));
        searchField.sendKeys("tulip");
        searchField.sendKeys(Keys.ENTER);

        var searchResult = driver.findElement(By.tagName("h3"));
        var getText = searchResult.getAttribute("innerText");

        Assert.assertEquals(getText,"Tulip");
    }
    @Test
    public void testCalculator(){
        //waiting test
        driver.manage().timeouts().implicitlyWait(Duration.ofSeconds(20));
        this.wait = new WebDriverWait(driver, Duration.ofSeconds(2));

        driver.get("https://www.calculatorsoup.com/calculators/math/basic.php");
        var acceptCoockies = driver.findElement(By.className("fc-primary-button"));
        acceptCoockies.click();
        var inputData = driver.findElement(By.id("cs_display"));
        var firstNumber = driver.findElement(By.name("cs_two"));
        firstNumber.click();
        var operation = driver.findElement(By.name("cs_add"));
        operation.click();
        var secondNumber = driver.findElement(By.name("cs_two"));
        secondNumber.click();
        var equalSign = driver.findElement(By.name("cs_equal"));
        equalSign.click();

        var result = inputData.getAttribute("value");
        Assert.assertEquals(result,"4");
    }
    @Test
    public void testCalculatorMultiply(){
        //waiting test
        driver.manage().timeouts().implicitlyWait(Duration.ofSeconds(20));
        this.wait = new WebDriverWait(driver, Duration.ofSeconds(2));

        var inputData = driver.findElement(By.id("cs_display"));
        var firstNumber = driver.findElement(By.name("cs_two"));
        firstNumber.click();
        var operation = driver.findElement(By.name("cs_multiply"));
        operation.click();
        var secondNumber = driver.findElement(By.name("cs_two"));
        secondNumber.click();
        var equalSign = driver.findElement(By.name("cs_equal"));
        equalSign.click();

        var result = inputData.getAttribute("value");
        Assert.assertEquals(result,"4");
    }
    @Test
    public void testCalculatorDivide(){
        //waiting test
        driver.manage().timeouts().implicitlyWait(Duration.ofSeconds(20));
        this.wait = new WebDriverWait(driver, Duration.ofSeconds(2));

        var inputData = driver.findElement(By.id("cs_display"));
        var firstNumber = driver.findElement(By.name("cs_two"));
        firstNumber.click();
        var operation = driver.findElement(By.name("cs_divide"));
        operation.click();
        var secondNumber = driver.findElement(By.name("cs_two"));
        secondNumber.click();
        var equalSign = driver.findElement(By.name("cs_equal"));
        equalSign.click();

        var result = inputData.getAttribute("value");
        Assert.assertEquals(result,"1");
    }

}
