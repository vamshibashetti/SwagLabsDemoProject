using System.Text;
using System;
using OpenQA.Selenium;
using System.Threading;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace SwagLabClassLib
{
    public class LogInPage
    {
        private IWebDriver _driver;
        
        //username TextBox
        [FindsBy(How=How.Id, Using="user-name")]
        private IWebElement _username;
         //Password TextBox
        [FindsBy(How=How.Id, Using="password")]
        private IWebElement _password;
         //LogIn button

       
        [FindsBy(How=How.Id, Using="login-button")]
        private IWebElement _loginbutton;
        
        [FindsBy(How=How.XPath, Using="//h3[@data-test='error']")]
        private IWebElement _errormsg;

        public LogInPage(IWebDriver driver)
        {
          
          _driver =driver; 
        PageFactory.InitElements(_driver,this);
        }

         public void username(string uname)
         {

        _username.Clear();
        _username.SendKeys(uname);
    
        }
         public void password(string upassword){

        _password.Clear();
        _password.SendKeys(upassword);

        }


         public void loginbutton(){

            _loginbutton.Click();
        }
        public ProductsPage loginMethod(string uname,string upassword)
        {
          _username.Clear();
        _username.SendKeys(uname);
          _password.Clear();
        _password.SendKeys(upassword);
             _loginbutton.Click();
          return new ProductsPage(_driver);
        }
        
         public string lockedusermsg(){

            string actualerror=_errormsg.Text;
            return actualerror;
        }
         public String getPageTitle()
        {
            return _driver.Title;
        }

    }
    }

