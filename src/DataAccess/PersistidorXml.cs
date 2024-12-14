using AbstractLayer;

using MapperLayer;

using ServiceLayer;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;


namespace DataAccess
{
    /// <summary>
    /// Permite leer y escribir datos en archivos XML.
    /// </summary>
    /// <typeparam name="T">Entidad a ser leída/escrita.</typeparam>
    public class PersistidorXml<T> : IPersistidor<T> where T : IEntidadPersistente
    {
        /// <summary>
        /// Constructor por defecto (utiliza la carpeta de datos configurada).
        /// </summary>
        public PersistidorXml() : this(null) { }

        /// <summary>
        /// Constructor que permite especificar la carpeta de datos.
        /// </summary>
        /// <param name="carpeta"></param>
        public PersistidorXml(string carpeta)
        {
            _carpeta = carpeta ?? ConfigurationService.Configuracion.CarpetaData;
        }

        private readonly string _carpeta;

        //......................................................................

        /// <summary>
        /// Lector de la persistencia de datos en formato XML.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="XmlException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="Exception"></exception>
        public IList<T> Leer()
        {
            string archivo = $"{typeof(T).Name}.xml";
            string ruta = Path.Combine(_carpeta, archivo);

            if (!File.Exists(ruta))
            {
                //throw new FileNotFoundException("No se encontró el archivo.", ruta);
                CrearArchivoVacio(ruta);
                return new List<T>(); // Retornar una lista vacía ya que no hay datos
            }

            StreamReader lector = null;

            try
            {
                XmlSerializer serializador = new XmlSerializer(typeof(List<T>));
                lector = new StreamReader(ruta, Encoding.Unicode);
                return (IList<T>)serializador.Deserialize(lector);
            }
            catch (XmlException ex) { throw new XmlException("Se produjo un error al procesar el archivo XML.", ex); }
            catch (IOException ex) { throw new IOException("Se produjo un error al leer el archivo.", ex); }
            catch (Exception ex) { throw new Exception("Se produjo un error al intentar leer los datos.", ex); }
            finally
            {
                if (lector != null)
                {
                    lector.Close();
                    lector.Dispose();
                }
            }
        }

        /// <summary>
        /// Escritor de la persistencia de datos en formato XML.
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        /// <exception cref="XmlException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="Exception"></exception>
        public bool Escribir(IList<T> datos)
        {
            string archivo = $"{typeof(T).Name}.xml";
            string ruta = Path.Combine(_carpeta, archivo);

            try
            {
                // Asegurarse de que la carpeta exista
                if (!Directory.Exists(_carpeta))
                {
                    Directory.CreateDirectory(_carpeta);
                }

                // Crear y escribir el archivo XML
                XmlSerializer serializador = new XmlSerializer(typeof(List<T>));
                using (StreamWriter escritor = new StreamWriter(ruta, false, Encoding.Unicode))
                {
                    serializador.Serialize(escritor, datos);
                }
                return true;
            }
            catch (XmlException ex) { throw new XmlException("Se produjo un error al procesar el archivo XML.", ex); }
            catch (IOException ex) { throw new IOException("Se produjo un error al escribir el archivo.", ex); }
            catch (Exception ex) { throw new Exception("Se produjo un error al intentar escribir los datos.", ex); }
        }

        //..........................................................................

/*
Justificación
    - Dejar de manejar manualmente la creación del archivo.
    - Evitar excepciones innecesarias.
    - Al retornar una lista vacía si no existe el archivo,
      las operaciones posteriores no se ven afectadas.
Este cambio asegura que la clase sea autosuficiente y cumpla con el principio de
robustez en el diseño orientado a objetos.
*/
private void CrearArchivoVacio(string ruta)
{
    try
    {
        XmlSerializer serializador = new XmlSerializer(typeof(List<T>));
        using (StreamWriter escritor = new StreamWriter(ruta, false, Encoding.Unicode))
        {
            serializador.Serialize(escritor, new List<T>());
        }
    }
    catch (Exception ex)
    {
        throw new Exception("Se produjo un error al intentar crear el archivo XML.", ex);
    }
}
}

}
