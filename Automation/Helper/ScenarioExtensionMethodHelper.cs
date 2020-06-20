using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

namespace Automation.Helper
{
    public static class ScenarioExtensionMethodHelper
    {
        public static ExtentTest step = null;

        public static void AddScreenCaptureFromPath(string imageFullFilePath)
        {
            if (step != null)
                step.AddScreenCaptureFromPath(imageFullFilePath);
        }

        public static ExtentTest StepDefinitionGiven(this ExtentTest extent, ScenarioContext scenarioContext)
        {
            step = CreateScenario(extent, StepDefinitionType.Given);
            return step;
        }

        public static ExtentTest StepDefinitionWhen(this ExtentTest extent, ScenarioContext scenarioContext)
        {
            step = CreateScenario(extent, StepDefinitionType.When);
            return step;
        }

        public static ExtentTest StepDefinitionThen(this ExtentTest extent, ScenarioContext scenarioContext)
        {
            step = CreateScenario(extent, StepDefinitionType.Then);
            return step;
        }
        private static ExtentTest CreateScenario(ExtentTest extent, StepDefinitionType stepDefinitionType)
        {
            var stepInfo = ScenarioStepContext.Current.StepInfo;
            var scenarioStepContext = GetStepInfoFormattedText(stepInfo);
            
            switch (stepDefinitionType)
            {
                case StepDefinitionType.Given:
                    return extent.CreateNode<Given>(scenarioStepContext); // cria o node para Given

                case StepDefinitionType.Then:
                    return extent.CreateNode<Then>(scenarioStepContext); // cria o node para Then

                case StepDefinitionType.When:
                    return extent.CreateNode<When>(scenarioStepContext); // cria o node para When
                default:
                    throw new ArgumentOutOfRangeException(nameof(stepDefinitionType), stepDefinitionType, null);
            }
        }

        private static string GetStepInfoFormattedText(StepInfo stepInfo)
        {
            var scenarioStepContext = stepInfo.Text.Replace("<", "&lt;").Replace(">", "&gt;");                       

            return scenarioStepContext;
        }

        public static void UpdateScenario(ScenarioContext scenarioContext, ExtentTest _step)
        {
            var error = scenarioContext.TestError;

            if (scenarioContext.TestError != null && _step != null)
            {
                if (error.InnerException != null)
                    _step.Fail(error.InnerException);
                else
                    _step.Fail(error.Message);
            }
        }
    }
}