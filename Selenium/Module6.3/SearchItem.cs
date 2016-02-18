using System;
using System.Configuration;
using Module6._3.selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Module6._3
{
    [Binding]
    public class SearchItem : BaseSelenium
    {
        [Given(@"I enter ""(.*)"" in the search field")]
        public void GivenIEnterInTheSearchField(string searchRequest)
        {
            var url = new Uri(ConfigurationSettings.AppSettings["url"]);
            Driver.Navigate().GoToUrl(url);
            Driver.FindElement(By.XPath("//*[@id='gh-ac']")).SendKeys(searchRequest);
        }
        
        [When(@"I perform search field")]
        public void WhenIPerformSearchField()
        {
            Driver.FindElement(By.XPath("//*[@id='gh-btn']")).Click();
        }
        
        [Then(@"I should see the search result for the ""(.*)""")]
        public void ThenIShouldSeeTheSearchResultForThe(string expected)
        {
            string firstItem = Driver.FindElement(By.XPath("//*[@id='ListViewInner']/li[1]")).Text;
            Assert.That(firstItem.Contains(expected));
        }
    }
}
