using System;
using OpenQA.Selenium;

namespace Module6.Helpers
{
    public class Actions : BasePage
    {
        public Actions(IWebDriver driver)
            : base(driver)
        {
        }

        public static void MouseClick(IWebElement element)
        {
            Console.WriteLine("Click the mouse on the element");
            var builder = new OpenQA.Selenium.Interactions.Actions(Driver);
            builder.Click(element).Perform();
        }

        public static void KeyboardSendKeys(string code)
        {
            Console.WriteLine("Send key '" + code + "' from keyboard");
            var builder = new OpenQA.Selenium.Interactions.Actions(Driver);
            builder.SendKeys(code).Perform();
        }
    }
}
