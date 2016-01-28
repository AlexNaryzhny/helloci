using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace Module5
{
    class NewMailRuTests
    {
        IWebDriver _driver;

        [SetUp]
        public void Init()
        {
            bool isRemote = true;
            const string driverPath = "@//..//..//..//driver";
            switch (isRemote)
            {
                case false:
                    _driver = new ChromeDriver(driverPath);
                    _driver.Manage().Window.Maximize();
                    _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(100));
                    _driver.Navigate().GoToUrl(LoginPage.MailRuUrl);
                    break;
                case true:
                    DesiredCapabilities capability = DesiredCapabilities.Chrome();
                    //capability.SetCapability("maxInstances", 3);
                    _driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capability);
                    _driver.Manage().Window.Maximize();
                    _driver.Navigate().GoToUrl(LoginPage.MailRuUrl);
                    break;
            }

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
        [Description("Test Save message as Draft")]
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
        [Description("Test Send message")]
        public void Test3_SendMessage()
        {
            LoginPage lp = new LoginPage(_driver);
            lp.SetUserNamePassword("Lexx20", "astalavista");
            MainPage mp = lp.ClickLoginButton();
            mp.NavigateToDraft();
            NewMessagePage nmp = mp.SelectMessageFromDraft();
            nmp.SendMessage();
            nmp.NavigateToDraft();
            BasePage.VerifyMessageExistInFolder(By.XPath(mp.messageXpath), "Draft");
            //Assert.IsFalse(mp.message.Displayed);
            mp.NavigateToSent();
            BasePage.VerifyMessageExistInFolder(By.XPath(mp.messageXpath), "Send");
            //Assert.IsTrue(mp.message.Displayed);
            mp.LogOut();
        }

        [TearDown]
        public void Clean()
        {
            _driver.Quit();
        }
    }
}
