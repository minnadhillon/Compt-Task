using MarsFramework.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;

namespace MarsFramework.Pages
{
    class SignIn
    {
        public SignIn()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }
        //Click on SignIn Link
        [FindsBy(How = How.LinkText, Using = "Sign In")]
        private IWebElement btnSignIn { get; set; }
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")]
        private IWebElement txtUsername { get; set; }
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/input[1]")]
        private IWebElement txtPassword { get; set; }
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[4]/button[1]")]
        private IWebElement btnLogin { get; set; }

    
        #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign')]")]
        private IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        private IWebElement LoginBtn { get; set; }

        #endregion


        internal void LoginSteps()
        {
            
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "SignIn");


            //Navigate to the Url
            GlobalDefinitions.driver.Navigate().GoToUrl(GlobalDefinitions.ExcelLib.ReadData(2, "Url"));

                        
            //Click SignIn
            btnSignIn.Click();
            Thread.Sleep(5000);

            //Enter Username
            txtUsername.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Username"));
            //Enter password
            txtPassword.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Password"));

            
            //Click on Login Button
            btnLogin.Click();
            
           


        }
    }
}