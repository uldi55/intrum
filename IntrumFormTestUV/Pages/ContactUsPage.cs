using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using IntrumFormTestUV.Helpers;
using SeleniumExtras.WaitHelpers;

namespace IntrumFormTestUV.Pages
{
    public class ContactUsPage: PageBase
    {
        public static void ClickOnFormButton(IWebDriver driver)
        {
            Retry.Do(() => FindElementByXpath(driver, "//a[@href='/saistibu-parvaldisana/ja-esat-sanemis-vestuli/iebildumu-un-komentaru-forma/']").Click(), TimeSpan.FromSeconds(1));
        }

        public static void AcceptCookies(IWebDriver driver)
        {
            Retry.Do(() => FindElementById(driver, "onetrust-accept-btn-handler").Click(), TimeSpan.FromSeconds(1));
        }

        public static IWebElement CookiesPopup(IWebDriver driver)
        {
            return FindElementById(driver, "onetrust-group-container");
        }
        
        public static IWebElement SlideWrapper(IWebDriver driver)
        {
            return FindElementById(driver, "slide_wrapper");
        }

        public static IWebElement SlideOutForm(IWebDriver driver)
        {
            return FindElementById(driver, "slide");
        }
        public static void WaitForFormToOpen(IWebDriver driver)
        {
            ClickOnFormButton(driver);
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            w.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#slide > button")));
        }
    }
}
