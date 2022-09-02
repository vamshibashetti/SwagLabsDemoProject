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
    public class CheckoutPage
    {     
          private IWebDriver _driver;
        
        [FindsBy(How= How.Id, Using="first-name")]
        private IWebElement _FirstName;

        [FindsBy(How= How.Id, Using="last-name")]
        private IWebElement _LastName;

        [FindsBy(How= How.Id, Using="postal-code")]
        private IWebElement _PostalCode;

        [FindsBy(How= How.Id, Using="continue")]
        private IWebElement _Continue;

        [FindsBy(How= How.Id, Using="finish")]
        private IWebElement _Finish;

        public CheckoutPage(IWebDriver driver)
        {
          
          _driver =driver; 
        PageFactory.InitElements(_driver,this);
        }


        public void FirstName(string Fname){

            _FirstName.SendKeys(Fname);
        }

         public void LastName(string Lname){

            _LastName.SendKeys(Lname);
        }

          public void PostalCode(string Pin){

            _PostalCode.SendKeys(Pin);
        }

         public void Continue(){

            _Continue.Click();
        }

         public void Finish()
         {

            _Finish.Click();
        }
        public CheckoutCompletePage checkoutFinish(string Fname,string Lname,string Pin){
           _FirstName.SendKeys(Fname);
            _LastName.SendKeys(Lname);
            _PostalCode.SendKeys(Pin);
             _Continue.Click();
             _Finish.Click();
             return new CheckoutCompletePage(_driver);
        }


        
    }
}