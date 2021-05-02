using System;
using System.Collections.Generic;
using System.Threading;
using Aquality.Selenium.Browsers;
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

        private IButton UnselectAll => ElementFactory.GetButton(By.XPath("//label[@for='interest_unselectall']//span[contains(@class,'_box')]"), "UnselectAll");
        

        private ITextBox Upload => ElementFactory.GetTextBox(By.XPath("//a[contains(@class,'upload-button')]"), "DotOrg");
        
        private ITextBox Avatar => ElementFactory.GetTextBox(By.XPath("//div[contains(@class,'avatar-image')]"), "avatar");
        
        //не знаю что тут лучше использовать (checkBox или button)
        private IButton AcceptButton => ElementFactory.GetButton(By.XPath("//span[@class='icon icon-check checkbox__check']"), "Accept button");

        //не уверен или стоит использовать один элемент для всех кнопок Next
        private IButton NextButton => ElementFactory.GetButton(By.XPath("//*[contains(text(),'Next')]"), "Next button");

        private IButton HideHelpButton => ElementFactory.GetButton(By.XPath("//button[contains(@class,'send-to-bottom')]"), "Hide help button");
        private IElement HelpForm => ElementFactory.GetLabel(By.XPath("//div[@class='help-form']"), "Help form");

        private IButton AcceptCookieButton => ElementFactory.GetButton(By.XPath("//button[contains(text(),'Not')]"), "Accepr cookie button");

        private ITextBox Timer => ElementFactory.GetTextBox(By.XPath("//div[contains(@class,'timer')]"), "Timer");
        
        public InformationPage() : base(By.XPath("//div[@class='game view']"), "Information page")
        {
        }

        public String GetNumCard()
        {        
            return NumCards.GetText();
        }

        //не уверен или стоит это выносить в Utilities (но мысль такая была)
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

        public void ClickHideHelp()
        {
            HideHelpButton.Click();
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

        public Boolean HelpFormIsDisplayed()
        {
            return HelpForm.State.IsDisplayed;
        }

        //не уверен или можно как-то объединить два следующих метода в одну логику
        public Boolean AcceptCookieWaitIsDisplayed()
        {
            return AcceptCookieButton.State.WaitForDisplayed();
        }

        public Boolean AcceptCookieIsDisplayed()
        {
            return AcceptCookieButton.State.IsDisplayed;
        }

        public void ClickAcceptCookie()
        {
            AcceptCookieButton.Click();
        }

        public void UnselectAllInterests()
        {
            UnselectAll.Click();
        }

        public void ClickRandomInterests(int numberInterests)
        {
            //количество всех интересов
            int allInterests = ElementFactory.FindElements<ITextBox>(By.XPath("//span[contains(@class,'_box')]")).Count -1;

            int[] randomArrayInt = GenerateRandomInput.GenerateRandomArrayInt(numberInterests, allInterests);

            for (int i = numberInterests; i>=1; i--)
            {
                ElementFactory.GetButton(By.XPath("(//span[contains(@class,'_box')])[" + randomArrayInt[i-1] + "]"), "Interest").Click();
            }
        }

        public void Send()
        {
            string filePath = @"C:\1.png";
            Avatar.SendKeys(filePath);
        }

        public void UploadClick()
        {
            var browser = AqualityServices.Browser;

            Upload.Click();
 
            IWebElement a = browser.Driver.SwitchTo().ActiveElement();
            a.SendKeys("C:\a.png");
            a.SendKeys("{ENTER}");
        }

        public String GetTimer()
        {
            String time = Timer.GetText();
            return time;
        }
    }
}
