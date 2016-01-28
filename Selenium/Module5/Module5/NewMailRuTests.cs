using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Module5
{
    class NewMailRuTests
    {
        IWebDriver _driver;

        [SetUp]
        public void Init()
        {
            const string driverPath = "@//..//..//..//driver";
            _driver = new ChromeDriver(driverPath);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(LoginPage.MailRuUrl);
        }

        [Test]
        [Description("Test Login to Mailbox")]
        public void Test1_LogInToMailbox()
        {
            LoginPage lp = new LoginPage(_driver);
            lp.SetUserNamePassword("Lexx20", "astalavista");
            MainPage mp = lp.ClickLoginButton();
            Assert.IsTrue(mp.loginEmail.Text.ToLower().Equals("lexx20@mail.ru"));
            mp.LogOut();
        }

        [Test]
        [Description("Test Login to Mailbox")]
        public void Test2_CreateNewMessageAndSave()
        {
            LoginPage lp = new LoginPage(_driver);
            lp.SetUserNamePassword("Lexx20", "astalavista");
            MainPage mp = lp.ClickLoginButton();
            NewMessagePage nmp = mp.CreateNewMessage();
            nmp.FillTextFields("subject", "body");
            nmp.SaveAsDraft();
            nmp.NavigateToDraft();
            Assert.IsTrue(mp.draftMessages.Displayed);
            mp.LogOut();
        }

        [Test]
        [Description("Test Login to Mailbox")]
        public void Test3_SendMessage()
        {
            LoginPage lp = new LoginPage(_driver);
            lp.SetUserNamePassword("Lexx20", "astalavista");
            MainPage mp = lp.ClickLoginButton();
            mp.NavigateToDraft();
            NewMessagePage nmp = mp.SelectMessageFromDraft();
            nmp.SendMessage();
            nmp.NavigateToDraft();
            Assert.IsFalse(mp.draftMessages.Displayed);
            mp.NavigateToSent();
            Assert.IsTrue(mp.sentMessages.Displayed);
            mp.LogOut();
        }

        [TearDown]
        public void Clean()
        {
            _driver.Quit();
        }
    }
}
