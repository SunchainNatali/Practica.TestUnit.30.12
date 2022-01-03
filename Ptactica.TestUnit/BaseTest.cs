using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Ptactica.TestUnit
{
    public class BaseTest:IDisposable
    {
        
        private IWebDriver chrome;
       

        public void Dispose()
        {
            chrome.Quit();
           
        }

        public IWebDriver StartDriverWishURL(string url)
        {
            chrome = new ChromeDriver();
            chrome.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            chrome.Navigate().GoToUrl(url);
            return chrome;
           

        }
      
    }
}
