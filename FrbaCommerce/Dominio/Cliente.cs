using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dal;
using System.Data;

namespace Dominio
{
    public class Cliente
    {
        //Miembros
        private DataAccessObject<Cliente> daoCliente;

        // Properties con la convencion del DataAccessObject
        public int autoId { get; set; }
        public string campoApellido { get; set; }
        public string campoNombre { get; set; }
        public string campoTipoDocumento { get; set; }
        public int campoDocumento { get; set; }
        public DateTime campoFechaNacimiento { get; set; }
        public string campoMail { get; set; }
        public string campoTelefono { get; set; }
        public int foraneaIdDireccion { get; set; }
        public int foraneaIdUsuario { get; set; }
        public bool campoDeleted { get; set; }

        public Direccion prototipoDireccion { get; set; }


        #region Constructores
        public Cliente() { daoCliente = new DataAccessObject<Cliente>(); }

        public Cliente(string Apellido, string Nombre,string TipoDocumento, int Documento, DateTime FechaNacimiento,
                       string Mail, string Telefono, bool p_deleted): this()
        {
            campoApellido = Apellido;
            campoNombre = Nombre;
            campoFechaNacimiento = FechaNacimiento;
            campoTipoDocumento = TipoDocumento;
            campoDocumento = Documento;
            campoMail = Mail;
            campoTelefono = Telefono;
            campoDeleted = p_deleted;
        }

        public Cliente(string Apellido, string Nombre, string TipoDocumento, int Documento, 
                       DateTime FechaNacimiento, string Mail, string Telefono)
            : this(Apellido, Nombre,TipoDocumento, Documento, FechaNacimiento, Mail, Telefono, false) { }

        #endregion


        //Metodos publicos
        public static Cliente get(int idClavePrimaria)
        {
            return DataAccessObject<Cliente>.get(idClavePrimaria);
        }

        public void save()
        {
            daoCliente.insert(this);
        }

        public void update()
        {
            daoCliente.update(this);
        }

        public DataTable upFullByPrototype()
        {
            return DataAccessObject<Cliente>.upFullOnTableByPrototype(this);
        }

        public static void delete(int idClavePrimaria)
        {
            DataAccessObject<Cliente>.delete(idClavePrimaria);
        }

        public void borradoLogico()
        {
            campoDeleted = !campoDeleted;
            update();
        }
    }
}
