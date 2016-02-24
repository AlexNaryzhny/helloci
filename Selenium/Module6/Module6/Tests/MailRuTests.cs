using log4net;
using log4net.Config;
using Module6.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;


namespace Module6.Tests
{
    internal class MailRuTests
    {
        IWebDriver _driver;
        private static readonly ILog Logger = LogManager.GetLogger(typeof(MailRuTests));

        [SetUp]
        public void Init()
        {
            _driver = BasePage.InitDriver(_driver);
        }

        [Test]
        [Description("Test Login to Mailbox")]
        public void Test1_LogInToMailbox()
        {
            XmlConfigurator.Configure();
            Logger.Debug("Started Test1");
            LoginPage lp = new LoginPage(_driver);
            Logger.Info("Open LoginPage");
            lp.SetUserNamePassword();
            Logger.Warn("Enetr username and password...");
            MainPage mp = lp.ClickLoginButton();
            Assert.IsTrue(mp.loginEmail.Text.ToLower().Equals(lp.Email));
            Logger.Error("Assert passed");
            Utils.HighlightElement(mp.loginEmail);
            mp.LogOut();
            Logger.Fatal("Test finished!");
        }

        [Test]
        [Description("Test Save message as Draft")]
        public void Test2_CreateNewMessageAndSave()
        {
            XmlConfigurator.Configure();
            Logger.Debug("Started Test2");
            LoginPage lp = new LoginPage(_driver);
            Logger.Info("Open LoginPage");
            lp.SetUserNamePassword();
            Logger.Warn("Enetr username and password...");
            MainPage mp = lp.ClickLoginButton();
            Logger.Info("Login to Mailbox");
            NewMessagePage nmp = mp.CreateNewMessage();
            Logger.Info("Create New Message");
            nmp.FillTextFields();
            Logger.Info("Fill the fields");
            nmp.SaveAsDraft();
            Logger.Info("Save as Draft");
            nmp.NavigateToDraft();
            Logger.Info("Check Draft folder");
            Assert.IsTrue(_driver.FindElement(By.XPath(mp.messageXpath)).Displayed);
            Logger.Error("Assert passed");
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
