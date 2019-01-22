using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ReporteEquipoDL
    {
        public List<ReporteEquipoBE> Listado(int IdEmpresa)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_rptEquipo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ReporteEquipoBE> Equipolist = new List<ReporteEquipoBE>();
            ReporteEquipoBE Equipo;
            while (reader.Read())
            {
                Equipo = new ReporteEquipoBE();
                Equipo.Logo = (byte[])reader["Logo"];
                Equipo.Codigo = reader["Codigo"].ToString();
                Equipo.DescEquipo = reader["DescEquipo"].ToString();
                Equipo.Precio = Decimal.Parse(reader["Precio"].ToString());
                Equipolist.Add(Equipo);
            }
            reader.Close();
            reader.Dispose();
            return Equipolist;
        }
    }
}
