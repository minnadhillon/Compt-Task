using MarsFramework.Global;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        //Path For Title
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[1]/div[1]/div[2]/div[1]/div[1]/input[1]")]
        private IWebElement txtTitle { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "//tr[1]//td[8]//i[2]")]
        private IWebElement edit { get; set; }

        //Click on Yes 
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[2]/div[1]/div[3]/button[2]")]
        private IWebElement clickYesButton { get; set; }
        

        [FindsBy(How = How.XPath, Using = "//table[@class='ui striped table']//tbody")]
        private IWebElement table { get; set; }

        //Edit function
        internal void ListingsEdit()
        {
            Thread.Sleep(5000);
            manageListingsLink.Click();
            Thread.Sleep(1000);
            edit.Click();
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");
            //Getting title from the excel sheet
            string Title = GlobalDefinitions.ExcelLib.ReadData(2, "Title");
            Thread.Sleep(2000);
            //Validating if the title comes up in the title text box
            if (Title == txtTitle.Text)
            {
                System.Console.WriteLine("Test passed");
            }
            else
            {
                System.Console.WriteLine("Test Failed");
            }

        }

        //Delete function
        internal void ListingsDelete()
        {
            Thread.Sleep(5000);
            manageListingsLink.Click();
            Thread.Sleep(1000);
            IList<IWebElement> rows = new List<IWebElement>(table.FindElements(By.TagName("tr")));
            //Number of rows for the page
            int number = rows.Count();            
            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "ManageListings");
            //Text obtained from each row
            var text = "";
            //Record from the Excel sheet
            string record = GlobalDefinitions.ExcelLib.ReadData(2, "Record");
            for (int i = 1; i <= 2; i++)
            {
                for (int j = 1; j <= number; j++)
                {
                    IWebElement element = Global.GlobalDefinitions.driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/table[1]/tbody[1]/tr[" + j + "]/td[3]"));
                    text = element.Text;
                    if (text == record)
                    {
                        IWebElement del = Global.GlobalDefinitions.driver.FindElement(By.XPath("//tr[" + j + "]//td[8]//i[3]"));
                        del.Click();
                        clickYesButton.Click();
                        Console.WriteLine(text + "has been deleted");
                        bool found=Validate();
                        if (found == true)
                        {
                            Console.WriteLine("Test failed");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Test passed");
                            return;
                        }
                    }
                }
                //Clicking the forward button
                IWebElement button = Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='ui buttons semantic-ui-react-button-pagination']"));
                button.Click();
                Thread.Sleep(2000);
                //Generating the number of rows for the next page
                rows = new List<IWebElement>(table.FindElements(By.TagName("tr")));
                int news = rows.Count();
                //Assigning the new generated row to number in the for loop
                number = news;
            }
            Console.WriteLine("There was no record with the text   " + record);
        }
        //Validating if the deleted record has been removed
        private bool Validate()
        {
            IList<IWebElement> rows = new List<IWebElement>(table.FindElements(By.TagName("tr")));
            int number = rows.Count();
            
            for (int i = 1; i <= 2; i++)
            {
                for (int j = 1; j <= number; j++)
                {
                    Thread.Sleep(5000);
                    IWebElement element = GlobalDefinitions.driver.FindElement(By.XPath("//tr["+j+"]//td[3]"));
                     string text = element.Text;
                     if (text == "TesterMinna")
                    {
                        return true;
                    }
                }
                IWebElement button = Global.GlobalDefinitions.driver.FindElement(By.XPath("//div[@class='ui buttons semantic-ui-react-button-pagination']"));
                button.Click();
                Thread.Sleep(2000);
                rows = new List<IWebElement>(table.FindElements(By.TagName("tr")));
                int news = rows.Count();
                number = news;
            }
            return false;
        }       
    }
}

       



    

    



    

    

    
           


            

        


