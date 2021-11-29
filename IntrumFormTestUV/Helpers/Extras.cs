using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace IntrumFormTestUV.Helpers
{
    public class Extras
    {
        public static void TryAndCatch(IWebDriver driver, string name, Action action) //used for catching exception in the action performed
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                SaveScreenshot(PrepareDirectory("Screenshots"), TakeScreenshot(driver), name);
                throw ex;
            }
        }

        public static string PrepareDirectory(string foldername) //prepares directory for screenshot
        {
            var folderPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\" + foldername; 
            //var folderPath = Environment.CurrentDirectory + @"\" + foldername;
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            return folderPath + @"\";
        }

        public static void SwitchTab(IWebDriver driver, int tab) //switches to another tab
        {
            driver.SwitchTo().Window(driver.WindowHandles[tab]);
        }

        public static void CloseTab(IWebDriver driver) //closing new tab, returning to previous
        {
            driver.ExecuteJavaScript("window.close();");

            SwitchTab(driver, 0);
        }

        public static void SaveScreenshot(string dir, Screenshot screenshot, string testname) //saves screenshot with some usable data
        {
            screenshot.SaveAsFile(dir + testname + DateTime.Now.ToString("HH_mm_ss") + ".png",
                ScreenshotImageFormat.Png);
        }

        public static Screenshot TakeScreenshot(IWebDriver driver) //takes screenshot
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            return screenshot;
        }
        public static void MaximizeWindow(IWebDriver driver) //maximizes window
        {
            driver.Manage().Window.Maximize();
        }

        public static string RandomString(int length) //random string - useful in testing
        {
            Random random = new Random();
            const string chars = "abcdefghijklmnoprstuwxyz";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
