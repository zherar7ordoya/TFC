using AbstractLayer;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ServiceLayer
{
    /// <summary>
    /// DataGridViewService es una clase estática que provee métodos para trabajar con DataGridViews.
    /// </summary>
    public static class DataGridViewService
    {
        /// <summary>
        /// El motivo de este simulador es que el ListBox de MaterialSkin no
        /// implementa la propiedad DataSource. El ListBox nativo, sí.
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="columnasVisibles"></param>
        public static void SimularListbox(DataGridView dgv, params string[] columnasVisibles)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.Visible = columnasVisibles.Contains(column.Name);
            }
            dgv.ColumnHeadersVisible = false;
        }

        /// <summary>
        /// Click <see href="https://stackoverflow.com/a/14441110/14009797"/>
        /// Método que selecciona una fila en un DataGridView incluso si la
        /// columna que se busca está oculta.
        /// 
        /// NOTA
        /// Dado que es un método genérico y que no tengo forma de saber cuáles
        /// columnas estarán ocultas, el método usa un método de fuerza bruta.
        /// Feo, pero eficaz.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dgv"></param>
        /// <param name="item"></param>
        public static void SeleccionarFila<T>(DataGridView dgv, T item) where T : IEntidadPersistente
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (((IEntidadPersistente)row.DataBoundItem).Id == item.Id)
                {
                    int index = row.Index;
                    VisibilizarFila(dgv, index);

                    for (int x = 0; x < row.Cells.Count; x++)
                    {
                        try
                        {
                            dgv.CurrentCell = dgv.Rows[index].Cells[x];
                        }
                        // TODO: Algún día, mejorar este mecanismo.
                        catch (InvalidOperationException) { continue; }
                    }

                    break;
                }
            }
        }

        /// <summary>
        /// Click <see href="https://stackoverflow.com/a/35146824/14009797"/>
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="index"></param>
        private static void VisibilizarFila(DataGridView dgv, int index)
        {
            if (index >= 0 && index < dgv.RowCount)
            {
                int totalFilasVisibles = dgv.DisplayedRowCount(false);
                int primerFilaVisible = dgv.FirstDisplayedScrollingRowIndex;

                if (index < primerFilaVisible)
                {
                    dgv.FirstDisplayedScrollingRowIndex = index;
                }
                else if (index >= primerFilaVisible + totalFilasVisibles)
                {
                    dgv.FirstDisplayedScrollingRowIndex = index - totalFilasVisibles + 1;
                }
            }
        }
    }
}
