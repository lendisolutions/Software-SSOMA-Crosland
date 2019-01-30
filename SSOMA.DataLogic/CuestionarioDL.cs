using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class CuestionarioDL
    {
        public CuestionarioDL() { }

        public void Inserta(CuestionarioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cuestionario_Inserta");

            db.AddInParameter(dbCommand, "pIdCuestionario", DbType.Int32, pItem.IdCuestionario);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, pItem.IdTema);
            db.AddInParameter(dbCommand, "pDescCuestionario", DbType.String, pItem.DescCuestionario);
            db.AddInParameter(dbCommand, "pFechaIni", DbType.DateTime, pItem.FechaIni);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pNotaMaxima", DbType.Int32, pItem.NotaMaxima);
            db.AddInParameter(dbCommand, "pNotaAprobatoria", DbType.Int32, pItem.NotaAprobatoria);
            db.AddInParameter(dbCommand, "pDuracion", DbType.Int32, pItem.Duracion);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(CuestionarioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cuestionario_Actualiza");

            db.AddInParameter(dbCommand, "pIdCuestionario", DbType.Int32, pItem.IdCuestionario);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, pItem.IdTema);
            db.AddInParameter(dbCommand, "pDescCuestionario", DbType.String, pItem.DescCuestionario);
            db.AddInParameter(dbCommand, "pFechaIni", DbType.DateTime, pItem.FechaIni);
            db.AddInParameter(dbCommand, "pFechaFin", DbType.DateTime, pItem.FechaFin);
            db.AddInParameter(dbCommand, "pNotaMaxima", DbType.Int32, pItem.NotaMaxima);
            db.AddInParameter(dbCommand, "pNotaAprobatoria", DbType.Int32, pItem.NotaAprobatoria);
            db.AddInParameter(dbCommand, "pDuracion", DbType.Int32, pItem.Duracion);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, pItem.IdSituacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public void ActualizaSituacion(int IdCuestionario, int IdSituacion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cuestionario_ActualizaSituacion");

            db.AddInParameter(dbCommand, "pIdCuestionario", DbType.Int32, IdCuestionario);
            db.AddInParameter(dbCommand, "pIdSituacion", DbType.Int32, IdSituacion);

            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(CuestionarioBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cuestionario_Elimina");

            db.AddInParameter(dbCommand, "pIdCuestionario", DbType.Int32, pItem.IdCuestionario);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public CuestionarioBE Selecciona(int IdEmpresa, int idCuestionario)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cuestionario_Selecciona");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pidCuestionario", DbType.Int32, idCuestionario);

            IDataReader reader = db.ExecuteReader(dbCommand);
            CuestionarioBE Cuestionario = null;
            while (reader.Read())
            {
                Cuestionario = new CuestionarioBE();
                Cuestionario.IdCuestionario = Int32.Parse(reader["idCuestionario"].ToString());
                Cuestionario.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Cuestionario.RazonSocial = reader["RazonSocial"].ToString();
                Cuestionario.IdTema = Int32.Parse(reader["IdTema"].ToString());
                Cuestionario.DescTema = reader["DescTema"].ToString();
                Cuestionario.DescCuestionario = reader["descCuestionario"].ToString();
                Cuestionario.FechaIni = DateTime.Parse(reader["FechaIni"].ToString());
                Cuestionario.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                Cuestionario.NotaMaxima = Int32.Parse(reader["NotaMaxima"].ToString());
                Cuestionario.NotaAprobatoria = Int32.Parse(reader["NotaAprobatoria"].ToString());
                Cuestionario.Duracion = Int32.Parse(reader["Duracion"].ToString());
                Cuestionario.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Cuestionario.DescSituacion = reader["DescSituacion"].ToString();
                Cuestionario.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return Cuestionario;
        }

        public List<CuestionarioBE> ListaTodosActivo(int IdEmpresa, int IdTema)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cuestionario_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pIdTema", DbType.Int32, IdTema);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CuestionarioBE> Cuestionariolist = new List<CuestionarioBE>();
            CuestionarioBE Cuestionario;
            while (reader.Read())
            {
                Cuestionario = new CuestionarioBE();
                Cuestionario.IdCuestionario = Int32.Parse(reader["idCuestionario"].ToString());
                Cuestionario.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                Cuestionario.RazonSocial = reader["RazonSocial"].ToString();
                Cuestionario.IdTema = Int32.Parse(reader["IdTema"].ToString());
                Cuestionario.DescTema = reader["DescTema"].ToString();
                Cuestionario.DescCuestionario = reader["descCuestionario"].ToString();
                Cuestionario.FechaIni = DateTime.Parse(reader["FechaIni"].ToString());
                Cuestionario.FechaFin = DateTime.Parse(reader["FechaFin"].ToString());
                Cuestionario.NotaMaxima = Int32.Parse(reader["NotaMaxima"].ToString());
                Cuestionario.NotaAprobatoria = Int32.Parse(reader["NotaAprobatoria"].ToString());
                Cuestionario.Duracion = Int32.Parse(reader["Duracion"].ToString());
                Cuestionario.IdSituacion = Int32.Parse(reader["IdSituacion"].ToString());
                Cuestionario.DescSituacion = reader["DescSituacion"].ToString();
                Cuestionario.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                Cuestionariolist.Add(Cuestionario);
            }
            reader.Close();
            reader.Dispose();
            return Cuestionariolist;
        }

        public List<CuestionarioBE> ListaCombo(int IdEmpresa, int Periodo)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_Cuestionario_ListaCombo");
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, IdEmpresa);
            db.AddInParameter(dbCommand, "pPeriodo", DbType.Int32, Periodo);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<CuestionarioBE> Cuestionariolist = new List<CuestionarioBE>();
            CuestionarioBE Cuestionario;
            while (reader.Read())
            {
                Cuestionario = new CuestionarioBE();
                Cuestionario.IdCuestionario = Int32.Parse(reader["idCuestionario"].ToString());
                Cuestionario.DescCuestionario = reader["descCuestionario"].ToString();
                Cuestionariolist.Add(Cuestionario);
            }
            reader.Close();
            reader.Dispose();
            return Cuestionariolist;
        }
    }
}
