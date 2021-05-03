using NUnit.Framework;
using Resources;
using Userinyerface.Forms.Pages;
using UserinyerfaceTest.src.UserinyerfaceTests;

namespace UserinyerfaceTests
{
    internal class UserinyerfaceTest : UITest
    {
        [Test]
        public void UserinyerfaceLogination()
        {
            CheckStartPageAndMoveNext();

            var infoPage = new InformationPage();
            Assert.AreEqual("1", infoPage.ParseNumCard(), "Wrong card");

            infoPage.TypePassword();
            infoPage.TypeEmail();
            infoPage.TypeDomain();
            infoPage.ClickDropdown();
            infoPage.SelectDotOrg();
            infoPage.ClickAcceptButton();
            infoPage.ClickNextButton();
            Assert.AreEqual("2", infoPage.ParseNumCard(), "Wrong card");

            infoPage.UnselectAllInterests();
            infoPage.ClickRandomInterests(Constants.needingInterests);

            
            infoPage.UploadImage();
            infoPage.ClickNextButton();
            Assert.AreEqual("3", infoPage.ParseNumCard(), "Wrong card");
        }

        [Test]
        public void HelpHidden()
        {
            CheckStartPageAndMoveNext();

            var infoPage = new InformationPage();
            Assert.IsTrue(infoPage.HelpFormIsDisplayed(), "Element not displayed");

            infoPage.ClickHideHelp();
            Assert.IsFalse(infoPage.HelpFormIsDisplayed(), "Element displayed");
        }

        [Test]
        public void AcceptCookie()
        {
            CheckStartPageAndMoveNext();

            var infoPage = new InformationPage();
            Assert.IsTrue(infoPage.AcceptCookieWaitIsDisplayed(), "Form Accept cookie should be displayed");
            infoPage.ClickAcceptButton();
            Assert.IsTrue(infoPage.AcceptCookieIsDisplayed(), "Form Accept cookie should not be displayed");
        }

        [Test]
        public void TimerTest()
        {
            CheckStartPageAndMoveNext();

            var infoPage = new InformationPage();
            Assert.AreEqual(Constants.startTimer, infoPage.GetTimer(), "Wrong timer start");
        }

        private void CheckStartPageAndMoveNext()
        {
            var mainPage = new MainPage();
            Assert.IsTrue(mainPage.State.IsDisplayed, "It's not main page");
            mainPage.ClickNextButton();
        }
    }
}