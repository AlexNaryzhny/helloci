using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Module6.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace Module6
{
    public class BasePage
    {
        protected static IWebDriver Driver;
        public static string Url = ConfigurationSettings.AppSettings["url"];
        private static readonly string driverPath = ConfigurationSettings.AppSettings["driverPath"];
        
        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }

        public static IWebDriver InitDriver(IWebDriver driver)
        {
            driver = new ChromeDriver(driverPath);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(100));
            driver.Navigate().GoToUrl(Url);
            return driver;
        }
    }
}
