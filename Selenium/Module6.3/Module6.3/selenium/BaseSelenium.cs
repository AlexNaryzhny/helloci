using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Module6._3.selenium
{
    public class BaseSelenium
    {
        public static IWebDriver Driver;

        public static void Init()
        {
            string Url = ConfigurationSettings.AppSettings["url"];
            string defaultPage = ConfigurationSettings.AppSettings["path"];
            Driver = new ChromeDriver(defaultPage);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(Url);
        }

        public static void Close()
        {
            try
            {
                Driver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                Driver = null;
            }

        }
    }
}
