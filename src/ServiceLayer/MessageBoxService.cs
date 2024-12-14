using System.Windows.Forms;

namespace ServiceLayer
{
    /// <summary>
    /// Servicio para mostrar mensajes al usuario.
    /// </summary>
    public static class MessageBoxService
    {
        /// <summary>
        /// Confirma una acción con el usuario.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public static bool Confirmar(string mensaje)
        {
            return MessageBox.Show(mensaje,
                                   "Pregunta",
                                   MessageBoxButtons.YesNo,
                                   MessageBoxIcon.Question) == DialogResult.Yes;
        }

        /// <summary>
        /// Advierte al usuario sobre una acción.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public static DialogResult Advertir(string mensaje)
        {
            return MessageBox.Show(mensaje,
                                   "Advertencia",
                                   MessageBoxButtons.YesNoCancel,
                                   MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Informa al usuario.
        /// </summary>
        /// <param name="mensaje"></param>
        public static void Informar(string mensaje)
        {
            MessageBox.Show(mensaje,
                            "Información",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        /// <summary>
        /// Muestra un mensaje de error al usuario.
        /// </summary>
        /// <param name="mensaje"></param>
        public static void Error(string mensaje)
        {
            MessageBox.Show(mensaje,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }

        /// <summary>
        /// Muestra un mensaje de éxito al usuario.
        /// </summary>
        /// <param name="mensaje"></param>
        public static void Exito(string mensaje)
        {
            MessageBox.Show(mensaje,
                            "Éxito",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

    }
}
