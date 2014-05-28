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

                removeTheLastComma(ref listaCampos);
                removeTheLastComma(ref listaValores);

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
                string where = "";
                object valorProperty;

                // Armamos el where recorriendo las properties del objeto Prototipo y validando que no sean "vacias"
                List<PropertyInfo> propiedadesCampos = getListaPropiedadesCampos(prototipo);
                foreach (PropertyInfo unaProperty in propiedadesCampos)
                {
                    valorProperty = getValorProperty(unaProperty, prototipo);

                    if (noEsVacio(valorProperty))
                        agregarCondicion(ref where, getNombreCampo(unaProperty), valorProperty);
                }

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

        private bool noEsVacio(object valorProperty)
        {
            // TODO: hacer un switch del tipo de la property para validar que no agregue como condiciones
            // los que sean strings vacias o numeros 0, etc.
            return true;
        }

        private void agregarCondicion(ref string where, string nombreCampo, object valorCampo)
        {
            // TODO: toda la logica en cada tipo de like en strings, equals en numbers. equals en fecha con formateo, etc.
        }

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
                listaValores += formatToSql(getValorProperty(unaProperty, objetoAObtenerCampos)) + ",";
            }
        }

        private string formatToSql(object unValor)
        {
            if (unValor.GetType() == typeof(string))
                return String.Format("'{0}'", (string)unValor);
            else if (unValor.GetType() == typeof(decimal))
                return unValor.ToString().Replace(',', '.');

            return unValor.ToString();
        }

        private void removeTheLastComma(ref string listaStrings)
        {
            listaStrings = listaStrings.Substring(0, listaStrings.Length - 1);
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
