using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;
using System.Data;

namespace Dominio
{
    public class Funcionalidad
    {
        public static Dictionary<String, int> funcionalidades;

        static Funcionalidad()
        {
            funcionalidades = new Dictionary<string, int>();
            funcionalidades.Add("ComprarOfertar", 1);
            funcionalidades.Add("GenEditPublicacion", 2);
            funcionalidades.Add("Facturacion", 3);
            funcionalidades.Add("HistorialCliente", 4);
            funcionalidades.Add("Estadisticas", 5);
            funcionalidades.Add("ABMs", 6);
        }


        //Miembros
        private DataAccessObject<Funcionalidad> daoFuncionalidad;

        // Properties con la convencion del DataAccessObject
        public int autoId { get; set; }
        public string campoNombre { get; set; }
        public bool campoDeleted { get; set; }

        #region Constructores
        public Funcionalidad() { daoFuncionalidad = new DataAccessObject<Funcionalidad>(); }

        public Funcionalidad(string nombre, bool p_deleted)
            : this()
        {
            campoNombre = nombre;
            campoDeleted = p_deleted;
        }

        public Funcionalidad(string nombre) : this(nombre, false) { }

        #endregion


        //Metodos publicos
        public static Funcionalidad get(int idClavePrimaria)
        {
            return DataAccessObject<Funcionalidad>.get(idClavePrimaria);
        }

        public int save()
        {
            return daoFuncionalidad.insert(this);
        }

        public void update()
        {
            daoFuncionalidad.update(this);
        }

        public DataTable upFullByPrototype()
        {
            return DataAccessObject<Funcionalidad>.upFullOnTableByPrototype(this);
        }

        public static List<Funcionalidad> upFull()
        {
            return DataAccessObject<Funcionalidad>.upFull();
        }

        public static void delete(int idClavePrimaria)
        {
            DataAccessObject<Funcionalidad>.delete(idClavePrimaria);
        }

        public void borradoLogico()
        {
            campoDeleted = !campoDeleted;
            update();
        }

    }
}
