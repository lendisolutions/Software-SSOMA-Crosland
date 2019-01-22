using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class EmpresaDL
    {
        public EmpresaDL() { }

        public Int32 Inserta(EmpresaBE pItem)
        {
            Int32 intIdEmpresa = 0;
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Empresa_Inserta");

            db.AddOutParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pRuc", DbType.String, pItem.Ruc);
            db.AddInParameter(dbCommand, "pRazonSocial", DbType.String, pItem.RazonSocial);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pTelefono", DbType.String, pItem.Telefono);
            db.AddInParameter(dbCommand, "pActividadEconomica", DbType.String, pItem.ActividadEconomica);
            db.AddInParameter(dbCommand, "pNumeroTrabajadores", DbType.Int32, pItem.NumeroTrabajadores);
            db.AddInParameter(dbCommand, "pIdTipoEmpresa", DbType.Int32, pItem.IdTipoEmpresa);
            db.AddInParameter(dbCommand, "pLogo", DbType.Binary, pItem.Logo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            intIdEmpresa = (int)db.GetParameterValue(dbCommand, "pIdEmpresa");

            return intIdEmpresa;
        }

        public void Actualiza(EmpresaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Empresa_Actualiza");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pRuc", DbType.String, pItem.Ruc);
            db.AddInParameter(dbCommand, "pRazonSocial", DbType.String, pItem.RazonSocial);
            db.AddInParameter(dbCommand, "pDireccion", DbType.String, pItem.Direccion);
            db.AddInParameter(dbCommand, "pTelefono", DbType.String, pItem.Telefono);
            db.AddInParameter(dbCommand, "pActividadEconomica", DbType.String, pItem.ActividadEconomica);
            db.AddInParameter(dbCommand, "pNumeroTrabajadores", DbType.Int32, pItem.NumeroTrabajadores);
            db.AddInParameter(dbCommand, "pIdTipoEmpresa", DbType.Int32, pItem.IdTipoEmpresa);
            db.AddInParameter(dbCommand, "pLogo", DbType.Binary, pItem.Logo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(EmpresaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Empresa_Elimina");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public EmpresaBE Selecciona(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Empresa_Selecciona");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EmpresaBE empresa = null;
            while (reader.Read())
            {
                empresa = new EmpresaBE();
                empresa.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                empresa.Ruc = reader["Ruc"].ToString();
                empresa.RazonSocial = reader["RazonSocial"].ToString();
                empresa.Direccion = reader["Direccion"].ToString();
                empresa.Telefono = reader["Telefono"].ToString();
                empresa.ActividadEconomica = reader["ActividadEconomica"].ToString();
                empresa.NumeroTrabajadores = Int32.Parse(reader["NumeroTrabajadores"].ToString());
                empresa.IdTipoEmpresa = Int32.Parse(reader["IdTipoEmpresa"].ToString());
                empresa.DescTipoEmpresa = reader["DescTipoEmpresa"].ToString();
                empresa.Logo = (byte[])reader["Logo"];
                empresa.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return empresa;
        }

        public List<EmpresaBE> SeleccionaTodos()
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Empresa_Selecciona");

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EmpresaBE> empresalist = new List<EmpresaBE>();
            EmpresaBE empresa;
            while (reader.Read())
            {
                empresa = new EmpresaBE();
                empresa.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                empresa.Ruc = reader["Ruc"].ToString();
                empresa.RazonSocial = reader["RazonSocial"].ToString();
                empresa.Direccion = reader["Direccion"].ToString();
                empresa.Telefono = reader["Telefono"].ToString();
                empresa.ActividadEconomica = reader["ActividadEconomica"].ToString();
                empresa.NumeroTrabajadores = Int32.Parse(reader["NumeroTrabajadores"].ToString());
                empresa.IdTipoEmpresa = Int32.Parse(reader["IdTipoEmpresa"].ToString());
                empresa.DescTipoEmpresa = reader["DescTipoEmpresa"].ToString();
                empresa.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                empresalist.Add(empresa);
            }
            reader.Close();
            reader.Dispose();
            return empresalist;
        }

        public List<EmpresaBE> ListaTodosActivo(int IdEmpresa, int IdTipoEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Empresa_ListaTodosActivo");

            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoEmpresa", DbType.Int32, IdTipoEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EmpresaBE> empresalist = new List<EmpresaBE>();
            EmpresaBE empresa;
            while (reader.Read())
            {
                empresa = new EmpresaBE();
                empresa.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                empresa.Ruc = reader["Ruc"].ToString();
                empresa.RazonSocial = reader["RazonSocial"].ToString();
                empresa.Direccion = reader["Direccion"].ToString();
                empresa.Telefono = reader["Telefono"].ToString();
                empresa.ActividadEconomica = reader["ActividadEconomica"].ToString();
                empresa.NumeroTrabajadores = Int32.Parse(reader["NumeroTrabajadores"].ToString());
                empresa.IdTipoEmpresa = Int32.Parse(reader["IdTipoEmpresa"].ToString());
                empresa.DescTipoEmpresa = reader["DescTipoEmpresa"].ToString();
                empresa.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                empresalist.Add(empresa);
            }
            reader.Close();
            reader.Dispose();
            return empresalist;
        }

        public List<EmpresaBE> ListaCombo(int IdTipoEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Empresa_ListaCombo");

            db.AddInParameter(dbCommand, "pIdTipoEmpresa", DbType.Int32, IdTipoEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EmpresaBE> empresalist = new List<EmpresaBE>();
            EmpresaBE empresa;
            while (reader.Read())
            {
                empresa = new EmpresaBE();
                empresa.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                empresa.RazonSocial = reader["RazonSocial"].ToString();
                empresalist.Add(empresa);
            }
            reader.Close();
            reader.Dispose();
            return empresalist;
        }

        public EmpresaBE SeleccionaDescripcion(string RazonSocial)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Empresa_SeleccionaDescripcion");

            db.AddInParameter(dbCommand, "pRazonSocial", DbType.Int32, RazonSocial);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EmpresaBE empresa = null;
            while (reader.Read())
            {
                empresa = new EmpresaBE();
                empresa.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                empresa.Ruc = reader["Ruc"].ToString();
                empresa.RazonSocial = reader["RazonSocial"].ToString();
                empresa.Direccion = reader["Direccion"].ToString();
                empresa.Telefono = reader["Telefono"].ToString();
                empresa.ActividadEconomica = reader["ActividadEconomica"].ToString();
                empresa.NumeroTrabajadores = Int32.Parse(reader["NumeroTrabajadores"].ToString());
                empresa.IdTipoEmpresa = Int32.Parse(reader["IdTipoEmpresa"].ToString());
                empresa.DescTipoEmpresa = reader["DescTipoEmpresa"].ToString();
                empresa.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return empresa;
        }

        public EmpresaBE SeleccionaRuc(string Ruc)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Empresa_SeleccionaRuc");

            db.AddInParameter(dbCommand, "pRuc", DbType.String, Ruc);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EmpresaBE empresa = null;
            while (reader.Read())
            {
                empresa = new EmpresaBE();
                empresa.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                empresa.Ruc = reader["Ruc"].ToString();
                empresa.RazonSocial = reader["RazonSocial"].ToString();
                empresa.Direccion = reader["Direccion"].ToString();
                empresa.Telefono = reader["Telefono"].ToString();
                empresa.ActividadEconomica = reader["ActividadEconomica"].ToString();
                empresa.NumeroTrabajadores = Int32.Parse(reader["NumeroTrabajadores"].ToString());
                empresa.IdTipoEmpresa = Int32.Parse(reader["IdTipoEmpresa"].ToString());
                empresa.DescTipoEmpresa = reader["DescTipoEmpresa"].ToString();
                empresa.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return empresa;
        }
    }
}
