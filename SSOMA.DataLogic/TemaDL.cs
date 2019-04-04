using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class TemaDL
    {
        public TemaDL() { }

        public Int32 Inserta(TemaBE pItem)
        {
            Int32 intTema = 0;
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tema_Inserta");

            db.AddOutParameter(dbCommand, "pIdTema", DbType.Int32, pItem.IdTema);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCategoriaTema", DbType.Int32, pItem.IdCategoriaTema);
            db.AddInParameter(dbCommand, "pIdTipoTema", DbType.Int32, pItem.IdTipoTema);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pObjetivo", DbType.String, pItem.Objetivo);
            db.AddInParameter(dbCommand, "pDescTema", DbType.String, pItem.DescTema);
            db.AddInParameter(dbCommand, "pFechaIni", DbType.DateTime, pItem.FechaIni);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pHoras", DbType.Int32, pItem.Horas);
            db.AddInParameter(dbCommand, "pLogo", DbType.Binary, pItem.Logo);
            db.AddInParameter(dbCommand, "pFirma1", DbType.Binary, pItem.Firma1);
            db.AddInParameter(dbCommand, "pFirma2", DbType.Binary, pItem.Firma2);
            db.AddInParameter(dbCommand, "pResponsable", DbType.String, pItem.Responsable);
            db.AddInParameter(dbCommand, "pResponsableCargo", DbType.String, pItem.ResponsableCargo);
            db.AddInParameter(dbCommand, "pResponsableEmpresa", DbType.String, pItem.ResponsableEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoCapacitacion", DbType.Int32, pItem.IdTipoCapacitacion);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            intTema = (int)db.GetParameterValue(dbCommand, "pIdTema");

            return intTema;

        }

        public void Actualiza(TemaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tema_Actualiza");

            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, pItem.IdTema);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCategoriaTema", DbType.Int32, pItem.IdCategoriaTema);
            db.AddInParameter(dbCommand, "pIdTipoTema", DbType.Int32, pItem.IdTipoTema);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, pItem.Periodo);
            db.AddInParameter(dbCommand, "pObjetivo", DbType.String, pItem.Objetivo);
            db.AddInParameter(dbCommand, "pDescTema", DbType.String, pItem.DescTema);
            db.AddInParameter(dbCommand, "pFechaIni", DbType.DateTime, pItem.FechaIni);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pHoras", DbType.Int32, pItem.Horas);
            db.AddInParameter(dbCommand, "pLogo", DbType.Binary, pItem.Logo);
            db.AddInParameter(dbCommand, "pFirma1", DbType.Binary, pItem.Firma1);
            db.AddInParameter(dbCommand, "pFirma2", DbType.Binary, pItem.Firma2);
            db.AddInParameter(dbCommand, "pResponsable", DbType.String, pItem.Responsable);
            db.AddInParameter(dbCommand, "pResponsableCargo", DbType.String, pItem.ResponsableCargo);
            db.AddInParameter(dbCommand, "pResponsableEmpresa", DbType.String, pItem.ResponsableEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoCapacitacion", DbType.Int32, pItem.IdTipoCapacitacion);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaSituacion(int IdTema, int IdSituacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tema_ActualizaSituacion");

            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, IdTema);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(TemaBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tema_Elimina");

            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, pItem.IdTema);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public TemaBE Selecciona(int IdEmpresa, int idTema)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tema_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pidTema", DbType.Int32, idTema);

            IDataReader reader = db.ExecuteReader(dbCommand);
            TemaBE Tema = null;
            while (reader.Read())
            {
                Tema = new TemaBE();
                Tema.IdTema = Int32.Parse(reader["idTema"].ToString());
                Tema.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Tema.RazonSocial = reader["RazonSocial"].ToString();
                Tema.IdCategoriaTema = Int32.Parse(reader["IdCategoriaTema"].ToString());
                Tema.DescCategoriaTema = reader["DescCategoriaTema"].ToString();
                Tema.IdTipoTema = Int32.Parse(reader["IdTipoTema"].ToString());
                Tema.DescTipoTema = reader["DescTipoTema"].ToString();
                Tema.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Tema.Objetivo = reader["Objetivo"].ToString();
                Tema.DescTema = reader["descTema"].ToString();
                Tema.FechaIni = DateTime.Parse(reader["FechaIni"].ToString());
                Tema.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                Tema.Horas = Int32.Parse(reader["Horas"].ToString());
                Tema.Logo = (byte[])reader["Logo"];
                Tema.Firma1 = (byte[])reader["Firma1"];
                Tema.Firma2 = (byte[])reader["Firma2"];
                Tema.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Tema.DescSituacion = reader["DescSituacion"].ToString();
                Tema.Responsable = reader["Responsable"].ToString();
                Tema.ResponsableCargo = reader["ResponsableCargo"].ToString();
                Tema.ResponsableEmpresa = reader["ResponsableEmpresa"].ToString();
                Tema.IdTipoCapacitacion = Int32.Parse(reader["IdTipoCapacitacion"].ToString());
                Tema.DescTipoCapacitacion = reader["DescTipoCapacitacion"].ToString();
                Tema.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Tema;
        }

        public List<TemaBE> ListaTodosActivo(int IdEmpresa, int IdCategoriaTema, int IdTipoTema, int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tema_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdCategoriaTema", DbType.Int32, IdCategoriaTema);
            db.AddInParameter(dbCommand, "pIdTipoTema", DbType.Int32, IdTipoTema);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TemaBE> Temalist = new List<TemaBE>();
            TemaBE Tema;
            while (reader.Read())
            {
                Tema = new TemaBE();
                Tema.IdTema = Int32.Parse(reader["idTema"].ToString());
                Tema.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Tema.RazonSocial = reader["RazonSocial"].ToString();
                Tema.IdCategoriaTema = Int32.Parse(reader["IdCategoriaTema"].ToString());
                Tema.DescCategoriaTema = reader["DescCategoriaTema"].ToString();
                Tema.IdTipoTema = Int32.Parse(reader["IdTipoTema"].ToString());
                Tema.DescTipoTema = reader["DescTipoTema"].ToString();
                Tema.Periodo = Int32.Parse(reader["Periodo"].ToString());
                Tema.Objetivo = reader["Objetivo"].ToString();
                Tema.DescTema = reader["descTema"].ToString();
                Tema.FechaIni = DateTime.Parse(reader["FechaIni"].ToString());
                Tema.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                Tema.Horas = Int32.Parse(reader["Horas"].ToString());
                Tema.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Tema.DescSituacion = reader["DescSituacion"].ToString();
                Tema.Responsable = reader["Responsable"].ToString();
                Tema.ResponsableCargo = reader["ResponsableCargo"].ToString();
                Tema.ResponsableEmpresa = reader["ResponsableEmpresa"].ToString();
                Tema.IdTipoCapacitacion = Int32.Parse(reader["IdTipoCapacitacion"].ToString());
                Tema.DescTipoCapacitacion = reader["DescTipoCapacitacion"].ToString();
                Tema.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Temalist.Add(Tema);
            }
            reader.Close();
            reader.Dispose();
            return Temalist;
        }

        public List<TemaBE> ListaCombo(int IdEmpresa,int IdTipoTema, int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Tema_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTipoTema", DbType.Int32, IdTipoTema);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32,Periodo );

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<TemaBE> Temalist = new List<TemaBE>();
            TemaBE Tema;
            while (reader.Read())
            {
                Tema = new TemaBE();
                Tema.IdTema = Int32.Parse(reader["idTema"].ToString());
                Tema.DescTema = reader["descTema"].ToString();
                Temalist.Add(Tema);
            }
            reader.Close();
            reader.Dispose();
            return Temalist;
        }
    }
}
