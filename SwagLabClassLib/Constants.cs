using Microsoft.VisualBasic;
using System.Security.AccessControl;
using System;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SwagLabClassLib
{
    public  static class Constants
    {
        public static string SwagUrl;
        public static string Browser;
        public static string username;
        public static string password;
        public static string Firstname;
        public static string Lastname;
        public static string Pincode;

        static Constants(){

          var configurationBuilder = new ConfigurationBuilder ();
          configurationBuilder.SetBasePath (Directory.GetCurrentDirectory ());
          configurationBuilder.AddJsonFile (@"C:\RootFolder1\SwagLabsDemoProject\TestData.json", optional : true, reloadOnChange : true);
          IConfigurationRoot configuration = configurationBuilder.Build ();
       SwagUrl = configuration.GetSection ("ApplicationUnderTest:Url").Value;
       Browser = configuration.GetSection ("ApplicationUnderTest:Browser").Value;
       username = configuration.GetSection ("ApplicationUnderTest:username").Value;
       password = configuration.GetSection ("ApplicationUnderTest:password").Value;
       Firstname = configuration.GetSection ("ApplicationUnderTest:FirstName").Value;
       Lastname = configuration.GetSection ("ApplicationUnderTest:LastName").Value;
       Pincode = configuration.GetSection ("ApplicationUnderTest:Pincode").Value;

        
       
        
        }


      //  public static void InitConstants(){

      //     var configurationBuilder = new ConfigurationBuilder ();
      //     configurationBuilder.SetBasePath (Directory.GetCurrentDirectory ());
      //     configurationBuilder.AddJsonFile (@"C:\RootFolder1\SwagLabsDemoProject\TestData.json", optional : true, reloadOnChange : true);
      //     IConfigurationRoot configuration = configurationBuilder.Build ();
      //  SwagUrl = configuration.GetSection ("ApplicationUnderTest:Url").Value;

        
       
        
      //   }
         
      
         
      


        
    }
}