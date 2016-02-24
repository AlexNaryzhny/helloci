using System;
using System.Configuration;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Module6.Helpers
{
    public class Utils : BasePage
    {
        public Utils(IWebDriver driver)
            : base(driver)
        {
        }
        private static readonly string filePath = ConfigurationSettings.AppSettings["filePath"];

        public static void HighlightElement(IWebElement element)
        {
            Console.WriteLine("Executes JavaScript Highlight");
            string bg = element.GetCssValue("backgroundColor");
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].style.backgroundColor = '" + "yellow" + "'", element);
            Snapshot();
            js.ExecuteScript("arguments[0].style.backgroundColor = '" + bg + "'", element);
        }

        public static void Snapshot()
        {
            Console.WriteLine("Create screenshot.");
            string path = CreateScreenshotFileName;
            Screenshot ss = ((ITakesScreenshot)Driver).GetScreenshot();
            ss.SaveAsFile(path, System.Drawing.Imaging.ImageFormat.Png);
        }

        public static string CreateScreenshotFileName
        {
            get
            {
                var timeStamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                var filename = TestContext.CurrentContext.Test.FullName;
                filename = filename + "-" + timeStamp;
                var fullname = filePath + filename + ".png";
                Console.WriteLine("Screenshot saved: screen/{0}", filename);
                return fullname;
            }
        }

        public static string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }
    }
}
