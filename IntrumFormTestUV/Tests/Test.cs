using IntrumFormTestUV.Base;
using IntrumFormTestUV.Helpers;
using IntrumFormTestUV.Pages;
using NLog;
using NUnit.Framework;
using FluentAssertions;
using System;
using System.Linq;
using OpenQA.Selenium;

namespace IntrumFormTestUV.Tests
{
    [Category("FormTests")]
    public class FormTests : TestBase
    {
        //tests ordered, as they will be executed one after another
        [Test, Order(1)]
        public void CheckIfFormOpensUp()
        {
            Logger.Info("-----------------------------------------------------------------------");
            Logger.Info("Starting tests on clicking the \"Contact us\" form button");

            Extras.TryAndCatch(WebDriver, "Check If Form Opens Up", () =>
            {
                Extras.MaximizeWindow(WebDriver);

                Assert.That(ContactUsPage.CookiesPopup(WebDriver).Displayed);

                ContactUsPage.AcceptCookies(WebDriver);//accept all cookies

                ContactUsPage.WaitForFormToOpen(WebDriver); //clicking on the form button and waiting until it is opened

                Assert.True(ContactUsPage.SlideOutForm(WebDriver).Displayed);//checking if the form is opened

                FormPage.CloseSlide(WebDriver);//we close the form (seems to be more reliable afterwards)
            });
        }

        [Test, Order(2)]
        public void CheckIfAllFieldsArePresent()
        {
            Logger.Info("-----------------------------------------------------------------------");
            Logger.Info("Starting test on verifying fields in the Form");
            Extras.TryAndCatch(WebDriver, "Check If All Fields Present", () =>
            {
                ContactUsPage.WaitForFormToOpen(WebDriver);//clicking on the form button and waiting until it is opened
                Assert.True(ContactUsPage.SlideOutForm(WebDriver).Displayed);//checking if the form is opened

                Assert.AreEqual(6, FormPage.FormInputFieldsList(WebDriver).Count); //we check if there are enough elements (according to form)

                foreach (var el in FormPage.FormInputFields(WebDriver))
                {
                    Assert.True(el.Displayed);//we check if elements in the list are displayed
                }

                var testData = new TestData();//creating test data class

                for (var i = 0; i <= 6; i++)
                {
                    testData.formTexts.Should().Contain(FormPage.FormInputFieldTextsList(WebDriver)[i]);//checking if the texts we got from website contain those we actually see there
                };

                FormPage.CloseSlide(WebDriver);//we close the form (seems to be more reliable afterwards)
            });
        }

        [Test, Order(3)]
        public void CheckValidationsMain()
        {
            Logger.Info("-----------------------------------------------------------------------");
            Logger.Info("Starting test on verifying validations in the Form");
            Extras.TryAndCatch(WebDriver, "Check Validations Main", () =>
            {
                ContactUsPage.WaitForFormToOpen(WebDriver);//clicking on the form button and waiting until it is opened
                Assert.True(ContactUsPage.SlideOutForm(WebDriver).Displayed);//checking if the form is opened

                Retry.Do(() => Assert.True(FormPage.ConfirmButton(WebDriver).Displayed), TimeSpan.FromSeconds(1), 5); //we check  if the form is open (trying 10 times, crazy)
                Retry.Do(() => FormPage.ConfirmButton(WebDriver).Click(), TimeSpan.FromSeconds(1), 5);

                Assert.AreEqual(7, FormPage.ErrorTextsList(WebDriver).Count); //we check if there are enough validation texts (according to form)

                foreach (string text in FormPage.ErrorTextsList(WebDriver))
                {
                    Assert.AreEqual("Lūdzu, aizpildiet lauku", text); //we check if texts are correct
                }
            });
        }

        [Test, Order(4)]
        public void CheckSubmittingFormWithCorrectData()
        {
            Logger.Info("-----------------------------------------------------------------------");
            Logger.Info("Starting test on submitting the Form with correct data");
            Extras.TryAndCatch(WebDriver, "Check Submitting Form With Correct Data", () =>
            {
                var testData = new TestData(); //creating new test data
                Retry.Do(() => FormPage.FillFormWithCorrectData(WebDriver), TimeSpan.FromSeconds(1), 5);

                //FormPage.WaitForMissingLibraryError(WebDriver);

                if (FormPage.MissingLibraryError(WebDriver).Displayed)
                {
                    Assert.Fail("bad form, error is displayed, inputs gone");
                }
                else
                {
                    for (var i = 0; i <= 6; i++)
                    {
                        FormPage.FormInputFieldsList(WebDriver)[i].GetAttribute("value").Should().Contain(testData.correctInput[i]); //taking input field submitted value and checking if it got there
                    }
                }
                //FormPage.ConfirmButton(WebDriver).Click();  //this is not used as it will send the form which is not needed.
                //Well. It probably wont get so far as the form will get an error. At least on my machine ¯\_(ツ)_/¯
                FormPage.ClearForm(WebDriver); //usually not needed as this test seems to fail
            });
        }

        [Test, Order(5)]
        public void CheckConsoleErrors()
        {

            //this test will not get to go into action, but it would fail too as there are type errors instead of normal validation
            Logger.Info("-----------------------------------------------------------------------");
            Logger.Info("Starting test on checking console errors in the Form");
            Extras.TryAndCatch(WebDriver, "Check Console Errors", () =>
            {
                FormPage.ClearForm(WebDriver);
                FormPage.FillFormWithBadOrMissingData(WebDriver);//sending bad data or nothing to the form to see what it thinks

                var testData = new TestData(); //creating new test data 
                var jsErrors = WebDriver.Manage().Logs.GetLog(LogType.Browser).Where(x => testData.errorStrings.Any(e => x.Message.Contains(e)));
                if (jsErrors.Any())
                {
                    Assert.Fail("JavaScript error(s):" + jsErrors.Aggregate("", (s, entry) => s + entry.Message));//fails if sees console errors of specified type (borrowed from web)
                }
            });
        }
    }
}
