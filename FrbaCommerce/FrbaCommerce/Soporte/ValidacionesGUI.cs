using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TNGS.NetControls;

namespace FrbaCommerce
{
    public static class Valid
    {
        public static bool noEsVacio(NumberEdit numberEdit)
        {
            return numberEdit.Numero != 0;
        }

        public static bool noEsVacio(TextEdit textEdit)
        {
            return textEdit.Text.Trim() != "";
        }

        public static bool noEsVacio(CuitEdit cuitEdit)
        {
            return cuitEdit.Text.Trim() != "";
        }
    }
}
