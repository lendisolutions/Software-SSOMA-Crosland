using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class RiesgoDL
    {
        public RiesgoDL() { }

        public void Inserta(RiesgoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Riesgo_Inserta");

            db.AddInParameter(dbCommand, "pIdRiesgo", DbType.Int32, pItem.IdRiesgo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescRiesgo", DbType.String, pItem.DescRiesgo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(RiesgoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Riesgo_Actualiza");

            db.AddInParameter(dbCommand, "pIdRiesgo", DbType.Int32, pItem.IdRiesgo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescRiesgo", DbType.String, pItem.DescRiesgo);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(RiesgoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Riesgo_Elimina");

            db.AddInParameter(dbCommand, "pIdRiesgo", DbType.Int32, pItem.IdRiesgo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public RiesgoBE Selecciona(int idRiesgo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Riesgo_Selecciona");
            db.AddInParameter(dbCommand, "pidRiesgo", DbType.Int32, idRiesgo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            RiesgoBE Riesgo = null;
            while (reader.Read())
            {
                Riesgo = new RiesgoBE();
                Riesgo.IdRiesgo = Int32.Parse(reader["idRiesgo"].ToString());
                Riesgo.DescRiesgo = reader["descRiesgo"].ToString();
                Riesgo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Riesgo;
        }

        public List<RiesgoBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Riesgo_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<RiesgoBE> Riesgolist = new List<RiesgoBE>();
            RiesgoBE Riesgo;
            while (reader.Read())
            {
                Riesgo = new RiesgoBE();
                Riesgo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Riesgo.IdRiesgo = Int32.Parse(reader["idRiesgo"].ToString());
                Riesgo.DescRiesgo = reader["descRiesgo"].ToString();
                Riesgo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Riesgolist.Add(Riesgo);
            }
            reader.Close();
            reader.Dispose();
            return Riesgolist;
        }

        public List<RiesgoBE> ListaCombo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Riesgo_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<RiesgoBE> Riesgolist = new List<RiesgoBE>();
            RiesgoBE Riesgo;
            while (reader.Read())
            {
                Riesgo = new RiesgoBE();
                Riesgo.IdRiesgo = Int32.Parse(reader["idRiesgo"].ToString());
                Riesgo.DescRiesgo = reader["descRiesgo"].ToString();
                Riesgolist.Add(Riesgo);
            }
            reader.Close();
            reader.Dispose();
            return Riesgolist;
        }
    }
}
