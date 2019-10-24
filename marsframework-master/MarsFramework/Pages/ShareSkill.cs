using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoItX3Lib;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Path for ShareSkill button
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        private IWebElement btnShareSkill { get; set; }
        //Path For Title
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[1]/div[1]/div[2]/div[1]/div[1]/input[1]")]
        private IWebElement txtTitle { get; set; }
        //Path For Description
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[2]/div[1]/div[2]/div[1]/textarea[1]")]
        private IWebElement txtDescription { get; set; }
        //Path For Category dropdown Arrow
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[3]/div[2]/div[1]/div[1]/select[1]")]
        private IWebElement drdArr { get; set; }
        //Path For select SubCategory Arrow
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[3]/div[2]/div[1]/div[2]/div[1]/select[1]")]
        private IWebElement drdSubArr { get; set; }
        //Path For select Tag
        [FindsBy(How = How.XPath, Using = " /html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[4]/div[2]/div[1]/div[1]/div[1]/div[1]/input[1]")]
        private IWebElement txtTag { get; set; }
        //Path For select second Tag
        [FindsBy(How = How.XPath, Using = "  /html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[4]/div[2]/div[1]/div[1]/div[1]/div[1]/input[1]")]
        private IWebElement txtTagsec { get; set; }
        //Path For radio hourlySevice Type
        [FindsBy(How = How.Name, Using = "serviceType")]
        private IList<IWebElement> service { get; set; }
         //Path For Location Type
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[6]/div[2]/div[1]/div[1]/div[1]/input[1]")]
        private IList<IWebElement> location { get; set; }
        //Path For Calendar text
        [FindsBy(How = How.XPath, Using = " /html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[7]/div[2]/div[1]/div[1]/div[4]/input[1]")]
        private IWebElement txtCal { get; set; }
         //Path For Available days checkbox
        [FindsBy(How = How.Name, Using = "Available")]
        private IList<IWebElement> chkDays { get; set; }
        //Path For start time text
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[7]/div[2]/div[1]/div[2]/div[2]/input[1] ")]
        private IWebElement txtStart { get; set; }
        //Path For End time text
        [FindsBy(How = How.XPath, Using = " /html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[7]/div[2]/div[1]/div[2]/div[3]/input[1]")]
        private IWebElement txtEnd { get; set; }
        //Path For radio Skill Trade
        [FindsBy(How = How.Name, Using = "skillTrades")]
        private IList<IWebElement>SkillTrades { get; set; }
        //Path For radio Skill Credit Amount
        [FindsBy(How = How.Name, Using = "charge")]
        private IWebElement txtCredamt { get; set; }
        //Path For radio Skill1 Exchange
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[8]/div[4]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")]
        private IWebElement txtEx1 { get; set; }
        //Path For radio Skill2 Exchange
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[8]/div[4]/div[1]/div[1]/div[1]/div[1]/div[1]/input[1]")]
        private IWebElement txtEx2 { get; set; }
        //Path For Work sample
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[9]/div[1]/div[2]/section[1]/div[1]/label[1]/div[1]/span[1]/i[1]")]
        private IWebElement btnclick { get; set; }
        //Path For Work sample
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[9]/div[1]/div[2]/section[1]/div[1]/input[1]")]
        private IWebElement btnSamp { get; set; }
        //Path For Service
        [FindsBy(How = How.Name, Using = "isActive")]
        private IList<IWebElement> show { get; set; }
        //Path For Save
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[11]/div[1]/input[1]")]
        private IWebElement btnSave { get; set; }


        internal void SaveShareSkill()
        {
            Thread.Sleep(3000);
            //Click the share skill button
            btnShareSkill.Click();
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ShareSkill");
            //Enter Username
            txtTitle.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            //Enter password
            txtDescription.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
             //Selecting Category
            drdArr.Click();
            Thread.Sleep(1000);
            SelectElement SelCategory = new SelectElement(drdArr);
            SelCategory.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));
            //Selecting SubCategory
            drdSubArr.Click();
            Thread.Sleep(1000);
            SelectElement SelsubCategory = new SelectElement(drdSubArr);
            SelsubCategory.SelectByText(GlobalDefinitions.ExcelLib.ReadData(2, "Subcategory"));
            //Entering first tag
            txtTag.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tag1"));
            txtTag.SendKeys(Keys.Enter);
             //Entering second tag
            txtTagsec.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tag2"));
            txtTag.SendKeys(Keys.Enter);

            //Selecting radio buttons for service
            // This will tell you the number of radiobuttons present
            int Size = service.Count;

            // Start the loop from first radiobutton to last radiobutton
            for (int i = 0; i < Size; i++)
            {
                // Store the radiobutton value to the string variable, using 'Value' attribute
                String Value = service.ElementAt(i).GetAttribute("value");

                // Select the radiobutton if the value of the radiobutton is same what you are looking for
                if (Value.Equals(GlobalDefinitions.ExcelLib.ReadData(2, "Service")))
                {
                    service.ElementAt(i).Click();
                    // This will take the execution out of for loop
                    break;
                }
            }

            //Selecting radio buttons for location
            // This will tell you the number of radiobuttons present
            int sizeofLoc = location.Count;

            // Start the loop from first radiobutton to last radiobutton
            for (int i = 0; i < sizeofLoc; i++)
            {
                // Store the checkbox name to the string variable, using 'Value' attribute
                String Value = location.ElementAt(i).GetAttribute("value");

                // Select the radiobutton if the value of the radiobutton is same what you are looking for
                if (Value.Equals(GlobalDefinitions.ExcelLib.ReadData(2, "Location")))
                {
                    service.ElementAt(i).Click();
                    // This will take the execution out of for loop
                    break;
                }
            }
            //Enter EndDate
            txtCal.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "End Date"));
            

            //Selecting checkbox for Available Days
            // This will tell you the number of checkboxes are present
            int sizeofAvail= chkDays.Count;

            // Start the loop from first checkbox to last checkbox
            for (int i = 0; i < sizeofAvail; i++)
            {
                // Store the checkbox name to the string variable, using 'index' attribute
                String availableValue = chkDays.ElementAt(i).GetAttribute("index"); ;

                // Select the checkbox it the index of the checkbox is same what you are looking for
                if (availableValue.Equals(GlobalDefinitions.ExcelLib.ReadData(2, "Days")))
                {
                    chkDays.ElementAt(i).Click();
                    // This will take the execution out of for loop
                    break;
                }
            }
            //Enter start time
            txtStart.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Start Time"));

            //Enter End time
            txtEnd.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "End Time"));
            
            //Selecting radio buttons for Skill trades
            // Tis will tell you the number of radiobuttons present
            int sizeofSkills = SkillTrades.Count;
            String skillValue="";
            // Start the loop from first checkbox to last checkbox
            for (int i = 0; i < sizeofSkills; i++)
            {
                // Store the checkbox name to the string variable, using 'Value' attribute
                 skillValue = SkillTrades.ElementAt(i).GetAttribute("value");

                // Select the checkbox it the value of the checkbox is same what you are looking for
                if (skillValue.Equals(GlobalDefinitions.ExcelLib.ReadData(2, "Skill Trade")))
                {
                    SkillTrades.ElementAt(i).Click();
                    // This will take the execution out of for loop
                    break;
                }
            }
            Thread.Sleep(5000);
          
            //Depending on the option of skill trade we get different dynamic elements
            if(skillValue =="1")
            {
            txtCredamt.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Amount")) ;
           
            }
            else
            {
                txtEx1.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill1"));
                txtEx1.SendKeys(Keys.Enter);
                txtEx2.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Skill2"));
                txtEx1.SendKeys(Keys.Enter);
            }
            //  Attach the work sample using AutoItX3
            //btnclick.Click();
            //Thread.Sleep(1000);
            //AutoItX3 auto = new AutoItX3();
            //auto.ControlFocus("Open", "", "Edit1");
            //Thread.Sleep(3000);
            //auto.ControlSetText("Open", "", "Edit1", @"C:\Users\minna\Documents\REFER.docx");
            //auto.ControlClick("Open", "", "Button1");

            //Selecting radio button for Active or hidden
            // This will tell you the number of radio buttons present
            int sizeofshow = show.Count;
            // Start the loop from first radiobutton to last radiobutton
            for (int i = 0; i < sizeofshow; i++)
            {
                // Store the checkbox name to the string variable, using 'index' attribute
                String showValue = show.ElementAt(i).GetAttribute("value"); ;

                // Select the radiobutton's value and check if it is same what you are looking for
                if (showValue.Equals(GlobalDefinitions.ExcelLib.ReadData(2, "Display")))
                {
                    show.ElementAt(i).Click();
                    // This will take the execution out of for loop
                    break;
                }
            }
            btnSave.Click();
            Thread.Sleep(7000);
            //Validating if the record get added to the service listing
            IWebElement title = GlobalDefinitions.driver.FindElement(By.XPath("//tr[1]//td[3]"));
            string ntext = title.Text;
            if (ntext == "TesterMinna")
            {
                Console.WriteLine("Test Passed");
            }
            else
            {
                Console.WriteLine("test Failed");
            }
            
        }

}
   
}
