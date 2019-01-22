using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class MesDL
    {
        public MesDL() { }

        public List<MesBE> ListaTodosActivo()
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Mes_ListaTodosActivo");


            IDataReader reader = db.ExecuteReader(dbCommand);
            List<MesBE> Meslist = new List<MesBE>();
            MesBE Mes;
            while (reader.Read())
            {
                Mes = new MesBE();
                Mes.Descripcion = reader["Descripcion"].ToString();
                Meslist.Add(Mes);
            }
            reader.Close();
            reader.Dispose();
            return Meslist;
        }
    }
}
