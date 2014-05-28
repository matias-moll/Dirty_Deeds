﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;
using System.Data;

namespace Dominio
{
    public class Rubro
    {
        private bool deleted;

        public int autoId { get; set; }
        public string campoDescripcion { get; set; }
        public byte campoDeleted { get { if (deleted) return 1; else return 0; } }

        public Rubro(string descripcion, bool p_deleted)
        {
            campoDescripcion = descripcion;
            deleted = p_deleted;
        }

        public Rubro(string descripcion) : this(descripcion, false) { }


        //Metodos publicos
        public void save()
        {
            DataAccessObject<Rubro> daoRol = new DataAccessObject<Rubro>();
            daoRol.insert(this);
        }

        public void update()
        {

        }

        public static DataTable upFullByCondition()
        {
            return DataAccessObject<Rubro>.upFullOnTable();
        }
    }
}
