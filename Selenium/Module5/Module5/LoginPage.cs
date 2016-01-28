using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Module5
{
    class LoginPage : BasePage
    {
        public static string MailRuUrl = "http://mail.ru";
        
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

        public LoginPage SetUserNamePassword(string username, string password)
        {
            Console.WriteLine("Enter username and password...");
            usernameId.SendKeys(username);
            passwordId.SendKeys(password);
            return this;
        }

        public MainPage ClickLoginButton()
        {
            Console.WriteLine("Click on Login button...");
            loginButton.Click();
            WaitUntilAvailable(d => d.FindElement(By.Id("b-nav_folders")));
            return new MainPage(Driver);
        }
    }
}
