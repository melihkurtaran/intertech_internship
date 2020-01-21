using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace seleniumFirst
{
    class Program
    {

        [SetUp]
        public void Initialize()
        {
            PropertiesCollection.driver = new InternetExplorerDriver();

            //Navigate to n11 page
            PropertiesCollection.driver.Navigate().GoToUrl("http://n11.com");
            Console.WriteLine("Opened URL");

            //maximize the browser screen
            PropertiesCollection.driver.Manage().Window.Maximize();

        }

        [Test]
       public void ExecuteTest()
        {

            //Find the search tab and search for "Iphone 8 Plus"
            IWebElement searchTab = PropertiesCollection.driver.FindElement(By.Id("searchData"));
            SeleniumSetMethods.EnterText(searchTab, "Iphone 8 Plus");

            //Press the search button
            IWebElement searchBtn = PropertiesCollection.driver.FindElement(By.ClassName("searchBtn"));
            SeleniumSetMethods.Clicks(searchBtn);
            PropertiesCollection.driver.Navigate().Forward();

            //declaring action for mouse movements   
            Actions action = new Actions(PropertiesCollection.driver);
           
            //creating array of elements for columns
            IWebElement[] columns = new IWebElement[100];
            PropertiesCollection.driver.FindElements(By.ClassName("pro")).CopyTo(columns,0);

            //js for scrolling
            IJavaScriptExecutor js = (IJavaScriptExecutor)PropertiesCollection.driver;

            //hover the mouse for the first 4 elements
            for (int i = 0; i < 4; i++)
            {
                ((IJavaScriptExecutor)PropertiesCollection.driver).ExecuteScript("arguments[0].scrollIntoView(true);", columns[i]);
                Thread.Sleep(500);
                action.MoveToElement(columns[i]).Perform();            
            }

            //clicks to the 5th element
            SeleniumSetMethods.Clicks(columns[4]);
            PropertiesCollection.driver.Navigate().Forward();

            //clicks "hemen al" button
            IWebElement buyButton = PropertiesCollection.driver.FindElement(By.Id("instantPay"));
            SeleniumSetMethods.Clicks(buyButton);
            PropertiesCollection.driver.Navigate().Forward();

            //clicks "üye olmadan devam et"
            PropertiesCollection.driver.Navigate().GoToUrl("https://www.n11.com/misafir-sepet");

            //enter the e-mail address
            IWebElement txtEmail = PropertiesCollection.driver.FindElement(By.Id("guestEmail"));
            txtEmail.EnterText("iphone_buyer@gmail.com");

            //submit e-mail
            IWebElement btnEmail = PropertiesCollection.driver.FindElement(By.Id("js-guestEmailCheck"));
            SeleniumSetMethods.Clicks(btnEmail);

            //scroll down
            js.ExecuteScript("window.scrollBy(0,400)");

            //fills the form with a function
            AddressPageObject page = new AddressPageObject();
            page.FilltheForm("Mehmet Çakır", "5389467390", "58342398316", "Ev", "34956", 
                "Orta Mah. Üniversite Cad. Orhanlı, Tuzla/İstabul","İstanbul","Tuzla","Orta");

        }

        [TearDown]
        public void CleanUp()
        {
            PropertiesCollection.driver.Close();
            Console.WriteLine("Closed browser");
        }
    }
}
