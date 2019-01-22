using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class AreaDL
    {
        public AreaDL() { }

        public void Inserta(AreaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Area_Inserta");

            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pDescArea", DbType.String, pItem.DescArea);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(AreaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Area_Actualiza");

            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pDescArea", DbType.String, pItem.DescArea);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(AreaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Area_Elimina");

            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public AreaBE Selecciona(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Area_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pidArea", DbType.Int32, IdArea);

            IDataReader reader = db.ExecuteReader(dbCommand);
            AreaBE Area = null;
            while (reader.Read())
            {
                Area = new AreaBE();
                Area.IdArea = Int32.Parse(reader["idArea"].ToString());
                Area.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Area.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Area.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Area.DescArea = reader["descArea"].ToString();
                Area.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Area;
        }

        public AreaBE SeleccionaDescripcion(int IdEmpresa, int IdUnidadMinera, string DescArea)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Area_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pDescArea", DbType.String, DescArea);

            IDataReader reader = db.ExecuteReader(dbCommand);
            AreaBE Area = null;
            while (reader.Read())
            {
                Area = new AreaBE();
                Area.IdArea = Int32.Parse(reader["idArea"].ToString());
                Area.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Area.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Area.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Area.DescArea = reader["descArea"].ToString();
                Area.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Area;
        }

        public List<AreaBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Area_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AreaBE> Arealist = new List<AreaBE>();
            AreaBE Area;
            while (reader.Read())
            {
                Area = new AreaBE();
                Area.IdArea = Int32.Parse(reader["idArea"].ToString());
                Area.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Area.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Area.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Area.DescArea = reader["descArea"].ToString();
                Area.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Arealist.Add(Area);
            }
            reader.Close();
            reader.Dispose();
            return Arealist;
        }
    }
}
