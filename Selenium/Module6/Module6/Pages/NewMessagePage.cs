using System;
using System.Configuration;
using System.Threading;
using Module6.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Module6
{
    public class NewMessagePage :BasePage
    {
        private readonly string subject = ConfigurationSettings.AppSettings["randomSubject"];
        private readonly string body = ConfigurationSettings.AppSettings["body"];
        private readonly string recipient = ConfigurationSettings.AppSettings["recipient"];
        private readonly string testMessage = ConfigurationSettings.AppSettings["testMessage"];
        //public string randomSubject = Utils.RandomString(5);
        [FindsBy(How = How.XPath, Using = "//*[@id='compose__header__content']/div[2]/div[2]/div[1]/textarea[2]")]
        private IWebElement toField;

        [FindsBy(How = How.XPath, Using = "//*[@class='compose__header__field__box']/input[@class='compose__header__field']")]
        private IWebElement subjectField;

        [FindsBy(How = How.XPath, Using = "//*[@id='tinymce']/div/div/div")]
        private IWebElement bodyField;

        [FindsBy(How = How.XPath, Using = "//span[text() = 'Отправить']")] 
        private IWebElement sendButton;

        [FindsBy(How = How.XPath, Using = "//span[text() = 'Сохранить']")]
        private IWebElement saveAsDraftButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='b-nav_folders']/div/div[3]/a/span")]
        private IWebElement DraftFolder;

        public NewMessagePage(IWebDriver driver) : base(driver)
        {
        }

        public NewMessagePage FillTextFields()
        {
            Console.WriteLine("Fill the text fields...");
            Thread.Sleep(400);
            toField.SendKeys(recipient);
            Actions.KeyboardSendKeys(Keys.Tab);
            subjectField.SendKeys(subject);
            Actions.KeyboardSendKeys(Keys.Tab);
            Actions.KeyboardSendKeys(testMessage);
            Actions.MouseClick(toField);
            return this;
        }

        public NewMessagePage SendMessage()
        {
            Console.WriteLine("Click on Send button...");
            Thread.Sleep(300);
            sendButton.Click();
            WaitHelper.WaitUntilAvailable(d => d.FindElement(By.XPath("//*[@id='b-compose__sent']/div/div[1]/div")));
            return this;
        }

        public NewMessagePage SaveAsDraft()
        {
            Console.WriteLine("Click on Save button...");
            saveAsDraftButton.Click();
            WaitHelper.WaitUntilAvailable(d => d.FindElement(By.XPath("//span[text() = 'Сохранено в ']")));
            return this;
        }

        public MainPage NavigateToDraft()
        {
            Console.WriteLine("Navigate to Draft folder...");
            Thread.Sleep(200);
            DraftFolder.Click();
            WaitHelper.WaitUntilAvailable(d => d.FindElement(By.Id("b-letters")));
            return new MainPage(Driver);
        }
    }
}
