using System;
using System.Linq;
using System.Text;
using System.IO;
using EntityLayer;


namespace ServiceLayer
{
    /// <summary>Generador de archivos HTML para documentos de negocio.</summary>
    public static class HtmlGeneratorService
    {
        /// <summary>Genera una cadena HTML para una orden de servicio.</summary>
        /// <param name="transaccion">La transacción contenedora</param>
        /// <returns>Cadena HTML</returns>
        /// <exception cref="ArgumentNullException">Transacción incompleta.</exception>
        public static string GenerarOrden(Transaccion transaccion)
        {
            // Validaciones previas
            if (transaccion == null
                || transaccion.Cliente == null
                || transaccion.Orden == null)
            {
                throw new ArgumentNullException("Transacción incompleta.");
            }

            // Construcción del HTML usando StringBuilder
            var builder = new StringBuilder();
            var configuracion = ConfigurationService.Configuracion;

            string recurso = "Resources/Logo.jpg";
            string base64 = "";

            // Verifica si la carpeta base existe (y si no, se crea).
            if (!Directory.Exists(configuracion.CarpetaDocumentos)) Directory.CreateDirectory(configuracion.CarpetaDocumentos);

            // Convertir la imagen original a Base64.
            if (File.Exists(recurso))
            {
                byte[] bytes = File.ReadAllBytes(recurso);
                base64 = Convert.ToBase64String(bytes);
            }

            // El HTML está escrito como si fuera un archivo independiente (columna cero).
            builder.AppendLine($@"
<!DOCTYPE html>
<html lang='es'>

<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>

    <!-- *** Título de la página *** -->
    <title>Orden de Mudanza {transaccion.Orden.Id:D3}</title>

    <style>
        body {{
            font-family: Arial, sans-serif;
            margin: 20px; /* Reducido para compacidad */
            font-size: 14px; /* Tamaño de texto ligeramente menor */
        }}

        h1 {{
            color: #333;
            margin: 10px 0;
            text-align: center;
        }}

        h2 {{
            color: #555;
        }}

        .documento {{
            border: 1px solid #ddd;
            padding: 15px; /* Compactado */
            max-width: 800px;
            margin: auto;
        }}

        .encabezado {{
            text-align: center;
            margin-bottom: 15px; /* Menos espacio vertical */
        }}

        .encabezado img {{
            max-height: 80px;
        }}

        .informacion, .items {{
            margin-bottom: 15px; /* Espacio uniforme */
        }}

        .informacion p, .items td, .items th {{
            margin: 2px 0; /* Reducido */
        }}

        .items table {{
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }}

        .items th,
        .items td {{
            border: 1px solid #ddd;
            padding: 5px; /* Compacto */
            text-align: left;
        }}

        .items th {{
            background-color: #f2f2f2;
        }}

        .totales {{
            text-align: right;
            margin-top: 10px; /* Espacio ajustado */
            font-size: 16px;
        }}

        ul {{
            margin: 10px 0;
            padding-left: 20px;
        }}
    </style>
</head>

<body>
    <div class='documento'>

        <!-- *** Encabezado *** -->

        <div class='encabezado'>

            <!-- *** Incrustar la imagen como un recurso codificado en Base64 dentro del HTML *** -->
            <img src='data:image/jpeg;base64,{base64}' alt='La Mudadora' style='max-height: 80px;' />
            
            <h1>Orden de Mudanza {transaccion.Orden.Id:D3}</h1>
            <p><strong>Fecha:</strong> {transaccion.Orden.Fecha:ddd dd-MMMM-yyyy}</p>
            <p><strong>Vendedor:</strong> {transaccion.Orden.Operador}</p>
        </div>
        <div class='informacion'>
            <br>
            <h2>«La Mudadora» Empresa de Mudanzas</h2>
            <p><strong>Dirección:</strong> {configuracion.EmpresaDireccion}</p>
            <p><strong>Teléfono:</strong> {configuracion.EmpresaTelefono}</p>
            <p><strong>CUIT:</strong> {configuracion.EmpresaCUIT}</p>
            <p><strong>IVA:</strong> {configuracion.EmpresaCondicionIVA}</p>

            <!-- *** Información del cliente *** -->

            <br>
            <h2>Cliente</h2>");

            if (transaccion.Cliente is PersonaFisica fisica)
            {
                builder.AppendLine($@"
            <p><strong>Nombre:</strong> {fisica.Nombre}</p>
            <p><strong>DNI:</strong> {fisica.DNI}</p>
            <p><strong>Dirección:</strong> {fisica.Direccion}</p>");
            }
            else if (transaccion.Cliente is PersonaJuridica juridica)
            {
                builder.AppendLine($@"
            <p><strong>Razón Social:</strong> {juridica.RazonSocial}</p>
            <p><strong>CUIT:</strong> {juridica.CUIT}</p>
            <p><strong>Dirección:</strong> {juridica.Direccion}</p>");
            }

            builder.AppendLine($@"
            <p><strong>Teléfono:</strong> {transaccion.Cliente.Telefono}</p>
            <p><strong>Email:</strong> {transaccion.Cliente.Email}</p>
            <p><strong>IVA:</strong> {transaccion.Cliente.CondicionFiscal}</p>
            <p><strong>Tarifa:</strong> {transaccion.Cliente.NivelTarifario}</p>");

            builder.AppendLine($@"
        </div>

        <!-- *** Descripción de la mudanza *** -->

        <div class='items'>
            <br>
            <h2>Descripción de la mudanza</h2>
            <table>
                <tr>
                    <th>Fecha de mudanza</th>
                    <td>{transaccion.Orden.FechaMudanza:ddd dd-MMMM-yyyy}</td>
                </tr>
                <tr>
                    <th>Origen</th>
                    <td>{transaccion.Orden.Origen}</td>
                </tr>
                <tr>
                    <th>Destino</th>
                    <td>{transaccion.Orden.Destino}</td>
                </tr>
                <tr>
                    <th>Distancia</th>
                    <td>{transaccion.Orden.Distancia} kilómetros</td>
                </tr>
                <tr>
                    <th>Domicilio de carga</th>
                    <td>{transaccion.Orden.LugarCarga}</td>
                </tr>
                <tr>
                    <th>Domicilio de descarga</th>
                    <td>{transaccion.Orden.LugarDescarga}</td>
                </tr>
                <tr>
                    <th>Observaciones</th>
                    <td>{transaccion.Orden.Observaciones}</td>
                </tr>
            </table>
        </div>

        <!-- *** Inventario de ítems *** -->

        <div class='items'>
            <br>
            <h2>Inventario de ítems</h2>
            <ul>");

            foreach (var item in transaccion.Orden.Items)
            {
                builder.AppendLine($"<li>{item}</li>");
            }

            builder.AppendLine($@"
            </ul>
        </div>

        <!-- *** Firma y Cotización *** -->
        <br>
        <br>
        <table style='width: 100%; margin-top: 30px; text-align: center;'>
            <tr>
                <td>
                    <p>Firma/DNI solicitud conforme</p>
                </td>
                <td>
                    <p>Firma/DNI recibido conforme</p>
                </td>
            </tr>
        </table>

        <br>
        <br>
        <br>
        <br>
        <div class='totales'>
            <h2>Total Cotización: {transaccion.Orden.Cotizacion:C}</h2>
        </div>
    </div>
</body>

</html>");

            return builder.ToString();
        }

        /// <summary>Genera una cadena HTML para una factura de servicio.</summary>
        /// <param name="transaccion">La transacción contenedora</param>
        /// <returns>Cadena HTML</returns>
        /// <exception cref="ArgumentNullException">Transacción incompleta.</exception>
        public static string GenerarFactura(Transaccion transaccion)
        {
            // Validaciones previas
            if (transaccion == null
                || transaccion.Cliente == null
                || transaccion.Orden == null
                || transaccion.Factura == null)
            {
                throw new ArgumentNullException("Transacción incompleta.");
            }

            // Construcción del HTML usando StringBuilder
            var builder = new StringBuilder();
            var configuracion = ConfigurationService.Configuracion;

            string recurso = "Resources/Logo.jpg";
            string base64 = "";

            // Verifica si la carpeta base existe (y si no, se crea).
            if (!Directory.Exists(configuracion.CarpetaDocumentos)) Directory.CreateDirectory(configuracion.CarpetaDocumentos);

            // Convertir la imagen original a Base64.
            if (File.Exists(recurso))
            {
                byte[] bytes = File.ReadAllBytes(recurso);
                base64 = Convert.ToBase64String(bytes);
            }

            builder.AppendLine($@"
<!DOCTYPE html>
<html lang='es'>

<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>

    <!-- *** Título de la página *** -->

    <title>Factura Contado {transaccion.Factura.Id:D3}</title>

    <style>
        body {{
            font-family: Arial, sans-serif;
            margin: 40px;
        }}

        h1 {{
            color: #333;
            text-align: center;
        }}

        h2 {{
            color: #555;
        }}

        .documento {{
            border: 1px solid #ddd;
            padding: 20px;
            max-width: 800px;
            margin: auto;
        }}

        .encabezado {{
            text-align: center;
            margin-bottom: 30px;
        }}

        .encabezado img {{
            max-height: 80px;
        }}

        .informacion {{
            margin-bottom: 30px;
        }}

        .informacion p {{
            margin: 5px 0;
        }}

        .detalle table {{
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }}

        .detalle th, .detalle td {{
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }}

        .detalle th {{
            background-color: #f2f2f2;
        }}

        .totales {{
            text-align: right;
            font-size: 20px;
        }}
    </style>
</head>

<body>
    <div class='documento'>

        <!-- *** ENCABEZADO *** -->

        <div class='encabezado'>

            <!-- *** Incrustar la imagen como un recurso codificado en Base64 dentro del HTML *** -->

            <img src='data:image/jpeg;base64,{base64}' alt='La Mudadora' style='max-height: 80px;' />

            <h1>Factura Contado {transaccion.Factura.Id:D3}</h1>
            <p><strong>Fecha:</strong> {transaccion.Factura.Fecha:ddd dd-MMMM-yyyy}</p>
            <p><strong>Cajero:</strong> {transaccion.Factura.Operador}</p>

        </div>

        <div class='informacion'>
            <br>
            <h2>«La Mudadora» Empresa de Mudanzas</h2>
            <p><strong>Dirección:</strong> {configuracion.EmpresaDireccion}</p>
            <p><strong>Teléfono:</strong> {configuracion.EmpresaTelefono}</p>
            <p><strong>CUIT:</strong> {configuracion.EmpresaCUIT}</p>
            <p><strong>IVA:</strong> {configuracion.EmpresaCondicionIVA}</p>

            <!-- *** CLIENTE *** -->

            <br>
            <h2>Cliente</h2>");

            if (transaccion.Cliente is PersonaFisica fisica)
            {
                builder.AppendLine($@"
            <p><strong>Nombre:</strong> {fisica.Nombre}</p>
            <p><strong>DNI:</strong> {fisica.DNI}</p>
            <p><strong>Dirección:</strong> {fisica.Direccion}</p>");
            }
            else if (transaccion.Cliente is PersonaJuridica juridica)
            {
                builder.AppendLine($@"
            <p><strong>Razón Social:</strong> {juridica.RazonSocial}</p>
            <p><strong>CUIT:</strong> {juridica.CUIT}</p>
            <p><strong>Dirección:</strong> {juridica.Direccion}</p>");
            }

            builder.AppendLine($@"
            <p><strong>Teléfono:</strong> {transaccion.Cliente.Telefono}</p>
            <p><strong>Email:</strong> {transaccion.Cliente.Email}</p>
            <p><strong>IVA:</strong> {transaccion.Cliente.CondicionFiscal}</p>
            <p><strong>Tarifa:</strong> {transaccion.Cliente.NivelTarifario}</p>");

            builder.AppendLine($@"

            <!-- *** TRAZABILIDAD *** -->

            <br><br>
            <table>
                <tr>
                    <td style=""width: 16%;"">ORDEN</td>
                    <td style=""width: 16%;"">{transaccion.Orden.Id}</td>
                </tr>
            </table>
        </div>

        <!-- *** DETALLE *** -->

        <div class='detalle'>
            <h2>Detalle</h2>
            <table>
                <tr>
                    <th>Fecha de mudanza</th>
                    <td>{transaccion.Orden.FechaMudanza:ddd dd-MMMM-yyyy}</td>
                </tr>
                <tr>
                    <th>Origen</th>
                    <td>{transaccion.Orden.Origen}</td>
                </tr>
                <tr>
                    <th>Destino</th>
                    <td>{transaccion.Orden.Destino}</td>
                </tr>
                <tr>
                    <th>Distancia</th>
                    <td>{transaccion.Orden.Distancia} kilómetros</td>
                </tr>
                <tr>
                    <th>Domicilio de carga</th>
                    <td>{transaccion.Orden.LugarCarga}</td>
                </tr>
                <tr>
                    <th>Domicilio de descarga</th>
                    <td>{transaccion.Orden.LugarDescarga}</td>
                </tr>
                <tr>
                    <th>Observaciones</th>
                    <td>{transaccion.Orden.Observaciones}</td>
                </tr>
            </table>
        </div>

        <!-- *** TOTALES *** -->

        <div class='totales'>
            <br><br>
            <table style=""width: 100%;"">
                <tr>
                    <td style=""text-align: left; width: 33%;"">Subtotal</td>
                    <td style=""text-align: left; width: 33%;"">Impuesto</td>
                    <td style=""text-align: right; width: 33%;""><h2>Total</h2></td>
                </tr>
                <tr>
                    <td style=""text-align: left; width: 33%;"">{transaccion.Factura.Subtotal:C}</td>
                    <td style=""text-align: left; width: 33%;"">{transaccion.Factura.Impuesto:C}</td>
                    <td style=""text-align: right; width: 33%;""><h2>{transaccion.Factura.Total:C}</h2></td>
                </tr>
            </table>
        </div>

    </div>
    
</body>

</html>");

            return builder.ToString();
        }

        /// <summary>Genera una cadena HTML para un despacho de servicio.</summary>
        /// <param name="transaccion">La transacción contenedora</param>
        /// <returns>Cadena HTML</returns>
        /// <exception cref="ArgumentNullException">Transacción incompleta.</exception>
        public static string GenerarDespacho(Transaccion transaccion)
        {
            // Validaciones previas
            if (transaccion == null
                || transaccion.Cliente == null
                || transaccion.Orden == null
                || transaccion.Factura == null
                || transaccion.Despacho == null)
            {
                throw new ArgumentNullException("Transacción incompleta.");
            }

            // Construcción del HTML usando StringBuilder
            var builder = new StringBuilder();
            var configuracion = ConfigurationService.Configuracion;

            string recurso = "Resources/Logo.jpg";
            string base64 = "";

            // Verifica si la carpeta base existe (y si no, se crea).
            if (!Directory.Exists(configuracion.CarpetaDocumentos)) Directory.CreateDirectory(configuracion.CarpetaDocumentos);

            // Convertir la imagen original a Base64.
            if (File.Exists(recurso))
            {
                byte[] bytes = File.ReadAllBytes(recurso);
                base64 = Convert.ToBase64String(bytes);
            }

            builder.AppendLine($@"
<!DOCTYPE html>
<html lang='es'>

<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>

    <!-- *** Título de la página *** -->

    <title>Despacho de Servicio {transaccion.Despacho.Id:D3}</title>

    <style>
        body {{
            font-family: Arial, sans-serif;
            margin: 20px;
        }}

        h1, h2 {{
            margin-bottom: 10px;
        }}

        h1 {{
            color: #333;
            text-align: center;
        }}

        h2 {{
            color: #555;
        }}

        .documento {{
            border: 1px solid #aaa;
            padding: 20px;
            max-width: 800px;
            margin: auto;
        }}

        .encabezado {{
            text-align: center;
            margin-bottom: 30px;
        }}

        .encabezado img {{
            max-height: 80px;
        }}

        .informacion {{
            margin-bottom: 30px;
        }}

        .informacion p {{
            margin: 5px 0;
        }}

        .detalle table {{
            width: 100%;
            border-collapse: collapse;
            margin-top: 10px;
        }}

        .detalle th, .detalle td {{
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }}

        .detalle th {{
            background-color: #f9f9f9;
        }}

        .totales {{
            text-align: right;
            font-size: 18px;
            margin-top: 30px;
        }}

        .totales p {{
            margin: 5px 0;
        }}

        .totales p:last-child {{
            margin-top: 15px;
            font-style: italic;
        }}
    </style>
</head>

<body>
    <div class='documento'>

        <!-- *** ENCABEZADO *** -->

        <div class='encabezado'>

            <!-- *** Incrustar la imagen como un recurso codificado en Base64 dentro del HTML *** -->

            <img src='data:image/jpeg;base64,{base64}' alt='La Mudadora' style='max-height: 80px;' />

            <h1>Despacho de Servicio {transaccion.Despacho.Id:D3}</h1>
            <p><strong>Fecha:</strong> {transaccion.Despacho.Fecha:ddd dd-MMMM-yyyy}</p>
            <p><strong>Logístico:</strong> {transaccion.Despacho.Operador}</p>

        </div>

        <div class='informacion'>
            <br>
            <h2>«La Mudadora» Empresa de Mudanzas</h2>
            <p><strong>Dirección:</strong> {configuracion.EmpresaDireccion}</p>
            <p><strong>Teléfono:</strong> {configuracion.EmpresaTelefono}</p>
            <p><strong>CUIT:</strong> {configuracion.EmpresaCUIT}</p>
            <p><strong>IVA:</strong> {configuracion.EmpresaCondicionIVA}</p>

            <!-- *** CLIENTE *** -->

            <br>
            <h2>Cliente</h2>");

            if (transaccion.Cliente is PersonaFisica fisica)
            {
                builder.AppendLine($@"
            <p><strong>Nombre:</strong> {fisica.Nombre}</p>
            <p><strong>DNI:</strong> {fisica.DNI}</p>
            <p><strong>Dirección:</strong> {fisica.Direccion}</p>");
            }
            else if (transaccion.Cliente is PersonaJuridica juridica)
            {
                builder.AppendLine($@"
            <p><strong>Razón Social:</strong> {juridica.RazonSocial}</p>
            <p><strong>CUIT:</strong> {juridica.CUIT}</p>
            <p><strong>Dirección:</strong> {juridica.Direccion}</p>");
            }

            builder.AppendLine($@"
            <p><strong>Teléfono:</strong> {transaccion.Cliente.Telefono}</p>
            <p><strong>Email:</strong> {transaccion.Cliente.Email}</p>
            <p><strong>IVA:</strong> {transaccion.Cliente.CondicionFiscal}</p>
            <p><strong>Tarifa:</strong> {transaccion.Cliente.NivelTarifario}</p>");

            builder.AppendLine($@"

            <!-- *** TRAZABILIDAD *** -->

            <br><br>
            <table>
                <tr>
                    <td style=""width: 16%;"">ORDEN</td>
                    <td style=""width: 16%;"">{transaccion.Orden.Id}</td>
                    <td style=""width: 16%;"">FACTURA</td>
                    <td style=""width: 16%;"">{transaccion.Factura.Id}</td>
                </tr>
            </table>
        </div>

        <!-- *** DETALLE *** -->

        <div class='detalle'>

            <br>
            <h2>Asignaciones</h2>
            <br>
            <strong>Camión</strong>
            <table>
                <tr>
                    <td>Marca</td>
                    <td>Modelo</td>
                    <td>Dominio</td>
                </tr>
                <tr>
                    <td>{transaccion.Despacho.Camion.Marca}</td>
                    <td>{transaccion.Despacho.Camion.Modelo}</td>
                    <td>{transaccion.Despacho.Camion.Dominio}</td>
                </tr>
            </table>

            <br>
            <strong>Chofer</strong>
            <table>
                <tr>
                    <td>DNI</td>
                    <td>Teléfono</td>
                    <td>Nombre</td>
                </tr>
                <tr>
                    <td>{transaccion.Despacho.Chofer.DNI}</td>
                    <td>{transaccion.Despacho.Chofer.Telefono}</td>
                    <td>{transaccion.Despacho.Chofer}</td>
                </tr>
            </table>

            <!-- *** ESTIBADORES *** -->

            <br>
            <strong>Estibadores</strong>
            <table>
                <tr>
                    <td>DNI</td>
                    <td>Teléfono</td>
                    <td>Nombre</td>
                </tr>

                <!-- Recorremos la lista de Estibadores y generamos filas para cada uno -->

                {string.Join(Environment.NewLine, transaccion.Despacho.Estibadores.Select(estibador => $@"
                <tr>
                    <td>{estibador.DNI}</td>
                    <td>{estibador.Telefono}</td>
                    <td>{estibador}</td>
                </tr>"))}
            </table>

            <!-- *** INSUMOS *** -->

            <br>
            <strong>Insumos</strong>
            <table>
                <tr>
                    <td>Descripción</td>
                </tr>

                <!-- Recorremos la lista de Insumos y generamos filas para cada uno -->
                {string.Join(Environment.NewLine, transaccion.Despacho.Insumos.Select(insumo => $@"
                <tr>
                    <td>{insumo}</td>
                </tr>"))}
            </table>

        </div>

        <!-- *** TOTALES *** -->

        <div class='totales'>
            <br>
            <br>
            <p>Firma/DNI recibido conforme</p>
        </div>

    </div>
    
</body>

</html>");

            return builder.ToString();
        }

        /// <summary>Genera una cadena HTML para una liquidación de servicio.</summary>
        /// <param name="transaccion">La transacción contenedora</param>
        /// <returns>Cadena HTML</returns>
        /// <exception cref="ArgumentNullException">Transacción incompleta.</exception>
        public static string GenerarLiquidacion(Transaccion transaccion)
        {
            // Validaciones previas
            if (transaccion == null
                || transaccion.Cliente == null
                || transaccion.Orden == null
                || transaccion.Factura == null
                || transaccion.Despacho == null)
            {
                throw new ArgumentNullException("Transacción incompleta.");
            }

            // Construcción del HTML usando StringBuilder
            var builder = new StringBuilder();
            var configuracion = ConfigurationService.Configuracion;

            string recurso = "Resources/Logo.jpg";
            string base64 = "";

            // Verifica si la carpeta base existe (y si no, se crea).
            if (!Directory.Exists(configuracion.CarpetaDocumentos)) Directory.CreateDirectory(configuracion.CarpetaDocumentos);

            // Convertir la imagen original a Base64.
            if (File.Exists(recurso))
            {
                byte[] bytes = File.ReadAllBytes(recurso);
                base64 = Convert.ToBase64String(bytes);
            }

            builder.AppendLine($@"
<!DOCTYPE html>
<html lang='es'>

<head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>

    <!-- *** Título de la página *** -->

    <title>Liquidación de Comisión y Reembolso {transaccion.Liquidacion.Id:D3}</title>

    <style>
        body {{
            font-family: Arial, sans-serif;
            margin: 20px;
        }}

        h1, h2 {{
            margin-bottom: 10px;
        }}

        h1 {{
            color: #333;
            text-align: center;
        }}

        h2 {{
            color: #555;
        }}

        .documento {{
            border: 1px solid #aaa;
            padding: 20px;
            max-width: 800px;
            margin: auto;
        }}

        .encabezado {{
            text-align: center;
            margin-bottom: 30px;
        }}

        .encabezado img {{
            max-height: 80px;
        }}

        .informacion {{
            margin-bottom: 30px;
        }}

        .informacion p {{
            margin: 5px 0;
        }}

        .detalle table {{
            width: 100%;
            border-collapse: collapse;
            margin-top: 10px;
        }}

        .detalle th, .detalle td {{
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }}

        .detalle th {{
            background-color: #f9f9f9;
        }}

        .totales {{
            text-align: right;
            font-size: 18px;
            margin-top: 30px;
        }}

        .totales p {{
            margin: 5px 0;
        }}

        .totales p:last-child {{
            margin-top: 15px;
            font-style: italic;
        }}
    </style>
</head>

<body>
    <div class='documento'>

        <!-- *** ENCABEZADO *** -->

        <div class='encabezado'>

            <!-- *** Incrustar la imagen como un recurso codificado en Base64 dentro del HTML *** -->

            <img src='data:image/jpeg;base64,{base64}' alt='Logo de la empresa La Mudadora' style='max-height: 80px;' />

            <h1>Liquidación de Comisión y Reembolso {transaccion.Liquidacion.Id:D3}</h1>
            <p><strong>Fecha:</strong> {transaccion.Liquidacion.Fecha:ddd dd-MMMM-yyyy}</p>
            <p><strong>Contable:</strong> {transaccion.Liquidacion.Operador}</p>

        </div>

        <div class='informacion'>
            <br>
            <h2>«La Mudadora» Empresa de Mudanzas</h2>
            <p><strong>Dirección:</strong> {configuracion.EmpresaDireccion}</p>
            <p><strong>Teléfono:</strong> {configuracion.EmpresaTelefono}</p>
            <p><strong>CUIT:</strong> {configuracion.EmpresaCUIT}</p>
            <p><strong>IVA:</strong> {configuracion.EmpresaCondicionIVA}</p>
        </div>");

            builder.AppendLine($@"
         <div class='informacion'>
            <!-- *** TRAZABILIDAD*** -->
            <br><br>
            <table>
                <tr>
                    <td style=""width: 16%;"">ORDEN</td>
                    <td style=""width: 16%;"">{transaccion.Orden.Id}</td>
                    <td style=""width: 16%;"">FACTURA</td>
                    <td style=""width: 16%;"">{transaccion.Factura.Id}</td >
                    <td style=""width: 16%;"">DESPACHO</td>
                    <td style=""width: 16%;"">{transaccion.Despacho.Id}</td>
                </tr>
            </table>
        </div> 

        <!-- *** DETALLE *** -->

        <div class= 'detalle'>

            <!-- *** COMPROBANTES *** -->
            <br>
            <h2>Comprobantes</h2>
            <table>
                <tr>
                    <td>Fecha</td>
                    <td>Número</td>
                    <td>Emisor</td>
                    <td>Concepto</td>
                    <td>Monto</td>
                </tr>

                <!-- Recorremos la lista de comprobantes y generamos filas para cada uno. -->

                {string.Join(Environment.NewLine, transaccion.Liquidacion.Comprobantes.Select(comprobante => $@"
                <tr>
                    <td>{comprobante.Fecha:dd/MMM/yy}</td>
                    <td>{comprobante.Numero}</td>
                    <td>{comprobante.Emisor}</td>
                    <td>{comprobante.Concepto}</td>
                    <td>{comprobante.Monto:C}</td>
                </tr>"))}
            </table>

            <br><br>

            <h2>Totales</h2>
            <table>
                <tr>
                    <td>Concepto</td>
                    <td>Monto</td>
                    <td>Coeficiente</td>
                    <td>Subtotal</td>
                </tr>
                <tr>
                    <td>Comisión sobre orden de servicio</td>
                    <td>{transaccion.Liquidacion.MontoOrden:C}</td>
                    <td>0.10</td>
                    <td>{transaccion.Liquidacion.Comision:C}</td>
                </tr>
                <tr>
                    <td>Reembolso de gastos de tránsito</td>
                    <td>{transaccion.Liquidacion.MontoComprobantes:C}</td>
                    <td>1.00</td>
                    <td>{transaccion.Liquidacion.Reembolso:C}</td>
                </tr>
            </table>

            <br>
            <br>
            <br>
            <br>
            <div class='totales'>
                <h2>Total Liquidación: {transaccion.Liquidacion.TotalLiquidacion:C}</h2>
            </div>
        </div>

    </div>


</body>

</html> ");

            return builder.ToString();
        }

        //......................................................................
    }
}

