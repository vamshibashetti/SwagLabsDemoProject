using System.IO;
using System.ComponentModel;
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
using SeleniumExtras.WaitHelpers;


namespace SwagLabClassLib
{
    public class ProductsPage
    {
         private IWebDriver _driver;
         private WebDriverWait Wait;

        //sidebar elements
        [FindsBy(How= How.Id, Using="react-burger-menu-btn")]
        private IWebElement _menubtn;
        [FindsBy(How= How.Id, Using="inventory_sidebar_link")]
        private IWebElement _allitemslink;
        [FindsBy(How= How.Id, Using="logout_sidebar_link")]
        private IWebElement _logoutlink;
        [FindsBy(How= How.Id, Using="reset_sidebar_link")]
        private IWebElement _resetlink;
        [FindsBy(How= How.Id, Using="react-burger-cross-btn")]
        private IWebElement _crossbtn;
        
        
       //cart link
        [FindsBy(How= How.ClassName, Using="shopping_cart_link")]
        private IWebElement _cartlink;

        
        
        [FindsBy(How= How.ClassName, Using="product_sort_container")]
        private IWebElement _sortdropdown;
        //items selection
        [FindsBy(How= How.XPath, Using="//span[@class='title']")]
         private IWebElement _products;

        [FindsBy(How= How.XPath, Using="//div[contains(text(), 'Sauce Labs Backpack')]")]

        private IWebElement _backpack;

        [FindsBy(How= How.Id, Using="add-to-cart-sauce-labs-backpack")]

        private IWebElement _backpackcart;

        [FindsBy(How= How.XPath, Using="//div[contains(text(), 'Sauce Labs Bike Light')]")]

        private IWebElement _bikelight;

        [FindsBy(How= How.XPath, Using="//button[@id='add-to-cart-sauce-labs-bike-light']")]

        private IWebElement _bikelightcart;

         [FindsBy(How= How.XPath, Using="//div[contains(text(), 'Sauce Labs Bolt T-Shirt')]")]

        private IWebElement _boltTshirt;

        [FindsBy(How= How.XPath, Using="//button[@id='add-to-cart-sauce-labs-bolt-t-shirt']")]

        private IWebElement _boltTshirtc;

        [FindsBy(How= How.Id, Using="add-to-cart-test.allthethings()-t-shirt-(red)")]

        private IWebElement _RedTshirt;

        //FiltersDropdown
        [FindsBy(How= How.XPath, Using="//select[@class='product_sort_container']")]

        private IWebElement _FilterDropdown;

        //problemuser
        [FindsBy(How= How.XPath, Using="//img[@alt='Sauce Labs Backpack']")]
        private IWebElement _prouserbackpackimage;


    
      public ProductsPage(IWebDriver driver)
        {
          
          _driver =driver; 
          Wait = new WebDriverWait(driver,TimeSpan.FromSeconds(20));
      
        PageFactory.InitElements(_driver,this);
        }

        public void menubtn(){

            _menubtn.Click();
        }

        public void allitemslink(){

            _allitemslink.Click();
        }

        public void logoutlink(){

             _logoutlink.Click();
        }

        public void resetlink(){

           _resetlink.Click();
        }
        public void crossbtn(){

            _crossbtn.Click();
        }

        public void cartlink(){

            _cartlink.Click();
        }

    

          public void backpack()

        {

        _backpack.Click();

        }



        public void backpackcart()

        {

        _backpackcart.Click();

        }



        public void bikelight()

        {

        _bikelight.Click();

        }



        public void bikelightcart()

        {

        _bikelightcart.Click();

        }
       public CartPage navigatetocart()
       {
         _backpackcart.Click();
         _bikelightcart.Click();
          Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable( _boltTshirtc));
        _boltTshirtc.Click();
         _RedTshirt.Click();
          _cartlink.Click();

          return new CartPage(_driver);
       }
        
       public string productsTitleverify()
        {

         string actual =  _products.Text;
          return actual;

        }
        public string  probuserbackpackimage()

        {

            string actualValue=_prouserbackpackimage.GetAttribute("src");

            return actualValue;

        }

        public void FiltersDropdown()
        {
             Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable( _FilterDropdown));
          SelectElement productsfilter = new SelectElement((_FilterDropdown));
           productsfilter.SelectByValue("lohi");
        }
         

    }
    }
