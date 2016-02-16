using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Module6.driver.Singleton;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Module6.driver.Factory
{
    class FactoryTest
    {
        [Test]
        [Description("Test Factory")]
        public void LogInToMailboxUsingFactory()
        {
            WebDriverCreator creator = new ChromeDriverCreator();
            IWebDriver driver = creator.FactoryMethod();
            driver.Navigate().GoToUrl("https://mail.ru/");
            LoginPage lp = new LoginPage(driver);
            lp.SetUserNamePassword();
            MainPage mp = lp.ClickLoginButton();
            Assert.IsTrue(mp.loginEmail.Text.ToLower().Equals(lp.Email));
            mp.LogOut();
            driver.Quit();
        }
    }
}
