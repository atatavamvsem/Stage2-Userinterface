using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;

namespace Userinyerface.Forms.Pages
{
    public class MainPage : BaseAppForm
    {
        private IButton NextButton => ElementFactory.GetButton(By.XPath("//a[contains(.,'HERE')]"), "Next");

        public MainPage() : base(By.XPath("//div[@class='start view view--center']"), "Main page")
        {
        }

        public void ClickNextButton()
        {
            NextButton.ClickAndWait();
        }
    }
}
