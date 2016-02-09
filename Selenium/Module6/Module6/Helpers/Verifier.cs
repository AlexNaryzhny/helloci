using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Module6.Helpers
{
    public class Verifier :BasePage
    {
        public Verifier(IWebDriver driver) : base(driver)
        {
        }

        public static bool VerifyMessageExistInFolder(By locator, string folder)
        {
            Console.WriteLine("Verify existing message in folder...");
            try
            {
                Driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
