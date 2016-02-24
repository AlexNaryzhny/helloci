using OpenQA.Selenium;

namespace Module6.driver.Factory
{
    public abstract class WebDriverCreator
    {
        protected IWebDriver Driver;
        public abstract IWebDriver FactoryMethod();
    }
}
