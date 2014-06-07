using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;

namespace Dal
{
    public class DataAccessObject<PersistentObject>
    {
        public void insert(PersistentObject objetoAPersistir)
        {
            string commandInsert = "";

            try
            {
                string listaCampos, listaValores;
                listaCampos = listaValores = "";

                fillListaCamposYListaValoresFrom(ref listaCampos, ref listaValores, objetoAPersistir);

                removeTheLast(ref listaCampos, ",");
                removeTheLast(ref listaValores, ",");

                string nombreTabla = objetoAPersistir.GetType().Name;
                commandInsert = String.Format("insert into DIRTYDEEDS.{0} ({1}) values ({2})", nombreTabla, listaCampos, listaValores);

                StaticDataAccess.executeCommand(commandInsert);
            }
            catch (Exception e)
            {
                throw new DataBaseException("Se produjo un error cuando se intentaba insertar un registro en la base de datos.",
                                            commandInsert, e.Message, e.StackTrace);
            }
           
        }

        public void update()
        {

        }

        public void delete()
        {

        }

        public DataTable upFullOnTableByPrototype(PersistentObject prototipo)
        {
            string query = "";
            try
            {
                string where = "where ";
                object valorProperty;

                // Armamos el where recorriendo las properties del objeto Prototipo y validando que no sean "vacias"
                List<PropertyInfo> propiedadesCampos = getListaPropiedadesCampos(prototipo);
                foreach (PropertyInfo unaProperty in propiedadesCampos)
                {
                    valorProperty = getValorProperty(unaProperty, prototipo);
                    // Si no es vacio el valor, agregamos la condicion.
                    if (!LogicByType.esVacio(valorProperty))
                        LogicByType.agregarCondicion(ref where, getNombreCampo(unaProperty), valorProperty);
                }

                removeTheLast(ref where, "and");

                query = String.Format("select * from DIRTYDEEDS.{0} {1}", typeof(PersistentObject).Name, where); 

                return StaticDataAccess.executeQuery(query);
            }
            catch(Exception e)
            {
                throw new DataBaseException("Se produjo un error cuando se intentaba realizar la consulta en la base de datos.",
                                            query, e.Message, e.StackTrace);
            }

        }

        public List<PersistentObject> upFull()
        {
            return null;
        }

        public PersistentObject get()
        {
            return (PersistentObject)new Object();
        }



        #region Metodos privados 

        private string getNombreCampo(PropertyInfo unaProperty)
        {
            return unaProperty.Name.Substring(getPositionOfFirstUpperCaseChar(unaProperty.Name));
        }

        private object getValorProperty(PropertyInfo unaProperty, PersistentObject unObjeto)
        {
            return unObjeto.GetType().InvokeMember(unaProperty.Name,
                                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty,
                                    null, unObjeto, null);
        }

        private List<PropertyInfo> getListaPropiedadesCampos(object prototipo)
        {
            return prototipo.GetType().GetProperties().Where
                           (unaProperty => representaUnCampoDeLaBase(unaProperty.Name)).ToList();
        }

        private void fillListaCamposYListaValoresFrom(ref string listaCampos, ref string listaValores, PersistentObject objetoAObtenerCampos)
        {
            List<PropertyInfo> propiedadesCampos = getListaPropiedadesCampos(objetoAObtenerCampos);
            foreach (PropertyInfo unaProperty in propiedadesCampos)
            {
                listaCampos += getNombreCampo(unaProperty) + ",";
                listaValores += LogicByType.formatToSql(getValorProperty(unaProperty, objetoAObtenerCampos)) + ",";
            }
        }

        private void removeTheLast(ref string stringArmada, string stringARemover)
        {
            stringArmada = stringArmada.Substring(0, stringArmada.Length - stringARemover.Length);
        }

        private int getPositionOfFirstUpperCaseChar(string unaProperty)
        {
            for (int i = 0; i < unaProperty.Length - 1; i++)
                if (char.IsUpper(unaProperty[i]))
                    return i;
            return 0;

        }

        private bool representaUnCampoDeLaBase(string unaProperty)
        {
            return (unaProperty.Contains("campo") || unaProperty.Contains("clave"));
        }

        #endregion

    }
}
