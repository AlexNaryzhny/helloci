using System;
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

        public static void HighlightElement(IWebElement element)
        {
            Console.WriteLine("Executes JavaScript Highlight");
            var js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", element, "color: yellow; border: 2px solid yellow;");
            //Snapshot();
            js.ExecuteScript("arguments[0].setAttribute('style', arguments[1]);", element, "");

        }

        public static void Snapshot()
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
