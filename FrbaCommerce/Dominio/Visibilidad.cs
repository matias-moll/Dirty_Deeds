﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;
using System.Data;

namespace Dominio
{
    public class Visibilidad
    {
        private DataAccessObject<Visibilidad> daoVisibilidad;

        public int autoId { get; set; }
        public string campoCodigo { get; set; }
        public string campoDescripcion { get; set; }
        public decimal campoPrecio { get; set; }
        public decimal campoPorcentaje { get; set; }
        public bool campoDeleted { get; set; }

        #region Constructores

        public Visibilidad() { daoVisibilidad = new DataAccessObject<Visibilidad>(); }

        public Visibilidad(string codigo,string descripcion, decimal precio, decimal porcentaje, bool p_deleted) : this()
        {
            campoCodigo = codigo;
            campoDescripcion = descripcion;
            campoPrecio = precio;
            campoPorcentaje = porcentaje;
            campoDeleted = p_deleted;
        }

        public Visibilidad(string codigo,string descripcion, decimal precio, decimal porcentaje) :
            this(codigo,descripcion, precio, porcentaje, false) { }

        #endregion

        // Metodos publicos
        public void save()
        {
            daoVisibilidad.insert(this);
        }

        public static void delete(int idClavePrimaria)
        {
            DataAccessObject<Visibilidad>.delete(idClavePrimaria);
        }

        public void borradoLogico()
        {
            campoDeleted = !campoDeleted;
            update();
        }

        public void update()
        {
            daoVisibilidad.update(this);
        }

        public static List<Visibilidad> upFull()
        {
            return DataAccessObject<Visibilidad>.upFull();
        }

        public DataTable upFullByPrototype()
        {
            return DataAccessObject<Visibilidad>.upFullOnTableByPrototype(this);
        }

        public static Visibilidad get(int idClavePrimaria)
        {
            return DataAccessObject<Visibilidad>.get(idClavePrimaria);
        }

    }
}
