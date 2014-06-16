using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce
{
    public abstract class Estado
    {
        public static Dictionary<string, Estado> estados;

        static Estado()
        {
            estados = new Dictionary<string, Estado>();
            estados.Add("Activa", new Activa());
            estados.Add("Borrador", new Borrador());
            estados.Add("Nueva", new Nueva());
            estados.Add("Pausada", new Pausada());
            estados.Add("Finalizada", new Finalizada());
        }

        public abstract void habilitaControlesCorrespondientes(Publicacion formPublicacion);

        public abstract int id { get;  }

        public static Estado getEstadoFromId(int idEstado)
        {
            switch (idEstado)
            {
                case 1: return estados["Activa"];
                case 2: return estados["Borrador"];
                case 3: return estados["Pausada"];
                case 4: return estados["Finalizada"];
                default: return null;
            }

        }


        internal static bool esEstadoFinalizada(Estado estado)
        {
            return estado.id == Finalizada.Id;
        }
    }
}
