using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class CapacitacionDetalleDL
    {
        public void Inserta(CapacitacionDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CapacitacionDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdCapacitacionDetalle", DbType.Int32, pItem.IdCapacitacionDetalle);
            db.AddInParameter(dbCommand, "pIdCapacitacion", DbType.Int32, pItem.IdCapacitacion);
            db.AddInParameter(dbCommand, "pItem", DbType.Int32, pItem.Item);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pCodigo", DbType.String, pItem.Codigo);
            db.AddInParameter(dbCommand, "pApeNom", DbType.String, pItem.ApeNom);
            db.AddInParameter(dbCommand, "pDescArea", DbType.String, pItem.DescArea);
            db.AddInParameter(dbCommand, "pNota", DbType.Int32, pItem.Nota);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(CapacitacionDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CapacitacionDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdCapacitacionDetalle", DbType.Int32, pItem.IdCapacitacionDetalle);
            db.AddInParameter(dbCommand, "pIdCapacitacion", DbType.Int32, pItem.IdCapacitacion);
            db.AddInParameter(dbCommand, "pItem", DbType.Int32, pItem.Item);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pCodigo", DbType.String, pItem.Codigo);
            db.AddInParameter(dbCommand, "pApeNom", DbType.String, pItem.ApeNom);
            db.AddInParameter(dbCommand, "pDescArea", DbType.String, pItem.DescArea);
            db.AddInParameter(dbCommand, "pNota", DbType.Int32, pItem.Nota);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(CapacitacionDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CapacitacionDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdCapacitacionDetalle", DbType.Int32, pItem.IdCapacitacionDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public CapacitacionDetalleBE Selecciona(int IdCapacitacionDetalle)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CapacitacionDetalle_Selecciona");
            db.AddInParameter(dbCommand, "pidCapacitacionDetalle", DbType.Int32, IdCapacitacionDetalle);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CapacitacionDetalleBE CapacitacionDetalle = null;
            while (reader.Read())
            {
                CapacitacionDetalle = new CapacitacionDetalleBE();
                CapacitacionDetalle.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                CapacitacionDetalle.IdCapacitacion = Int32.Parse(reader["idCapacitacion"].ToString());
                CapacitacionDetalle.IdCapacitacionDetalle = Int32.Parse(reader["idCapacitacionDetalle"].ToString());
                CapacitacionDetalle.Item = Int32.Parse(reader["Item"].ToString());
                CapacitacionDetalle.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                CapacitacionDetalle.Codigo = reader["Codigo"].ToString();
                CapacitacionDetalle.ApeNom = reader["ApeNom"].ToString();
                CapacitacionDetalle.DescArea = reader["DescArea"].ToString();
                CapacitacionDetalle.Nota = Int32.Parse(reader["Nota"].ToString());
                CapacitacionDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return CapacitacionDetalle;
        }

        public List<CapacitacionDetalleBE> ListaTodosActivo(int IdCapacitacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_CapacitacionDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdCapacitacion", DbType.Int32, IdCapacitacion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CapacitacionDetalleBE> CapacitacionDetallelist = new List<CapacitacionDetalleBE>();
            CapacitacionDetalleBE CapacitacionDetalle;
            while (reader.Read())
            {
                CapacitacionDetalle = new CapacitacionDetalleBE();
                CapacitacionDetalle.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                CapacitacionDetalle.IdCapacitacion = Int32.Parse(reader["idCapacitacion"].ToString());
                CapacitacionDetalle.IdCapacitacionDetalle = Int32.Parse(reader["idCapacitacionDetalle"].ToString());
                CapacitacionDetalle.Item = Int32.Parse(reader["Item"].ToString());
                CapacitacionDetalle.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                CapacitacionDetalle.Codigo = reader["Codigo"].ToString();
                CapacitacionDetalle.ApeNom = reader["ApeNom"].ToString();
                CapacitacionDetalle.DescArea = reader["DescArea"].ToString();
                CapacitacionDetalle.Nota = Int32.Parse(reader["Nota"].ToString());
                CapacitacionDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                CapacitacionDetalle.TipoOper = 4; //CONSULTAR
                CapacitacionDetallelist.Add(CapacitacionDetalle);
            }
            reader.Close();
            reader.Dispose();
            return CapacitacionDetallelist;
        }

    }
}
