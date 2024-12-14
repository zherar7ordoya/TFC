using EntityLayer;

using MaterialSkin2Framework.Controls;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ServiceLayer
{
    /// <summary>
    /// Servicio que mapea desde un objeto hacia los componentes y viceversa.
    /// </summary>
    public static class ComponentService
    {
        /// <summary>
        /// Mapea los valores de un objeto hacia los controles.
        /// </summary>
        /// <param name="empleado"></param>
        /// <param name="mapeoControles"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void MapearHaciaComponentes(Empleado empleado, Dictionary<string, Control> mapeoControles)
        {
            foreach (var entry in mapeoControles)
            {
                var propiedad = typeof(Empleado).GetProperty(entry.Key);
                if (propiedad == null) continue;

                var valor = propiedad.GetValue(empleado);

                // Asignación de valores a los controles
                switch (entry.Value)
                {
                    case MaterialTextBox2 textBox:
                        textBox.Text = valor?.ToString();
                        break;
                    case MaterialCheckbox checkBox:
                        checkBox.Checked = valor != null && (bool)valor;
                        break;
                    case NumericUpDown numeric:
                        numeric.Value = valor != null ? Convert.ToDecimal(valor) : numeric.Minimum;
                        break;
                    case DateTimePicker dateTimePicker:
                        dateTimePicker.Value = valor != null ? (DateTime)valor : dateTimePicker.MinDate;
                        break;
                    default:
                        throw new InvalidOperationException($"Tipo de control no soportado: {entry.Value.GetType().Name}");
                }
            }
        }

        /// <summary>
        /// Mapea los valores de los controles hacia un objeto.
        /// </summary>
        /// <param name="empleado"></param>
        /// <param name="mapeoControles"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void MapearHaciaObjeto(ref Empleado empleado, Dictionary<string, Control> mapeoControles)
        {
            foreach (var entry in mapeoControles)
            {
                var propiedad = typeof(Empleado).GetProperty(entry.Key);
                if (propiedad == null || !propiedad.CanWrite) continue;

                // Obtención de valores de los controles
                object valor = null;
                switch (entry.Value)
                {
                    case MaterialTextBox2 textBox:
                        valor = Convert.ChangeType(textBox.Text, propiedad.PropertyType);
                        break;

                    case MaterialCheckbox checkBox:
                        valor = checkBox.Checked;
                        break;

                    case NumericUpDown numeric:
                        valor = Convert.ChangeType(numeric.Value, propiedad.PropertyType);
                        break;

                    case DateTimePicker dateTimePicker:
                        valor = dateTimePicker.Value;
                        break;
                    default:
                        throw new InvalidOperationException($"Tipo de control no soportado: {entry.Value.GetType().Name}");
                }

                propiedad.SetValue(empleado, valor);
            }
        }
    }
}
