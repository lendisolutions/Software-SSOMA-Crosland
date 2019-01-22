using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class CarpetaDL
    {
        public CarpetaDL() { }

        public void Inserta(CarpetaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Carpeta_Inserta");

            db.AddInParameter(dbCommand, "pIdCarpeta", DbType.Int32, pItem.IdCarpeta);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescCarpeta", DbType.String, pItem.DescCarpeta);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(CarpetaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Carpeta_Actualiza");

            db.AddInParameter(dbCommand, "pIdCarpeta", DbType.Int32, pItem.IdCarpeta);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescCarpeta", DbType.String, pItem.DescCarpeta);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(CarpetaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Carpeta_Elimina");

            db.AddInParameter(dbCommand, "pIdCarpeta", DbType.Int32, pItem.IdCarpeta);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public CarpetaBE Selecciona(int idCarpeta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Carpeta_Selecciona");
            db.AddInParameter(dbCommand, "pidCarpeta", DbType.Int32, idCarpeta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CarpetaBE Carpeta = null;
            while (reader.Read())
            {
                Carpeta = new CarpetaBE();
                Carpeta.IdCarpeta = Int32.Parse(reader["idCarpeta"].ToString());
                Carpeta.DescCarpeta = reader["descCarpeta"].ToString();
                Carpeta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Carpeta;
        }

        public List<CarpetaBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Carpeta_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CarpetaBE> Carpetalist = new List<CarpetaBE>();
            CarpetaBE Carpeta;
            while (reader.Read())
            {
                Carpeta = new CarpetaBE();
                Carpeta.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Carpeta.IdCarpeta = Int32.Parse(reader["idCarpeta"].ToString());
                Carpeta.DescCarpeta = reader["descCarpeta"].ToString();
                Carpeta.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Carpetalist.Add(Carpeta);
            }
            reader.Close();
            reader.Dispose();
            return Carpetalist;
        }

        public List<CarpetaBE> ListaCombo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Carpeta_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CarpetaBE> Carpetalist = new List<CarpetaBE>();
            CarpetaBE Carpeta;
            while (reader.Read())
            {
                Carpeta = new CarpetaBE();
                Carpeta.IdCarpeta = Int32.Parse(reader["idCarpeta"].ToString());
                Carpeta.DescCarpeta = reader["descCarpeta"].ToString();
                Carpetalist.Add(Carpeta);
            }
            reader.Close();
            reader.Dispose();
            return Carpetalist;
        }
    }
}
