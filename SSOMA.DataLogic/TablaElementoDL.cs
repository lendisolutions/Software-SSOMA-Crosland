using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class TablaElementoDL
    {
        public TablaElementoDL() { }

        public Int32 Inserta(TablaElementoBE pItem)
        {
            Int32 intTablaElemento = 0;
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TablaElemento_Inserta");

            db.AddOutParameter(dbCommand, "pIdTablaElemento", DbType.Int32, pItem.IdTablaElemento);
            db.AddInParameter(dbCommand, "pIdTabla", DbType.Int32, pItem.IdTabla);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pDescTablaElemento", DbType.String, pItem.DescTablaElemento);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
            intTablaElemento = (int)db.GetParameterValue(dbCommand, "pIdTablaElemento");

            return intTablaElemento;
        }

        public void Actualiza(TablaElementoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TablaElemento_Actualiza");

            db.AddInParameter(dbCommand, "pIdTablaElemento", DbType.Int32, pItem.IdTablaElemento);
            db.AddInParameter(dbCommand, "pIdTabla", DbType.Int32, pItem.IdTabla);
            db.AddInParameter(dbCommand, "pAbreviatura", DbType.String, pItem.Abreviatura);
            db.AddInParameter(dbCommand, "pDescTablaElemento", DbType.String, pItem.DescTablaElemento);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);

            db.ExecuteNonQuery(dbCommand);
        }

        public void Elimina(TablaElementoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TablaElemento_Elimina");

            db.AddInParameter(dbCommand, "pIdTablaElemento", DbType.Int32, pItem.IdTablaElemento);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);
        }

        public TablaElementoBE SeleccionaDescripcion(int IdTabla, string DescTablaElemento)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TablaElemento_SeleccionaDescripcion");
            db.AddInParameter(dbCommand, "pIdTabla", DbType.Int32, IdTabla);
            db.AddInParameter(dbCommand, "pDescTablaElemento", DbType.String, DescTablaElemento);

            IDataReader reader = db.ExecuteReader(dbCommand);
            
            TablaElementoBE TablaElemento=null;
            while (reader.Read())
            {
                TablaElemento = new TablaElementoBE();
                TablaElemento.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                TablaElemento.IdTablaElemento = Int32.Parse(reader["idTablaElemento"].ToString());
                TablaElemento.IdTabla = Int32.Parse(reader["idTabla"].ToString());
                TablaElemento.DescTabla = reader["descTabla"].ToString();
                TablaElemento.Abreviatura = reader["Abreviatura"].ToString();
                TablaElemento.DescTablaElemento = reader["descTablaElemento"].ToString();
                TablaElemento.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
               
            }
            reader.Close();
            reader.Dispose();
            //TablaElementolist.Insert(0, new TablaElementoBE() { IdTablaElemento = 0, DescTablaElemento = "TODOS" });
            return TablaElemento;
        }

        public List<TablaElementoBE> ListaTodosActivo(int IdEmpresa, int IdTabla)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_TablaElemento_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTabla", DbType.Int32, IdTabla);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TablaElementoBE> TablaElementolist = new List<TablaElementoBE>();
            TablaElementoBE TablaElemento;
            while (reader.Read())
            {
                TablaElemento = new TablaElementoBE();
                TablaElemento.IdEmpresa = Int32.Parse(reader["idEmpresa"].ToString());
                TablaElemento.IdTablaElemento = Int32.Parse(reader["idTablaElemento"].ToString());
                TablaElemento.IdTabla = Int32.Parse(reader["idTabla"].ToString());
                TablaElemento.DescTabla = reader["descTabla"].ToString();
                TablaElemento.Abreviatura = reader["Abreviatura"].ToString();
                TablaElemento.DescTablaElemento = reader["descTablaElemento"].ToString();
                TablaElemento.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                TablaElementolist.Add(TablaElemento);
            }
            reader.Close();
            reader.Dispose();
            //TablaElementolist.Insert(0, new TablaElementoBE() { IdTablaElemento = 0, DescTablaElemento = "TODOS" });
            return TablaElementolist;
        }
    }
}
