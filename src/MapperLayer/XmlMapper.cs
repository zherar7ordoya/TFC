using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace MapperLayer
{
    /// <summary>Mapea objetos a XML y viceversa de forma genérica, incluyendo soporte para propiedades complejas y colecciones.</summary>
    /// <typeparam name="T">El tipo de objeto que será mapeado.</typeparam>
    [Obsolete("Usar CRU de la capa DataManager.")]
    public class XmlMapper<T> where T : class, new()
    {
        /// <summary>Convierte una lista de objetos a una representación XML.</summary>
        /// <param name="objects">Lista de objetos a serializar en XML.</param>
        /// <returns>Un <see cref="XElement"/> que representa la lista de objetos en formato XML.</returns>
        public XElement MapToXml(List<T> objects)
        {
            XElement rootElement = new XElement(typeof(T).Name + "s");

            foreach (var obj in objects)
            {
                XElement objElement = new XElement(typeof(T).Name);

                foreach (var prop in typeof(T).GetProperties())
                {
                    var value = prop.GetValue(obj);

                    if (value == null) continue;

                    if (prop.PropertyType.IsPrimitive || prop.PropertyType == typeof(string) || prop.PropertyType == typeof(DateTime))
                    {
                        // Mapeo de propiedades simples (primitivas o cadenas).
                        var xmlAttribute = (XmlAttributeAttribute)Attribute.GetCustomAttribute(prop, typeof(XmlAttributeAttribute));
                        if (xmlAttribute != null)
                        {
                            objElement.SetAttributeValue(xmlAttribute.AttributeName ?? prop.Name, value);
                        }
                        else
                        {
                            objElement.Add(new XElement(prop.Name, value));
                        }
                    }
                    else if (typeof(IEnumerable<object>).IsAssignableFrom(prop.PropertyType) && prop.PropertyType != typeof(string))
                    {
                        // Mapeo de colecciones de objetos.
                        var collection = (IEnumerable<object>)value;
                        XElement collectionElement = new XElement(prop.Name);

                        foreach (var item in collection)
                        {
                            XElement itemElement = MapToXmlInternal(item);
                            collectionElement.Add(itemElement);
                        }

                        objElement.Add(collectionElement);
                    }
                    else
                    {
                        // Mapeo de propiedades complejas (objetos).
                        XElement complexElement = MapToXmlInternal(value);
                        complexElement.Name = prop.Name;
                        objElement.Add(complexElement);
                    }
                }

                rootElement.Add(objElement);
            }

            return rootElement;
        }

        /// <summary>Convierte un XML en una lista de objetos.</summary>
        /// <param name="rootElement">El elemento raíz del XML que contiene los datos.</param>
        /// <returns>Una lista de objetos del tipo <typeparamref name="T"/>.</returns>
        public List<T> MapFromXml(XElement rootElement)
        {
            List<T> objects = new List<T>();

            foreach (var element in rootElement.Elements(typeof(T).Name))
            {
                T obj = new T();

                foreach (var prop in typeof(T).GetProperties())
                {
                    if (prop.PropertyType.IsPrimitive || prop.PropertyType == typeof(string) || prop.PropertyType == typeof(DateTime))
                    {
                        // Mapeo de propiedades simples (primitivas o cadenas).
                        var xmlAttribute = (XmlAttributeAttribute)Attribute.GetCustomAttribute(prop, typeof(XmlAttributeAttribute));
                        var value = xmlAttribute != null
                            ? element.Attribute(xmlAttribute.AttributeName ?? prop.Name)?.Value
                            : element.Element(prop.Name)?.Value;

                        if (value != null)
                        {
                            prop.SetValue(obj, Convert.ChangeType(value, prop.PropertyType));
                        }
                    }
                    else if (typeof(IEnumerable<object>).IsAssignableFrom(prop.PropertyType) && prop.PropertyType != typeof(string))
                    {
                        // Mapeo de colecciones de objetos.
                        var itemType = prop.PropertyType.GetGenericArguments().FirstOrDefault();
                        if (itemType != null)
                        {
                            var collectionElement = element.Element(prop.Name);
                            if (collectionElement != null)
                            {
                                var listType = typeof(List<>).MakeGenericType(itemType);
                                var list = (IList<object>)Activator.CreateInstance(listType);

                                foreach (var itemElement in collectionElement.Elements(itemType.Name))
                                {
                                    var item = MapFromXmlInternal(itemType, itemElement);
                                    list.Add(item);
                                }

                                prop.SetValue(obj, list);
                            }
                        }
                    }
                    else
                    {
                        // Mapeo de propiedades complejas (objetos).
                        var complexElement = element.Element(prop.Name);
                        if (complexElement != null)
                        {
                            var complexValue = MapFromXmlInternal(prop.PropertyType, complexElement);
                            prop.SetValue(obj, complexValue);
                        }
                    }
                }

                objects.Add(obj);
            }

            return objects;
        }

        /// <summary>Método auxiliar para convertir un objeto a un <see cref="XElement"/>.</summary>
        /// <param name="obj">El objeto a convertir.</param>
        /// <returns>Un <see cref="XElement"/> que representa el objeto.</returns>
        private XElement MapToXmlInternal(object obj)
        {
            XElement objElement = new XElement(obj.GetType().Name);

            foreach (var prop in obj.GetType().GetProperties())
            {
                var value = prop.GetValue(obj);
                if (value == null) continue;

                if (prop.PropertyType.IsPrimitive || prop.PropertyType == typeof(string) || prop.PropertyType == typeof(DateTime))
                {
                    objElement.Add(new XElement(prop.Name, value));
                }
                else if (typeof(IEnumerable<object>).IsAssignableFrom(prop.PropertyType) && prop.PropertyType != typeof(string))
                {
                    XElement collectionElement = new XElement(prop.Name);

                    foreach (var item in (IEnumerable<object>)value)
                    {
                        collectionElement.Add(MapToXmlInternal(item));
                    }

                    objElement.Add(collectionElement);
                }
                else
                {
                    XElement complexElement = MapToXmlInternal(value);
                    objElement.Add(complexElement);
                }
            }

            return objElement;
        }

        /// <summary>Método auxiliar para convertir un <see cref="XElement"/> en un objeto.</summary>
        /// <param name="type">El tipo del objeto a crear.</param>
        /// <param name="element">El <see cref="XElement"/> que contiene los datos.</param>
        /// <returns>El objeto creado a partir del XML.</returns>
        private object MapFromXmlInternal(Type type, XElement element)
        {
            var obj = Activator.CreateInstance(type);

            foreach (var prop in type.GetProperties())
            {
                if (prop.PropertyType.IsPrimitive || prop.PropertyType == typeof(string) || prop.PropertyType == typeof(DateTime))
                {
                    var value = element.Element(prop.Name)?.Value;
                    if (value != null)
                    {
                        prop.SetValue(obj, Convert.ChangeType(value, prop.PropertyType));
                    }
                }
                else if (typeof(IEnumerable<object>).IsAssignableFrom(prop.PropertyType) && prop.PropertyType != typeof(string))
                {
                    var itemType = prop.PropertyType.GetGenericArguments().FirstOrDefault();
                    if (itemType != null)
                    {
                        var collectionElement = element.Element(prop.Name);
                        if (collectionElement != null)
                        {
                            var listType = typeof(List<>).MakeGenericType(itemType);
                            var list = (IList<object>)Activator.CreateInstance(listType);

                            foreach (var itemElement in collectionElement.Elements(itemType.Name))
                            {
                                var item = MapFromXmlInternal(itemType, itemElement);
                                list.Add(item);
                            }

                            prop.SetValue(obj, list);
                        }
                    }
                }
                else
                {
                    var complexElement = element.Element(prop.Name);
                    if (complexElement != null)
                    {
                        var complexValue = MapFromXmlInternal(prop.PropertyType, complexElement);
                        prop.SetValue(obj, complexValue);
                    }
                }
            }

            return obj;
        }
    }
}
