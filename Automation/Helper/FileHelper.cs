using Automation.Settings;
using OpenQA.Selenium;
using System;
using System.IO;
using static Automation.DriverFactory.Driver;

namespace Automation.Helper
{
    public class FileHelper
    {
        private static readonly string imagesPath = Environment.GetEnvironmentVariable("IMAGES_PATH");
        private static readonly string reportsPath = Environment.GetEnvironmentVariable("REPORTS_PATH");
        private static readonly string imagesExtension = Environment.GetEnvironmentVariable("IMAGES_EXTENSION");

        public static string FullFilePath { get; set; }
        public static readonly string resourcesPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\")) + "Resources\\";


        public static void PrintScreen(string methodName)
        {
            string dirPath = imagesPath + methodName;
            //string dirPath = "../TestPrints/" + methodName;
            FullFilePath = dirPath + "\\" + GetTimeToFileName() + imagesExtension;

            CreateFolder(dirPath);

            ITakesScreenshot camera = GetDriver() as ITakesScreenshot;
            Screenshot foto = camera.GetScreenshot();
            foto.SaveAsFile(FullFilePath, ScreenshotImageFormat.Png);
        }

        private static string GetTimeToFileName()
        {
            return DateTime.Now.ToString("_ddMMyyyy_HHmmss");
        }

        public static void CreateFolder(string dirPath)
        {
            Directory.CreateDirectory(dirPath);
        }

    }
}
