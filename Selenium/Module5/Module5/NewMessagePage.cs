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
    class NewMessagePage :BasePage
    {
        [FindsBy(How = How.XPath, Using = "//*[@id='compose__header__content']/div[2]/div[2]/div[1]/textarea[2]")]
        private IWebElement toField;

        [FindsBy(How = How.XPath, Using = "//*[@class='compose__header__field__box']/input[@class='compose__header__field']")]
        private IWebElement subjectField;

        [FindsBy(How = How.XPath, Using = "//*[@id='tinymce']/div/div/div")] //"//*[@id='tinymce']")]
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

        public NewMessagePage FillTextFields(string subject, string body)
        {
            Console.WriteLine("Fill the text fields...");
            Thread.Sleep(400);
            toField.SendKeys("aliaksandr_naryzhny@epam.com");
            KeyboardSendKeys(Keys.Tab);
            subjectField.SendKeys(subject);
            KeyboardSendKeys(Keys.Tab);
            KeyboardSendKeys("test");
            MouseClick(toField);
            return this;
        }

        public NewMessagePage SendMessage()
        {
            Console.WriteLine("Click on Send button...");
            Thread.Sleep(300);
            sendButton.Click();
            WaitUntilAvailable(d => d.FindElement(By.XPath("//*[@id='b-compose__sent']/div/div[1]/div")));
            return this;
        }

        public NewMessagePage SaveAsDraft()
        {
            Console.WriteLine("Click on Save button...");
            saveAsDraftButton.Click();
            WaitUntilAvailable(d => d.FindElement(By.XPath("//span[text() = 'Сохранено в ']")));
            return this;
        }

        public MainPage NavigateToDraft()
        {
            Console.WriteLine("Navigate to Draft folder...");
            Thread.Sleep(200);
            DraftFolder.Click();
            WaitUntilAvailable(d => d.FindElement(By.Id("b-letters")));
            return new MainPage(Driver);
        }
    }
}
