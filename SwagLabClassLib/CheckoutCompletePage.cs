using System;
using System.Linq;
using OpenQA.Selenium;
using System.Threading;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;



namespace SwagLabClassLib
{
    public class CheckoutCompletePage
    {
        private IWebDriver _driver;
        
        [FindsBy(How= How.Id, Using="back-to-products")]
        private IWebElement _backtohomebtn;

        public CheckoutCompletePage(IWebDriver driver)
        {
          
          _driver =driver; 
        PageFactory.InitElements(_driver,this);
        }
        
         public ProductsPage backtohomebtn()
        {
            _backtohomebtn.Click();
            return new ProductsPage(_driver);
        }

        
    }
}