using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Xml.Serialization;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Module5
{
    [TestFixture]
    [Description("Testing Web Driver")]

    public class TestMailRu
    {
        public static IWebDriver driver;
        public static WebDriverWait wait;
        #region Setup

        [SetUp]
        public void Init()
        {
            Console.WriteLine("Test setup");
            const string driverPath = "@//..//..//..//driver";
            driver = new ChromeDriver(driverPath);
            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        #endregion

        [Test]
        public void Test1_VerifyLoginToMailbox()
        {
            Console.WriteLine("LogIn to mailbox.");
            LogInToMailbox();
            Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='PH_user-email']")).Text.ToLower().Equals("lexx20@mail.ru"));
            //VerifyLogin();
            LogOut();
        }

        [Test]
        public void Test2_CreateNewMessage()
        {
            Console.WriteLine("Creating new message.");
            LogInToMailbox();
            NavigateToNewMessage();
            FillInfo();
            SaveAsDraft();
            NavigateToDraftFolderFromNewMessage();
            Console.WriteLine(VerifyMessageExistInFolder(By.ClassName("b-datalist__body"))
                ? "Message exist in Draft folder"
                : "Message not exist in Draft folder");
            VerifyMessageText();
            LogOut();
        }

        [Test]
        public void Test3_SendMessage()
        {
            Console.WriteLine("Send message from Draft folder.");
            LogInToMailbox();
            NavigateToDraftFolder();
            SendMessageFromDraft();
            NavigateToDraftFolder();
            Console.WriteLine(VerifyMessageExistInFolder(By.ClassName("b-datalist__body"))
                ? "Message exist in Draft folder"
                : "Message not exist in Draft folder");

            NavigateToSentFolder();
            VerifySendMessage();
            LogOut();

        }

        public static void LogInToMailbox()
        {
            Console.WriteLine("Trying to login...");
            driver.Navigate().GoToUrl("http://mail.ru");
            string usernameId = "mailbox__login";
            string passwordId = "mailbox__password";
            string loginButton = "mailbox__auth__button";

            driver.FindElement(By.Id(usernameId)).SendKeys("Lexx20");
            driver.FindElement(By.Id(passwordId)).SendKeys("astalavista");
            driver.FindElement(By.Id(loginButton)).Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.XPath("//*[@id='b-nav_folders']/div")));
        }

        public static bool VerifyLogin()
        {
            Console.WriteLine("Verify Is Login successfull...");
            if (driver.FindElement(By.XPath("//*[@id='PH_user-email']")).Text.ToLower().Equals("lexx20@mail.ru"))
            {
                Console.WriteLine("Login to mailbox was successfull");
                return true;
            }
            return false;
        }

        //public static void Cleanup(IWebDriver driver, WebDriverWait wait)
        //{
        //    Console.WriteLine("Clean Draft folder...");
        //    driver.FindElement(By.XPath("//*[@id='b-nav_folders']/div/div[3]/a/span")).Click();
        //    wait.Until(d => d.FindElement(By.Id("b-letters")));

        //    ReadOnlyCollection<IWebElement> list =
        //        driver.FindElements(By.XPath("//*[@class='js-item-checkbox b-datalist__item__cbx']"));
        //    while (true)
        //    {
        //        var chbox = list.Count;
        //        for (int i = 0; i < chbox; )
        //        {
        //            list[i].Click();
        //            i++;
        //        }
        //        break;
        //    }

        //    driver.FindElement(By.LinkText("Удалить")).Click();
        //}

        public static void NavigateToNewMessage()
        {
            Console.WriteLine("Click on New message...");
            driver.FindElement(By.XPath("//*[@class='b-toolbar__btn js-shortcut']/span")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.XPath("//label[text() = 'Кому']")));
            Thread.Sleep(600);
        }

        public static void FillInfo()
        {
            Console.WriteLine("Filling the text fields...");
            var toField =
                driver.FindElement(By.XPath("//*[@id='compose__header__content']/div[2]/div[2]/div[1]/textarea[2]"));
            Thread.Sleep(400);
            toField.SendKeys("aliaksandr_naryzhny@epam.com");
            var themeField =
                driver.FindElement(
                    By.XPath("//*[@class='compose__header__field__box']/input[@class='compose__header__field']"));

            themeField.SendKeys("new message");
            driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("iframe[title='{#aria.rich_text_area}']")));
            var bodyField = driver.FindElement(By.XPath("//*[@id='tinymce']"));
            bodyField.SendKeys("text message");
            driver.SwitchTo().DefaultContent();
            Thread.Sleep(300);
        }

        public static void SaveAsDraft()
        {
            Console.WriteLine("Save as Draft message...");
            driver.FindElement(By.XPath("//span[text() = 'Сохранить']")).Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.ClassName("b-toolbar__message")));
        }
        
        public static void NavigateToDraftFolderFromNewMessage()
        {
            Console.WriteLine("Navigating to Draft folder...");
            driver.FindElement(By.XPath("//*[@id='b-nav_folders']/div/div[3]/a/span")).Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.XPath("//span[text() = 'Сохранено в ']")));
        }

        public static void NavigateToDraftFolder()
        {
            Console.WriteLine("Navigating to Draft folder...");
            driver.FindElement(By.XPath("//*[@id='b-nav_folders']/div/div[3]/a/span")).Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.Id("b-letters")));
        }

        public static bool VerifyMessageExistInFolder(By locator)
        {
            Console.WriteLine("Verify existing message in folder...");
            try
            {
                driver.FindElement(locator);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public static void VerifyMessageText()
        {
            Console.WriteLine("Verify text in fields...");
            var emailTxt = driver.FindElement(By.XPath("//*[@class='b-datalist__item__panel']/div[3]/div[2]"));
            var themeTxt = driver.FindElement(By.XPath("//*[@class='b-datalist__item__panel']/div[3]/div[1]"));
            var bodyTxt = driver.FindElement(By.XPath("//*[@class='b-datalist__item__panel']/div[3]/div[1]/span"));

            if (emailTxt.Text.Contains("aliaksandr_naryzhny@epam.com"))
            {
                Console.WriteLine("Email field verified.");
            }
            if (themeTxt.Text.Contains("new message"))
            {
                Console.WriteLine("Theme field verified.");
            }
            if (bodyTxt.Text.Contains("text message"))
            {
                Console.WriteLine("Body field verified.");
            }
        }

        public static void NavigateToSentFolder()
        {
            Console.WriteLine("Navigate to Send folder...");
            driver.FindElement(By.XPath("//span[text() = 'Отправленные']")).Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.Id("b-letters")));
        }

        public static void SendMessageFromDraft()
        {
            Console.WriteLine("Sending message...");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Thread.Sleep(100);
            Console.WriteLine("Click on Draft...");
            driver.FindElement(By.XPath(".//div[text()='aliaksandr_naryzhny@epam.com']")).Click();
            Console.WriteLine("Wait...");
            wait.Until(d => d.FindElement(By.XPath("//input[@name='Subject']")));
            Console.WriteLine("Click on Send...");
            driver.FindElement(By.XPath("//span[text() = 'Отправить']")).Click();
            Console.WriteLine("Wait...");
            wait.Until(d => d.FindElement(By.XPath("//*[@id='b-compose__sent']/div/div[1]/div")));
        }

        public static void VerifySendMessage()
        {
            Console.WriteLine("Verifing message in Sent folder...");
            var send = driver.FindElements(By.XPath("//*[@class='b-datalist__item__panel']/div[3]/div[2]"));
            while (true)
            {
                int sendm = send.Count;
                for (int i = 0; i < sendm; )
                {
                    if (send[i].Text.ToLower().Equals("aliaksandr_naryzhny@epam.com"))
                    {
                        Console.WriteLine("Message presended in Send folder.");
                        break;
                    }
                    i++;
                }
                break;
            }
        }

        public static void LogOut()
        {
            driver.FindElement(By.Id("PH_logoutLink"));
        }

        [TearDown]
        public void Clean()
        {
            Console.WriteLine("Test teardown");
            driver.Quit();
        }
    }
}