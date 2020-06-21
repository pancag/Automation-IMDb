using OpenQA.Selenium;
using System;
using Automation.Helper;
using static Automation.DriverFactory.Driver;
using Automation.DSL;
using Automation.Enums;

namespace Automation.Base
{
    public abstract class BasePage
    {
        public DSLIMDb dslIMDb;

        public BasePage()
        {
            dslIMDb = new DSLIMDb();
        }

 
    }
}
