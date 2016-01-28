using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace Module5
{
    class BasePage
    {
        protected static IWebDriver Driver;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }

        public static void WaitUntilAvailable(Func<IWebDriver, object> condition)
        {
            IWait<IWebDriver> wait = new WebDriverWait(Driver,
                TimeSpan.FromSeconds(30));
            wait.Timeout = TimeSpan.FromSeconds(60);
            wait.PollingInterval = TimeSpan.FromSeconds(1);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Until(condition);
        }

        public static void VerifyMessageExistInFolder(By locator, string folder)
        {
            Console.WriteLine("Verify existing message in folder...");
            try
            {
                Driver.FindElement(locator);
                Console.WriteLine("Message exist in {0} folder", folder);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Message not exist in {0} folder", folder);
            }
        }

        public void MouseClick(IWebElement element)
        {
            Console.WriteLine("Click the mouse on the element");
            var builder = new Actions(Driver);
            builder.Click(element).Perform();
        }

        public void KeyboardSendKeys(string code)
        {
            Console.WriteLine("Send key '" + code + "' from keyboard");
            var builder = new Actions(Driver);
            builder.SendKeys(code).Perform();
        }

        public void HighlightElement(IWebElement element)
        {
            Console.WriteLine("Executes JavaScript Highlight");
            var js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", element, "color: yellow; border: 2px solid yellow;");
            Snap();
            js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", element, "");
            
        }

        public static void Snap()
        {
            Console.WriteLine("Create screenshot.");
            ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile(CreateScreenshotFileName, System.Drawing.Imaging.ImageFormat.Png);
        }

        public static string CreateScreenshotFileName
        {
            get
            {
                var timeStamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                var filename = TestContext.CurrentContext.Test.FullName;
                const string filePath = "@//..//..//..//screen/";
                filename = filename + "-" + timeStamp;
                var fullname = filePath + filename + ".png";
                Console.WriteLine("Screenshot saved: screen/{0}", filename);
                return fullname;
            }
        }
    }
}
