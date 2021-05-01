using System;
using Aquality.Selenium.Elements.Interfaces;
using OpenQA.Selenium;
using Resources;
using Utilities;

namespace Userinyerface.Forms.Pages
{ 
    public class InformationPage : BaseAppForm
    {
        private ITextBox NumCards => ElementFactory.GetTextBox(By.XPath("//div[@class='page-indicator']"), "Card");

        private ITextBox PasswordInput => ElementFactory.GetTextBox(By.XPath("//input[contains(@placeholder,'Password')]"), "Password");
        private ITextBox EmailInput => ElementFactory.GetTextBox(By.XPath("//input[contains(@placeholder,'email')]"), "Email");
        private ITextBox DomainInput => ElementFactory.GetTextBox(By.XPath("//input[contains(@placeholder,'Domain')]"), "Domain");

        private IButton Dropdown => ElementFactory.GetButton(By.XPath("//div[contains(@class,'dropdown__opener')]"), "Dropdown");
        private IButton DotOrg => ElementFactory.GetButton(By.XPath("//div[contains(@class,'list-item')][2]"), "DotOrg");
        
        
        
        //не знаю что тут лучше использовать (checkBox или button)
        private IButton AcceptButton => ElementFactory.GetButton(By.XPath("//span[@class='icon icon-check checkbox__check']"), "Accept button");
        private IButton NextButton => ElementFactory.GetButton(By.XPath("//a[contains(text(),'Next')]"), "Next button");

        public InformationPage() : base(By.XPath("//div[@class='game view']"), "Information page")
        {
        }

        public String GetNumCard()
        {        
            return NumCards.GetText();
        }

        public String ParseNumCard()
        {
            String info = NumCards.GetText();
            char ch = ' ';
            int indexOfChar = info.IndexOf(ch);
            info = info.Substring(0, indexOfChar);
            return info;
        }

        public void ClickAcceptButton()
        {
            AcceptButton.ClickAndWait();
        }

        public void ClickNextButton()
        {
            NextButton.ClickAndWait();
        }

        public void ClickDropdown()
        {
            Dropdown.ClickAndWait();
        }

        public void SelectDotOrg()
        {
            DotOrg.ClickAndWait();
        }

        public void TypePassword()
        {
            PasswordInput.ClearAndType(GenerateRandomInput.GeneratePassword(Constants.lengthInput));
        }

        public void TypeEmail()
        {
            EmailInput.ClearAndType(GenerateRandomInput.GenerateEmail(Constants.lengthInput));
        }

        public void TypeDomain()
        {
            DomainInput.ClearAndType(GenerateRandomInput.GenerateDomain(Constants.lengthInput));
        }
    }
}
