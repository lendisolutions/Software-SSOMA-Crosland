using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;


namespace SSOMA.DataLogic
{
    public class TemaPersonaDL
    {
        public TemaPersonaDL() { }

        public void Inserta(TemaPersonaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TemaPersona_Inserta");

            db.AddInParameter(dbCommand, "pIdTemaPersona", DbType.Int32, pItem.IdTemaPersona);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, pItem.IdTema);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pFlagMatricula", DbType.Boolean, pItem.FlagMatricula);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(TemaPersonaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TemaPersona_Actualiza");

            db.AddInParameter(dbCommand, "pIdTemaPersona", DbType.Int32, pItem.IdTemaPersona);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, pItem.IdTema);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pFlagMatricula", DbType.Boolean, pItem.FlagMatricula);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(TemaPersonaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TemaPersona_Elimina");

            db.AddInParameter(dbCommand, "pIdTemaPersona", DbType.Int32, pItem.IdTemaPersona);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public TemaPersonaBE Selecciona(int idTemaPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TemaPersona_Selecciona");
            db.AddInParameter(dbCommand, "pidTemaPersona", DbType.Int32, idTemaPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TemaPersonaBE TemaPersona = null;
            while (reader.Read())
            {
                TemaPersona = new TemaPersonaBE();
                TemaPersona.IdTemaPersona = Int32.Parse(reader["idTemaPersona"].ToString());
                TemaPersona.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                TemaPersona.IdTema = Int32.Parse(reader["IdTema"].ToString());
                TemaPersona.DescTema = reader["DescTema"].ToString();
                TemaPersona.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                TemaPersona.DescArea = reader["DescArea"].ToString();
                TemaPersona.Dni = reader["Dni"].ToString();
                TemaPersona.ApeNom = reader["ApeNom"].ToString();
                TemaPersona.FlagMatricula = Boolean.Parse(reader["FlagMatricula"].ToString());
                TemaPersona.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return TemaPersona;
        }

        public List<TemaPersonaBE> ListaTodosActivo(int IdEmpresa, int IdTema ,int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TemaPersona_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, IdTema);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);
            
            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TemaPersonaBE> TemaPersonalist = new List<TemaPersonaBE>();
            TemaPersonaBE TemaPersona;
            while (reader.Read())
            {
                TemaPersona = new TemaPersonaBE();
                TemaPersona.IdTemaPersona = Int32.Parse(reader["idTemaPersona"].ToString());
                TemaPersona.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                TemaPersona.IdTema = Int32.Parse(reader["IdTema"].ToString());
                TemaPersona.DescTema = reader["DescTema"].ToString();
                TemaPersona.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                TemaPersona.DescArea = reader["DescArea"].ToString();
                TemaPersona.Dni = reader["Dni"].ToString();
                TemaPersona.ApeNom = reader["ApeNom"].ToString();
                TemaPersona.FlagMatricula = Boolean.Parse(reader["FlagMatricula"].ToString());
                TemaPersona.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                TemaPersona.TipoOper = 4; //CONSULTAR
                TemaPersonalist.Add(TemaPersona);
            }
            reader.Close();
            reader.Dispose();
            return TemaPersonalist;
        }
    }
}
