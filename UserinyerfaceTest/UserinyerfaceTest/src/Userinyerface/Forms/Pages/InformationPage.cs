using System;
using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;

namespace Userinyerface.Forms.Pages
{ 
    public class InformationPage : BaseAppForm
    {
        private ITextBox NumCards => ElementFactory.GetTextBox(By.XPath("//div[@class='page-indicator']"), "Card");
        //не знаю что тут лучше использовать (checkBox или button)
        private IButton AcceptButton => ElementFactory.GetButton(By.XPath("//span[@class='icon icon-check checkbox__check']"), "Accept button");
        public InformationPage() : base(By.XPath("//div[@class='game view']"), "Information page")
        {
        }

        public String GetNumCard()
        {        
            return NumCards.GetText();
        }

        public void ClickAcceptButton()
        {
            AcceptButton.ClickAndWait();
        }
    }
}
