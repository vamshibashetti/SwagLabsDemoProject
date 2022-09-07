
using System.Net.NetworkInformation;
using System.Runtime.Serialization;
using System.Linq.Expressions;
using Microsoft.VisualBasic;
using System.Net.Http.Headers;
using System;
using SwagLabClassLib;
using System.Diagnostics;
using System.Runtime.ExceptionServices;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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


namespace SwagLabMsTest
{
    [TestClass]
    public class SwagLabTest
    {
      
        IWebDriver driver;
       
        [TestInitialize]
        public void setup()

        {
            driver = new ChromeDriver(@"C:\Root Folder\WebDriver");
           // SwagLabClassLib.Constants.InitConstants();
            driver.Navigate().GoToUrl(SwagLabClassLib.Constants.SwagUrl);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            
        }
        [DataTestMethod]
        [Ignore]
        [DataRow("standard_user","secret_sauce")]
        [DataRow("locked_out_user","secret_sauce")]
        [DataRow("problem_user","secret_sauce")]
        [DataRow("performance_glitch_user","secret_sauce")]
        public void Loginwithmultiuserscerdentials(string user, string pass)
        {


            SwagLabClassLib.LogInPage log =new SwagLabClassLib.LogInPage(driver);
            log.username(user);
            log.password(pass);
            log.loginbutton();
            string actualoginltitle = log.getPageTitle();
           string expectedlogintitle="Swag Labs";
           Assert.AreEqual(expectedlogintitle,actualoginltitle,"title doesnot match");
        }
        [TestMethod]
   
        public void productpagevalidation(){
            SwagLabClassLib.LogInPage log =new SwagLabClassLib.LogInPage(driver);
            log.username(SwagLabClassLib.Constants.username);
            log.password(SwagLabClassLib.Constants.password);
            log.loginbutton();
           string actualoginltitle = log.getPageTitle();
           string expectedlogintitle="Swag Labs";
           Assert.AreEqual(expectedlogintitle,actualoginltitle,"title doesnot match");
            SwagLabClassLib.ProductsPage products =new SwagLabClassLib.ProductsPage(driver);
           string actualtitle = products.productsTitleverify();
           string expectedtitle="PRODUCTS";
           Assert.AreEqual(expectedtitle,actualtitle,"title doesnot match");
            products.backpackcart();
            products.bikelightcart();
            products.cartlink();
            SwagLabClassLib.CartPage cart = new SwagLabClassLib.CartPage(driver);
             cart.checkoutbtn();
            

        }
        [TestMethod]
        public void EndtoEndScenario(){
           
           SwagLabClassLib.LogInPage log =new SwagLabClassLib.LogInPage(driver);
           
           var productspage =log.loginMethod(SwagLabClassLib.Constants.username,SwagLabClassLib.Constants.password);
           string actualtitle = productspage.productsTitleverify();
           Assert.AreEqual("PRODUCTS",actualtitle,"product title not matched");
           
           var cartpage = productspage.navigatetocart();
           string actualitem = cartpage.SauceLabsBackpack();
           Assert.AreEqual("Sauce Labs Backpack",actualitem,"item not matched");
           
           var checkoutpage =cartpage.checkoutbtn();
           var checkoutcomplete = checkoutpage.checkoutFinish(SwagLabClassLib.Constants.Firstname,SwagLabClassLib.Constants.Lastname,SwagLabClassLib.Constants.Pincode);
           checkoutcomplete.backtohomebtn();
           
           productspage.menubtn();
           productspage.logoutlink();
        

        }
         [DataTestMethod]
         [Ignore]
         [DataRow("locked_out_user","secret_sauce")]
        public void Loginwithlockeduser(string username,string password){
            SwagLabClassLib.LogInPage log =new SwagLabClassLib.LogInPage(driver);
            log.username(username);
            log.password(password);
            log.loginbutton();
            string actuallockedoutmsg ="Epic sadface: Sorry, this user has been locked out.";
            string expectedlockedoutmsg =log.lockedusermsg();
            Assert.AreEqual(actuallockedoutmsg,expectedlockedoutmsg,"the user is locked ");


        }
         [DataTestMethod]
         [Ignore]
         [DataRow("problem_user","secret_sauce")]
        public void Problemuser(string pname,string ppassword){
            SwagLabClassLib.LogInPage log =new SwagLabClassLib.LogInPage(driver);
            var productspage =log.loginMethod(pname,ppassword);
          
           string actualbackpackimg =productspage.probuserbackpackimage();

            string expectedbackpackimg = "/static/media/sauce-backpack-1200x1500.34e7aa42.jpg";

            Assert.AreNotEqual(expectedbackpackimg,actualbackpackimg,"problem user image doesnot match");


        }

         
        [TestMethod]
        public void dropdownValidation(){
           
           SwagLabClassLib.LogInPage log =new SwagLabClassLib.LogInPage(driver);

           var productspage =log.loginMethod(SwagLabClassLib.Constants.username,SwagLabClassLib.Constants.password);
           string actualtitle = productspage.productsTitleverify();
           Assert.AreEqual("PRODUCTS",actualtitle,"product title not matched");
              productspage.FiltersDropdown();
           
           var cartpage = productspage.navigatetocart();
           string actualitem = cartpage.SauceLabsBackpack();
           Assert.AreEqual("Sauce Labs Backpack",actualitem,"item not matched");
           
           var checkoutpage =cartpage.checkoutbtn();
           var checkoutcomplete = checkoutpage.checkoutFinish(SwagLabClassLib.Constants.Firstname,SwagLabClassLib.Constants.Lastname,SwagLabClassLib.Constants.Pincode);
           checkoutcomplete.backtohomebtn();
           
           productspage.menubtn();
           productspage.logoutlink();
        

        }
        
