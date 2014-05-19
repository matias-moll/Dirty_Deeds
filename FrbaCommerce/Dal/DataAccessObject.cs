using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Dal
{
    public class DataAccessObject<PersistentObject>
    {
        public void insert(PersistentObject objetoAPersistir)
        {
            string listaCampos, listaValores;
            listaCampos = listaValores = "";

            List<PropertyInfo> propiedadesCampos = objetoAPersistir.GetType().GetProperties().Where
                                    (unaProperty => representaUnCampoDeLaBase(unaProperty.Name)).ToList();
            foreach (PropertyInfo unaProperty in propiedadesCampos)
            {
                listaCampos += unaProperty.Name.Substring(getPositionOfFirstUpperCaseChar(unaProperty.Name)) + ",";
                listaValores += formatToSql(objetoAPersistir.GetType().InvokeMember(unaProperty.Name,
                                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty,
                                    null, objetoAPersistir, null)) + ",";
            }

            removeTheLastComma(ref listaCampos);
            removeTheLastComma(ref listaValores);
            
            string nombreTabla = objetoAPersistir.GetType().Name;
            string commandInsert = String.Format("insert into DIRTYDEEDS.{0} ({1}) values ({2})", nombreTabla, listaCampos, listaValores);

            StaticDataAccess.executeCommand(commandInsert);
           
        }

        private string formatToSql(object unValor)
        {
            if (unValor.GetType() == typeof(string))
                return String.Format("'{0}'", (string)unValor);

            return unValor.ToString();
        }

        private void removeTheLastComma(ref string listaStrings)
        {
            listaStrings = listaStrings.Substring(0, listaStrings.Length - 1);
        }

        private int getPositionOfFirstUpperCaseChar(string unaProperty)
        {
            for (int i = 0; i < unaProperty.Length-1; i++)
                if (char.IsUpper(unaProperty[i]))
                    return i;
            return 0;
                
        }

        private bool representaUnCampoDeLaBase(string unaProperty)
        {
            return (unaProperty.Contains("campo") || unaProperty.Contains("clave"));
        }

        public void update()
        {

        }

        public void delete()
        {

        }

        public List<PersistentObject> upFull()
        {
            return null;
        }

        public PersistentObject get()
        {
            return (PersistentObject)new Object();
        }

    }
}
