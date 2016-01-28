using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

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
    }
}
