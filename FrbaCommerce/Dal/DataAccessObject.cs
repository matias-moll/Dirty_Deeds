using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;

namespace Dal
{
    public class DataAccessObject<PersistentObject> where PersistentObject :new()
    {

        #region Interfaz Publica

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

        public static void delete(int idClavePrimaria, Type tipoObjetoABorrar)
        {
            string deleteCommand = "";
            try
            {
                string nombreTabla = tipoObjetoABorrar.Name;
                deleteCommand = String.Format("delete from DIRTYDEEDS.{0} where Id = {1}", nombreTabla, idClavePrimaria);
                StaticDataAccess.executeCommand(deleteCommand);
            }
            catch (Exception e)
            {
                throw new DataBaseException("Se produjo un error cuando se intentaba realizar el borrado en la base de datos.",
                                            deleteCommand, e.Message, e.StackTrace);
            }
        }

        public static PersistentObject get(int idClavePrimaria, Type tipoObjetoAObtener)
        {
            string query = "";
            try
            {
                string nombreTabla = tipoObjetoAObtener.Name;
                query = String.Format("select * from DIRTYDEEDS.{0} where Id = {1}", nombreTabla, idClavePrimaria);
                DataTable dtEntidad = StaticDataAccess.executeQuery(query);
                return makeObject(dtEntidad.Rows[0], tipoObjetoAObtener.GetType());
            }
            catch (Exception e)
            {
                throw new DataBaseException("Se produjo un error cuando se intentaba obtener el objeto a partir de clave.",
                                            query, e.Message, e.StackTrace);
            }
        }

        public DataTable upFullOnTableByPrototype(PersistentObject prototipo)
        {
            string query = "";
            try
            {
                string where = "where ";
                object valorProperty;

                // Armamos el where recorriendo las properties del objeto Prototipo y validando que no sean "vacias"
                List<PropertyInfo> propiedadesCampos = getListaPropiedadesCampos(prototipo.GetType());
                foreach (PropertyInfo unaProperty in propiedadesCampos)
                {
                    valorProperty = getValorProperty(unaProperty.Name, prototipo);
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

        #endregion



        #region Metodos privados

        private static PersistentObject makeObject(DataRow drEntidad, Type tipoClase)
        {
            PersistentObject objetoCreado = new PersistentObject();
            List<PropertyInfo> propiedadesCampos = getListaPropiedadesCampos(tipoClase);

            // Le cargamos todos los valores del datarow al objeto.
            foreach (PropertyInfo unaProperty in propiedadesCampos)
                setValorProperty(unaProperty.Name, objetoCreado, drEntidad[getNombreCampo(unaProperty)]);

            // Agregamos la clave primaria que tiene un tratamiento diferente al de los campos
            setValorProperty("claveId", objetoCreado, drEntidad["Id"]); // TODO: pensar como no hardcodear esto.

            return objetoCreado;
        }

        private static List<PropertyInfo> getListaPropiedadesCampos(Type tipoClaseAObtenerProperties)
        {
            return tipoClaseAObtenerProperties.GetProperties().Where
                           (unaProperty => representaUnCampoDeLaBase(unaProperty.Name)).ToList();
        }

        private void fillListaCamposYListaValoresFrom(ref string listaCampos, ref string listaValores, PersistentObject objetoAObtenerCampos)
        {
            List<PropertyInfo> propiedadesCampos = getListaPropiedadesCampos(objetoAObtenerCampos.GetType());
            foreach (PropertyInfo unaProperty in propiedadesCampos)
            {
                listaCampos += getNombreCampo(unaProperty) + ",";
                listaValores += LogicByType.formatToSql(getValorProperty(unaProperty.Name, objetoAObtenerCampos)) + ",";
            }
        }

        private static object getValorProperty(string mensaje, PersistentObject unObjeto)
        {
            return unObjeto.GetType().InvokeMember(mensaje,
                                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty,
                                    null, unObjeto, null);
        }

        private static void setValorProperty(string mensaje, PersistentObject unObjeto, object valor)
        {
            unObjeto.GetType().InvokeMember(mensaje,
                                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty,
                                    null, unObjeto, new object[] { valor });
        }

        private static string getNombreCampo(PropertyInfo unaProperty)
        {
            return unaProperty.Name.Substring(getPositionOfFirstUpperCaseChar(unaProperty.Name));
        }

        private void removeTheLast(ref string stringArmada, string stringARemover)
        {
            stringArmada = stringArmada.Substring(0, stringArmada.Length - stringARemover.Length);
        }

        private static int getPositionOfFirstUpperCaseChar(string unaProperty)
        {
            for (int i = 0; i < unaProperty.Length - 1; i++)
                if (char.IsUpper(unaProperty[i]))
                    return i;
            return 0;

        }

        private static bool representaUnCampoDeLaBase(string unaProperty)
        {
            return (unaProperty.Contains("campo"));
        }

        #endregion

    }
}
