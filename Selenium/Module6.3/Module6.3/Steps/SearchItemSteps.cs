using System;
using System.Configuration;
using System.IO;
using Module6._3.selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Module6._3.Steps
{
    [Binding]
    public class SearchItemSteps : BaseSelenium
    {
        [Given(@"I enter ""(.*)"" in the text feild")]
        public void GivenIEnterInTheTextFeild(string searchRequest)
        {
            Driver = new ChromeDriver(ConfigurationSettings.AppSettings["path"]); 
            Driver.Manage().Window.Maximize();
            var url = new Uri(ConfigurationSettings.AppSettings["url"]);
            Driver.Navigate().GoToUrl(url);
            Driver.FindElement(By.XPath("//*[@id='gh-ac']")).SendKeys(searchRequest);
        }

        [When(@"I perform search")]
        public void WhenIPerformSearch()
        {
            Driver.FindElement(By.XPath("//*[@id='gh-btn']")).Click();
        }

        [Then(@"I should see the search result for the ""(.*)"" item")]
        public void ThenIShouldSeeTheSearchResultForTheItem(string expected)
        {
            string firstItem = Driver.FindElement(By.XPath("//*[@id='ListViewInner']/li[1]")).Text;
            Assert.That(firstItem.Contains(expected));
            Driver.Quit();
        }
      
    }
}
