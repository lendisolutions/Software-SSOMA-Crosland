using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ResumenPersonaDL
    {
        public ResumenPersonaDL() { }

        public void Inserta(ResumenPersonaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ResumenPersona_Inserta");

            db.AddInParameter(dbCommand, "pIdResumenPersona", DbType.Int32, pItem.IdResumenPersona);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, pItem.IdTema);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pNotaFinal", DbType.Int32, pItem.NotaFinal);
            db.AddInParameter(dbCommand, "pSituacion", DbType.String, pItem.Situacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
           
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(ResumenPersonaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ResumenPersona_Actualiza");

            db.AddInParameter(dbCommand, "pIdResumenPersona", DbType.Int32, pItem.IdResumenPersona);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, pItem.IdTema);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pNotaFinal", DbType.Int32, pItem.NotaFinal);
            db.AddInParameter(dbCommand, "pSituacion", DbType.String, pItem.Situacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

        }

        public void Elimina(ResumenPersonaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ResumenPersona_Elimina");

            db.AddInParameter(dbCommand, "pIdResumenPersona", DbType.Int32, pItem.IdResumenPersona);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public ResumenPersonaBE Selecciona(int IdResumenPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ResumenPersona_Selecciona");
            db.AddInParameter(dbCommand, "pidResumenPersona", DbType.Int32, IdResumenPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ResumenPersonaBE ResumenPersona = null;
            while (reader.Read())
            {
                ResumenPersona = new ResumenPersonaBE();
                ResumenPersona.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ResumenPersona.IdResumenPersona = Int32.Parse(reader["idResumenPersona"].ToString());
                ResumenPersona.IdTema = Int32.Parse(reader["IdTema"].ToString());
                ResumenPersona.DescTema = reader["DescTema"].ToString();
                ResumenPersona.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                ResumenPersona.ApeNom = reader["ApeNom"].ToString();
                ResumenPersona.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                ResumenPersona.NotaFinal = Int32.Parse(reader["NotaFinal"].ToString());
                ResumenPersona.Situacion = reader["Situacion"].ToString();
                ResumenPersona.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ResumenPersona;
        }

        public List<ResumenPersonaBE> ListaTodosActivo(int IdEmpresa, int IdTema, int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ResumenPersona_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, IdTema);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ResumenPersonaBE> ResumenPersonalist = new List<ResumenPersonaBE>();
            ResumenPersonaBE ResumenPersona;
            while (reader.Read())
            {
                ResumenPersona = new ResumenPersonaBE();
                ResumenPersona.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ResumenPersona.IdResumenPersona = Int32.Parse(reader["idResumenPersona"].ToString());
                ResumenPersona.IdTema = Int32.Parse(reader["IdTema"].ToString());
                ResumenPersona.DescTema = reader["DescTema"].ToString();
                ResumenPersona.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                ResumenPersona.ApeNom = reader["ApeNom"].ToString();
                ResumenPersona.Fecha = DateTime.Parse(reader["Fecha"].ToString());
                ResumenPersona.NotaFinal = Int32.Parse(reader["NotaFinal"].ToString());
                ResumenPersona.Situacion = reader["Situacion"].ToString();
                ResumenPersona.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ResumenPersonalist.Add(ResumenPersona);
            }
            reader.Close();
            reader.Dispose();
            return ResumenPersonalist;
        }
    }
}
