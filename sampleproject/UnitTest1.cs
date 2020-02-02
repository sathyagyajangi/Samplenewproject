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

            ExtentHtmlReporter reporter = new ExtentHtmlReporter("./Reports/yahoo.html");
            ExtentReports extent = new ExtentReports();
            extent.AttachReporter(reporter);

            var test = extent.CreateTest("yahooBeta");

            IWebDriver driver = new ChromeDriver();

            try

            {
               

                driver.Url = "https://google.co.in/";

                driver.Manage().Window.Maximize();

                test.Log(Status.Pass, "Test case passed");

                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

                ss.SaveAsFile("./Screenshots/Image.png");


            }

            catch (Exception)
            {

                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();

                ss.SaveAsFile("./Screenshots/Image.png");

                test.Log(Status.Fail, "Test case failed");
            }

            extent.Flush();

            driver.Close();
        }
       
    }
}
