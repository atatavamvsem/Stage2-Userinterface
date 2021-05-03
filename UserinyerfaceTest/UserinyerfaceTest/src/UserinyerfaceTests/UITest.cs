using Aquality.Selenium.Browsers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Resources;

namespace UserinyerfaceTest.src.UserinyerfaceTests
{
    internal class UITest
    {
        [SetUp]
        public void Setup()
        {
            AqualityServices.Browser.GoTo(Constants.UrlUserinyerface);
            AqualityServices.Browser.Maximize();
        }

        [TearDown]
        public void CleanUp()
        {
            if (AqualityServices.IsBrowserStarted)
            {
                AqualityServices.Browser.Quit();
            }
        }
    }
}
