using OpenQA.Selenium;

internal class ProgressTakeScreenShot
    {
        private IWebDriver driver;
        private readonly string screenShotsDirectory = @"C:\Users\TsvetanAtanasov\Desktop\InterviewTask\Progress\TestResultsScreenshots";

        public ProgressTakeScreenShot(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void TakeScreenshot(string testCaseName)
        {
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(screenShotsDirectory);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }
                Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                string fileName = Path.Combine(screenShotsDirectory, $"{testCaseName}_{timestamp}.png");
                image.SaveAsFile(fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error taking screenshot: {ex.Message}");
            }
        }   
    }