namespace AbstractLayer
{
    /// <summary>
    /// Enumerador de los distintos permisos (Forms) a los que puede tener acceso un usuario.
    /// </summary>
    public enum PermisoEnum
    {
        // Menú Venta...........................................................

        /// <summary>
        /// Formulario de captura de datos de un cliente para realizar una venta.
        /// </summary>
        CapturadorForm, // 1

        /// <summary>
        /// Formulario de facturación de la venta realizada.
        /// </summary>
        FacturadorForm, // 2

        // Menú Logística.......................................................

        /// <summary>
        /// Formulario de asignaciones de despachos a los choferes.
        /// </summary>
        DespachadorForm, // 3

        /// <summary>
        /// Formulario de liquidación al chofer de comisiones y gastos de viaje.
        /// </summary>
        LiquidadorForm, // 4

        // Menú Gestión.........................................................

        /// <summary>
        /// Formulario de gestión (ABM) de camiones.
        /// </summary>
        CamionesForm, // 5

        /// <summary>
        /// Formulario de gestión (ABM) de clientes.
        /// </summary>
        ClientesForm, // 6

        /// <summary>
        /// Formulario de gestión (ABM) de empleados.
        /// </summary>
        EmpleadosForm, // 7

        /// <summary>
        /// Formulario de gestión (ABM) de locaciones.
        /// </summary>
        LocacionesForm, // 8

        /// <summary>
        /// Formulario de gestión (ABM) de tarifas.
        /// </summary>
        TarifasForm, // 9

        /// <summary>
        /// Formulario de visualización de indicadores de gestión.
        /// </summary>
        DashboardForm, // 10

        // Menú Mantenimiento...................................................

        /// <summary>
        /// Formulario de gestión (ABM) de permisos de los rol.
        /// </summary>
        PermisosForm, // 11

        /// <summary>
        /// Formulario de gestión (ABM) de permisos de usuario.
        /// </summary>
        RolesForm, // 12

        /// <summary>
        /// Formulario de consulta de bitácora de eventos.
        /// </summary>
        BitacoraForm, // 13

        /// <summary>
        /// Formulario para realizar copias de seguridad de la base de datos.
        /// </summary>
        BackupForm, // 14

        /// <summary>
        /// Formulario para restaurar la base de datos desde una copia de seguridad.
        /// </summary>
        RestoreForm, // 15

        /// <summary>
        /// Formulario para configurar los parámetros de la aplicación.
        /// </summary>
        ConfiguracionForm, // 16
    }
}