using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;
using MapperLayer;


namespace UnitTests
{
    /// <summary>
    /// Pruebas unitarias para la clase XmlMapper con objetos complejos.
    /// </summary>
    [TestClass]
    public class XmlMapperTests
    {
        /// <summary>Obtiene o establece el contexto de las pruebas que proporciona.</summary>
        public TestContext TestContext { get; set; } // Permite imprimir resultados en la consola de TestContext

        /// <summary>Clase principal para pruebas.</summary>
        public class Empleado
        {
            /// <summary>Obtiene o establece el ID del empleado.</summary>
            public int Id { get; set; }
            /// <summary>Obtiene o establece el nombre del empleado.</summary>
            public string Nombre { get; set; }
            /// <summary>Obtiene o establece el departamento del empleado.</summary>
            public Departamento Departamento { get; set; }
        }

        /// <summary>Clase compleja anidada.</summary>
        public class Departamento
        {
            /// <summary>Obtiene o establece el código del departamento.</summary>
            public int Codigo { get; set; }
            /// <summary>Obtiene o establece el nombre del departamento.</summary>
            public string Nombre { get; set; }
        }

        /// <summary>Prueba que el método <see cref="XmlMapper{T}.MapToXml"/> mapea objetos complejos a XML correctamente.</summary>
        [TestMethod]
        [System.Obsolete]
        public void MapToXml_ComplexObjects_GeneratesCorrectXml()
        {
            // Arrange: Crear una lista de empleados con propiedades complejas
            var empleados = new List<Empleado>
            {
                new Empleado
                {
                    Id = 1,
                    Nombre = "Gerardo",
                    Departamento = new Departamento { Codigo = 101, Nombre = "IT" }
                },
                new Empleado
                {
                    Id = 2,
                    Nombre = "Ana",
                    Departamento = new Departamento { Codigo = 102, Nombre = "HR" }
                }
            };

            var mapper = new XmlMapper<Empleado>();

            // Act: Mapear los empleados a XML
            XElement xml = mapper.MapToXml(empleados);

            // Assert: Asegurarse de que el XML generado sea válido y tenga los datos correctos
            TestContext.WriteLine(xml.ToString()); // Imprimir el XML en el TestContext para inspección visual
            Assert.IsNotNull(xml);
            Assert.AreEqual("Empleados", xml.Name.LocalName);
            Assert.AreEqual(2, xml.Elements("Empleado").Count());
            Assert.AreEqual("IT", xml.Element("Empleado")?.Element("Departamento")?.Element("Nombre")?.Value);
        }
    }
}
