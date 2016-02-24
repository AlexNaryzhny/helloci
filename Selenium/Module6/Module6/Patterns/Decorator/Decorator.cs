using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace Module6.driver.Decorator
{
    public class Decorator : IWebDriver
    {
        protected IWebDriver driver;

        public Decorator(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement FindElement(By @by)
        {
            Console.WriteLine("Find element:{0}",by);
            return driver.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
            return driver.FindElements(by);
        }

        public void Dispose()
        {
            driver.Dispose();
        }

        public void Close()
        {
            driver.Close();
        }

        public void Quit()
        {
            driver.Quit();
        }

        public IOptions Manage()
        {
            return driver.Manage();
        }

        public INavigation Navigate()
        {
            Console.WriteLine("Navigating...");
            return driver.Navigate();
        }

        public ITargetLocator SwitchTo()
        {
            return driver.SwitchTo();
        }

        public string Url { get; set; }
        public string Title { get; private set; }
        public string PageSource { get; private set; }
        public string CurrentWindowHandle { get; private set; }
        public ReadOnlyCollection<string> WindowHandles { get; private set; }
    }
}
