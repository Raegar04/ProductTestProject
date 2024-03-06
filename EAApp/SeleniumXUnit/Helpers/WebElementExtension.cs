
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework.Helpers
{
    public static class WebElementExtension
    {
        public static void SelectDropDownByText(this IWebElement webElement, string text)
        {
            var select = new SelectElement(webElement);
            select.SelectByText(text);
        }

        public static void SelectDropDownByValue(this IWebElement webElement, string value)
        {
            var select = new SelectElement(webElement);
            select.SelectByText(value.ToString());
        }

        public static void SelectDropDownByValue(this IWebElement webElement, int index)
        {
            var select = new SelectElement(webElement);
            select.SelectByIndex(index);
        }
    }
}
