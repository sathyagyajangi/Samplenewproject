using System;
using System.Threading;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace sampleproject
{
    [TestClass]
    public class UnitTest1
    {

        IWebDriver driver;

        [TestMethod]

        public void Beta()
        {
            string imgName = DateTime.Now.ToString("dd/MM/yyyy-HH-mm-ss");

            ExtentHtmlReporter reporter = new ExtentHtmlReporter("C:\\Users\\Satyanarayan\\source\\git\\Samplenewproject\\sampleproject\\Reports\\Beta\\yahoo.html");
            ExtentReports extent = new ExtentReports();
            extent.AttachReporter(reporter);

            var test = extent.CreateTest("yahooBeta");

            try

            {
                IWebDriver driver = new ChromeDriver();

                driver.Url = "https://beta-cricket-yahoo.sportz.io/";

                driver.Manage().Window.Maximize();




                for (int i = 2; i <= 11; i++)
                {

                    string title = driver.FindElement(By.XPath("/html/body/div[1]/header/div/section/div/div[3]/div/nav/ul/li[" + i + "]/a")).GetAttribute("title");

                    FunctionLibrary.waitForElement(driver, "/html/body/div[1]/header/div/section/div/div[3]/div/nav/ul/li[" + i + "]/a");


                    FunctionLibrary.clickAction(driver, "/html/body/div[1]/header/div/section/div/div[3]/div/nav/ul/li[" + i + "]/a", "xpath");

                    test.Log(Status.Pass, driver.Title + "Test case Passsed");

                    Console.WriteLine(title);





                    if (title.Contains("Series"))
                    {


                        driver.Navigate().GoToUrl("https://beta-cricket-yahoo.sportz.io/series/sri-lanka-tour-of-australia-2019-1111");

                        Thread.Sleep(2000);

                        for (int j = 2; j <= 10; j++)
                        {

                            FunctionLibrary.waitForElement(driver, "/html/body/div[1]/div/myapp/section[1]/div/div/div/div/section/div/div/div[2]/div/a[" + j + "]");

                            FunctionLibrary.clickAction(driver, "/html/body/div[1]/div/myapp/section[1]/div/div/div/div/section/div/div/div[2]/div/a[" + j + "]", "xpath");

                            test.Log(Status.Pass, driver.Title + "Test case Passsed");
                            Console.WriteLine(driver.Title);

                        }


                    }




                }





                driver.Close();

            }

            catch (Exception)
            {

                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

                ss.SaveAsFile("C:\\Users\\Satyanarayan\\source\\repos\\YahooSmokeTest\\YahooSmokeTest\\Screenshot\\image.png");


                test.Log(Status.Fail, "Test case failed");
            }

            extent.Flush();

        }
    }
}
