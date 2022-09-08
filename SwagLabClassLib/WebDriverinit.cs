// using OpenQA.Selenium.Chrome;
// using OpenQA.Selenium.Edge;
// using OpenQA.Selenium.Firefox;
// using OpenQA.Selenium.Remote;
// using OpenQA.Selenium;

// using System;


// namespace SwagLabClassLib
// {
//     public enum BrowserType
//     {
//         chrome,
//         Firefox,
//         Edge
//     }
//     public class WebDriverinit
//     {
//         public IWebDriver GetWebDriver(BrowserType browserType)
//         {
//             dynamic capability= GetBrowserOptions(browserType);
//         }
//         private dynamic GetBrowserOptions(BrowserType browserType)
//         {
//                switch (browserType)
//             {
//                 case BrowserType.Chrome:
//                     return new ChromeDriver();
//                 case BrowserType.Firefox:
//                     return new FirefoxDriver();
//                 case BrowserType.Edge:
//                     return new EdgeDriver();
//                 default:
//                     throw new ArgumentOutOfRangeException(nameof(browserType), browserType, null);
//             }



//         }
        
//     }
// }
        
    