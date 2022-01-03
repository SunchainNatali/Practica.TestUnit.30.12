using System;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;



namespace Ptactica.TestUnit
{
    public class UnitTest1 : BaseTest
    {
       
        
        IWebDriver chrome;
      
        [Fact]
        public void CheckTheButtonToPlaceAnOrderTest()
        {
            chrome = StartDriverWishURL("https://prostor.ua/ru/?gclid=Cj0KCQiAq7COBhC2ARIsANsPATFzmqf5e7ap-odDifldC5jLh4Ti5RNm0c9DIcaH97GU6KbtCztCWusaAo1zEALw_wcB");
            IWebElement poisk = chrome.FindElement(By.LinkText("Акции"));
            poisk.Click();
            IWebElement vvod = chrome.FindElement(By.LinkText("Дом"));
            vvod.Click();
            IWebElement element = chrome.FindElement(By.CssSelector(".catalog-grid__item:nth-child(1) .catalogCard-title > a"));
            element.Click();
            IWebElement bay = chrome.FindElement(By.LinkText("Купить"));
            bay.Click();
            IWebElement korzina = chrome.FindElement(By.LinkText("Оформить заказ"));
            korzina.Click();
            
            string actual = chrome.Url;
            Assert.Equal("https://prostor.ua/ru/checkout/", actual);
        }

        [Fact]
        public void CheckAutorizationSuccessfulTest()
        {
            chrome = StartDriverWishURL("https://allo.ua/ru/?gclid=Cj0KCQiAq7COBhC2ARIsANsPATFx8HKwt1FmrjfLiAGyHAydw7BUMMrDkH9kyTj_DYUiUOs05M6ZpysaAl5pEALw_wcB");
            IWebElement registration = chrome.FindElement(By.CssSelector(".v-icon__user-secondary"));
            registration.Click();
            IWebElement email = chrome.FindElement(By.Id("auth"));
            email.SendKeys("natalinikulina1989@gmail.com");
            IWebElement pasword = chrome.FindElement(By.Id("v-login-password"));
            pasword.SendKeys("82haluli");
            IWebElement enter = chrome.FindElement(By.CssSelector(".modal-submit-button"));
            enter.Click();
            string actual = chrome.Url;
            Assert.Equal("https://allo.ua/ru/?gclid=Cj0KCQiAq7COBhC2ARIsANsPATFx8HKwt1FmrjfLiAGyHAydw7BUMMrDkH9kyTj_DYUiUOs05M6ZpysaAl5pEALw_wcB", actual);            
        }

        [Fact]
        public void CheckForAddingTheQuantutyOfGoods()
        {
            chrome = StartDriverWishURL("https://prostor.ua/ru/");
            IWebElement step1 = chrome.FindElement(By.LinkText("Косметика"));
            step1.Click();
            IWebElement step2 = chrome.FindElement(By.LinkText("Для лица"));
            step2.Click();
            IWebElement step3 = chrome.FindElement(By.CssSelector(".catalog-grid__item:nth-child(1) .catalogCard-img"));
            step3.Click();
            IWebElement step4 = chrome.FindElement(By.LinkText("Купить"));
            step4.Click();
            IWebElement addproduct = chrome.FindElement(By.CssSelector(".icon-plus"));
            addproduct.Click();
            IWebElement amountIncreased = chrome.FindElement(By.CssSelector(".j-sum-p"));
            string actual = amountIncreased.Text; 
            Assert.Equal("160 грн", actual);
           
        }
       
        [Fact]
        public void CheckingTheOperationOfTheCheckBoxForTheFilter()
        {
            chrome = StartDriverWishURL("https://prostor.ua/ru/");
            IWebElement step = chrome.FindElement(By.LinkText("Новогодние цены"));
            step.Click();
            IWebElement step1 = chrome.FindElement(By.XPath("//div[2]/ul/li/a/span/i"));
            step1.Click();
            string actual = chrome.Url;
            Assert.Equal("https://prostor.ua/ru/supertseny/", actual);
        }

        
        [Fact]
        public void CheckingProductSearchDisplay()
        {
            chrome = StartDriverWishURL("https://prostor.ua/ru/");
            IWebElement mail = chrome.FindElement(By.XPath("//input"));
            mail.Click();
            IWebElement element = chrome.FindElement(By.Id("q"));
            element.Click();
            element.SendKeys("MAXI color помада жидкая GLAM MATT lip gloss, 4.5мл");
            element.SendKeys(Keys.Enter);
           // element.Click();
            TimeSpan.MinValue.Milliseconds.CompareTo(10000);
            string actual = chrome.Url;
            Assert.Equal("https://prostor.ua/ru/#/search/MAXI%20color%20%D0%BF%D0%BE%D0%BC%D0%B0%D0%B4%D0%B0%20%D0%B6%D0%B8%D0%B4%D0%BA%D0%B0%D1%8F%20GLAM%20MATT%20lip%20gloss,%204.5%D0%BC%D0%BB", actual);
                      
        }

