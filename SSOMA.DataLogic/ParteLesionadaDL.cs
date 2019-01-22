using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ParteLesionadaDL
    {
        public ParteLesionadaDL() { }

        public void Inserta(ParteLesionadaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ParteLesionada_Inserta");

            db.AddInParameter(dbCommand, "pIdParteLesionada", DbType.Int32, pItem.IdParteLesionada);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescParteLesionada", DbType.String, pItem.DescParteLesionada);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(ParteLesionadaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ParteLesionada_Actualiza");

            db.AddInParameter(dbCommand, "pIdParteLesionada", DbType.Int32, pItem.IdParteLesionada);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescParteLesionada", DbType.String, pItem.DescParteLesionada);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ParteLesionadaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ParteLesionada_Elimina");

            db.AddInParameter(dbCommand, "pIdParteLesionada", DbType.Int32, pItem.IdParteLesionada);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public ParteLesionadaBE Selecciona(int idParteLesionada)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ParteLesionada_Selecciona");
            db.AddInParameter(dbCommand, "pidParteLesionada", DbType.Int32, idParteLesionada);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ParteLesionadaBE ParteLesionada = null;
            while (reader.Read())
            {
                ParteLesionada = new ParteLesionadaBE();
                ParteLesionada.IdParteLesionada = Int32.Parse(reader["idParteLesionada"].ToString());
                ParteLesionada.DescParteLesionada = reader["descParteLesionada"].ToString();
                ParteLesionada.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ParteLesionada;
        }

        public List<ParteLesionadaBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ParteLesionada_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ParteLesionadaBE> ParteLesionadalist = new List<ParteLesionadaBE>();
            ParteLesionadaBE ParteLesionada;
            while (reader.Read())
            {
                ParteLesionada = new ParteLesionadaBE();
                ParteLesionada.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ParteLesionada.IdParteLesionada = Int32.Parse(reader["idParteLesionada"].ToString());
                ParteLesionada.DescParteLesionada = reader["descParteLesionada"].ToString();
                ParteLesionada.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ParteLesionadalist.Add(ParteLesionada);
            }
            reader.Close();
            reader.Dispose();
            return ParteLesionadalist;
        }

        public List<ParteLesionadaBE> ListaCombo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ParteLesionada_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ParteLesionadaBE> ParteLesionadalist = new List<ParteLesionadaBE>();
            ParteLesionadaBE ParteLesionada;
            while (reader.Read())
            {
                ParteLesionada = new ParteLesionadaBE();
                ParteLesionada.IdParteLesionada = Int32.Parse(reader["idParteLesionada"].ToString());
                ParteLesionada.DescParteLesionada = reader["descParteLesionada"].ToString();
                ParteLesionadalist.Add(ParteLesionada);
            }
            reader.Close();
            reader.Dispose();
            return ParteLesionadalist;
        }
    }
}
