using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.Support.UI;

namespace VelocityRisk
{
    [TestClass]
    public class PersonalPolicyTests
    {
        [TestMethod]
        public void Test_HomeOwners()
        {
            using (IWebDriver driver = new FirefoxDriver())
            {
                driver.Navigate().GoToUrl("http://velocityrisk.com/");

                IWebElement productslink = driver.FindElement(By.LinkText("products"));
                productslink.Click();
                IWebElement personallink = driver.FindElement(By.LinkText("personal"));
                personallink.Click();
                IWebElement homeownerslink = driver.FindElement(By.LinkText("homeowners"));
                homeownerslink.Click();


                IList<IWebElement> hopolicies = driver.FindElements(By.ClassName("logo-wrap"));
                Assert.IsTrue(CheckPolicies(hopolicies,"Fire"));
                Assert.IsTrue(CheckPolicies(hopolicies, "Lightning"));
                Assert.IsTrue(CheckPolicies(hopolicies, "Theft"));
                Assert.IsTrue(CheckPolicies(hopolicies, "Wind Damage"));

                IWebElement btnHOPolicy = driver.FindElement(By.LinkText("Understand Your Policy"));
                btnHOPolicy.Click();
                IWebElement popupUnderstandPolicy = driver.FindElement(By.ClassName("box-title"));
                Console.WriteLine(popupUnderstandPolicy.Text);
                Assert.IsTrue(popupUnderstandPolicy.Text == "What does a Homeowners policy protect?");
                //Assert.IsTrue(driver.PageSource.Contains("What does a Homeowners policy protect?"));

            }

        }
        public Boolean CheckPolicies(IList<IWebElement> logo, string polName)
        {
            foreach (var policylogo in logo)
            {
                if (policylogo.Text == polName)
                {return true;}
            }
            return false;
        }
    }
}
