using System.Net.Http.Headers;
using System.Diagnostics.Tracing;
using System.Dynamic;
using System.ComponentModel;
using System;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwagLabClassLib;
using OpenQA.Selenium;
using System.Threading;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;

namespace SwagLabMsTest
{
    public class TestClass
    {
         IWebDriver driver;

        [TestInitialize]
        public void start_Browser()

        {
            driver = new ChromeDriver(@"C:\Root Folder\WebDriver");
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            
        }
        
    }
}