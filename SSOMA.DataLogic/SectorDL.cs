using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class SectorDL
    {
        public SectorDL() { }

        public void Inserta(SectorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Sector_Inserta");

            db.AddInParameter(dbCommand, "pIdSector", DbType.Int32, pItem.IdSector);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pDescSector", DbType.String, pItem.DescSector);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(SectorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Sector_Actualiza");

            db.AddInParameter(dbCommand, "pIdSector", DbType.Int32, pItem.IdSector);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pDescSector", DbType.String, pItem.DescSector);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(SectorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Sector_Elimina");

            db.AddInParameter(dbCommand, "pIdSector", DbType.Int32, pItem.IdSector);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public SectorBE Selecciona(int IdSector)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Sector_Selecciona");
            db.AddInParameter(dbCommand, "pidSector", DbType.Int32, IdSector);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SectorBE Sector = null;
            while (reader.Read())
            {
                Sector = new SectorBE();
                Sector.IdSector = Int32.Parse(reader["idSector"].ToString());
                Sector.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Sector.RazonSocial = reader["RazonSocial"].ToString();
                Sector.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Sector.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Sector.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Sector.DescArea = reader["DescArea"].ToString();
                Sector.DescSector = reader["descSector"].ToString();
                Sector.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Sector;
        }

        public SectorBE SeleccionaDescripcion(int IdEmpresa, int IdUnidadMinera, int IdArea, string DescSector)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Sector_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);
            db.AddInParameter(dbCommand, "pDescSector", DbType.String, DescSector);

            IDataReader reader = db.ExecuteReader(dbCommand);
            SectorBE Sector = null;
            while (reader.Read())
            {
                Sector = new SectorBE();
                Sector.IdSector = Int32.Parse(reader["idSector"].ToString());
                Sector.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Sector.RazonSocial = reader["RazonSocial"].ToString();
                Sector.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Sector.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Sector.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Sector.DescArea = reader["DescArea"].ToString();
                Sector.DescSector = reader["descSector"].ToString();
                Sector.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Sector;
        }

        public List<SectorBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Sector_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<SectorBE> Sectorlist = new List<SectorBE>();
            SectorBE Sector;
            while (reader.Read())
            {
                Sector = new SectorBE();
                Sector.IdSector = Int32.Parse(reader["idSector"].ToString());
                Sector.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Sector.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Sector.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Sector.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Sector.DescArea = reader["DescArea"].ToString();
                Sector.DescSector = reader["descSector"].ToString();
                Sector.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Sectorlist.Add(Sector);
            }
            reader.Close();
            reader.Dispose();
            return Sectorlist;
        }
    }
}
