using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Module6.Helpers
{
    public class WaitHelper : BasePage
    {
        public WaitHelper(IWebDriver driver)
            : base(driver)
        {
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