        [Fact]
        public void CheckingLanguageChangeSite()
        {
            chrome = StartDriverWishURL("https://kasta.ua/uk/");
            IWebElement web = chrome.FindElement(By.CssSelector(".header__lang"));
            web.Click();
            IWebElement web1 = chrome.FindElement(By.LinkText("Русский"));
            web1.Click();
            string actual = chrome.Url;
            Assert.Equal("https://kasta.ua/", actual);
        }

        [Fact]
        public void CheckingThePossibilityOfGoingToTheSectionHM()
        {
            chrome = StartDriverWishURL("https://kasta.ua/uk/");
            IWebElement step1 = chrome.FindElement(By.CssSelector("#up > div.header-container > div > div.dsc > div > a:nth-child(7) > div > div"));
            step1.Click();
            IWebElement step2 = chrome.FindElement(By.CssSelector("#root > div:nth-child(3) > div:nth-child(1) > div.wrapper.light_bg > div:nth-child(2) > div > div:nth-child(3) > div > div > div > a:nth-child(5) > img"));
            step2.Click();
            string actual = chrome.Url;
            Assert.Equal("https://kasta.ua/uk/brand/H%26M/", actual);
        }

        [Fact]
        public void CheckingThePossibilityOfPlacingAnOrder()
        {
            chrome = StartDriverWishURL("https://kasta.ua/uk/");
            IWebElement step1 = chrome.FindElement(By.ClassName("search_input"));
            step1.Click();
            step1.SendKeys("Серое кэжуал платье Yumster");
            step1.SendKeys(Keys.Enter);
            IWebElement step2 = chrome.FindElement(By.ClassName("p__info_name"));
            step2.Click();
            IWebElement step3 = chrome.FindElement(By.CssSelector("#productBuy"));
            step3.Click();
            IWebElement step4 = chrome.FindElement(By.CssSelector(".size_item:nth-child(3)"));
            step4.Click();
            IWebElement step5 = chrome.FindElement(By.LinkText("Оформить заказ"));
            step5.Click();
            TimeSpan.MinValue.Milliseconds.CompareTo(10000);
            string actual = chrome.Url;
            Assert.Equal("https://kasta.ua/checkout/1325015389/", actual);
                      
        }

        [Fact]
        public void CheckingIfAnItemHasBeenAddedToTheCart()
        {
            chrome = StartDriverWishURL("https://kasta.ua/uk/");
            IWebElement step1 = chrome.FindElement(By.LinkText("Кошик"));
            step1.Click();
            IWebElement step2 = chrome.FindElement(By.LinkText("Перейти до покупок"));
            step2.Click();
            IWebElement step3 = chrome.FindElement(By.ClassName("search_input"));
            step3.Click();
            step3.SendKeys("Жіночий наручний годинник Womage Чорний NoName Часи однотонний коричневий");
            step3.SendKeys(Keys.Enter);
            IWebElement step4 = chrome.FindElement(By.CssSelector(".catalog__add-to-cart"));
            step4.Click();
            IWebElement step5 = chrome.FindElement(By.CssSelector(".header_basket-title"));
            step5.Click();
            string actual = chrome.Url;
            Assert.Equal("https://kasta.ua/basket/", actual);
        }

        [Fact]
        public void CheckingLabel()
        {
            chrome = StartDriverWishURL("https://kasta.ua/uk/");
            IWebElement step1 = chrome.FindElement(By.XPath("//a[9]/div/img"));
            step1.Click();
            IWebElement step2 = chrome.FindElement(By.XPath("//div[2]/div/div/div/div/div/a[2]/div/div"));
            step2.Click();
            IWebElement step3 = chrome.FindElement(By.XPath("//div[6]/div/div/label/div/span"));
            step3.Click();
            string actual = chrome.Url;
            Assert.Equal("https://kasta.ua/uk/m/in-trend-tovary/?depot=true&kind=suknya", actual);
           

        }
    }
}
