using Aquality.Selenium.Browsers;
using Aquality.Selenium.Configurations;
using NUnit.Framework;
using Resources;
using System;
using Userinyerface.Forms.Pages;

namespace UserinyerfaceTests
{
    public class UserinyerfaceTest
    {
        
        [SetUp]
        public void Setup()
        {
            AqualityServices.Browser.GoTo(Constants.UrlUserinyerface);
            //AqualityServices.Browser.Maximize();
        }

        [Test]
        public void UserinyerfaceLogination()
        {
            var mainPage = new MainPage();
            Assert.IsTrue(mainPage.State.IsDisplayed, "It's not main page");
            mainPage.ClickNextButton();

            var infoPage = new InformationPage();
            AqualityServices.Logger.Info(infoPage.GetNumCard());
            //Console.WriteLine(infoPage.GetNumCard());
            infoPage.ClickAcceptButton();
            
            AqualityServices.Logger.Info(infoPage.GetNumCard());
        }

        [TearDown]
        public void CleanUp()
        {
            AqualityServices.Browser.Quit();
        }
    }
}