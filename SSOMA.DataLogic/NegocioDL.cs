using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class NegocioDL
    {
        public NegocioDL() { }

        public void Inserta(NegocioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Negocio_Inserta");

            db.AddInParameter(dbCommand, "pIdNegocio", DbType.Int32, pItem.IdNegocio);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescNegocio", DbType.String, pItem.DescNegocio);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(NegocioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Negocio_Actualiza");

            db.AddInParameter(dbCommand, "pIdNegocio", DbType.Int32, pItem.IdNegocio);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescNegocio", DbType.String, pItem.DescNegocio);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(NegocioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Negocio_Elimina");

            db.AddInParameter(dbCommand, "pIdNegocio", DbType.Int32, pItem.IdNegocio);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public NegocioBE Selecciona(int IdEmpresa, int idNegocio)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Negocio_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pidNegocio", DbType.Int32, idNegocio);

            IDataReader reader = db.ExecuteReader(dbCommand);
            NegocioBE Negocio = null;
            while (reader.Read())
            {
                Negocio = new NegocioBE();
                Negocio.IdNegocio = Int32.Parse(reader["idNegocio"].ToString());
                Negocio.DescNegocio = reader["descNegocio"].ToString();
                Negocio.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Negocio;
        }

        public NegocioBE SeleccionaDescripcion(int IdEmpresa, string DescNegocio)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Negocio_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pDescNegocio", DbType.String, DescNegocio);

            IDataReader reader = db.ExecuteReader(dbCommand);
            NegocioBE Negocio = null;
            while (reader.Read())
            {
                Negocio = new NegocioBE();
                Negocio.IdNegocio = Int32.Parse(reader["idNegocio"].ToString());
                Negocio.DescNegocio = reader["descNegocio"].ToString();
                Negocio.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Negocio;
        }

        public NegocioBE SeleccionaParametros(string CODUNIDADP, string CODCENTROP)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Negocio_SeleccionaParametro");
            db.AddInParameter(dbCommand, "pCODUNIDADP", DbType.String, CODUNIDADP);
            db.AddInParameter(dbCommand, "pCODCENTROP", DbType.String, CODCENTROP);

            IDataReader reader = db.ExecuteReader(dbCommand);
            NegocioBE Negocio = null;
            while (reader.Read())
            {
                Negocio = new NegocioBE();
                Negocio.IdNegocio = Int32.Parse(reader["idNegocio"].ToString());
                Negocio.DescNegocio = reader["descNegocio"].ToString();
                Negocio.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Negocio.RazonSocial = reader["RazonSocial"].ToString();
                Negocio.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Negocio;
        }

        public List<NegocioBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Negocio_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<NegocioBE> Negociolist = new List<NegocioBE>();
            NegocioBE Negocio;
            while (reader.Read())
            {
                Negocio = new NegocioBE();
                Negocio.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Negocio.IdNegocio = Int32.Parse(reader["idNegocio"].ToString());
                Negocio.DescNegocio = reader["descNegocio"].ToString();
                Negocio.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Negociolist.Add(Negocio);
            }
            reader.Close();
            reader.Dispose();
            return Negociolist;
        }

        public List<NegocioBE> ListaCombo(int IdEmpresa, int IdNegocio)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Negocio_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdNegocio", DbType.Int32, IdNegocio);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<NegocioBE> Negociolist = new List<NegocioBE>();
            NegocioBE Negocio;
            while (reader.Read())
            {
                Negocio = new NegocioBE();
                Negocio.IdNegocio = Int32.Parse(reader["idNegocio"].ToString());
                Negocio.DescNegocio = reader["descNegocio"].ToString();
                Negocio.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Negociolist.Add(Negocio);
            }
            reader.Close();
            reader.Dispose();
            return Negociolist;
        }
    }
}
