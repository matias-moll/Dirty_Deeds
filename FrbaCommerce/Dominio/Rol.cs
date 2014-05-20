﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;
using System.Data;

namespace Dominio
{
    public class Rol
    {
        //Miembros
        private bool deleted;
        private DataAccessObject<Rol> daoRol;

        // Properties con la convencion del DataAccessObject
        public int claveId { get; set; }
        public string campoNombre { get; set; }
        public byte campoDeleted { get { if (deleted) return 1; else return 0; } }


        // Constructores
        public Rol(int id, string nombre, bool p_deleted)
        {
            claveId = id;
            campoNombre = nombre;
            deleted = p_deleted;
            daoRol = new DataAccessObject<Rol>();
        }

        public Rol(int id, string nombre): this(id, nombre, false){}


        //Metodos publicos
        public void save()
        {
            daoRol.insert(this);
        }

        public void update()
        {

        }

        public static DataTable upFullByCondition()
        {
            return DataAccessObject<Rol>.upFullOnTable();
        }

        public void borradoLogico()
        {
            deleted = true;
        }

    }
}
