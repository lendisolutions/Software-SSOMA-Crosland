using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class DescansoMedicoDL
    {
        public DescansoMedicoDL() { }

        public Int32 Inserta(DescansoMedicoBE pItem)
        {
            Int32 intIdDescansoMedico = 0;
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescansoMedico_Inserta");

            db.AddOutParameter(dbCommand, "pIdDescansoMedico", DbType.Int32, pItem.IdDescansoMedico);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdTipoDescansoMedico", DbType.Int32, pItem.IdTipoDescansoMedico);
            db.AddInParameter(dbCommand, "pFechaIni", DbType.DateTime, pItem.FechaIni);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pDias", DbType.Int32, pItem.Dias);
            db.AddInParameter(dbCommand, "pHoras", DbType.Int32, pItem.Horas);
            db.AddInParameter(dbCommand, "pSueldo", DbType.Decimal, pItem.Sueldo);
            db.AddInParameter(dbCommand, "pKpi", DbType.Decimal, pItem.Kpi);
            db.AddInParameter(dbCommand, "pIdContingencia", DbType.Int32, pItem.IdContingencia);
            db.AddInParameter(dbCommand, "pDiagnostico", DbType.String, pItem.Diagnostico);
            db.AddInParameter(dbCommand, "pCentroMedico", DbType.String, pItem.CentroMedico);
            db.AddInParameter(dbCommand, "pIdCategoriaDiagnostico", DbType.Int32, pItem.IdCategoriaDiagnostico);
            db.AddInParameter(dbCommand, "pIdCondicionDescansoMedico", DbType.Int32, pItem.IdCondicionDescansoMedico);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

            intIdDescansoMedico = (int)db.GetParameterValue(dbCommand, "pIdDescansoMedico");

            return intIdDescansoMedico;

        }

        public void Actualiza(DescansoMedicoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescansoMedico_Actualiza");

            db.AddInParameter(dbCommand, "pIdDescansoMedico", DbType.Int32, pItem.IdDescansoMedico);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, pItem.Numero);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, pItem.IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, pItem.IdArea);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, pItem.IdPersona);
            db.AddInParameter(dbCommand, "pIdTipoDescansoMedico", DbType.Int32, pItem.IdTipoDescansoMedico);
            db.AddInParameter(dbCommand, "pFechaIni", DbType.DateTime, pItem.FechaIni);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pMes", DbType.Int32, pItem.Mes);
            db.AddInParameter(dbCommand, "pDias", DbType.Int32, pItem.Dias);
            db.AddInParameter(dbCommand, "pHoras", DbType.Int32, pItem.Horas);
            db.AddInParameter(dbCommand, "pSueldo", DbType.Decimal, pItem.Sueldo);
            db.AddInParameter(dbCommand, "pKpi", DbType.Decimal, pItem.Kpi);
            db.AddInParameter(dbCommand, "pIdContingencia", DbType.Int32, pItem.IdContingencia);
            db.AddInParameter(dbCommand, "pDiagnostico", DbType.String, pItem.Diagnostico);
            db.AddInParameter(dbCommand, "pCentroMedico", DbType.String, pItem.CentroMedico);
            db.AddInParameter(dbCommand, "pIdCategoriaDiagnostico", DbType.Int32, pItem.IdCategoriaDiagnostico);
            db.AddInParameter(dbCommand, "pIdCondicionDescansoMedico", DbType.Int32, pItem.IdCondicionDescansoMedico);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaNumero(int IdDescansoMedico, string Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescansoMedico_ActualizaNumero");

            db.AddInParameter(dbCommand, "pIdDescansoMedico", DbType.Int32, IdDescansoMedico);
            db.AddInParameter(dbCommand, "pNumero", DbType.String, Numero);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaSituacion(int IdDescansoMedico, int IdCondicionDescansoMedico)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescansoMedico_ActualizaSituacion");

            db.AddInParameter(dbCommand, "pIdDescansoMedico", DbType.Int32, IdDescansoMedico);
            db.AddInParameter(dbCommand, "pIdCondicionDescansoMedico", DbType.Int32, IdCondicionDescansoMedico);

            db.ExecuteNonQuery(dbCommand);

        }
        public void Elimina(DescansoMedicoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescansoMedico_Elimina");

            db.AddInParameter(dbCommand, "pIdDescansoMedico", DbType.Int32, pItem.IdDescansoMedico);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public DescansoMedicoBE Selecciona(int idDescansoMedico)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescansoMedico_Selecciona");
            db.AddInParameter(dbCommand, "pidDescansoMedico", DbType.Int32, idDescansoMedico);

            IDataReader reader = db.ExecuteReader(dbCommand);
            DescansoMedicoBE DescansoMedico = null;
            while (reader.Read())
            {
                DescansoMedico = new DescansoMedicoBE();
                DescansoMedico.IdDescansoMedico = Int32.Parse(reader["idDescansoMedico"].ToString());
                DescansoMedico.Numero = reader["Numero"].ToString();
                DescansoMedico.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                DescansoMedico.RazonSocial = reader["RazonSocial"].ToString();
                DescansoMedico.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                DescansoMedico.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                DescansoMedico.IdArea = Int32.Parse(reader["IdArea"].ToString());
                DescansoMedico.DescArea = reader["DescArea"].ToString();
                DescansoMedico.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                DescansoMedico.ApeNom = reader["ApeNom"].ToString();
                DescansoMedico.Cargo = reader["Cargo"].ToString();
                DescansoMedico.IdTipoDescansoMedico = Int32.Parse(reader["IdTipoDescansoMedico"].ToString());
                DescansoMedico.DescTipoDescansoMedico = reader["DescTipoDescansoMedico"].ToString();
                DescansoMedico.FechaIni = DateTime.Parse(reader["FechaIni"].ToString());
                DescansoMedico.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                DescansoMedico.Mes = Int32.Parse(reader["Mes"].ToString());
                DescansoMedico.DescMes = reader["DescMes"].ToString();
                DescansoMedico.Dias = Int32.Parse(reader["Dias"].ToString());
                DescansoMedico.Horas = Int32.Parse(reader["Horas"].ToString());
                DescansoMedico.Sueldo = Decimal.Parse(reader["Sueldo"].ToString());
                DescansoMedico.Kpi = Decimal.Parse(reader["Kpi"].ToString());
                DescansoMedico.IdContingencia = Int32.Parse(reader["IdContingencia"].ToString());
                DescansoMedico.DescContingencia = reader["DescContingencia"].ToString();
                DescansoMedico.Diagnostico = reader["Diagnostico"].ToString();
                DescansoMedico.CentroMedico = reader["CentroMedico"].ToString();
                DescansoMedico.IdCategoriaDiagnostico = Int32.Parse(reader["IdCategoriaDiagnostico"].ToString());
                DescansoMedico.Abreviatura = reader["Abreviatura"].ToString();
                DescansoMedico.IdCondicionDescansoMedico = Int32.Parse(reader["IdCondicionDescansoMedico"].ToString());
                DescansoMedico.DescCondicionDescansoMedico = reader["DescCondicionDescansoMedico"].ToString();
                DescansoMedico.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return DescansoMedico;
        }

        public DescansoMedicoBE SeleccionaNumero(int Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescansoMedico_SeleccionaNumero");
            db.AddInParameter(dbCommand, "pNumero", DbType.Int32, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            DescansoMedicoBE DescansoMedico = null;
            while (reader.Read())
            {
                DescansoMedico = new DescansoMedicoBE();
                DescansoMedico.IdDescansoMedico = Int32.Parse(reader["idDescansoMedico"].ToString());
                DescansoMedico.Numero = reader["Numero"].ToString();
                DescansoMedico.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                DescansoMedico.RazonSocial = reader["RazonSocial"].ToString();
                DescansoMedico.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                DescansoMedico.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                DescansoMedico.IdArea = Int32.Parse(reader["IdArea"].ToString());
                DescansoMedico.DescArea = reader["DescArea"].ToString();
                DescansoMedico.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                DescansoMedico.ApeNom = reader["ApeNom"].ToString();
                DescansoMedico.Cargo = reader["Cargo"].ToString();
                DescansoMedico.IdTipoDescansoMedico = Int32.Parse(reader["IdTipoDescansoMedico"].ToString());
                DescansoMedico.DescTipoDescansoMedico = reader["DescTipoDescansoMedico"].ToString();
                DescansoMedico.FechaIni = DateTime.Parse(reader["FechaIni"].ToString());
                DescansoMedico.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                DescansoMedico.Mes = Int32.Parse(reader["Mes"].ToString());
                DescansoMedico.DescMes = reader["DescMes"].ToString();
                DescansoMedico.Dias = Int32.Parse(reader["Dias"].ToString());
                DescansoMedico.Horas = Int32.Parse(reader["Horas"].ToString());
                DescansoMedico.Sueldo = Decimal.Parse(reader["Sueldo"].ToString());
                DescansoMedico.Kpi = Decimal.Parse(reader["Kpi"].ToString());
                DescansoMedico.IdContingencia = Int32.Parse(reader["IdContingencia"].ToString());
                DescansoMedico.DescContingencia = reader["DescContingencia"].ToString();
                DescansoMedico.Diagnostico = reader["Diagnostico"].ToString();
                DescansoMedico.CentroMedico = reader["CentroMedico"].ToString();
                DescansoMedico.IdCategoriaDiagnostico = Int32.Parse(reader["IdCategoriaDiagnostico"].ToString());
                DescansoMedico.Abreviatura = reader["Abreviatura"].ToString();
                DescansoMedico.IdCondicionDescansoMedico = Int32.Parse(reader["IdCondicionDescansoMedico"].ToString());
                DescansoMedico.DescCondicionDescansoMedico = reader["DescCondicionDescansoMedico"].ToString();
                DescansoMedico.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return DescansoMedico;
        }

        public List<DescansoMedicoBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera, int IdArea, int IdPersona)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescansoMedico_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);
            db.AddInParameter(dbCommand, "pIdPersona", DbType.Int32, IdPersona);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DescansoMedicoBE> DescansoMedicolist = new List<DescansoMedicoBE>();
            DescansoMedicoBE DescansoMedico;
            while (reader.Read())
            {
                DescansoMedico = new DescansoMedicoBE();
                DescansoMedico.IdDescansoMedico = Int32.Parse(reader["idDescansoMedico"].ToString());
                DescansoMedico.Numero = reader["Numero"].ToString();
                DescansoMedico.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                DescansoMedico.RazonSocial = reader["RazonSocial"].ToString();
                DescansoMedico.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                DescansoMedico.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                DescansoMedico.IdArea = Int32.Parse(reader["IdArea"].ToString());
                DescansoMedico.DescArea = reader["DescArea"].ToString();
                DescansoMedico.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                DescansoMedico.ApeNom = reader["ApeNom"].ToString();
                DescansoMedico.Cargo = reader["Cargo"].ToString();
                DescansoMedico.IdTipoDescansoMedico = Int32.Parse(reader["IdTipoDescansoMedico"].ToString());
                DescansoMedico.DescTipoDescansoMedico = reader["DescTipoDescansoMedico"].ToString();
                DescansoMedico.FechaIni = DateTime.Parse(reader["FechaIni"].ToString());
                DescansoMedico.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                DescansoMedico.Mes = Int32.Parse(reader["Mes"].ToString());
                DescansoMedico.DescMes = reader["DescMes"].ToString();
                DescansoMedico.Dias = Int32.Parse(reader["Dias"].ToString());
                DescansoMedico.Horas = Int32.Parse(reader["Horas"].ToString());
                DescansoMedico.Sueldo = Decimal.Parse(reader["Sueldo"].ToString());
                DescansoMedico.Kpi = Decimal.Parse(reader["Kpi"].ToString());
                DescansoMedico.IdContingencia = Int32.Parse(reader["IdContingencia"].ToString());
                DescansoMedico.DescContingencia = reader["DescContingencia"].ToString();
                DescansoMedico.Diagnostico = reader["Diagnostico"].ToString();
                DescansoMedico.CentroMedico = reader["CentroMedico"].ToString();
                DescansoMedico.IdCategoriaDiagnostico = Int32.Parse(reader["IdCategoriaDiagnostico"].ToString());
                DescansoMedico.Abreviatura = reader["Abreviatura"].ToString();
                DescansoMedico.IdCondicionDescansoMedico = Int32.Parse(reader["IdCondicionDescansoMedico"].ToString());
                DescansoMedico.DescCondicionDescansoMedico = reader["DescCondicionDescansoMedico"].ToString();
                DescansoMedico.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DescansoMedicolist.Add(DescansoMedico);
            }
            reader.Close();
            reader.Dispose();
            return DescansoMedicolist;
        }

        public List<DescansoMedicoBE> ListaFecha(int IdEmpresa, int IdUnidadMinera, int IdArea, DateTime FechaDesde, DateTime FechaHasta)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescansoMedico_ListaFecha");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);
            db.AddInParameter(dbCommand, "pFechaDesde", DbType.DateTime, FechaDesde);
            db.AddInParameter(dbCommand, "pFechaHasta", DbType.DateTime, FechaHasta);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DescansoMedicoBE> DescansoMedicolist = new List<DescansoMedicoBE>();
            DescansoMedicoBE DescansoMedico;
            while (reader.Read())
            {
                DescansoMedico = new DescansoMedicoBE();
                DescansoMedico.IdDescansoMedico = Int32.Parse(reader["idDescansoMedico"].ToString());
                DescansoMedico.Numero = reader["Numero"].ToString();
                DescansoMedico.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                DescansoMedico.RazonSocial = reader["RazonSocial"].ToString();
                DescansoMedico.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                DescansoMedico.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                DescansoMedico.IdArea = Int32.Parse(reader["IdArea"].ToString());
                DescansoMedico.DescArea = reader["DescArea"].ToString();
                DescansoMedico.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                DescansoMedico.ApeNom = reader["ApeNom"].ToString();
                DescansoMedico.Cargo = reader["Cargo"].ToString();
                DescansoMedico.IdTipoDescansoMedico = Int32.Parse(reader["IdTipoDescansoMedico"].ToString());
                DescansoMedico.DescTipoDescansoMedico = reader["DescTipoDescansoMedico"].ToString();
                DescansoMedico.FechaIni = DateTime.Parse(reader["FechaIni"].ToString());
                DescansoMedico.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                DescansoMedico.Mes = Int32.Parse(reader["Mes"].ToString());
                DescansoMedico.DescMes = reader["DescMes"].ToString();
                DescansoMedico.Dias = Int32.Parse(reader["Dias"].ToString());
                DescansoMedico.Horas = Int32.Parse(reader["Horas"].ToString());
                DescansoMedico.Sueldo = Decimal.Parse(reader["Sueldo"].ToString());
                DescansoMedico.Kpi = Decimal.Parse(reader["Kpi"].ToString());
                DescansoMedico.IdContingencia = Int32.Parse(reader["IdContingencia"].ToString());
                DescansoMedico.DescContingencia = reader["DescContingencia"].ToString();
                DescansoMedico.Diagnostico = reader["Diagnostico"].ToString();
                DescansoMedico.CentroMedico = reader["CentroMedico"].ToString();
                DescansoMedico.IdCategoriaDiagnostico = Int32.Parse(reader["IdCategoriaDiagnostico"].ToString());
                DescansoMedico.Abreviatura = reader["Abreviatura"].ToString();
                DescansoMedico.IdCondicionDescansoMedico = Int32.Parse(reader["IdCondicionDescansoMedico"].ToString());
                DescansoMedico.DescCondicionDescansoMedico = reader["DescCondicionDescansoMedico"].ToString();
                DescansoMedico.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DescansoMedicolist.Add(DescansoMedico);
            }
            reader.Close();
            reader.Dispose();
            return DescansoMedicolist;
        }

        public List<DescansoMedicoBE> ListaNumero(int Numero)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescansoMedico_ListaNumero");
            db.AddInParameter(dbCommand, "pNumero", DbType.Int32, Numero);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DescansoMedicoBE> DescansoMedicolist = new List<DescansoMedicoBE>();
            DescansoMedicoBE DescansoMedico;
            while (reader.Read())
            {
                DescansoMedico = new DescansoMedicoBE();
                DescansoMedico.IdDescansoMedico = Int32.Parse(reader["idDescansoMedico"].ToString());
                DescansoMedico.Numero = reader["Numero"].ToString();
                DescansoMedico.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                DescansoMedico.RazonSocial = reader["RazonSocial"].ToString();
                DescansoMedico.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                DescansoMedico.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                DescansoMedico.IdArea = Int32.Parse(reader["IdArea"].ToString());
                DescansoMedico.DescArea = reader["DescArea"].ToString();
                DescansoMedico.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                DescansoMedico.ApeNom = reader["ApeNom"].ToString();
                DescansoMedico.Cargo = reader["Cargo"].ToString();
                DescansoMedico.IdTipoDescansoMedico = Int32.Parse(reader["IdTipoDescansoMedico"].ToString());
                DescansoMedico.DescTipoDescansoMedico = reader["DescTipoDescansoMedico"].ToString();
                DescansoMedico.FechaIni = DateTime.Parse(reader["FechaIni"].ToString());
                DescansoMedico.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                DescansoMedico.Mes = Int32.Parse(reader["Mes"].ToString());
                DescansoMedico.DescMes = reader["DescMes"].ToString();
                DescansoMedico.Dias = Int32.Parse(reader["Dias"].ToString());
                DescansoMedico.Horas = Int32.Parse(reader["Horas"].ToString());
                DescansoMedico.Sueldo = Decimal.Parse(reader["Sueldo"].ToString());
                DescansoMedico.Kpi = Decimal.Parse(reader["Kpi"].ToString());
                DescansoMedico.IdContingencia = Int32.Parse(reader["IdContingencia"].ToString());
                DescansoMedico.DescContingencia = reader["DescContingencia"].ToString();
                DescansoMedico.Diagnostico = reader["Diagnostico"].ToString();
                DescansoMedico.CentroMedico = reader["CentroMedico"].ToString();
                DescansoMedico.IdCategoriaDiagnostico = Int32.Parse(reader["IdCategoriaDiagnostico"].ToString());
                DescansoMedico.Abreviatura = reader["Abreviatura"].ToString();
                DescansoMedico.IdCondicionDescansoMedico = Int32.Parse(reader["IdCondicionDescansoMedico"].ToString());
                DescansoMedico.DescCondicionDescansoMedico = reader["DescCondicionDescansoMedico"].ToString();
                DescansoMedico.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                DescansoMedicolist.Add(DescansoMedico);
            }
            reader.Close();
            reader.Dispose();
            return DescansoMedicolist;
        }

        
        public List<DescansoMedicoBE> ListaPorVencer(int IdEmpresa, int IdUnidadMinera, int IdArea, int Dias)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescansoMedico_ListaPorVencer");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);
            db.AddInParameter(dbCommand, "pDias", DbType.Int32, Dias);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DescansoMedicoBE> DescansoMedicolist = new List<DescansoMedicoBE>();
            DescansoMedicoBE DescansoMedico;
            while (reader.Read())
            {
                DescansoMedico = new DescansoMedicoBE();
                DescansoMedico.IdDescansoMedico = Int32.Parse(reader["idDescansoMedico"].ToString());
                DescansoMedico.Numero = reader["Numero"].ToString();
                DescansoMedico.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                DescansoMedico.RazonSocial = reader["RazonSocial"].ToString();
                DescansoMedico.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                DescansoMedico.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                DescansoMedico.IdArea = Int32.Parse(reader["IdArea"].ToString());
                DescansoMedico.DescArea = reader["DescArea"].ToString();
                DescansoMedico.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                DescansoMedico.ApeNom = reader["ApeNom"].ToString();
                DescansoMedico.Cargo = reader["Cargo"].ToString();
                DescansoMedico.IdTipoDescansoMedico = Int32.Parse(reader["IdTipoDescansoMedico"].ToString());
                DescansoMedico.DescTipoDescansoMedico = reader["DescTipoDescansoMedico"].ToString();
                DescansoMedico.FechaIni = DateTime.Parse(reader["FechaIni"].ToString());
                DescansoMedico.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                DescansoMedico.Mes = Int32.Parse(reader["Mes"].ToString());
                DescansoMedico.DescMes = reader["DescMes"].ToString();
                DescansoMedico.Dias = Int32.Parse(reader["Dias"].ToString());
                DescansoMedico.Horas = Int32.Parse(reader["Horas"].ToString());
                DescansoMedico.Sueldo = Decimal.Parse(reader["Sueldo"].ToString());
                DescansoMedico.Kpi = Decimal.Parse(reader["Kpi"].ToString());
                DescansoMedico.IdContingencia = Int32.Parse(reader["IdContingencia"].ToString());
                DescansoMedico.DescContingencia = reader["DescContingencia"].ToString();
                DescansoMedico.Diagnostico = reader["Diagnostico"].ToString();
                DescansoMedico.CentroMedico = reader["CentroMedico"].ToString();
                DescansoMedico.IdCategoriaDiagnostico = Int32.Parse(reader["IdCategoriaDiagnostico"].ToString());
                DescansoMedico.Abreviatura = reader["Abreviatura"].ToString();
                DescansoMedico.IdCondicionDescansoMedico = Int32.Parse(reader["IdCondicionDescansoMedico"].ToString());
                DescansoMedico.DescCondicionDescansoMedico = reader["DescCondicionDescansoMedico"].ToString();
                DescansoMedico.DiasVencimiento = Int32.Parse(reader["DiasVencimiento"].ToString());
                DescansoMedicolist.Add(DescansoMedico);
            }
            reader.Close();
            reader.Dispose();
            return DescansoMedicolist;
        }

        public List<DescansoMedicoBE> ListaVencido(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_DescansoMedico_ListaVencido");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdUnidadMinera", DbType.Int32, IdUnidadMinera);
            db.AddInParameter(dbCommand, "pIdArea", DbType.Int32, IdArea);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<DescansoMedicoBE> DescansoMedicolist = new List<DescansoMedicoBE>();
            DescansoMedicoBE DescansoMedico;
            while (reader.Read())
            {

                DescansoMedico = new DescansoMedicoBE();
                DescansoMedico.IdDescansoMedico = Int32.Parse(reader["idDescansoMedico"].ToString());
                DescansoMedico.Numero = reader["Numero"].ToString();
                DescansoMedico.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                DescansoMedico.RazonSocial = reader["RazonSocial"].ToString();
                DescansoMedico.IdUnidadMinera = Int32.Parse(reader["IdUnidadMinera"].ToString());
                DescansoMedico.DescUnidadMinera = reader["DescUnidadMinera"].ToString();
                DescansoMedico.IdArea = Int32.Parse(reader["IdArea"].ToString());
                DescansoMedico.DescArea = reader["DescArea"].ToString();
                DescansoMedico.IdPersona = Int32.Parse(reader["IdPersona"].ToString());
                DescansoMedico.ApeNom = reader["ApeNom"].ToString();
                DescansoMedico.Cargo = reader["Cargo"].ToString();
                DescansoMedico.IdTipoDescansoMedico = Int32.Parse(reader["IdTipoDescansoMedico"].ToString());
                DescansoMedico.DescTipoDescansoMedico = reader["DescTipoDescansoMedico"].ToString();
                DescansoMedico.FechaIni = DateTime.Parse(reader["FechaIni"].ToString());
                DescansoMedico.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                DescansoMedico.Mes = Int32.Parse(reader["Mes"].ToString());
                DescansoMedico.DescMes = reader["DescMes"].ToString();
                DescansoMedico.Dias = Int32.Parse(reader["Dias"].ToString());
                DescansoMedico.Horas = Int32.Parse(reader["Horas"].ToString());
                DescansoMedico.Sueldo = Decimal.Parse(reader["Sueldo"].ToString());
                DescansoMedico.Kpi = Decimal.Parse(reader["Kpi"].ToString());
                DescansoMedico.IdContingencia = Int32.Parse(reader["IdContingencia"].ToString());
                DescansoMedico.DescContingencia = reader["DescContingencia"].ToString();
                DescansoMedico.Diagnostico = reader["Diagnostico"].ToString();
                DescansoMedico.CentroMedico = reader["CentroMedico"].ToString();
                DescansoMedico.IdCategoriaDiagnostico = Int32.Parse(reader["IdCategoriaDiagnostico"].ToString());
                DescansoMedico.Abreviatura = reader["Abreviatura"].ToString();
                DescansoMedico.IdCondicionDescansoMedico = Int32.Parse(reader["IdCondicionDescansoMedico"].ToString());
                DescansoMedico.DescCondicionDescansoMedico = reader["DescCondicionDescansoMedico"].ToString();
                DescansoMedico.DiasVencimiento = Int32.Parse(reader["DiasVencimiento"].ToString());
                DescansoMedicolist.Add(DescansoMedico);
            }
            reader.Close();
            reader.Dispose();
            return DescansoMedicolist;
        }
    }
}
