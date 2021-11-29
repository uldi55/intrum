using OpenQA.Selenium;

namespace IntrumFormTestUV.Base
{
    public class DriverContext
    {
        //needed to pass the driver around
        public IWebDriver WebDriver { get; set; } 
    }
}
