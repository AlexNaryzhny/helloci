using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Module5
{
    class MainPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = "//*[@class='b-toolbar__btn js-shortcut']/span")]
        private IWebElement newMessageButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='PH_user-email']")]
        public IWebElement loginEmail;
        
        [FindsBy(How = How.XPath, Using = "//*[@id='b-nav_folders']/div/div[3]/a/span")]
        private IWebElement DraftFolder;

        [FindsBy(How = How.XPath, Using = "//span[text() = 'Отправленные']")]
        private IWebElement SentFolder;

        [FindsBy(How = How.XPath, Using = "//*[@class='b-datalist__item__panel']/div[3]/div[2]")]
        private IWebElement emailText;

        [FindsBy(How = How.XPath, Using = "//*[@class='b-datalist__item__panel']/div[3]/div[1]")]
        private IWebElement subjectText;

        [FindsBy(How = How.XPath, Using = "//*[@class='b-datalist__item__panel']/div[3]/div[1]/span")]
        private IWebElement bodyTxt;

        [FindsBy(How = How.XPath, Using = "//*[@class='b-datalist__item__panel']/div[3]/div[2]")]
        public IWebElement sentMessages;

        [FindsBy(How = How.Id, Using = "b-letters")]
        public IWebElement draftMessages;

        [FindsBy(How = How.Id, Using = "PH_logoutLink")]
        public IWebElement logoutLink;

        [FindsBy(How = How.XPath, Using = ".//div[@class='b-datalist__item__addr'][text()='aliaksandr_naryzhny@epam.com']")]
        public IWebElement message;

        public MainPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public NewMessagePage CreateNewMessage()
        {
            Console.WriteLine("Click on New Message button...");
            newMessageButton.Click();
            WaitUntilAvailable(d => d.FindElement(By.XPath("//label[text() = 'Кому']")));
            Thread.Sleep(600);
            return new NewMessagePage(Driver);
        }

        public NewMessagePage SelectMessageFromDraft()
        {
            Console.WriteLine("Select message...");
            message.Click();
            WaitUntilAvailable(d => d.FindElement(By.XPath("//input[@name='Subject']")));
            Thread.Sleep(500);
            return new NewMessagePage(Driver);
        }

        public MainPage NavigateToSent()
        {
            Console.WriteLine("Navigate to Sent folder...");
            SentFolder.Click();
            WaitUntilAvailable(d => d.FindElement(By.Id("b-letters")));
            return this;
        }

        public MainPage NavigateToDraft()
        {
            Console.WriteLine("Navigate to Draft folder...");
            DraftFolder.Click();
            WaitUntilAvailable(d => d.FindElement(By.Id("b-letters")));
            return this;
        }

        public MainPage LogOut()
        {
            Console.WriteLine("Logout from mailbox...");
            logoutLink.Click();
            return this;
        }
    }
}
