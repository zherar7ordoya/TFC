using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer;


namespace UnitTests
{
    /// <summary>
    /// Tests para la clase <see cref="XOREncryptionService"/>.
    /// </summary>
    [TestClass]
    public class ContraseñaServiceTests
    {
        /// <summary>
        /// Obtiene o establece el contexto de las pruebas que proporciona.
        /// </summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        /// Prueba que el método <see cref="XOREncryptionService.Encriptar"/> encripta el texto correctamente.
        /// </summary>
        [TestMethod]
        public void Encriptar_Desencriptar_DebeRetornarTextoOriginal()
        {
            // Arrange
            string textoPlano = "vendedor";
            string clave = "3M/Ezs/Oxdg=";

            // Act
            string textoEncriptado = textoPlano.Encriptar();
            string textoDesencriptado = textoEncriptado.Desencriptar();
            string revelado = clave.Desencriptar();

            // Log the encrypted text
            TestContext.WriteLine($"Texto encriptado: {textoEncriptado}");
            TestContext.WriteLine($"Texto desencriptado: {revelado}");

            // Assert
            Assert.AreEqual(textoPlano, textoDesencriptado);
        }
    }
}
