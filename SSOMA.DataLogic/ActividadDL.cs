using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ActividadDL
    {
        public ActividadDL() { }

        public void Inserta(ActividadBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Actividad_Inserta");

            db.AddInParameter(dbCommand, "pIdActividad", DbType.Int32, pItem.IdActividad);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pIdSector", DbType.Int32, pItem.IdSector);
            db.AddInParameter(dbCommand, "pDescActividad", DbType.String, pItem.DescActividad);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(ActividadBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Actividad_Actualiza");

            db.AddInParameter(dbCommand, "pIdActividad", DbType.Int32, pItem.IdActividad);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pIdSector", DbType.Int32, pItem.IdSector);
            db.AddInParameter(dbCommand, "pDescActividad", DbType.String, pItem.DescActividad);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ActividadBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Actividad_Elimina");

            db.AddInParameter(dbCommand, "pIdActividad", DbType.Int32, pItem.IdActividad);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public ActividadBE Selecciona(int IdActividad)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Actividad_Selecciona");
            db.AddInParameter(dbCommand, "pidActividad", DbType.Int32, IdActividad);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ActividadBE Actividad = null;
            while (reader.Read())
            {
                Actividad = new ActividadBE();
                Actividad.IdActividad = Int32.Parse(reader["idActividad"].ToString());
                Actividad.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Actividad.RazonSocial = reader["RazonSocial"].ToString();
                Actividad.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Actividad.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Actividad.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Actividad.DescArea = reader["DescArea"].ToString();
                Actividad.IdSector = Int32.Parse(reader["IdSector"].ToString());
                Actividad.DescSector = reader["DescSector"].ToString();
                Actividad.DescActividad = reader["DescActividad"].ToString();
                Actividad.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Actividad;
        }

        public List<ActividadBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera, int IdArea, int IdSector)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Actividad_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);
            db.AddInParameter(dbCommand, "pIdSector", DbType.Int32, IdSector);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ActividadBE> Actividadlist = new List<ActividadBE>();
            ActividadBE Actividad;
            while (reader.Read())
            {
                Actividad = new ActividadBE();
                Actividad.IdActividad = Int32.Parse(reader["idActividad"].ToString());
                Actividad.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Actividad.RazonSocial = reader["RazonSocial"].ToString();
                Actividad.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                Actividad.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                Actividad.IdArea = Int32.Parse(reader["IdArea"].ToString());
                Actividad.DescArea = reader["DescArea"].ToString();
                Actividad.IdSector = Int32.Parse(reader["IdSector"].ToString());
                Actividad.DescSector = reader["DescSector"].ToString();
                Actividad.DescActividad = reader["DescActividad"].ToString();
                Actividad.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Actividadlist.Add(Actividad);
            }
            reader.Close();
            reader.Dispose();
            return Actividadlist;
        }
    }
}
