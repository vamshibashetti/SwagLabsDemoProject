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
    public class CartPage
    {
        private IWebDriver _driver;

        [FindsBy(How= How.XPath, Using="//button[@id='checkout']")]
        private IWebElement _checkoutbtn;
        //items selected 
        [FindsBy(How= How.XPath, Using="//div[contains(text(),'Sauce Labs Backpack')]")]
        private IWebElement _SauceLabsBackpack;

        [FindsBy(How= How.XPath, Using="//*[@id='item_0_title_link']")]
        private IWebElement _SauceLabsBikeLight;

        [FindsBy(How= How.XPath, Using="//*[@id='item_1_title_link']")]
        private IWebElement _SauceLabsBoltT_Shirt;
        //Remove items
        [FindsBy(How= How.XPath, Using="//button[@id='remove-sauce-labs-bike-light']")]
        private IWebElement _RemoveBikeLight;
        [FindsBy(How= How.XPath, Using="//button[@id='remove-sauce-labs-backpack']")]
        private IWebElement _RemoveBackpack;
        //list of elements
        [FindsBy(How= How.ClassName, Using="inventory_item_name")]
        private  IList<IWebElement> _SelectedItemslist;
         //title
          [FindsBy(How= How.XPath, Using="//span[@class='title']")]
        private IWebElement _carttitle;
        
        public CartPage(IWebDriver driver)
        {
          
        _driver =driver; 
        PageFactory.InitElements(_driver,this);
        }

        public CheckoutPage checkoutbtn()
        {
          _checkoutbtn.Click();
          return new CheckoutPage(_driver);
        }
        public string SauceLabsBackpack(){

          string actual =  _SauceLabsBackpack.Text;
          return actual;

         }

        public string SauceLabsBikeLight(){

          string actual1 =  _SauceLabsBikeLight.Text;
          return actual1;

         }

        public string SauceLabsBoltT_Shirt(){

          string actual2 =  _SauceLabsBoltT_Shirt.Text;
          return actual2;

         } 
        public void RemoveItemsFromcart()
         {
          
          _RemoveBikeLight.Click();
          _RemoveBackpack.Click();
         }
         public int numberofitemsincart()
        {
         int itemscount =_SelectedItemslist.Count();         
          return itemscount;
        }
        public String cartPageTitle()
        {
            return _carttitle.Text;
        }
  
        
    }
}

