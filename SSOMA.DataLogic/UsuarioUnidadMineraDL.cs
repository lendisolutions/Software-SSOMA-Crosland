using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class UsuarioUnidadMineraDL
    {
        public UsuarioUnidadMineraDL() { }

        public void Inserta(UsuarioUnidadMineraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_UsuarioUnidadMinera_Inserta");

            db.AddInParameter(dbCommand, "pIdUsuarioUnidadMinera", DbType.Int32, pItem.IdUsuarioUnidadMinera);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUser", DbType.Int32, pItem.IdUser);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);


            db.ExecuteNonQuery(dbCommand);
        }

        public void Actualiza(UsuarioUnidadMineraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_UsuarioUnidadMinera_Actualiza");

            db.AddInParameter(dbCommand, "pIdUsuarioUnidadMinera", DbType.Int32, pItem.IdUsuarioUnidadMinera);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUser", DbType.Int32, pItem.IdUser);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(UsuarioUnidadMineraBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_UsuarioUnidadMinera_Elimina");

            db.AddInParameter(dbCommand, "pIdUsuarioUnidadMinera", DbType.Int32, pItem.IdUsuarioUnidadMinera);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);


            db.ExecuteNonQuery(dbCommand);
        }

        public List<UsuarioUnidadMineraBE> ListaEmpresaUusuario(int IdEmpresa, int IdUser)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_UsuarioUnidadMinera_ListaEmpresaUsuario");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUser", DbType.Int32, IdUser);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<UsuarioUnidadMineraBE> UsuarioUnidadMineralist = new List<UsuarioUnidadMineraBE>();
            UsuarioUnidadMineraBE UsuarioUnidadMinera;
            while (reader.Read())
            {
                UsuarioUnidadMinera = new UsuarioUnidadMineraBE();
                UsuarioUnidadMinera.IdUsuarioUnidadMinera = Int32.Parse(reader["IdUsuarioUnidadMinera"].ToString());
                UsuarioUnidadMinera.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                UsuarioUnidadMinera.IdUser = Int32.Parse(reader["IdUser"].ToString());
                UsuarioUnidadMinera.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                UsuarioUnidadMinera.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                UsuarioUnidadMinera.TipoOper = 4;
                UsuarioUnidadMineralist.Add(UsuarioUnidadMinera);
            }
            reader.Close();
            reader.Dispose();
            return UsuarioUnidadMineralist;
        }

        public List<UsuarioUnidadMineraBE> ListaEmpresaUnidadUusuario(int IdEmpresa, int IdUnidadMinera, int IdUser)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_UsuarioUnidadMinera_ListaEmpresaUnidadUsuario");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdUser", DbType.Int32, IdUser);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<UsuarioUnidadMineraBE> UsuarioUnidadMineralist = new List<UsuarioUnidadMineraBE>();
            UsuarioUnidadMineraBE UsuarioUnidadMinera;
            while (reader.Read())
            {
                UsuarioUnidadMinera = new UsuarioUnidadMineraBE();
                UsuarioUnidadMinera.IdUsuarioUnidadMinera = Int32.Parse(reader["IdUsuarioUnidadMinera"].ToString());
                UsuarioUnidadMinera.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                UsuarioUnidadMinera.IdUser = Int32.Parse(reader["IdUser"].ToString());
                UsuarioUnidadMinera.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                UsuarioUnidadMinera.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                UsuarioUnidadMinera.TipoOper = 4;
                UsuarioUnidadMineralist.Add(UsuarioUnidadMinera);
            }
            reader.Close();
            reader.Dispose();
            return UsuarioUnidadMineralist;
        }

        public List<UsuarioUnidadMineraBE> ListaUusuario(int IdUser)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_UsuarioUnidadMinera_ListaUsuario");
            db.AddInParameter(dbCommand, "pIdUser", DbType.Int32, IdUser);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<UsuarioUnidadMineraBE> UsuarioUnidadMineralist = new List<UsuarioUnidadMineraBE>();
            UsuarioUnidadMineraBE UsuarioUnidadMinera;
            while (reader.Read())
            {
                UsuarioUnidadMinera = new UsuarioUnidadMineraBE();
                UsuarioUnidadMinera.IdUsuarioUnidadMinera = Int32.Parse(reader["IdUsuarioUnidadMinera"].ToString());
                UsuarioUnidadMinera.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                UsuarioUnidadMinera.IdUser = Int32.Parse(reader["IdUser"].ToString());
                UsuarioUnidadMinera.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                UsuarioUnidadMinera.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                UsuarioUnidadMinera.TipoOper = 4;
                UsuarioUnidadMineralist.Add(UsuarioUnidadMinera);
            }
            reader.Close();
            reader.Dispose();
            return UsuarioUnidadMineralist;
        }
    }
}
