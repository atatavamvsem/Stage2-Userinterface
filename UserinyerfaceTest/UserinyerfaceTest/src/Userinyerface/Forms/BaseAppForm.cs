using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace Userinyerface.Forms
{
    public class BaseAppForm : Form
    {
        protected BaseAppForm(By locator, string name) : base(locator, name)
        {
        }
    }
}