using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dal
{
    public class DataBaseException : Exception
    {
        public DataBaseException(string mensaje, string sqlEjecutado, string error, string stackTrace)
            : base(String.Format("{0}\r\r\r " + 
                                 "Codigo SQL Ejecutado: {1} \r\r\r " +
                                 "Error: \r {2} \r\r\r "+
                                 "StackTrace: {3}", 
                                 mensaje, sqlEjecutado, error, stackTrace)) { }
    }
}
