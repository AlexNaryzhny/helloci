using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Module6.driver.Factory
{
    public class ChromeDriverCreator : WebDriverCreator
    {
        private readonly string driverPath = ConfigurationSettings.AppSettings["driverPath"];

        public override IWebDriver FactoryMethod()
        {
            ChromeDriver driver = new ChromeDriver(driverPath);
            return driver;
        }
    }
}
