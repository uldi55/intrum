using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;

namespace IntrumFormTestUV.Base
{
    public class TestBase : Base //base for all tests, using one time setup and teardown as tests will run one after another
    {
        [OneTimeSetUp]
        public void Startup()
        {
            Setup();
            ChromeOptions chromeOptions = new ChromeOptions();//webdriver setup, normal screen size and url from config
            chromeOptions.AddArgument("window-size=1920,1080");
            WebDriver.Navigate().GoToUrl(TestConfiguration.testUrl);
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [OneTimeTearDown]
        public virtual void Dispose() //teardown, after tests - quits and kills the driver
        {
            WebDriver.Quit();
            WebDriver.Dispose();
            Logger.Info("Chromedriver disposed");
        }
    } 
}