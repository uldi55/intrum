using System;
using IntrumFormTestUV.Configurations;
using NLog;
using OpenQA.Selenium.Chrome;

namespace IntrumFormTestUV.Base
{
    public class Base:DriverContext
    {
        public static ITestConfiguration TestConfiguration { get; private set; }
        public static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public void Setup()//base setup of webdriver and config
        {
            WebDriver = new ChromeDriver(Environment.CurrentDirectory); //sets driver in current directory
            var result = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "";
            result = "test"; //used in case environment variable is not specified to set config.
            TestConfiguration = GetConfig(result); //gets config for specified environmment
        }

        private static ITestConfiguration GetConfig(string environment)  //gets config for specified environmment
        {
            switch (environment.ToLower())
            {
                case "development":
                    return new DevEnvConfiguration();
                case "test":
                    return new TestEnvConfiguration();
                case "preprod":
                    return new PreProdEnvConfiguration();
                default:
                    return new LocalEnvConfiguration();
            }
        }
    }
}
