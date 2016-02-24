using System;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Module6.driver.Singleton
{
    public class WebDriverSingleton
    {
        private static IWebDriver _driver;
        private static readonly string driverPath = ConfigurationSettings.AppSettings["driverPath"];
        
        private WebDriverSingleton()
        {
        }

        public static IWebDriver GetInstance()
        {
            if (null == _driver)
            {
                _driver = new ChromeDriver(driverPath);
                _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(300));
                
            }
            return _driver;
        }

        public static void CloseDriver()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
