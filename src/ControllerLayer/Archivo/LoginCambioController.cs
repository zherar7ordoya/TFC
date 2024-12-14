using AbstractLayer;

using EntityLayer;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ControllerLayer
{
    /// <summary>
    /// Controlador de la vista de cambio de contraseña.
    /// </summary>
    public class LoginCambioController : ControllerCRU<Empleado>
    {
        /// <summary>
        /// El constructor recibe al Form LoginCambioFormulario.
        /// </summary>
        /// <param name="formulario"></param>
        public LoginCambioController(Form formulario)
        {
            LoginCambioFormulario = formulario;
            GenericFactory
                .Instanciar<ControllerException>()
                .ExceptionHandling(() => _empleados = Read());

            AsignarControles();
            AsignarEventos();
        }

        // Estructuras de datos
        private IList<Empleado> _empleados;

        // Componentes
        private readonly Form LoginCambioFormulario;

        private Button GuardarModificacionesButton;
        private CheckBox VerCheckBox;
        private Label CerrarFormLabel;
        private TextBox ContraseñaActualTextBox, ContraseñaNuevaTextBox, UsuarioTextBox;

        //......................................................................

        private void AsignarControles()
        {
            GuardarModificacionesButton = GetControl<Button>("GuardarModificacionesButton");
            VerCheckBox                 = GetControl<CheckBox>("VerCheckBox");
            CerrarFormLabel             = GetControl<Label>("CerrarFormLabel");
            GuardarModificacionesButton = GetControl<Button>("GuardarModificacionesButton");
            UsuarioTextBox              = GetControl<TextBox>("UsuarioTextBox");
            ContraseñaActualTextBox     = GetControl<TextBox>("ContraseñaActualTextBox");
            ContraseñaNuevaTextBox      = GetControl<TextBox>("ContraseñaNuevaTextBox");
        }

        private T GetControl<T>(string nombre) where T : Control
        {
            return (T)LoginCambioFormulario.Controls.Find(nombre, true).FirstOrDefault();
        }

        private void AsignarEventos()
        {
            CerrarFormLabel.MouseEnter        += (s, e) => CerrarFormLabel.BackColor = Color.Red;
            CerrarFormLabel.MouseLeave        += (s, e) => CerrarFormLabel.BackColor = Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(128)))), ((int)(((byte)(87)))));
            CerrarFormLabel.Click             += (s, e) => LoginCambioFormulario.Close();
            VerCheckBox.CheckedChanged        += VerCheckBox_CheckedChanged;
            GuardarModificacionesButton.Click += GuardarModificaciones_Click;
        }

        //......................................................................

        private void VerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ContraseñaActualTextBox.PasswordChar = VerCheckBox.Checked ? '\0' : '*';
            ContraseñaNuevaTextBox.PasswordChar  = VerCheckBox.Checked ? '\0' : '*';
        }

        // En caso de refactorizar, guiarse por EmpleadosController.cs
        private void GuardarModificaciones_Click(object sender, EventArgs e)
        {
            var empleado = _empleados.FirstOrDefault(x => x.Usuario == UsuarioTextBox.Text);
            var exito = HacerComprobaciones(empleado);
            if (!exito) return;

            empleado.Contraseña = ContraseñaNuevaTextBox.Text;
            empleado.PalabraSecreta = empleado.PalabraSecreta.Desencriptar();

            if (ValidationService.EsValido(empleado, out List<string> errores))
            {
                empleado.Contraseña = ContraseñaNuevaTextBox.Text.Encriptar();
                empleado.PalabraSecreta = empleado.PalabraSecreta.Encriptar();
                empleado.ContraseñasPasadas.Add(ContraseñaActualTextBox.Text);
                empleado.ContraseñaFecha = DateTime.Now;

                GenericFactory
                .Instanciar<ControllerException>()
                .ExceptionHandling(() =>
                {
                    exito = Update(empleado);

                    if (exito)
                    {
                        MessageBoxService.Exito(
                            "Contraseña actualizada correctamente.\n" +
                            "Ingrese sus nuevas credenciales.");
                        LoginCambioFormulario.Close();
                    }
                    else
                    {
                        MessageBoxService.Error(
                            "Error al actualizar la contraseña.\n" +
                            "Intente nuevamente.");
                    }
                });
            }
            else
            {
                MessageBoxService.Error(
                    "Error al actualizar la contraseña.\n" +
                    "Corrija los siguientes errores:\n" +
                    string.Join("\n", errores));
            }
        }

        private bool HacerComprobaciones(Empleado empleado)
        {
            if (empleado == null)
            {
                MessageBoxService.Error(
                    "Usuario no encontrado.\n" +
                    "Intente nuevamente.");
                return false;
            }

            var contraseñaActual = ContraseñaActualTextBox.Text.Encriptar();
            var contraseñaNueva  = ContraseñaNuevaTextBox.Text;

            if (empleado.Contraseña != contraseñaActual)
            {
                MessageBoxService.Error(
                    "Error al actualizar la contraseña.\n" +
                    "La contraseña actual no coincide.");
                return false;
            }

            if (empleado.ContraseñasPasadas.Any(x => x == contraseñaNueva))
            {
                MessageBoxService.Error(
                    "Error al actualizar la contraseña.\n" +
                    "La nueva contraseña no puede ser igual anteriores.");
                return false;
            }

            if (contraseñaNueva.Contains(empleado.DNI.ToString()) ||
                contraseñaNueva.Contains(empleado.Nombre) ||
                contraseñaNueva.Contains(empleado.Apellido) ||
                contraseñaNueva.Contains(empleado.FechaNacimiento.ToString("yyyy")))
            {
                MessageBoxService.Error(
                    "Error al actualizar la contraseña.\n" +
                    "La nueva contraseña no puede contener datos personales:\n" +
                    "DNI, nombre, apellido, o fecha de nacimiento.");
                return false;
            }
            return true;
        }
    }
}
