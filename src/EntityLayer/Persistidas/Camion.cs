using AbstractLayer;

namespace EntityLayer
{
    /// <summary>Clase que representa un camión.</summary>
    public class Camion : EntidadPersistente
    {
        /// <summary>Marca del camión.</summary>
        public string Marca { get; set; }

        /// <summary>Modelo del camión.</summary>
        public string Modelo { get; set; }

        /// <summary>Patente del camión.</summary>
        public string Dominio { get; set; }

        /// <summary>Espacio para describir la situación actual del camión.</summary>
        public string Observaciones { get; set; }

        /// <summary>Devuelve una representación en cadena del camión.</summary>
        public override string ToString()
        {
            return $"{Marca} {Modelo} ({Dominio})";
        }
    }
}
