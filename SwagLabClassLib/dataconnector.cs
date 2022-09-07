using Microsoft.VisualBasic;
using System.Security.AccessControl;
using System;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SwagLabClassLib
{
    public class dataconnector
    {   

        public string url;


        public dataconnector(){
         var configurationBuilder = new ConfigurationBuilder ();
          configurationBuilder.SetBasePath (Directory.GetCurrentDirectory ());
          configurationBuilder.AddJsonFile ("TestData.json", optional : true, reloadOnChange : true);
        
          IConfigurationRoot configuration = configurationBuilder.Build ();
    
        url =configuration.GetSection ("ApplicationUnderTest:Url").Value;
    
        }


    }
}