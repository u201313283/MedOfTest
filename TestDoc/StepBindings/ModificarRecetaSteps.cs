using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace TestDoc.StepBindings
{
    [Binding]
    public class ModificarRecetaSteps : IDisposable //Done 50
    {
        private ChromeDriver chromeDriver;
        public ModificarRecetaSteps() => chromeDriver = new ChromeDriver();

        [Given(@"una petición de edición de los datos de una receta")]
        public void GivenUnaPeticionDeEdicionDeLosDatosDeUnaReceta()
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
        
        [When(@"cuando el usuario de click en la cita a la que pertenece la receta")]
        public void WhenCuandoElUsuarioDeClickEnLaCitaALaQuePerteneceLaReceta()
        {
            chromeDriver.FindElementByName("Frecuencia").Clear();
            chromeDriver.FindElementByName("Frecuencia").SendKeys("12");
            chromeDriver.FindElementByName("Duracion").SendKeys("3");
            System.Threading.Thread.Sleep(5000);
            chromeDriver.FindElementByName("Guardar").Click();
        }
        
        [Then(@"el sistema verificará que la cita haya finalizado y llenará un formulario modificable con los datos de la receta y detectará que fueron modificados con datos correctos, acto seguido los modificará en la base de datos")]
        public void ThenElSistemaVerificaraQueLaCitaHayaFinalizadoYLlenaraUnFormularioModificableConLosDatosDeLaRecetaYDetectaraQueFueronModificadosConDatosCorrectosActoSeguidoLosModificaraEnLaBaseDeDatos()
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
