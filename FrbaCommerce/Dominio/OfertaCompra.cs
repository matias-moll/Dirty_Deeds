using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;
using System.Data;

namespace Dominio
{
    public class OfertaCompra
    {
        private DataAccessObject<OfertaCompra> daoOfertaCompra;

        public int autoid { get; set; }
        public int campoIdUsuario { get; set; }
        public int campoCodPublicacion { get; set; }
        public DateTime campoFecha { get; set; }
        public decimal campoMonto { get; set; }
        public int campoCantidad { get; set; }
        public string campoDiscriminante{ get; set; }

        #region Constructores

        public OfertaCompra() { daoOfertaCompra = new DataAccessObject<OfertaCompra>(); }

        public OfertaCompra(int idUsuario,int codPublicacion, DateTime fecha, decimal monto, int cantidad, string discriminante) : this()
        {
            campoIdUsuario = idUsuario;
            campoCodPublicacion = codPublicacion;
            campoFecha = fecha;
            campoMonto = monto;
            campoCantidad = cantidad;
            campoDiscriminante = discriminante;
        }


        #endregion

        //Metodos publicos
        public void save()
        {
            daoOfertaCompra.insert(this);
        }

        public static void delete(int idClavePrimaria)
        {
            DataAccessObject<OfertaCompra>.delete(idClavePrimaria, "CodPublicacion");
        }

        public void update()
        {
            daoOfertaCompra.update(this);
        }


        public List<OfertaCompra> getListByPrototype()
        {
            return DataAccessObject<OfertaCompra>.upFullByPrototype(this);
        }

        public DataTable upFullByPrototype()
        {
            return DataAccessObject<OfertaCompra>.upFullOnTableByPrototype(this);
        }

        public static List<OfertaCompra> upFull()
        {
            return DataAccessObject<OfertaCompra>.upFull();
        }

        public static OfertaCompra get(int idClavePrimaria)
        {
            return DataAccessObject<OfertaCompra>.get(idClavePrimaria);
        }
    }
}
