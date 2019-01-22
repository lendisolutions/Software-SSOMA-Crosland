using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class EquipoDL
    {
        public EquipoDL() { }

        public void Inserta(EquipoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Equipo_Inserta");

            db.AddInParameter(dbCommand, "pIdEquipo", DbType.Int32, pItem.IdEquipo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pCodigo", DbType.String, pItem.Codigo);
            db.AddInParameter(dbCommand, "pDescEquipo", DbType.String, pItem.DescEquipo);
            db.AddInParameter(dbCommand, "pPrecio", DbType.Decimal, pItem.Precio);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(EquipoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Equipo_Actualiza");

            db.AddInParameter(dbCommand, "pIdEquipo", DbType.Int32, pItem.IdEquipo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pCodigo", DbType.String, pItem.Codigo);
            db.AddInParameter(dbCommand, "pDescEquipo", DbType.String, pItem.DescEquipo);
            db.AddInParameter(dbCommand, "pPrecio", DbType.Decimal, pItem.Precio);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(EquipoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Equipo_Elimina");

            db.AddInParameter(dbCommand, "pIdEquipo", DbType.Int32, pItem.IdEquipo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public EquipoBE Selecciona(int IdEmpresa, int IdEquipo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Equipo_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdEquipo", DbType.Int32, IdEquipo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            EquipoBE Equipo = null;
            while (reader.Read())
            {
                Equipo = new EquipoBE();
                Equipo.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Equipo.IdEquipo = Int32.Parse(reader["idEquipo"].ToString());
                Equipo.Codigo = reader["Codigo"].ToString();
                Equipo.DescEquipo = reader["DescEquipo"].ToString();
                Equipo.Precio = Decimal.Parse(reader["Precio"].ToString());
                Equipo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());

            }
            reader.Close();
            reader.Dispose();
            return Equipo;
        }

        public List<EquipoBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Equipo_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<EquipoBE> Equipolist = new List<EquipoBE>();
            EquipoBE Equipo;
            while (reader.Read())
            {
                Equipo = new EquipoBE();
                Equipo.IdEmpresa = Int32.Parse(reader["idempresa"].ToString());
                Equipo.IdEquipo = Int32.Parse(reader["idEquipo"].ToString());
                Equipo.Codigo = reader["Codigo"].ToString();
                Equipo.DescEquipo = reader["DescEquipo"].ToString();
                Equipo.Precio = Decimal.Parse(reader["Precio"].ToString());
                Equipo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Equipolist.Add(Equipo);
            }
            reader.Close();
            reader.Dispose();
            return Equipolist;
        }
    }
}
