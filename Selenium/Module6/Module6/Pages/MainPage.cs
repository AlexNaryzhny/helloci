using System;
using System.Threading;
using Module6.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Module6
{
    public class MainPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//*[@class='b-toolbar__btn js-shortcut']/span")]
        private IWebElement newMessageButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='PH_user-email']")]
        public IWebElement loginEmail;

        [FindsBy(How = How.Id, Using = "PH_logoutLink")]
        public IWebElement logoutLink;

        [FindsBy(How = How.XPath, Using = "//*[@id='b-nav_folders']/div/div[3]/a/span")]
        private IWebElement DraftFolder;

        [FindsBy(How = How.XPath, Using = "//span[text() = 'Отправленные']")]
        private IWebElement SentFolder;

        [FindsBy(How = How.Id, Using = "b-letters")]
        public IWebElement draftMessages;
        
        [FindsBy(How = How.XPath, Using = "//div[text()='aliaksandr_naryzhny']")]
        public IWebElement message;

        public string messageXpath = "//div[text()='aliaksandr_naryzhny']";

        public MainPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public NewMessagePage CreateNewMessage()
        {
            Console.WriteLine("Click on New Message button...");
            newMessageButton.Click();
            WaitHelper.WaitUntilAvailable(d => d.FindElement(By.XPath("//label[text() = 'Кому']")));
            Thread.Sleep(600);
            return new NewMessagePage(Driver);
        }

        public NewMessagePage SelectMessageFromDraft()
        {
            Console.WriteLine("Select message...");
            message.Click();
            WaitHelper.WaitUntilAvailable(d => d.FindElement(By.XPath("//input[@name='Subject']")));
            Thread.Sleep(500);
            return new NewMessagePage(Driver);
        }

        public MainPage NavigateToSent()
        {
            Console.WriteLine("Navigate to Sent folder...");
            SentFolder.Click();
            WaitHelper.WaitUntilAvailable(d => d.FindElement(By.Id("b-letters")));
            return this;
        }

        public MainPage NavigateToDraft()
        {
            Console.WriteLine("Navigate to Draft folder...");
            DraftFolder.Click();
            WaitHelper.WaitUntilAvailable(d => d.FindElement(By.Id("b-letters")));
            Thread.Sleep(500);
            return this;
        }

        public void LogOut()
        {
            Console.WriteLine("Logout from mailbox...");
            //Utils.HighlightElement(loginEmail);
            logoutLink.Click();
        }
    }
}
