using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class HoraTrabajadaDL
    {
        public HoraTrabajadaDL() { }

        public void Inserta(HoraTrabajadaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HoraTrabajada_Inserta");

            db.AddInParameter(dbCommand, "pIdHoraTrabajada", DbType.Int32, pItem.IdHoraTrabajada);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pHora", DbType.Int32, pItem.Hora);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
           

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(HoraTrabajadaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HoraTrabajada_Actualiza");

            db.AddInParameter(dbCommand, "pIdHoraTrabajada", DbType.Int32, pItem.IdHoraTrabajada);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pHora", DbType.Int32, pItem.Hora);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);


            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(int Perido, int Mes)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HoraTrabajada_Elimina");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Perido);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);
            

            db.ExecuteNonQuery(dbCommand);
        }

        public List<HoraTrabajadaBE> ListaTodosActivo(int Perido)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HoraTrabajada_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Perido);
           
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<HoraTrabajadaBE> HoraTrabajadalist = new List<HoraTrabajadaBE>();
            HoraTrabajadaBE HoraTrabajada;
            while (reader.Read())
            {
                HoraTrabajada = new HoraTrabajadaBE();
                HoraTrabajada.Mes = Int32.Parse(reader["Mes"].ToString());
                HoraTrabajada.DescMes = reader["DescMes"].ToString();
                HoraTrabajada.CROSLAND_LOGISTICA_SAC = Int32.Parse(reader["CROSLAND_LOGISTICA_SAC"].ToString());
                HoraTrabajada.CROSLAND_FINANZAS_SAC = Int32.Parse(reader["CROSLAND_FINANZAS_SAC"].ToString());
                HoraTrabajada.CROSLAND_REPUESTOS_SAC = Int32.Parse(reader["CROSLAND_REPUESTOS_SAC"].ToString());
                HoraTrabajada.CROSLAND_AUTOMOTRIZ_SAC = Int32.Parse(reader["CROSLAND_AUTOMOTRIZ_SAC"].ToString());
                HoraTrabajada.CROSLAND_TECNICA_SAC = Int32.Parse(reader["CROSLAND_TECNICA_SAC"].ToString());
                HoraTrabajadalist.Add(HoraTrabajada);
            }
            reader.Close();
            reader.Dispose();
            return HoraTrabajadalist;
        }

        public int SeleccionaHora(int IdEmpresa, int Periodo, int Mes)
        {
            int intRowCount = 0;
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_HoraTrabajada_SeleccionaHora");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, Mes);
            

            intRowCount = int.Parse(db.ExecuteScalar(dbCommand).ToString());
            return intRowCount;
        }
    }
}
