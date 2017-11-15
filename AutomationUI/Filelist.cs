using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationUI
{
    [TestClass]
    public class Filelist
    {
        private static IWebDriver _driver;

        [AssemblyInitialize]
        public static void Setup(TestContext testContext)
        {
            _driver = new ChromeDriver();
        }

        [TestMethod]
        public void UploadFile()
        {
            _driver.Navigate().GoToUrl("https://filelist.ro/login.php");
            _driver.FindElement(By.Id("username")).SendKeys("Megatron4FL");
            _driver.FindElement(By.Id("password")).SendKeys("Automatica_2008^");
            _driver.FindElement(By.Id("password")).SendKeys(Keys.Enter);

            _driver.Navigate().GoToUrl("https://filelist.ro/upload.php");
            _driver.FindElement(By.Name("name")).SendKeys("abracadabra");
        }
    }
}
