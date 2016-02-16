using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Module6.driver.Factory;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Module6.driver.Decorator
{
    class DecoratorTest
    {
        IWebDriver driver;
        private readonly string driverPath = ConfigurationSettings.AppSettings["driverPath"];

        [Test]
        [Description("Test Decorator")]
        public void LogInToMailboxUsingFactory()
        {
            driver = new ChromeDriver(driverPath);
            driver.Manage().Window.Maximize();
            IWebDriver decorDriver = new Decorator(driver);
            decorDriver.Navigate().GoToUrl("https://mail.ru/");
            LoginPage lp = new LoginPage(decorDriver);
            lp.SetUserNamePassword();
            MainPage mp = lp.ClickLoginButton();
            Assert.IsTrue(mp.loginEmail.Text.ToLower().Equals(lp.Email));
            mp.LogOut();
            driver.Quit();
        }
    }
}
