using System;
using System.Configuration;
using Module6.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Module6
{
    public class LoginPage : BasePage
    {
        IWebDriver driver;

        private readonly string Username = ConfigurationSettings.AppSettings["user"];
        private readonly string Password = ConfigurationSettings.AppSettings["pass"];
        public string Email = ConfigurationSettings.AppSettings["email"];
        
        [FindsBy(How = How.Id, Using = "mailbox__login")]
        private IWebElement usernameId;

        [FindsBy(How = How.Id, Using = "mailbox__password")]
        private IWebElement passwordId;

        [FindsBy(How = How.Id, Using = "mailbox__auth__button")]
        private IWebElement loginButton;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
        }

        public LoginPage SetUserNamePassword()
        {
            Console.WriteLine("Enter username and password...");
            usernameId.SendKeys(Username);
            passwordId.SendKeys(Password);
            return this;
        }

        public MainPage ClickLoginButton()
        {
            Console.WriteLine("Click on Login button...");
            loginButton.Click();
            WaitHelper.WaitUntilAvailable(d => d.FindElement(By.Id("b-nav_folders")));
            return new MainPage(Driver);
        }
    }
}
