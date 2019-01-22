using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ProveedorDL
    {
        public ProveedorDL() { }

        public void Inserta(ProveedorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Proveedor_Inserta");

            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pRazonSocial", DbType.String, pItem.RazonSocial);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pContacto", DbType.String, pItem.Contacto);
            db.AddInParameter(dbCommand, "pTelefono", DbType.String, pItem.Telefono);
            db.AddInParameter(dbCommand, "pCelular", DbType.String, pItem.Celular);
            db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(ProveedorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Proveedor_Actualiza");

            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoDocumento", DbType.Int32, pItem.IdTipoDocumento);
            db.AddInParameter(dbCommand, "pNumeroDocumento", DbType.String, pItem.NumeroDocumento);
            db.AddInParameter(dbCommand, "pRazonSocial", DbType.String, pItem.RazonSocial);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pContacto", DbType.String, pItem.Contacto);
            db.AddInParameter(dbCommand, "pTelefono", DbType.String, pItem.Telefono);
            db.AddInParameter(dbCommand, "pCelular", DbType.String, pItem.Celular);
            db.AddInParameter(dbCommand, "pEmail", DbType.String, pItem.Email);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ProveedorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Proveedor_Elimina");

            db.AddInParameter(dbCommand, "pIdProveedor", DbType.Int32, pItem.IdProveedor);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public ProveedorBE Selecciona(int IdEmpresa, int idProveedor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Proveedor_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pidProveedor", DbType.Int32, idProveedor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ProveedorBE Proveedor = null;
            while (reader.Read())
            {
                Proveedor = new ProveedorBE();
                Proveedor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Proveedor.IdProveedor = Int32.Parse(reader["idProveedor"].ToString());
                Proveedor.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Proveedor.Abreviatura = reader["Abreviatura"].ToString();
                Proveedor.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Proveedor.RazonSocial = reader["RazonSocial"].ToString();
                Proveedor.Direccion = reader["Direccion"].ToString();
                Proveedor.Contacto = reader["Contacto"].ToString();
                Proveedor.Telefono = reader["Telefono"].ToString();
                Proveedor.Celular = reader["Celular"].ToString();
                Proveedor.Email = reader["Email"].ToString();
                Proveedor.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Proveedor;
        }

        public List<ProveedorBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Proveedor_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProveedorBE> Proveedorlist = new List<ProveedorBE>();
            ProveedorBE Proveedor;
            while (reader.Read())
            {
                Proveedor = new ProveedorBE();
                Proveedor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Proveedor.IdProveedor = Int32.Parse(reader["idProveedor"].ToString());
                Proveedor.IdTipoDocumento = Int32.Parse(reader["IdTipoDocumento"].ToString());
                Proveedor.Abreviatura = reader["Abreviatura"].ToString();
                Proveedor.NumeroDocumento = reader["NumeroDocumento"].ToString();
                Proveedor.RazonSocial = reader["RazonSocial"].ToString();
                Proveedor.Direccion = reader["Direccion"].ToString();
                Proveedor.Contacto = reader["Contacto"].ToString();
                Proveedor.Telefono = reader["Telefono"].ToString();
                Proveedor.Celular = reader["Celular"].ToString();
                Proveedor.Email = reader["Email"].ToString();
                Proveedor.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Proveedorlist.Add(Proveedor);
            }
            reader.Close();
            reader.Dispose();
            return Proveedorlist;
        }

        public List<ProveedorBE> ListaCombo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Proveedor_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ProveedorBE> Proveedorlist = new List<ProveedorBE>();
            ProveedorBE Proveedor;
            while (reader.Read())
            {
                Proveedor = new ProveedorBE();
                Proveedor.IdProveedor = Int32.Parse(reader["IdProveedor"].ToString());
                Proveedor.RazonSocial = reader["RazonSocial"].ToString();
                Proveedorlist.Add(Proveedor);
            }
            reader.Close();
            reader.Dispose();
            return Proveedorlist;
        }
    }
}
