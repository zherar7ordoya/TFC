using AbstractLayer;
using EntityLayer;
using System;
using System.IO;
using System.IO.Compression;


namespace ServiceLayer
{
    /// <summary>
    /// Servicio para realizar backups y restores de la base de datos.
    /// </summary>
    public class BackupService
    {
        /// <summary>
        /// Constructor que recibe una instancia de CRUD de Bitacora.
        /// </summary>
        /// <param name="crudBitacora"></param>
        public BackupService(ICRU<Bitacora> crudBitacora)
        {
            _crudBitacora = crudBitacora;
        }

        private readonly ICRU<Bitacora> _crudBitacora;
        private static readonly string _carpetaBackup = ConfigurationService.Configuracion.CarpetaBackup;
        private static readonly string _carpetaData = ConfigurationService.Configuracion.CarpetaData;

        //......................................................................

        /// <summary>
        /// Realiza un backup de la base de datos en un archivo ZIP.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="IOException"></exception>
        public Bitacora RealizarBackup()
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string zip = $"{timestamp}.zip";
            string rutaZip = Path.Combine(_carpetaBackup, zip);

            if (!Directory.Exists(_carpetaBackup))
            {
                // Crear el directorio de backup si no existe
                Directory.CreateDirectory(_carpetaBackup);
            }

            if (File.Exists(rutaZip))
            {
                throw new IOException($"El archivo de backup {zip} ya existe. No se puede realizar el backup.");
            }

            // Crear el archivo ZIP
            ZipFile.CreateFromDirectory(_carpetaData, rutaZip, CompressionLevel.Fastest, includeBaseDirectory: false);

            // Registrar el backup en la bitácora
            return GenericFactory.Instanciar<AuditLogService>(_crudBitacora).RegistrarBackup(zip, exito: true);
        }

        /// <summary>
        /// Realiza un restore de la base de datos a partir de un archivo ZIP.
        /// </summary>
        /// <param name="zip"></param>
        /// <returns></returns>
        /// <exception cref="IOException"></exception>
        public Bitacora RealizarRestore(string zip)
        {
            string rutaZip = Path.Combine(_carpetaBackup, zip);
            string rutaData = _carpetaData;

            if (!File.Exists(rutaZip))
            {
                throw new IOException($"El archivo de backup {zip} no existe. No se puede realizar el restore.");
            }

            if (Directory.Exists(rutaData))
            {
                // Eliminar la carpeta de datos actual
                Directory.Delete(rutaData, true);
            }

            // Extraer el contenido del ZIP al directorio de datos
            ZipFile.ExtractToDirectory(rutaZip, rutaData);

            // Registrar el restore en la bitácora
            return GenericFactory.Instanciar<AuditLogService>(_crudBitacora).RegistrarRestore(zip, exito: true);
        }
    }
}  