         [DataTestMethod]
         [Ignore]
        [DataRow("standard_user","secret_sauce","vamshi","bashetti","500049")]
        public void NumberofitemsselectedValidation(string uname,string upassword,string fname,string lname,string pin){
           
           SwagLabClassLib.LogInPage log =new SwagLabClassLib.LogInPage(driver);
          
           var productspage =log.loginMethod(uname,upassword);
           string actualtitle = productspage.productsTitleverify();
           var cartpage = productspage.navigatetocart();
        
           cartpage.RemoveItemsFromcart(); 
        
           int actualitems = cartpage.numberofitemsincart();
           int expecteditems = 2;
           Assert.AreEqual(expecteditems,actualitems,"noof items doesnot match");     
           var checkoutpage =cartpage.checkoutbtn();
           var checkoutcomplete = checkoutpage.checkoutFinish(fname,lname,pin);
           checkoutcomplete.backtohomebtn();
           productspage.menubtn();
           productspage.logoutlink();
        

        }
        
         [DataTestMethod]
         [Ignore]
    
        [DataRow("standard_user","secret_sauce","vamshi","bashetti","500049")]
        public void verifyingPagesTitle(string uname,string upassword,string fname,string lname,string pin){
           
           SwagLabClassLib.LogInPage log =new SwagLabClassLib.LogInPage(driver);
           string actualoginltitle = log.getPageTitle();
           string expectedlogintitle="Swag Labs";
           Assert.AreEqual(expectedlogintitle,actualoginltitle,"title doesnot match");
           var productspage =log.loginMethod(uname,upassword);
           string actualtitle = productspage.productsTitleverify();
           string expectedtitle="PRODUCTS";
           Assert.AreEqual(expectedtitle,actualtitle,"title doesnot match");

           var cartpage = productspage.navigatetocart();
           
           string actualctitle = cartpage.cartPageTitle();
           string expectedctitle="YOUR CART";
           Assert.AreEqual(expectedctitle,actualctitle,"title doesnot match");
           var checkoutpage =cartpage.checkoutbtn();
           var checkoutcomplete = checkoutpage.checkoutFinish(fname,lname,pin);
           checkoutcomplete.backtohomebtn();
           productspage.menubtn();
           productspage.logoutlink();
        

        }
        


        [TestCleanup]
        public void TearDown()
        {
           driver.Quit();

        }


    }
}
