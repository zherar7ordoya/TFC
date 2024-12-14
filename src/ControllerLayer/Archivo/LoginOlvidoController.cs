using AbstractLayer;

using EntityLayer;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace ControllerLayer
{
    /// <summary>
    /// Controlador de la vista de olvido de contraseña.
    /// </summary>
    public class LoginOlvidoController : ControllerCRU<Empleado>
    {
        /// <summary>
        /// El constructor recibe al Form LoginOlvidoFormulario.
        /// </summary>
        /// <param name="formulario"></param>
        public LoginOlvidoController(Form formulario)
        {
            LoginOlvidoFormulario = formulario;

            GenericFactory
                .Instanciar<ControllerException>()
                .ExceptionHandling(() => _empleados = Read());

            AsignarControles();
            AsignarEventos();
        }

        // Estructuras de datos.
        private IList<Empleado> _empleados;

        // Componentes de la interfaz.
        private readonly Form LoginOlvidoFormulario;
        private Button RecordarContraseñaButton;
        private CheckBox VerCheckBox;
        private Label CerrarFormLabel;
        private TextBox UsuarioTextBox, EmailTextBox, PalabraSecretaTextBox;

        //..................................................................

        private void AsignarControles()
        {
            RecordarContraseñaButton = GetControl<Button>("RecordarContraseñaButton");
            VerCheckBox = GetControl<CheckBox>("VerCheckBox");
            CerrarFormLabel = GetControl<Label>("CerrarFormLabel");
            UsuarioTextBox = GetControl<TextBox>("UsuarioTextBox");
            EmailTextBox = GetControl<TextBox>("EmailTextBox");
            PalabraSecretaTextBox = GetControl<TextBox>("PalabraSecretaTextBox");
        }

        private T GetControl<T>(string nombre) where T : Control
        {
            return (T)LoginOlvidoFormulario.Controls.Find(nombre, true).FirstOrDefault();
        }

        private void AsignarEventos()
        {
            CerrarFormLabel.MouseEnter += (s, e) => CerrarFormLabel.BackColor = Color.Red;
            CerrarFormLabel.MouseLeave += (s, e) => CerrarFormLabel.BackColor = Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(128)))), ((int)(((byte)(87)))));
            CerrarFormLabel.Click += (s, e) => LoginOlvidoFormulario.Close();
            VerCheckBox.CheckedChanged += VerCheckBox_CheckedChanged;
            RecordarContraseñaButton.Click += RecordarContraseñaButton_Click;
        }

        //......................................................................

        private void VerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PalabraSecretaTextBox.PasswordChar = VerCheckBox.Checked ? '\0' : '*';
        }

        private void RecordarContraseñaButton_Click(object sender, EventArgs e)
        {
                var empleado = _empleados.FirstOrDefault(x => x.Usuario == UsuarioTextBox.Text);
                var exito = HacerComprobaciones(empleado);
                if (!exito) return;

                // Crear un archivo de texto con la contraseña.
                var archivo = $"{empleado.Usuario}_restaurado.txt";
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), archivo);

                var contenido =
                $"Estimado/a {empleado.Nombre},\n\n" +
                $"Se ha solicitado la recuperación de su contraseña.\n" +
                $"Su contraseña es: {empleado.Contraseña.Desencriptar()}\n\n" +
                "Por favor, recuerde cambiar su contraseña tras iniciar sesión.\n\n" +
                "Atentamente,\n" +
                "El equipo de soporte.";

                File.WriteAllText(ruta, contenido);
                MessageBoxService.Informar(
                    $"La contraseña ha sido enviada a su casilla de e-mail.\n\n" +
                    $"(Revise en el escritorio el archivo {archivo})");
                LoginOlvidoFormulario.Close();
        }

        private bool HacerComprobaciones(Empleado empleado)
        {
            var email = EmailTextBox.Text;
            var palabraSecreta = PalabraSecretaTextBox.Text;
            var error = "Los datos ingresados no son correctos.";

            if (empleado == null)
            {
                MessageBoxService.Error(error);
                return false;
            }

            if (empleado.Email != email)
            {
                MessageBoxService.Error(error);
                return false;
            }

            if (empleado.PalabraSecreta.Desencriptar() != palabraSecreta)
            {
                MessageBoxService.Error(error);
                return false;
            }

            return true;
        }
    }
}
