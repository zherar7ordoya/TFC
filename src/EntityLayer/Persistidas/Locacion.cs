using AbstractLayer;

namespace EntityLayer
{
    /// <summary>Una locación.</summary>
    public class Locacion : EntidadPersistente
    {
        /// <summary>El lugar de la locación.</summary>
        public string Lugar { get; set; }

        /// <summary>Eje X de la locación.</summary>
        public int X { get; set; }

        /// <summary>Eje Y de la locación.</summary>
        public int Y { get; set; }

        //......................................................................

        /// <summary>Formato de impresión de la locación.</summary>
        public override string ToString()
        {
            return Lugar;
        }
    }
}
