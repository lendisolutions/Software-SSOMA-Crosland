using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class AreaEquipoDL
    {
        public AreaEquipoDL() { }

        public void Inserta(AreaEquipoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AreaEquipo_Inserta");

            db.AddInParameter(dbCommand, "pIdAreaEquipo", DbType.Int32, pItem.IdAreaEquipo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pIdEquipo", DbType.String, pItem.IdEquipo);
            db.AddInParameter(dbCommand, "pCodigo", DbType.String, pItem.Codigo);
            db.AddInParameter(dbCommand, "pDescEquipo", DbType.String, pItem.DescEquipo);
            db.AddInParameter(dbCommand, "pDias", DbType.Int32, pItem.Dias);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(AreaEquipoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AreaEquipo_Actualiza");

            db.AddInParameter(dbCommand, "pIdAreaEquipo", DbType.Int32, pItem.IdAreaEquipo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pIdEquipo", DbType.String, pItem.IdEquipo);
            db.AddInParameter(dbCommand, "pCodigo", DbType.String, pItem.Codigo);
            db.AddInParameter(dbCommand, "pDescEquipo", DbType.String, pItem.DescEquipo);
            db.AddInParameter(dbCommand, "pDias", DbType.Int32, pItem.Dias);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(AreaEquipoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AreaEquipo_Elimina");

            db.AddInParameter(dbCommand, "pIdAreaEquipo", DbType.Int32, pItem.IdAreaEquipo);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public AreaEquipoBE Selecciona(int IdAreaEquipo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AreaEquipo_Selecciona");
            db.AddInParameter(dbCommand, "pidAreaEquipo", DbType.Int32, IdAreaEquipo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            AreaEquipoBE AreaEquipo = null;
            while (reader.Read())
            {
                AreaEquipo = new AreaEquipoBE();
                AreaEquipo.IdAreaEquipo = Int32.Parse(reader["idAreaEquipo"].ToString());
                AreaEquipo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                AreaEquipo.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                AreaEquipo.IdArea = Int32.Parse(reader["IdArea"].ToString());
                AreaEquipo.IdEquipo = Int32.Parse(reader["IdEquipo"].ToString());
                AreaEquipo.Codigo = reader["Codigo"].ToString();
                AreaEquipo.DescEquipo = reader["DescEquipo"].ToString();
                AreaEquipo.Dias = Int32.Parse(reader["Dias"].ToString());
                AreaEquipo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return AreaEquipo;
        }

        public AreaEquipoBE SeleccionaEquipo(int IdEmpresa, int IdUnidadMinera, int IdArea, int IdEquipo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AreaEquipo_SeleccionaEquipo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);
            db.AddInParameter(dbCommand, "pIdEquipo", DbType.Int32, IdEquipo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            AreaEquipoBE AreaEquipo = null;
            while (reader.Read())
            {
                AreaEquipo = new AreaEquipoBE();
                AreaEquipo.IdAreaEquipo = Int32.Parse(reader["idAreaEquipo"].ToString());
                AreaEquipo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                AreaEquipo.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                AreaEquipo.IdArea = Int32.Parse(reader["IdArea"].ToString());
                AreaEquipo.IdEquipo = Int32.Parse(reader["IdEquipo"].ToString());
                AreaEquipo.Codigo = reader["Codigo"].ToString();
                AreaEquipo.DescEquipo = reader["DescEquipo"].ToString();
                AreaEquipo.Dias = Int32.Parse(reader["Dias"].ToString());
                AreaEquipo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return AreaEquipo;
        }

        public List<AreaEquipoBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AreaEquipo_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AreaEquipoBE> AreaEquipolist = new List<AreaEquipoBE>();
            AreaEquipoBE AreaEquipo;
            while (reader.Read())
            {
                AreaEquipo = new AreaEquipoBE();
                AreaEquipo.IdAreaEquipo = Int32.Parse(reader["idAreaEquipo"].ToString());
                AreaEquipo.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                AreaEquipo.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                AreaEquipo.IdArea = Int32.Parse(reader["IdArea"].ToString());
                AreaEquipo.IdEquipo = Int32.Parse(reader["IdEquipo"].ToString());
                AreaEquipo.Codigo = reader["Codigo"].ToString();
                AreaEquipo.DescEquipo = reader["DescEquipo"].ToString();
                AreaEquipo.Dias = Int32.Parse(reader["Dias"].ToString());
                AreaEquipo.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                AreaEquipolist.Add(AreaEquipo);
            }
            reader.Close();
            reader.Dispose();
            return AreaEquipolist;
        }
    }
}
