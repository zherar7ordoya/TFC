using System.Xml;
using System.Xml.Serialization;

namespace AbstractLayer
{
    /// <summary>
    /// Implementación abstracta de la interfaz IEntidad a ser heredada por las entidades persistibles del sistema.
    /// </summary>
    public abstract class EntidadPersistente : IEntidadPersistente
    {
        /// <summary>Atributo que representa el identificador único de la entidad.</summary>
        [XmlAttribute("Id")]
        public int Id { get; set; }

        /// <summary>Atributo que representa el estado de bloqueo de la entidad.</summary>

        [XmlAttribute("Bloqueado")]
        public bool Bloqueado { get; set; } = false;

        /// <summary>Atributo que representa el estado de eliminación de la entidad.</summary>
        [XmlAttribute("Eliminado")]
        public bool Eliminado { get; set; } = false;
    }
}
