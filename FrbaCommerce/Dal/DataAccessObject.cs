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

        public int insert(PersistentObject objetoAPersistir)
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
                commandInsert = String.Format("insert into DIRTYDEEDS.{0} ({1}) values ({2})  {3}", 
                                              nombreTabla, listaCampos, listaValores, returnIdentity());

                return StaticDataAccess.executeInsert(commandInsert);
            }
            catch (Exception e)
            {
                throw new DataBaseException("Se produjo un error cuando se intentaba insertar un registro en la base de datos.",
                                            commandInsert, e.Message, e.StackTrace);
            }
           
        }

        private static string returnIdentity()
        {
            return "SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]";
        }

        public void update(PersistentObject objetoAActualizar)
        {
            string commandUpdate = "";

            try
            {
                string listaCamposValores, listaCondiciones;
                listaCamposValores = listaCondiciones = "";

                // Instanciamos y llenamos el diccionario con todos los campos y valores del objeto.
                Dictionary<string, string> diccionarioCampoValor = new Dictionary<string, string>();
                fillDictionaryCampoValor(ref diccionarioCampoValor, objetoAActualizar);

                // Convertimos el diccionario en una string para el sql.
                listaCamposValores = makeStringOfFieldValues(diccionarioCampoValor);

                // TODO: cambiar esta condicion hardcoded por un metodo que busque todas las properties que compongan la clave y sus valores.
                listaCondiciones = "Id = " + getValorProperty("autoId",objetoAActualizar).ToString();

                string nombreTabla = objetoAActualizar.GetType().Name;
                commandUpdate = String.Format("update DIRTYDEEDS.{0} set {1} where {2}", nombreTabla, listaCamposValores, listaCondiciones);

                StaticDataAccess.executeCommand(commandUpdate);
            }
            catch (Exception e)
            {
                throw new DataBaseException("Se produjo un error cuando se intentaba actualizar un registro en la base de datos.",
                                            commandUpdate, e.Message, e.StackTrace);
            }
        }

        public static void delete(int idClavePrimaria)
        {
            string deleteCommand = "";
            try
            {
                string nombreTabla = typeof(PersistentObject).Name;
                deleteCommand = String.Format("delete from DIRTYDEEDS.{0} where Id = {1}", nombreTabla, idClavePrimaria);
                StaticDataAccess.executeCommand(deleteCommand);
            }
            catch (Exception e)
            {
                throw new DataBaseException("Se produjo un error cuando se intentaba realizar el borrado en la base de datos.",
                                            deleteCommand, e.Message, e.StackTrace);
            }
        }

        public static PersistentObject get(int idClavePrimaria)
        {
            string query = "";
            try
            {
                PersistentObject objetoAConstruir = new PersistentObject();
                string nombreTabla = objetoAConstruir.GetType().Name;
                query = String.Format("select * from DIRTYDEEDS.{0} where Id = {1}", nombreTabla, idClavePrimaria);
                DataTable dtEntidad = StaticDataAccess.executeQuery(query);
                fillObject(dtEntidad.Rows[0], ref objetoAConstruir);
                return objetoAConstruir;
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

                armaWheresSegunPrototipo(prototipo, ref where);

                string joins = "";

                List<PropertyInfo> propiedadesClavesForaneas= getListaPropiedadesForaneas(prototipo.GetType());
                List<PropertyInfo> propiedadesPrototiposForaneos = getListaPropiedadesPrototiposForaneos(prototipo.GetType());
                foreach (PropertyInfo unaPropiedad in propiedadesClavesForaneas)
                {
                    joins += String.Format("join DIRTYDEEDS.{0} on {1} ", nombreTablaForanea(unaPropiedad), 
                                                                        condicionForanea(unaPropiedad));
                    where += armaWhereForaneos(prototipo, unaPropiedad, propiedadesPrototiposForaneos);

                }


                query = String.Format("select * from DIRTYDEEDS.{0} {1} {2}", typeof(PersistentObject).Name, joins, where); 

                return StaticDataAccess.executeQuery(query);
            }
            catch(Exception e)
            {
                throw new DataBaseException("Se produjo un error cuando se intentaba realizar la consulta en la base de datos.",
                                            query, e.Message, e.StackTrace);
            }

        }

        private static void armaWheresSegunPrototipo(object prototipo, ref string where)
        {
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
        }

        private static string armaWhereForaneos(object objetoRaiz, PropertyInfo unaPropiedad, 
                                                List<PropertyInfo> propiedadesPrototiposForaneos)
        {
            string whereForaneo = " and ";
            // Ejemplo: foraneaIdDireccion, 9 caracteres ocupa el prefijo (foraneaId) lo siguiente es el nombre.
            string nombrePrototipoForaneo = unaPropiedad.Name.Substring(9, unaPropiedad.Name.Length -9);
            // FIltramos la lista para que nos quede la que estamos buscando
            propiedadesPrototiposForaneos.Where(unaProp => unaProp.Name.Contains(nombrePrototipoForaneo));
            if (propiedadesPrototiposForaneos.Count != 1)
                return "";
            // Obtenemos el objeto prototipo foraneo para construir los where a partir de la property encontrada
            object objetoPrototipoForaneo = getValorProperty(propiedadesPrototiposForaneos[0].Name, objetoRaiz);

            armaWheresSegunPrototipo(objetoPrototipoForaneo, ref whereForaneo);
            return whereForaneo;
        }

        public static List<PersistentObject> upFull()
        {
            string query = "";
            List<PersistentObject> listaObjetos = new List<PersistentObject>();
            try
            {
                
                string nombreTabla = typeof(PersistentObject).Name;
                query = String.Format("select * from DIRTYDEEDS.{0}", nombreTabla);
                DataTable dtListaEntidades = StaticDataAccess.executeQuery(query);
                // Iteramos por todas las filas que devolvio la consulta
                foreach (DataRow drEntidad in dtListaEntidades.Rows)
                {
                    // Creamos el objeto, lo llenamos a aprtir del datarow y lo agregamos a al lista.
                    PersistentObject objetoAAgregar = new PersistentObject();
                    fillObject(drEntidad, ref objetoAAgregar);
                    listaObjetos.Add(objetoAAgregar);
                }
                return listaObjetos;
            }
            catch (Exception e)
            {
                throw new DataBaseException("Se produjo un error cuando se intentaba obtener la lista de objetos.",
                                            query, e.Message, e.StackTrace);
            }
        }

        #endregion


        #region Metodos privados

        private static void fillObject(DataRow drEntidad, ref PersistentObject objetoALlenar)
        {
            List<PropertyInfo> propiedadesCampos = getListaPropiedadesCampos(objetoALlenar.GetType());

            // Le cargamos todos los valores del datarow al objeto.
            foreach (PropertyInfo unaProperty in propiedadesCampos)
                setValorProperty(unaProperty.Name, objetoALlenar, drEntidad[getNombreCampo(unaProperty)]);

            // Agregamos la clave primaria que tiene un tratamiento diferente al de los campos
            PropertyInfo propiedadClave = getPropiedadClave(objetoALlenar.GetType());
            setValorProperty(propiedadClave.Name, objetoALlenar, drEntidad[getNombreCampo(propiedadClave)]);
        }

        private static List<PropertyInfo> getListaPropiedadesCampos(Type tipoClaseAObtenerProperties)
        {
            return tipoClaseAObtenerProperties.GetProperties().Where
                           (unaProperty => (representaUnCampoDeLaBase(unaProperty.Name)) || 
                               (representaUnaClaveForanea(unaProperty.Name))).ToList();
        }

        private static List<PropertyInfo> getListaPropiedadesPrototiposForaneos(Type tipoClaseAObtenerProperties)
        {
            return tipoClaseAObtenerProperties.GetProperties().Where
                           (unaProperty => representaUnPrototipoForaneo(unaProperty.Name)).ToList();
        }

        private static List<PropertyInfo> getListaPropiedadesForaneas(Type tipoClaseAObtenerProperties)
        {
            return tipoClaseAObtenerProperties.GetProperties().Where
                           (unaProperty => representaUnaClaveForanea(unaProperty.Name)).ToList();
        }

        private static PropertyInfo getPropiedadClave(Type tipoClaseAObtenerProperties)
        {
            return tipoClaseAObtenerProperties.GetProperties().Where
                           (unaProperty => representaClaveEnLaBase(unaProperty.Name)).ToList()[0];
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

        private void fillDictionaryCampoValor(ref Dictionary<string, string> diccionarioCampoValor, PersistentObject objetoAPersistir)
        {
            List<PropertyInfo> propiedadesCampos = getListaPropiedadesCampos(objetoAPersistir.GetType());
            // Por cada property agregamos un objeto al diccionario con clave nombre de campo y valor valor del campo.
            foreach (PropertyInfo unaProperty in propiedadesCampos)
                diccionarioCampoValor.Add(getNombreCampo(unaProperty),
                    LogicByType.formatToSql(getValorProperty(unaProperty.Name, objetoAPersistir)));
        }

        private string makeStringOfFieldValues(Dictionary<string, string> diccionarioCampoValor)
        {
            string setCampoValor = "";
            // Armamos la string de asignacion de nombreCampo = valor para todas las entradas del diccionario.
            foreach (KeyValuePair<string, string> keyValuePair in diccionarioCampoValor)
                setCampoValor += String.Format("{0} = {1} ,", keyValuePair.Key, keyValuePair.Value);

            removeTheLast(ref setCampoValor, ",");

            return setCampoValor;
        }

        private static object getValorProperty(string mensaje, object unObjeto)
        {
            return unObjeto.GetType().InvokeMember(mensaje,
                                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty,
                                    null, unObjeto, null);
        }

        private static void setValorProperty(string mensaje, object unObjeto, object valor)
        {
            unObjeto.GetType().InvokeMember(mensaje,
                                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty,
                                    null, unObjeto, new object[] { valor });
        }

        private static string getNombreCampo(PropertyInfo unaProperty)
        {
            return unaProperty.Name.Substring(getPositionOfFirstUpperCaseChar(unaProperty.Name));
        }

        private static void removeTheLast(ref string stringArmada, string stringARemover)
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

        private string nombreTablaForanea(PropertyInfo unaPropiedad)
        {
            // Todas las foraneas deben respetar foraneaIdNombreTabla, entonces foraneaId ocupa 9 caracteres.
            return unaPropiedad.Name.Substring(9, unaPropiedad.Name.Length - 9);
        }

        private string condicionForanea(PropertyInfo unaPropiedad)
        {
            // Ejemplo
            // Property : foraneaIdDireccion
            // Condicion esperada: IdDireccion = Direccion.Id
            // Obtenemos el nombre del campo foraneo
            string condicion = unaPropiedad.Name.Substring(7, unaPropiedad.Name.Length - 7);
            // Le contactenamos el campo Id (default para claves primarias) anteponiendole el nombre de la tabla.
            condicion += String.Format(" = {0}.{1}", nombreTablaForanea(unaPropiedad), "Id");
            return condicion;
        }

        private static bool representaUnCampoDeLaBase(string unaProperty)
        {
            return (unaProperty.Contains("campo"));
        }

        private static bool representaUnaClaveForanea(string unaProperty)
        {
            return (unaProperty.Contains("foranea"));
        }

        private static bool representaUnPrototipoForaneo(string unaProperty)
        {
            return (unaProperty.Contains("prototipo"));
        }

        private static bool representaClaveEnLaBase(string unaProperty)
        {
            return (unaProperty.Contains("auto"));
        }

        #endregion

    }
}
