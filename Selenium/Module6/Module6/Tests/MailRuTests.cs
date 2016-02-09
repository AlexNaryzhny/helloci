using System;
using System.Security.Policy;
using Module6.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Module6.Tests
{
    internal class MailRuTests
    {
        IWebDriver _driver;

        [SetUp]
        public void Init()
        {
            _driver = BasePage.InitDriver(_driver);
        }

        [Test]
        [Description("Test Login to Mailbox")]
        public void Test1_LogInToMailbox()
        {
            LoginPage lp = new LoginPage(_driver);
            lp.SetUserNamePassword();
            MainPage mp = lp.ClickLoginButton();
            Assert.IsTrue(mp.loginEmail.Text.ToLower().Equals(lp.Email));
            mp.LogOut();
        }

        [Test]
        [Description("Test Save message as Draft")]
        public void Test2_CreateNewMessageAndSave()
        {
            LoginPage lp = new LoginPage(_driver);
            lp.SetUserNamePassword();
            MainPage mp = lp.ClickLoginButton();
            NewMessagePage nmp = mp.CreateNewMessage();
            nmp.FillTextFields();
            nmp.SaveAsDraft();
            nmp.NavigateToDraft();
            Assert.IsTrue(_driver.FindElement(By.XPath(mp.messageXpath)).Displayed);
            mp.LogOut();
        }

        [Test]
        [Description("Test Send message")]
        public void Test3_SendMessage()
        {
            LoginPage lp = new LoginPage(_driver);
            lp.SetUserNamePassword();
            MainPage mp = lp.ClickLoginButton();
            mp.NavigateToDraft();
            NewMessagePage nmp = mp.SelectMessageFromDraft();
            nmp.SendMessage();
            nmp.NavigateToDraft();
            Assert.IsFalse(Verifier.VerifyMessageExistInFolder(By.XPath(mp.messageXpath), "Message not exist in Draft folder"));
            mp.NavigateToSent();
            Assert.IsTrue(Verifier.VerifyMessageExistInFolder(By.XPath(mp.messageXpath), "Message not exist in Sent folder"));
            mp.LogOut();
        }

        [TearDown]
        public void Clean()
        {
            _driver.Quit();
        }
    }
}
