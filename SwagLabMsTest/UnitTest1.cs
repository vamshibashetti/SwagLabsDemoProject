
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
    [TestClass]
    public class UnitTest1
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
        [DataTestMethod]
    
        [DataRow("standard_user","secret_sauce")]
        [DataRow("locked_out_user","secret_sauce")]
        [DataRow("problem_user","secret_sauce")]
        [DataRow("performance_glitch_user","secret_sauce")]
        public void Loginwithmultiusers(string user, string pass)
        {
            LogInPage log =new LogInPage(driver);
            log.username(user);
            log.password(pass);
            log.loginbutton();
        }
        [TestMethod]
    
        public void productpage(){
            LogInPage log =new LogInPage(driver);
            log.username("standard_user");
            log.password("secret_sauce");
            log.loginbutton();
            ProductsPage products =new ProductsPage(driver);
            Thread.Sleep(3000);
            products.backpackcart();
            products.bikelightcart();
            products.cartlink();
            CartPage cart = new CartPage(driver);
             cart.checkoutbtn();
            Thread.Sleep(2000);

        }
        [DataTestMethod]
    
        [DataRow("standard_user","secret_sauce","vamshi","bashetti","500049")]
        public void EndtoEndScenario(string uname,string upassword,string fname,string lname,string pin){
           
           SwagLabClassLib.LogInPage log =new SwagLabClassLib.LogInPage(driver);
           
           var productspage =log.loginMethod(uname,upassword);
           string actualtitle = productspage.productsTitleverify();
           Assert.AreEqual("PRODUCTS",actualtitle,"product title not matched");
           
           var cartpage = productspage.navigatetocart();
           string actualitem = cartpage.SauceLabsBackpack();
           Assert.AreEqual("Sauce Labs Backpack",actualitem,"item not matched");
           
           var checkoutpage =cartpage.checkoutbtn();
           var checkoutcomplete = checkoutpage.checkoutFinish(fname,lname,pin);
           checkoutcomplete.backtohomebtn();
           
           productspage.menubtn();
           productspage.logoutlink();
        

        }
         [DataTestMethod]
         [DataRow("locked_out_user","secret_sauce")]
        public void lockeduservalidation(string username,string password){
            LogInPage log =new LogInPage(driver);
            log.username(username);
            log.password(password);
            log.loginbutton();
            string actuallockedoutmsg ="Epic sadface: Sorry, this user has been locked out.";
            string expectedlockedoutmsg =log.lockedusermsg();
            Assert.AreEqual(actuallockedoutmsg,expectedlockedoutmsg,"the user is locked ");


        }
         [DataTestMethod]
         [DataRow("problem_user","secret_sauce")]
        public void Problemuser(string pname,string ppassword){
            LogInPage log =new LogInPage(driver);
            var productspage =log.loginMethod(pname,ppassword);
          
           string actualbackpackimg =productspage.probuserbackpackimage();

            string expectedbackpackimg = "/static/media/sauce-backpack-1200x1500.34e7aa42.jpg";

            Assert.AreNotEqual(expectedbackpackimg,actualbackpackimg,"problem user image doesnot match");


        }

         
        [DataTestMethod]
    
        [DataRow("standard_user","secret_sauce","vamshi","bashetti","500049")]
        public void dropdown_Validation(string uname,string upassword,string fname,string lname,string pin){
           
           LogInPage log =new LogInPage(driver);

           var productspage =log.loginMethod(uname,upassword);
           string actualtitle = productspage.productsTitleverify();
           Assert.AreEqual("PRODUCTS",actualtitle,"product title not matched");
              productspage.FiltersDropdown();
           
           var cartpage = productspage.navigatetocart();
           string actualitem = cartpage.SauceLabsBackpack();
           Assert.AreEqual("Sauce Labs Backpack",actualitem,"item not matched");
           
           var checkoutpage =cartpage.checkoutbtn();
           var checkoutcomplete = checkoutpage.checkoutFinish(fname,lname,pin);
           checkoutcomplete.backtohomebtn();
           
           productspage.menubtn();
           productspage.logoutlink();
        

        }
         [DataTestMethod]
    
        [DataRow("standard_user","secret_sauce","vamshi","bashetti","500049")]
        public void Removingproducts_Validation(string uname,string upassword,string fname,string lname,string pin){
           
           LogInPage log =new LogInPage(driver);

           var productspage =log.loginMethod(uname,upassword);
           string actualtitle = productspage.productsTitleverify();
           var cartpage = productspage.navigatetocart();
           cartpage.RemoveItemsFromcart();       
           var checkoutpage =cartpage.checkoutbtn();
           var checkoutcomplete = checkoutpage.checkoutFinish(fname,lname,pin);
           checkoutcomplete.backtohomebtn();
           productspage.menubtn();
           productspage.logoutlink();
        

        }
        


        [TestCleanup]
        public void Cleanup()
        {
           driver.Quit();

        }


    }
}
