using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace TestDoc.StepBindings
{
    [Binding]
    public class AgregarDiagnosticoSteps : IDisposable //Done 50
    {
        private ChromeDriver chromeDriver;
        public AgregarDiagnosticoSteps() => chromeDriver = new ChromeDriver();

        [Given(@"una petición de registro de un diagnostico para una cita")]
        public void GivenUnaPeticionDeRegistroDeUnDiagnosticoParaUnaCita()
        {
            //Background :D!
            chromeDriver.Navigate().GoToUrl("http://localhost:8081/");
            chromeDriver.FindElementByName("email").SendKeys("brandonalegriavivanco1998@gmail.com");
            chromeDriver.FindElementByName("password").SendKeys("password");
            chromeDriver.FindElementByName("Login").Click();
            System.Threading.Thread.Sleep(5000);

            //Given
            chromeDriver.FindElementByName("IniciarCita").Click();
        }
        
        [Given(@"teniendo los campos del formulario llenados correctamentes")]
        public void GivenTeniendoLosCamposDelFormularioLlenadosCorrectamentes()
        {
            chromeDriver.FindElementByName("Observacion").SendKeys("Posiblemente tenga covid");
            System.Threading.Thread.Sleep(5000);
        }
        
        [When(@"el usuario haga click en el botón CREAR DIAGNOSTICO")]
        public void WhenElUsuarioHagaClickEnElBotonCREARDIAGNOSTICO()
        {
            chromeDriver.FindElementByName("Guardar").Click();
        }
        
        [Then(@"el sistema ingresará la información del nuevo diagnostico en la base de datos\.")]
        public void ThenElSistemaIngresaraLaInformacionDelNuevoDiagnosticoEnLaBaseDeDatos_()
        {
            Assert.IsTrue(chromeDriver.Url.Contains("citas"));
        }
        public void Dispose()
        {
            if (chromeDriver != null)
            {
                chromeDriver.Dispose();
                chromeDriver = null;
            }
        }
    }
}
