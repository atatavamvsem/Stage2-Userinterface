using Aquality.Selenium.Browsers;
using Aquality.Selenium.Configurations;
using NUnit.Framework;
using Resources;
using Userinyerface.Forms.Pages;

namespace UserinyerfaceTests
{
    public class UserinyerfaceTest
    {
        
        [SetUp]
        public void Setup()
        {
            AqualityServices.Browser.GoTo(Constants.UrlUserinyerface);
            AqualityServices.Browser.Maximize();
        }

        [Test]
        public void UserinyerfaceLogination()
        {
            var mainPage = new MainPage();
            Assert.IsTrue(mainPage.State.IsDisplayed, "Slider Form is not opened");
            mainPage.ClickNextButton();
        }

        [TearDown]
        public void CleanUp()
        {
            AqualityServices.Browser.Quit();
        }
    }
}