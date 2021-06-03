using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace TestDoc.StepBindings
{
    [Binding]
    public class AgregarRecetaSteps : IDisposable //Done 50
    {
        private ChromeDriver chromeDriver;
        public AgregarRecetaSteps() => chromeDriver = new ChromeDriver();

        [Given(@"una petición de registro de una receta para una cita")]
        public void GivenUnaPeticionDeRegistroDeUnaRecetaParaUnaCita()
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
        
        [Given(@"teniendo los campos del formulario llenados correctamente")]
        public void GivenTeniendoLosCamposDelFormularioLlenadosCorrectamente()
        {
            chromeDriver.FindElementByName("Frecuencia").SendKeys("8");
            chromeDriver.FindElementByName("Duracion").SendKeys("3");
            System.Threading.Thread.Sleep(5000);
            
        }
        
        [When(@"el usuario haga click en el botón CREAR RECETA")]
        public void WhenElUsuarioHagaClickEnElBotonCREARRECETA()
        {
            chromeDriver.FindElementByName("Guardar").Click();
        }
        
        [Then(@"el sistema ingresará la información de la nueva receta en la base de datos")]
        public void ThenElSistemaIngresaraLaInformacionDeLaNuevaRecetaEnLaBaseDeDatos()
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
