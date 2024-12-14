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
            try
            {
                // Obtener todas las rutas de archivos XML en la carpeta de datos
                string[] rutas = ObtenerRutas();
                var archivos = _crudArchivo.Read();

                // Verificar y marcar como bloqueados los archivos que ya no existen
                foreach (var archivo in archivos.ToList()) // Usamos ToList() para evitar problemas de modificación de colección mientras se recorre
                {
                    string archivoPath = Path.Combine(_carpetaData, archivo.Nombre);
                    if (!File.Exists(archivoPath))
                    {
                        archivo.Bloqueado = true;  // Marcar el archivo como bloqueado
                        _crudArchivo.Update(archivo);  // Actualizar el estado del archivo
                    }
                }

                // Desbloquear archivos que volvieron a existir
                foreach (var ruta in rutas)
                {
                    string nombre = Path.GetFileName(ruta);
                    var archivo = archivos.FirstOrDefault(a => a.Nombre == nombre);

                    // Si el archivo estaba bloqueado, desbloquearlo
                    if (archivo != null && archivo.Bloqueado)
                    {
                        archivo.Bloqueado = false;  // Desbloquear el archivo
                        _crudArchivo.Update(archivo);  // Actualizar el estado del archivo
                    }
                }

                // Filtrar solo los archivos que no están bloqueados
                archivos = _crudArchivo.Read().Where(a => !a.Bloqueado).ToList();

                // Procesar los archivos XML restantes
                foreach (var ruta in rutas)
                {
                    string nombre = Path.GetFileName(ruta);
                    string hash = CalcularSHA256(ruta);

                    var actualizable = archivos.FirstOrDefault(a => a.Nombre == nombre);  // Ya solo consideramos los no bloqueados

                    if (actualizable != null)
                    {
                        // Si existe y no está bloqueado, actualizar el hash y la fecha
                        actualizable.Hash = hash;
                        actualizable.Fecha = DateTime.Now;
                        _crudArchivo.Update(actualizable);
                    }
                    else
                    {
                        // Si no existe, crear un nuevo archivo
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
            catch (Exception ex)
            {
                MessageBoxService.Error("Ocurrió un error al registrar los hashes: " + ex.Message);
                return false;
            }


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

            try
            {
                var archivos = _crudArchivo.Read();

                // Filtrar los archivos bloqueados para solo verificar los activos
                archivos = archivos.Where(a => !a.Bloqueado).ToList();

                // Asume un primer inicio.
                // Si no hay archivos registrados, realizamos el registro de los hashes
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

                    // Calcular el hash real solo si el archivo existe
                    string archivoPath = Path.Combine(_carpetaData, archivo.Nombre);
                    if (File.Exists(archivoPath))
                    {
                        string hashReal = CalcularSHA256(archivoPath);
                        if (hashReal != hashEsperado)
                        {
                            mensaje = $"El archivo {archivo.Nombre} ha sido modificado.";
                            return false;
                        }
                    }
                }

                mensaje = "Verificación de consistencia de archivos correcta.";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = $"Ocurrió un error al comparar los hashes: {ex.Message}";
                return false;
            }

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
