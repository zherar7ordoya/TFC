using AbstractLayer;
using ControllerLayer;
using EntityLayer;
using ServiceLayer;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace ViewLayer
{
    /// <summary>
    /// Formulario de acceso al sistema.
    /// </summary>
    public partial class LoginAccesoForm : Form
    {
        /// <summary>
        /// <see cref="LoginAccesoForm"/>
        /// </summary>
        public LoginAccesoForm()
        {
            InitializeComponent();
            AsignarEventos();
        }

        private void AsignarEventos()
        {
            CerrarFormLabel.Click      += (s, e) => Close();
            CerrarFormLabel.MouseEnter += (s, e) => CerrarFormLabel.BackColor = Color.Red;
            CerrarFormLabel.MouseLeave += (s, e) => CerrarFormLabel.BackColor = Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(128)))), ((int)(((byte)(87)))));
            ModificarButton.Click      += ModificarButton_Click;
            RecordarButton.Click       += RecordarButton_Click;
            VerCheckBox.CheckedChanged += VerCheckBox_CheckedChanged;
            AccederButton.Click        += AccederButton_Click;
        }

        //......................................................................

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            LoginCambioForm formulario = new LoginCambioForm();
            formulario.Show();
            Close();
        }

        private void RecordarButton_Click(object sender, EventArgs e)
        {
            LoginOlvidoForm formulario = new LoginOlvidoForm();
            formulario.Show();
            Close();
        }

        private void VerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ContraseñaTextBox.PasswordChar = VerCheckBox.Checked ? '\0' : '*';
        }

        //......................................................................

        private void AccederButton_Click(object sender, EventArgs e)
        {
            var crudEmpleado = GenericFactory.Instanciar<ControllerCRU<Empleado>>();
            var carpetaBase = ConfigurationService.Configuracion.CarpetaBase;
            var crudBitacora = GenericFactory.Instanciar<ControllerCRU<Bitacora>>(carpetaBase);

            try
            {
                var resultado = GenericFactory.Instanciar<AuthenticationService>(crudEmpleado).Login(UsuarioTextBox.Text, ContraseñaTextBox.Text);

                if (resultado == LoginEnum.LoginValido)
                {
                    GenericFactory.Instanciar<AuditLogService>(crudBitacora).RegistrarLogin(exito: true, resultado);

                    MenuForm formulario = (MenuForm)MdiParent;
                    formulario.AsignarPermisos();
                    Close();
                }
            }
            catch (ExceptionLogin ex)
            {
                GenericFactory.Instanciar<AuditLogService>(crudBitacora).RegistrarLogin(exito: false, ex.Resultado);

                switch (ex.Resultado)
                {
                    case LoginEnum.ContraseñaExpirada:
                        MessageBoxService.Error("La contraseña ha expirado. Por favor, cambie su contraseña.");
                        break;
                    case LoginEnum.ContraseñaNoCoincide:
                        MessageBoxService.Error("La contraseña no coincide. Intente nuevamente.");
                        break;
                    case LoginEnum.UsuarioBloqueado:
                        MessageBoxService.Error("El usuario se encuentra bloqueado. Comuníquese con el administrador.");
                        break;
                    case LoginEnum.UsuarioEliminado:
                        MessageBoxService.Error("El usuario ha sido eliminado. Comuníquese con el administrador.");
                        break;
                    case LoginEnum.UsuarioNoEncontrado:
                        MessageBoxService.Error("El usuario no se encuentra registrado.");
                        break;
                    case LoginEnum.YaExisteSesion:
                        MessageBoxService.Error("Ya existe una sesión activa.");
                        break;
                    default:
                        MessageBoxService.Error("Error desconocido.");
                        break;
                }
            }
        }
    }
}
