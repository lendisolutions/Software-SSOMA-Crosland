using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ServicioExtintorDL
    {
        public ServicioExtintorDL() { }

        public void Inserta(ServicioExtintorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ServicioExtintor_Inserta");

            db.AddInParameter(dbCommand, "pIdServicioExtintor", DbType.Int32, pItem.IdServicioExtintor);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescServicioExtintor", DbType.String, pItem.DescServicioExtintor);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(ServicioExtintorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ServicioExtintor_Actualiza");

            db.AddInParameter(dbCommand, "pIdServicioExtintor", DbType.Int32, pItem.IdServicioExtintor);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pDescServicioExtintor", DbType.String, pItem.DescServicioExtintor);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ServicioExtintorBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ServicioExtintor_Elimina");

            db.AddInParameter(dbCommand, "pIdServicioExtintor", DbType.Int32, pItem.IdServicioExtintor);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public ServicioExtintorBE Selecciona(int IdEmpresa, int idServicioExtintor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ServicioExtintor_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pidServicioExtintor", DbType.Int32, idServicioExtintor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ServicioExtintorBE ServicioExtintor = null;
            while (reader.Read())
            {
                ServicioExtintor = new ServicioExtintorBE();
                ServicioExtintor.IdServicioExtintor = Int32.Parse(reader["idServicioExtintor"].ToString());
                ServicioExtintor.DescServicioExtintor = reader["descServicioExtintor"].ToString();
                ServicioExtintor.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ServicioExtintor;
        }

        public ServicioExtintorBE SeleccionaParametros(string CODUNIDADP, string CODCENTROP)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ServicioExtintor_SeleccionaParametro");
            db.AddInParameter(dbCommand, "pCODUNIDADP", DbType.String, CODUNIDADP);
            db.AddInParameter(dbCommand, "pCODCENTROP", DbType.String, CODCENTROP);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ServicioExtintorBE ServicioExtintor = null;
            while (reader.Read())
            {
                ServicioExtintor = new ServicioExtintorBE();
                ServicioExtintor.IdServicioExtintor = Int32.Parse(reader["idServicioExtintor"].ToString());
                ServicioExtintor.DescServicioExtintor = reader["descServicioExtintor"].ToString();
                ServicioExtintor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ServicioExtintor.RazonSocial = reader["RazonSocial"].ToString();
                ServicioExtintor.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ServicioExtintor;
        }

        public List<ServicioExtintorBE> ListaTodosActivo(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ServicioExtintor_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ServicioExtintorBE> ServicioExtintorlist = new List<ServicioExtintorBE>();
            ServicioExtintorBE ServicioExtintor;
            while (reader.Read())
            {
                ServicioExtintor = new ServicioExtintorBE();
                ServicioExtintor.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ServicioExtintor.IdServicioExtintor = Int32.Parse(reader["idServicioExtintor"].ToString());
                ServicioExtintor.DescServicioExtintor = reader["descServicioExtintor"].ToString();
                ServicioExtintor.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ServicioExtintorlist.Add(ServicioExtintor);
            }
            reader.Close();
            reader.Dispose();
            return ServicioExtintorlist;
        }

        public List<ServicioExtintorBE> ListaCombo(int IdEmpresa, int IdServicioExtintor)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ServicioExtintor_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdServicioExtintor", DbType.Int32, IdServicioExtintor);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ServicioExtintorBE> ServicioExtintorlist = new List<ServicioExtintorBE>();
            ServicioExtintorBE ServicioExtintor;
            while (reader.Read())
            {
                ServicioExtintor = new ServicioExtintorBE();
                ServicioExtintor.IdServicioExtintor = Int32.Parse(reader["idServicioExtintor"].ToString());
                ServicioExtintor.DescServicioExtintor = reader["descServicioExtintor"].ToString();
                ServicioExtintor.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ServicioExtintorlist.Add(ServicioExtintor);
            }
            reader.Close();
            reader.Dispose();
            return ServicioExtintorlist;
        }
    }
}
