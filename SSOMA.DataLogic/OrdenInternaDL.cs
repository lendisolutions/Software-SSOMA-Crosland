using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class OrdenInternaDL
    {
        public OrdenInternaDL() { }

        public void Inserta(OrdenInternaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_OrdenInterna_Inserta");

            db.AddInParameter(dbCommand, "pIdOrdenInterna", DbType.Int32, pItem.IdOrdenInterna);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pDescOrdenInterna", DbType.String, pItem.DescOrdenInterna);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(OrdenInternaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_OrdenInterna_Actualiza");

            db.AddInParameter(dbCommand, "pIdOrdenInterna", DbType.Int32, pItem.IdOrdenInterna);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pDescOrdenInterna", DbType.String, pItem.DescOrdenInterna);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(OrdenInternaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_OrdenInterna_Elimina");

            db.AddInParameter(dbCommand, "pIdOrdenInterna", DbType.Int32, pItem.IdOrdenInterna);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public OrdenInternaBE Selecciona(int IdEmpresa, int IdUnidadMinera, int IdOrdenInterna)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_OrdenInterna_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pidOrdenInterna", DbType.Int32, IdOrdenInterna);

            IDataReader reader = db.ExecuteReader(dbCommand);
            OrdenInternaBE OrdenInterna = null;
            while (reader.Read())
            {
                OrdenInterna = new OrdenInternaBE();
                OrdenInterna.IdOrdenInterna = Int32.Parse(reader["idOrdenInterna"].ToString());
                OrdenInterna.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                OrdenInterna.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                OrdenInterna.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                OrdenInterna.DescOrdenInterna = reader["descOrdenInterna"].ToString();
                OrdenInterna.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return OrdenInterna;
        }

        public OrdenInternaBE SeleccionaDescripcion(int IdEmpresa, int IdUnidadMinera, string DescOrdenInterna)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_OrdenInterna_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pDescOrdenInterna", DbType.String, DescOrdenInterna);

            IDataReader reader = db.ExecuteReader(dbCommand);
            OrdenInternaBE OrdenInterna = null;
            while (reader.Read())
            {
                OrdenInterna = new OrdenInternaBE();
                OrdenInterna.IdOrdenInterna = Int32.Parse(reader["idOrdenInterna"].ToString());
                OrdenInterna.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                OrdenInterna.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                OrdenInterna.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                OrdenInterna.DescOrdenInterna = reader["descOrdenInterna"].ToString();
                OrdenInterna.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return OrdenInterna;
        }

        public List<OrdenInternaBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_OrdenInterna_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<OrdenInternaBE> OrdenInternalist = new List<OrdenInternaBE>();
            OrdenInternaBE OrdenInterna;
            while (reader.Read())
            {
                OrdenInterna = new OrdenInternaBE();
                OrdenInterna.IdOrdenInterna = Int32.Parse(reader["idOrdenInterna"].ToString());
                OrdenInterna.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                OrdenInterna.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                OrdenInterna.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                OrdenInterna.DescOrdenInterna = reader["descOrdenInterna"].ToString();
                OrdenInterna.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                OrdenInternalist.Add(OrdenInterna);
            }
            reader.Close();
            reader.Dispose();
            return OrdenInternalist;
        }
    }
}
