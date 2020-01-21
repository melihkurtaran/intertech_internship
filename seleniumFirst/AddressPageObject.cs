using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Interactions;

namespace seleniumFirst
{
    class AddressPageObject
    {
        public AddressPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        //txt inputs
        [FindsBy(How = How.Id, Using = "fullName")]
        public IWebElement txtFullName { get; set; }

        [FindsBy(How = How.Id, Using = "gsm")]
        public IWebElement phoneNumber { get; set; }

        [FindsBy(How = How.Id, Using = "shippingAddresstcNO")]
        public IWebElement txtTC { get; set; }

        [FindsBy(How = How.Id, Using = "addressName")]
        public IWebElement txtAddressName { get; set; }

        [FindsBy(How = How.Id, Using = "postalCode")]
        public IWebElement postalCode { get; set; }

        [FindsBy(How = How.Id, Using = "addressDetail")]
        public IWebElement txtAddressDetail { get; set; }

        //dropdown inputs
        [FindsBy(How = How.Id, Using = "cityId")]
        public IWebElement ddlCity { get; set; }

        [FindsBy(How = How.Id, Using = "districtId")]
        public IWebElement ddlDistrict { get; set; }

        [FindsBy(How = How.Id, Using = "neighbourhoodId")]
        public IWebElement ddlMahalle { get; set; }

        [FindsBy(How = How.Id, Using = "js-goToPaymentBtn")]
        public IWebElement btnPay { get; set; }

        public void FilltheForm(string fullName, string number, string TC, string addressName, string postalcode, 
            string addressDetail, string city, string district, string mahalle)
        {
            //fullname
            txtFullName.EnterText(fullName);

            //postal code
            postalCode.EnterText(postalcode);

            //city
            ddlCity.SelectDropDown(city);

            //district
            ddlDistrict.SelectDropDown(district);

            //Mahalle
            ddlMahalle.SelectDropDown(mahalle);

            //phone number
            Actions navigator = new Actions(PropertiesCollection.driver);
            navigator.Click(phoneNumber)
                .SendKeys(Keys.End)
                .KeyDown(Keys.Shift)
                .SendKeys(Keys.Home)
                .KeyUp(Keys.Shift)
                .SendKeys(Keys.Backspace)
                .SendKeys(number)
                .Perform();

            //TC
            txtTC.EnterText(TC);

            //addressName
            txtAddressName.EnterText(addressName);

            //address detail
            txtAddressDetail.EnterText(addressDetail);

            //clicks button
            btnPay.Clicks();
        }
    }
}
