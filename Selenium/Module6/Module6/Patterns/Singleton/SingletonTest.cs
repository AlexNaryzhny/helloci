using NUnit.Framework;
using OpenQA.Selenium;

namespace Module6.driver.Singleton
{
    class SingletonTest
    {
        [Test]
        [Description("Test Singleton")]
        public void LogInToMailboxUsingSingleton()
        {

            IWebDriver driver = WebDriverSingleton.GetInstance();
            driver.Navigate().GoToUrl("https://mail.ru/");
            LoginPage lp = new LoginPage(driver);
            lp.SetUserNamePassword();
            MainPage mp = lp.ClickLoginButton();
            Assert.IsTrue(mp.loginEmail.Text.ToLower().Equals(lp.Email));
            mp.LogOut();
            WebDriverSingleton.CloseDriver();
        }
    }
}
