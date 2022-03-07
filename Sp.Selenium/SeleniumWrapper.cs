using CefSharp;
using CefSharp.WinForms;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Sp.Selenium
{
    public class SeleniumWrapper
    {
        
        public void TakeSnapshot1()
        {
            ChromiumWebBrowser browser = null;
            FirefoxDriver driver = null;
            try
            {
                FirefoxOptions options = new FirefoxOptions();
                options.SetPreference("security.sandbox.content.level", 5);
                driver = new FirefoxDriver(options);
                driver.Manage().Window.Size = new Size(800, 600);
                driver.Navigate().GoToUrl(string.Format("file:///{0}", @"C:\Users\arafats\source\repos\ConsoleApp1\ConsoleApp1\bin\Debug\netcoreapp3.1\Video_Clip_HTML_Test\index.html"));
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("Test.png", ScreenshotImageFormat.Png);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /*
        private void TakeSnapshot(IWebDriver driver, ChromiumWebBrowser vBrowser, string imageFileExtention, int index, string inputArea, Point location, string snapshotFolderPath, int areaWidth, int areaHeight, ImageFormat imageFormat)
        {
            Bitmap bitmap = null;

            if (!string.IsNullOrEmpty(inputArea))
            {
                Screenshot sc = ((ITakesScreenshot)driver).GetScreenshot();
                bitmap = Image.FromStream(new MemoryStream(sc.AsByteArray)) as Bitmap;
            }
            else
            {
                bitmap = vBrowser.ScreenshotAsync().Result;
            }

            bitmap = Transparent2Color(bitmap, Color.White);

            string fileName = string.Format(imageFileExtention, index);

            if (!string.IsNullOrEmpty(inputArea))
            {
                RectangleF part = new RectangleF(location.X, location.Y, areaWidth, areaHeight);

                using (Bitmap bn = bitmap.Clone(part, bitmap.PixelFormat))
                {
                    bn.Save(Path.Combine(snapshotFolderPath, fileName), imageFormat);
                }
            }
            else
            {
                bitmap.Save(Path.Combine(snapshotFolderPath, fileName), imageFormat);
            }
        }
        */
        public void Test()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.SetPreference("security.sandbox.content.level", 5);
            options.BrowserExecutableLocation = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
            IWebDriver driver = new FirefoxDriver(options);
            driver.Url = string.Format("file:///{0}", @"C:\Users\arafats\OneDrive - WPP Cloud\Documents\Video_Clip_HTML_Test\index.html");
            for (int i = 0; i < 200; i++)
            {
                var runningTask =Task.Factory.StartNew(() => ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(string.Format(@"Screenshots\Test-{0}.png", i), ScreenshotImageFormat.Png) );
                //runningTask.RunSynchronously();
                Thread.Sleep(50);
            }            
            //driver.Quit();
        }
    }
}
