using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class TratamientoDL
    {
        public TratamientoDL() { }

        public void Inserta(TratamientoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tratamiento_Inserta");

            db.AddInParameter(dbCommand, "pIdTratamiento", DbType.Int32, pItem.IdTratamiento);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescTratamiento", DbType.String, pItem.DescTratamiento);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(TratamientoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tratamiento_Actualiza");

            db.AddInParameter(dbCommand, "pIdTratamiento", DbType.Int32, pItem.IdTratamiento);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescTratamiento", DbType.String, pItem.DescTratamiento);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(TratamientoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tratamiento_Elimina");

            db.AddInParameter(dbCommand, "pIdTratamiento", DbType.Int32, pItem.IdTratamiento);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public TratamientoBE Selecciona(int idTratamiento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tratamiento_Selecciona");
            db.AddInParameter(dbCommand, "pidTratamiento", DbType.Int32, idTratamiento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TratamientoBE Tratamiento = null;
            while (reader.Read())
            {
                Tratamiento = new TratamientoBE();
                Tratamiento.IdTratamiento = Int32.Parse(reader["idTratamiento"].ToString());
                Tratamiento.DescTratamiento = reader["descTratamiento"].ToString();
                Tratamiento.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Tratamiento;
        }

        public List<TratamientoBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tratamiento_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TratamientoBE> Tratamientolist = new List<TratamientoBE>();
            TratamientoBE Tratamiento;
            while (reader.Read())
            {
                Tratamiento = new TratamientoBE();
                Tratamiento.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Tratamiento.IdTratamiento = Int32.Parse(reader["idTratamiento"].ToString());
                Tratamiento.DescTratamiento = reader["descTratamiento"].ToString();
                Tratamiento.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Tratamientolist.Add(Tratamiento);
            }
            reader.Close();
            reader.Dispose();
            return Tratamientolist;
        }

        public List<TratamientoBE> ListaCombo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tratamiento_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TratamientoBE> Tratamientolist = new List<TratamientoBE>();
            TratamientoBE Tratamiento;
            while (reader.Read())
            {
                Tratamiento = new TratamientoBE();
                Tratamiento.IdTratamiento = Int32.Parse(reader["idTratamiento"].ToString());
                Tratamiento.DescTratamiento = reader["descTratamiento"].ToString();
                Tratamientolist.Add(Tratamiento);
            }
            reader.Close();
            reader.Dispose();
            return Tratamientolist;
        }
    }
}
