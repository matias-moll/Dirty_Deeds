﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;
using System.Data;

namespace Dominio
{
    public class Item
    {
        private DataAccessObject<Item> daoItem;

        public int campoNumFactura { get; set; }
        public int campoNumItem { get; set; }
        public string campoDescripcion { get; set; }
        public decimal campoMonto { get; set; }
        public int campoCantidad { get; set; }

        #region Constructores

        public Item() { daoItem = new DataAccessObject<Item>(); }

        public Item(int numFactura, int numItem, string descripcion, decimal monto, int cantidad) : this()
        {
            campoNumFactura = numFactura;
            campoNumItem = numItem;
            campoDescripcion = descripcion;
            campoMonto = monto;
            campoCantidad = cantidad;
        }
        #endregion

        //Metodos publicos
        public void save()
        {
            daoItem.insert(this);
        }

        public static void delete(int idClavePrimaria)
        {
            DataAccessObject<Item>.delete(idClavePrimaria);
        }

        public static List<Item> upFull()
        {
            return DataAccessObject<Item>.upFull();
        }

        public void update()
        {
            daoItem.update(this);
        }

        public DataTable upFullByPrototype()
        {
            return DataAccessObject<Item>.upFullOnTableByPrototype(this);
        }

        public static Item get(int idClavePrimaria)
        {
            return DataAccessObject<Item>.get(idClavePrimaria);
        }
    }
}
