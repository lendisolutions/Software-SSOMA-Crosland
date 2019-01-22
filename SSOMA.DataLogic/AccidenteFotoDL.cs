using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class AccidenteFotoDL
    {
        public AccidenteFotoDL() { }

        public void Inserta(AccidenteFotoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteFoto_Inserta");

            db.AddInParameter(dbCommand, "pIdAccidenteFoto", DbType.Int32, pItem.IdAccidenteFoto);
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, pItem.IdAccidente);
            db.AddInParameter(dbCommand, "pFoto", DbType.Binary, pItem.Foto);
            db.AddInParameter(dbCommand, "pDescripcionFoto", DbType.String, pItem.DescripcionFoto);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(AccidenteFotoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteFoto_Actualiza");

            db.AddInParameter(dbCommand, "pIdAccidenteFoto", DbType.Int32, pItem.IdAccidenteFoto);
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, pItem.IdAccidente);
            db.AddInParameter(dbCommand, "pFoto", DbType.Binary, pItem.Foto);
            db.AddInParameter(dbCommand, "pDescripcionFoto", DbType.String, pItem.DescripcionFoto);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(AccidenteFotoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteFoto_Elimina");

            db.AddInParameter(dbCommand, "pIdAccidenteFoto", DbType.Int32, pItem.IdAccidenteFoto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public AccidenteFotoBE Selecciona(int IdAccidenteFoto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteFoto_Selecciona");
            db.AddInParameter(dbCommand, "pidAccidenteFoto", DbType.Int32, IdAccidenteFoto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            AccidenteFotoBE AccidenteFoto = null;
            while (reader.Read())
            {
                AccidenteFoto = new AccidenteFotoBE();
                AccidenteFoto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                AccidenteFoto.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                AccidenteFoto.IdAccidenteFoto = Int32.Parse(reader["idAccidenteFoto"].ToString());
                AccidenteFoto.Foto = (byte[])reader["Foto"];
                AccidenteFoto.DescripcionFoto = reader["DescripcionFoto"].ToString();
                AccidenteFoto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return AccidenteFoto;
        }

        public List<AccidenteFotoBE> ListaTodosActivo(int IdAccidente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteFoto_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, IdAccidente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccidenteFotoBE> AccidenteFotolist = new List<AccidenteFotoBE>();
            AccidenteFotoBE AccidenteFoto;
            while (reader.Read())
            {
                AccidenteFoto = new AccidenteFotoBE();
                AccidenteFoto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                AccidenteFoto.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                AccidenteFoto.IdAccidenteFoto = Int32.Parse(reader["idAccidenteFoto"].ToString());
                AccidenteFoto.Foto = (byte[])reader["Foto"];
                AccidenteFoto.DescripcionFoto = reader["DescripcionFoto"].ToString();
                AccidenteFoto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                AccidenteFoto.TipoOper = 4; //CONSULTAR
                AccidenteFotolist.Add(AccidenteFoto);
            }
            reader.Close();
            reader.Dispose();
            return AccidenteFotolist;
        }
    }
}
