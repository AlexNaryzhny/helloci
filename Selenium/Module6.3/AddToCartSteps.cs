using System;
using System.Configuration;
using System.Net.Mime;
using Module6._3.selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Module6._3
{
    [Binding]
    public class AddToCartSteps : BaseSelenium
    {
        [BeforeScenario]
        public void BeforeScenario()
        {
            Init();
        }

        [Given(@"I enter ""(.*)"" in the search feild")]
        public void GivenIEnterInTheSearchFeild(string searchRequest)
        {
            Driver.FindElement(By.XPath("//*[@id='gh-ac']")).SendKeys(searchRequest);
        }

        [When(@"I click on ""(.*)"" button")]
        public void WhenIClickOnButton(string p0)
        {
            Driver.FindElement(By.XPath("//*[@id='gh-btn']")).Click();
        }

        [When(@"I click on button labled ""(.*)""")]
        public void WhenIClickOnButtonLabled(string p0)
        {
            Driver.FindElement(By.XPath("//*[@id='cbelm']/div[1]/div[2]/a[2]")).Click();
        }

        [Then(@"I should see the result where ""(.*)"" item on the top")]
        public void ThenIShouldSeeTheResultWhereItemOnTheTop(string expected)
        {
            var firstItem = Driver.FindElement(By.XPath("//*[@id='ListViewInner']/li[1]")).Text;
            Assert.That(firstItem.Contains(expected));
        }

        [When(@"I click on the first item name")]
        public void WhenIClickOnTheFirstItemName()
        {
            Driver.FindElement(By.XPath("//*[@id='ListViewInner']/li[1]/div/div/a/img")).Click();
        }

        [Then(@"I should see full description")]
        public void ThenIShouldSeeFullDescription()
        {
            Driver.FindElement(By.XPath("//*[@id='CenterPanelInternal']"));
        }

        [When(@"I select color")]
        public void WhenISelectColor()
        {
            try
            {
                Driver.FindElement(By.XPath("//*[@id='msku-sel-1']")).Click();
                Driver.FindElement(By.XPath("//*[@id='msku-opt-0']")).Click();
                Driver.FindElement(By.XPath("//*[@id='msku-opt-1']")).Click();
                Driver.FindElement(By.XPath("//*[@id='msku-opt-2']")).Click();
            }
            catch (Exception)
            {

            }
        }

        [When(@"I click the button with label ""(.*)""")]
        public void WhenIClickTheButtonWithLabel(string p0)
        {
            Driver.FindElement(By.XPath("//*[@id='isCartBtn_btn']")).Click();
        }

        [Then(@"I should see confirmation message ""(.*)""")]
        public void ThenIShouldSeeConfirmationMessage(string text)
        {
            var confirmTxt = Driver.FindElement(By.XPath("//*[@id='pageLevelMessaing']/div/div")).Text;
            Assert.That(confirmTxt.Contains(text));
        }

        [When(@"I navigate to the cart")]
        public void WhenINavigateToTheCart()
        {
            Driver.FindElement(By.XPath("//*[@id='gh-cart-i']")).Click();
        }

        [Then(@"I should see ""(.*)"" item in the cart")]
        public void ThenIShouldSeeItemInTheCart(string itemInCart)
        {
            var cartTxt = Driver.FindElement(By.XPath("//*[@id='ShopCart']/div")).Text;
            Assert.That(cartTxt.Contains(itemInCart));
        }

        [When(@"I click the link labelled ""(.*)""")]
        public void WhenIClickTheLinkLabelled(string link)
        {
            Driver.FindElement(By.XPath("//div[a/text()='"+link+"']/a[1]")).Click();
        }

        [When(@"I want to click to order button")]
        public void WhenIWantToClickToOrderButton()
        {
            Driver.FindElement(By.XPath("//*[@id='ptcBtnRight']")).Click();
        }

        [Then(@"I should see a login page")]
        public void ThenIShouldSeeALoginPage()
        {
            var loginPanel = Driver.FindElement(By.XPath("//*[@id='mainCnt']"));
            Assert.That(loginPanel.Displayed);
        }

        [Given(@"I login to ebay")]
        public void GivenILoginToEbay()
        {
            Driver.FindElement(By.XPath("//*[@id='gh-ug']/a")).Click();
            Driver.FindElement(By.XPath("//*[@class='fld' and @type='text']")).SendKeys("testLogin6");
            Driver.FindElement(By.XPath("//*[@class='fld' and @type='password']")).SendKeys("Selenium!");
            Driver.FindElement(By.XPath("//*[@id='sgnBt']")).Click();
        }

        [Then(@"I enter ""(.*)"" in the search feild")]
        public void ThenIEnterInTheSearchFeild(string searchRequest)
        {
            Driver.FindElement(By.XPath("//*[@id='gh-ac']")).SendKeys(searchRequest);
        }

        [When(@"I want to click to ""(.*)"" button")]
        public void WhenIWantToClickToButton(string save)
        {
            Driver.FindElement(By.XPath("//div[a/text()='"+save+"']/a[2]")).Click();
        }


        [AfterScenario]
        public void AfterScenario()
        {
            Close();
        }
    }
}
