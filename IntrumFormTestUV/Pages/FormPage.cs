using IntrumFormTestUV.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntrumFormTestUV.Pages
{
    public class FormPage : PageBase
    {
        public static IWebElement CloseFormButton(IWebDriver driver)
        {
            return FindElementByCss(driver, "#slide > button");
        }

        public static IList<IWebElement> FormInputFields(IWebDriver driver)
        {
            return FindElementsByCss(driver, "input.text"); //input fields themselves
        }

        public static IList<IWebElement> FormFieldTextList(IWebDriver driver)
        {
            return FindElementsByCss(driver, "div > div.umbraco-forms-field");//input fields name
        }

        public static IWebElement CommentInputField(IWebDriver driver)
        {
            return FindElementByCss(driver, "div>textarea");
        }

        public static void AnswerDropdownSelectedByValue(IWebDriver driver, string value = "")
        {
            var dropdown = FindElementByCss(driver, "div>select");
            var selectedElement = new SelectElement(dropdown);
            selectedElement.SelectByValue(value);
        }

        public static IWebElement ConfirmButton(IWebDriver driver)
        {
            return FindElementByCss(driver, "div>input.btn");
        }

        public static IList<IWebElement> ValidationErrorList(IWebDriver driver)
        {
            return FindElementsByCss(driver, "span.field-validation-error");
        }

        public static IWebElement MissingLibraryError(IWebDriver driver)
        {
            return FindElementByCss(driver, "div.umbraco-forms.missing-library");
        }

        public static void WaitForMissingLibraryError(IWebDriver driver)
        {
            WebDriverWait w = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            w.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div.umbraco-forms.missing-library")));
        }

        public static void CloseSlide(IWebDriver driver)
        {
            CloseFormButton(driver).Click();
        }
        public static void FillFormWithBadOrMissingData(IWebDriver driver)
        {
            var inputs = FormInputFields(driver).ToList();
            inputs[0].SendKeys(Base.Base.TestConfiguration.badNameSurname);
            inputs[1].SendKeys(Base.Base.TestConfiguration.badPersCode);
            inputs[3].SendKeys(Base.Base.TestConfiguration.badPhoneNumber);
            inputs[4].SendKeys(Base.Base.TestConfiguration.badEmail);
        }
        public static void FillFormWithCorrectData(IWebDriver driver)
        {
            var inputs = FormInputFields(driver).ToList();
            inputs[0].SendKeys(Base.Base.TestConfiguration.goodNameSurname);
            inputs[1].SendKeys(Base.Base.TestConfiguration.goodPersCode);
            inputs[2].SendKeys("something");
            inputs[3].SendKeys(Base.Base.TestConfiguration.goodPhoneNumber);
            inputs[4].SendKeys(Base.Base.TestConfiguration.goodEmail);
            inputs[5].SendKeys(Base.Base.TestConfiguration.address);
            CommentInputField(driver).SendKeys("this is a comment");
            AnswerDropdownSelectedByValue(driver, "E-pasts");
        }

        public static void ClearForm(IWebDriver driver)
        {
            var inputs = FormInputFields(driver).ToList();
            inputs[0].Clear();
            inputs[1].Clear();
            inputs[2].Clear();
            inputs[3].Clear();
            inputs[4].Clear();
            inputs[5].Clear();
            CommentInputField(driver).Clear();
            AnswerDropdownSelectedByValue(driver);//this should clear the dropdown 
        }

        public static List<string> FormInputFieldTextsList(IWebDriver driver)
        {
            var formFieldTexts = Retry.Do(() => FormFieldTextList(driver).ToList().Select(el => el.Text), TimeSpan.FromSeconds(2), 5);//we get text value of the elements
            return formFieldTexts.ToList();
        }
        public static List<IWebElement> FormInputFieldsList(IWebDriver driver)
        {
            var formFieldsList = Retry.Do(() => FormInputFields(driver).ToList(), TimeSpan.FromSeconds(2), 5);
            return formFieldsList;
        }

        public static List<string> ErrorTextsList(IWebDriver driver)
        {
            var validationTexts = Retry.Do(() => ValidationErrorList(driver).ToList().Select(el => el.Text), TimeSpan.FromSeconds(1), 5);
            return validationTexts.ToList();
        }
    }
}
