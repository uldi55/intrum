using NLog;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace IntrumFormTestUV.Pages
{
    public class PageBase
    {
        //a base for web-elements with logging. Also somewhat shorter and easier to understand sytnax
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public static IWebElement FindElementByXpath(IWebDriver driver, string path)
        {
            try {IWebElement el =driver.FindElement(By.XPath(path));
                return el;
            }
            catch(Exception ex) {
                Logger.Error(ex.Message, $"Can't find element by xpath {path}");
                return null;
                throw ex;
            }
        }

        public static IWebElement FindElementById(IWebDriver driver, string id)
        {
            try
            {
                IWebElement el = driver.FindElement(By.Id(id));
                return el;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, $"Can't find element by id {id}");
                return null;
                throw ex;
            }
        }

        public static IWebElement FindElementByCss(IWebDriver driver, string css)
        {
            try
            {
                IWebElement el = driver.FindElement(By.CssSelector(css));
                return el;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, $"Can't find element by css {css}");
                return null;
                throw ex;
            }
        }

        public static IList<IWebElement> FindElementsByXpath(IWebDriver driver, string path)
        {
            try
            {
                IList<IWebElement> el = driver.FindElements(By.XPath(path));
                return el;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, $"Can't find elements by xpath {path}");
                return null;
                throw ex;
            }
        }

        public static IList<IWebElement> FindElementsById(IWebDriver driver, string id)
        {
            try
            {
                IList<IWebElement> el = driver.FindElements(By.Id(id));
                return el;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, $"Can't find elements by id {id}");
                return null;
                throw ex;
            }
        }

        public static IList<IWebElement> FindElementsByCss(IWebDriver driver, string css)
        {
            try
            {
                IList<IWebElement> el = driver.FindElements(By.CssSelector(css));
                return el;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message, $"Can not find elements by css {css}");
                return null;
                throw ex;
            }
        }
    }
}
