using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


/// <summary>
/// Servicio que permite:
/// - Cargar un TreeView a partir de una lista de objetos.
/// - Convertir un TreeView a una lista de objetos.
/// - Obtener el objeto almacenado en el nodo seleccionado.
/// </summary>
public static class TreeViewService
{
    /// <summary>
    /// Carga un TreeView a partir de una lista de objetos.
    /// </summary>
    public static void CargarListaEnTreeView<T>(TreeView treeView, List<T> items)
    {
        treeView.Nodes.Clear();
        foreach (var item in items)
        {
            var rootNode = CrearNodo(item);
            treeView.Nodes.Add(rootNode);
        }
    }

    /// <summary>
    /// Convierte un TreeView a una lista de objetos (asumiendo que los objetos están almacenados en el Tag).
    /// </summary>
    public static List<T> ObtenerListaCargada<T>(TreeView treeView) where T : new()
    {
        return treeView.Nodes
                       .Cast<TreeNode>()
                       .SelectMany(node => ObtenerListaDesdeNodo<T>(node))
                       .ToList();
    }

    /// <summary>
    /// Devuelve el objeto almacenado en el nodo seleccionado, si corresponde al tipo esperado.
    /// </summary>
    public static T ObtenerObjetoSeleccionado<T>(TreeView treeView) where T : class
    {
        return treeView.SelectedNode?.Tag as T;
    }

    //..........................................................................

    /// <summary>
    /// Mapea un objeto a un TreeNode.
    /// </summary>
    private static TreeNode CrearNodo<T>(T item)
    {
        if (item == null) return null;

        var node = new TreeNode(item.ToString()) { Tag = item };

        foreach (var property in typeof(T).GetProperties())
        {
            var value = property.GetValue(item);

            if (value is IList list) // Manejar listas
            {
                var listNode = new TreeNode($"{property.Name} (Lista)");
                foreach (var child in list)
                {
                    var childNode = CrearNodo(child);
                    if (childNode != null)
                        listNode.Nodes.Add(childNode);
                }
                node.Nodes.Add(listNode);
            }
            else if (value != null && value.GetType().IsClass && value.GetType() != typeof(string)) // Manejar objetos únicos
            {
                var childNode = CrearNodo(value);
                if (childNode != null)
                    node.Nodes.Add(new TreeNode(property.Name) { Nodes = { childNode } });
            }
            else if (value != null) // Propiedades simples
            {
                if (value is DateTime dateValue)
                {
                    // Formatear el DateTime para mostrar solo la fecha
                    node.Nodes.Add(new TreeNode($"{property.Name}: {dateValue:dd/MM/yyyy}"));
                }
                else
                {
                    node.Nodes.Add(new TreeNode($"{property.Name}: {value}"));
                }
            }
        }

        return node;
    }

    /// <summary>
    /// Convierte un nodo del TreeView a un objeto.
    /// </summary>
    private static IEnumerable<T> ObtenerListaDesdeNodo<T>(TreeNode node) where T : new()
    {
        var lista = new List<T>();
        var item = ActivarObjetoDesdeNodo<T>(node);

        if (item != null)
        {
            lista.Add(item);

            foreach (TreeNode childNode in node.Nodes)
            {
                lista.AddRange(ObtenerListaDesdeNodo<T>(childNode));
            }
        }

        return lista;
    }

    /// <summary>
    /// Reconstruye un objeto desde un nodo.
    /// </summary>
    private static T ActivarObjetoDesdeNodo<T>(TreeNode node) where T : new()
    {
        var item = new T();

        foreach (var property in typeof(T).GetProperties())
        {
            foreach (TreeNode childNode in node.Nodes)
            {
                if (childNode.Text.StartsWith(property.Name + ":"))
                {
                    var valueText = childNode.Text.Substring(property.Name.Length + 1).Trim();
                    if (property.PropertyType == typeof(string))
                    {
                        property.SetValue(item, valueText);
                    }
                    else if (property.PropertyType == typeof(int) && int.TryParse(valueText, out int intValue))
                    {
                        property.SetValue(item, intValue);
                    }
                    else if (property.PropertyType == typeof(DateTime) && DateTime.TryParse(valueText, out DateTime dateValue))
                    {
                        property.SetValue(item, dateValue);
                    }
                }
            }
        }

        return item;
    }
}
