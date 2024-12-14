using AbstractLayer;

using EntityLayer;

using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ServiceLayer
{
    /// <summary>
    /// Servicio que implementa la encriptación SHA256 de hashes.
    /// </summary>
    public class FileHashService
    {
        /// <summary>
        /// El servicio requiere un CRUD de archivos para poder leer y escribir.
        /// </summary>
        /// <param name="crudArchivo"></param>
        public FileHashService(ICRU<Archivo> crudArchivo)
        {
            _crudArchivo = crudArchivo;
            _carpetaData = ConfigurationService.Configuracion.CarpetaData;
        }

        private readonly ICRU<Archivo> _crudArchivo;
        private readonly string _carpetaData;

        //......................................................................

        private string[] ObtenerRutas()
        {
            if (!Directory.Exists(_carpetaData))
            {
                throw new DirectoryNotFoundException($"La carpeta {_carpetaData} no existe.");
            }

            return Directory.GetFiles(_carpetaData, "*.xml");
        }

        /// <summary>
        /// Persiste los hashes de los archivos XML en la carpeta de datos.
        /// </summary>
        /// <returns>Resultado de la operación.</returns>
        public bool RegistrarHashes()
        {
            // Obtener todas las rutas de archivos XML en la carpeta de datos
            string[] rutas = ObtenerRutas();
            // Leer la lista actual de archivos desde el CRUD
            var archivos = _crudArchivo.Read();

            foreach (var ruta in rutas)
            {
                string nombre = Path.GetFileName(ruta);
                string hash = CalcularSHA256(ruta);

                // Verificar si ya existe un archivo con el mismo nombre
                var actualizable = archivos.FirstOrDefault(a => a.Nombre == nombre);

                if (actualizable != null)
                {
                    // Si existe, actualizar el hash y actualizar el archivo en el CRUD
                    actualizable.Hash = hash;
                    actualizable.Fecha = DateTime.Now;
                    _crudArchivo.Update(actualizable);
                }
                else
                {
                    // Si no existe, crear un nuevo archivo con un nuevo Id
                    var nuevo = new Archivo
                    {
                        Fecha = DateTime.Now,
                        Nombre = nombre,
                        Hash = hash
                    };
                    _crudArchivo.Create(nuevo);
                }
            }
            return true;
        }

        /// <summary>
        /// Compara los hashes de los archivos XML en la carpeta de datos con los hashes registrados.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <returns>Resultado de la operación.</returns>
        /// <remarks>
        /// ¿Por qué crear los hashes ante un primer inicio?
        /// </remarks>
        public bool CompararHashes(out string mensaje)
        {
            mensaje = string.Empty;
            var archivos = _crudArchivo.Read();

            // Asume un primer inicio.
            // En el primer inicio (sin hashes previos), generamos un estado base confiable
            // para asegurar la detección de inconsistencias en futuros inicios.
            // Esto maneja escenarios donde la aplicación nunca fue cerrada correctamente.
            if (archivos.Count == 0)
            {
                mensaje = "No se encontraron comprobadores de consistencia.";
                return RegistrarHashes();
            }

            foreach (var archivo in archivos)
            {
                string hashEsperado = archivo.Hash;

                if (hashEsperado == null)
                {
                    mensaje = $"El archivo {archivo.Nombre} no tiene hash.";
                    return false;
                }

                string hashReal = CalcularSHA256(Path.Combine(_carpetaData, archivo.Nombre));

                if (hashReal != hashEsperado)
                {
                    mensaje = $"El archivo {archivo.Nombre} ha sido modificado.";
                    return false;
                }
            }
            mensaje = "Verificación de consistencia de archivos correcta.";
            return true;
        }

        private string CalcularSHA256(string ruta)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                using (FileStream fileStream = File.OpenRead(ruta))
                {
                    byte[] hash = sha256.ComputeHash(fileStream);
                    StringBuilder stringBuilder = new StringBuilder();

                    /* 
                     * ¿De dónde sale "x2"? "x2" proviene de los especificadores
                     * de formato estándar de .NET. Es parte de cómo permite dar
                     * formato a números, cadenas y fechas para convertirlas en
                     * texto.
                     * */
                    foreach (byte x in hash)
                    {
                        stringBuilder.Append(x.ToString("x2"));
                    }
                    return stringBuilder.ToString();
                }
            }
        }
    }
}
