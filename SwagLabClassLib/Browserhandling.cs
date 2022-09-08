using System.Text;
using System;
using OpenQA.Selenium;
using System.Threading;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace SwagLabClassLib
{
    public  class Browserhandling
    {
        public IWebDriver driver;

        public Browserhandling(IWebDriver driver)
        {
          this.driver =driver; 
         
        }

        public IWebDriver Browser(string browser)
       {
        if(browser=="firefox")
            {
               
                driver = new FirefoxDriver(@"C:\Root Folder\WebDriver");
            
            }
            else if (browser=="chrome")
            {     //this.driver =driver; 
                 driver = new ChromeDriver(@"C:\Root Folder\WebDriver");
            }
            else
            {     // this.driver =driver; 
                driver = new EdgeDriver(@"C:\Root Folder\WebDriver");
            }
            return driver;
       }
    }
}