using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class ExtintorInspeccionDetalleDL
    {
        public ExtintorInspeccionDetalleDL() { }

        public void Inserta(ExtintorInspeccionDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ExtintorInspeccionDetalle_Inserta");

            db.AddInParameter(dbCommand, "pIdExtintorInspeccionDetalle", DbType.Int32, pItem.IdExtintorInspeccionDetalle);
            db.AddInParameter(dbCommand, "pIdExtintorInspeccion", DbType.Int32, pItem.IdExtintorInspeccion);
            db.AddInParameter(dbCommand, "pIdExtintor", DbType.Int32, pItem.IdExtintor);
            db.AddInParameter(dbCommand, "pUno", DbType.Boolean, pItem.Uno);
            db.AddInParameter(dbCommand, "pDos", DbType.Boolean, pItem.Dos);
            db.AddInParameter(dbCommand, "pTres", DbType.Boolean, pItem.Tres);
            db.AddInParameter(dbCommand, "pCuatro", DbType.Boolean, pItem.Cuatro);
            db.AddInParameter(dbCommand, "pCinco", DbType.Boolean, pItem.Cinco);
            db.AddInParameter(dbCommand, "pSeis", DbType.Boolean, pItem.Seis);
            db.AddInParameter(dbCommand, "pSiete", DbType.Boolean, pItem.Siete);
            db.AddInParameter(dbCommand, "pOcho", DbType.Boolean, pItem.Ocho);
            db.AddInParameter(dbCommand, "pNueve", DbType.Boolean, pItem.Nueve);
            db.AddInParameter(dbCommand, "pDiez", DbType.Boolean, pItem.Diez);
            db.AddInParameter(dbCommand, "pOnce", DbType.Boolean, pItem.Once);
            db.AddInParameter(dbCommand, "pDoce", DbType.Boolean, pItem.Doce);
            db.AddInParameter(dbCommand, "pTrece", DbType.Boolean, pItem.Trece);
            db.AddInParameter(dbCommand, "pCatorce", DbType.Boolean, pItem.Catorce);
            db.AddInParameter(dbCommand, "pQuince", DbType.Boolean, pItem.Quince);
            db.AddInParameter(dbCommand, "pDiecisies", DbType.Boolean, pItem.Diecisies);
            db.AddInParameter(dbCommand, "pDiecisiete", DbType.Boolean, pItem.Diecisiete);
            db.AddInParameter(dbCommand, "pRecargadoPor", DbType.String, pItem.RecargadoPor);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(ExtintorInspeccionDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ExtintorInspeccionDetalle_Actualiza");

            db.AddInParameter(dbCommand, "pIdExtintorInspeccionDetalle", DbType.Int32, pItem.IdExtintorInspeccionDetalle);
            db.AddInParameter(dbCommand, "pIdExtintorInspeccion", DbType.Int32, pItem.IdExtintorInspeccion);
            db.AddInParameter(dbCommand, "pIdExtintor", DbType.Int32, pItem.IdExtintor);
            db.AddInParameter(dbCommand, "pUno", DbType.Boolean, pItem.Uno);
            db.AddInParameter(dbCommand, "pDos", DbType.Boolean, pItem.Dos);
            db.AddInParameter(dbCommand, "pTres", DbType.Boolean, pItem.Tres);
            db.AddInParameter(dbCommand, "pCuatro", DbType.Boolean, pItem.Cuatro);
            db.AddInParameter(dbCommand, "pCinco", DbType.Boolean, pItem.Cinco);
            db.AddInParameter(dbCommand, "pSeis", DbType.Boolean, pItem.Seis);
            db.AddInParameter(dbCommand, "pSiete", DbType.Boolean, pItem.Siete);
            db.AddInParameter(dbCommand, "pOcho", DbType.Boolean, pItem.Ocho);
            db.AddInParameter(dbCommand, "pNueve", DbType.Boolean, pItem.Nueve);
            db.AddInParameter(dbCommand, "pDiez", DbType.Boolean, pItem.Diez);
            db.AddInParameter(dbCommand, "pOnce", DbType.Boolean, pItem.Once);
            db.AddInParameter(dbCommand, "pDoce", DbType.Boolean, pItem.Doce);
            db.AddInParameter(dbCommand, "pTrece", DbType.Boolean, pItem.Trece);
            db.AddInParameter(dbCommand, "pCatorce", DbType.Boolean, pItem.Catorce);
            db.AddInParameter(dbCommand, "pQuince", DbType.Boolean, pItem.Quince);
            db.AddInParameter(dbCommand, "pDiecisies", DbType.Boolean, pItem.Diecisies);
            db.AddInParameter(dbCommand, "pDiecisiete", DbType.Boolean, pItem.Diecisiete);
            db.AddInParameter(dbCommand, "pRecargadoPor", DbType.String, pItem.RecargadoPor);
            db.AddInParameter(dbCommand, "pObservacion", DbType.String, pItem.Observacion);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Elimina(ExtintorInspeccionDetalleBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ExtintorInspeccionDetalle_Elimina");

            db.AddInParameter(dbCommand, "pIdExtintorInspeccionDetalle", DbType.Int32, pItem.IdExtintorInspeccionDetalle);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public ExtintorInspeccionDetalleBE Selecciona(int IdExtintorInspeccionDetalle)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ExtintorInspeccionDetalle_Selecciona");
            db.AddInParameter(dbCommand, "pidExtintorInspeccionDetalle", DbType.Int32, IdExtintorInspeccionDetalle);

            IDataReader reader = db.ExecuteReader(dbCommand);
            ExtintorInspeccionDetalleBE ExtintorInspeccionDetalle = null;
            while (reader.Read())
            {
                ExtintorInspeccionDetalle = new ExtintorInspeccionDetalleBE();
                ExtintorInspeccionDetalle.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ExtintorInspeccionDetalle.IdExtintorInspeccion = Int32.Parse(reader["IdExtintorInspeccion"].ToString());
                ExtintorInspeccionDetalle.IdExtintorInspeccionDetalle = Int32.Parse(reader["idExtintorInspeccionDetalle"].ToString());
                ExtintorInspeccionDetalle.IdExtintor = Int32.Parse(reader["idExtintor"].ToString());
                ExtintorInspeccionDetalle.Codigo = reader["Codigo"].ToString();
                ExtintorInspeccionDetalle.Serie = reader["Serie"].ToString();
                ExtintorInspeccionDetalle.Abreviatura = reader["Abreviatura"].ToString();
                ExtintorInspeccionDetalle.Capacidad = reader["Capacidad"].ToString();
                ExtintorInspeccionDetalle.Ubicacion = reader["Ubicacion"].ToString();
                ExtintorInspeccionDetalle.Marca = reader["Marca"].ToString();
                ExtintorInspeccionDetalle.Uno = Boolean.Parse(reader["Uno"].ToString());
                ExtintorInspeccionDetalle.Dos = Boolean.Parse(reader["Dos"].ToString());
                ExtintorInspeccionDetalle.Tres = Boolean.Parse(reader["Tres"].ToString());
                ExtintorInspeccionDetalle.Cuatro = Boolean.Parse(reader["Cuatro"].ToString());
                ExtintorInspeccionDetalle.Cinco = Boolean.Parse(reader["Cinco"].ToString());
                ExtintorInspeccionDetalle.Seis = Boolean.Parse(reader["Seis"].ToString());
                ExtintorInspeccionDetalle.Siete = Boolean.Parse(reader["Siete"].ToString());
                ExtintorInspeccionDetalle.Ocho = Boolean.Parse(reader["Ocho"].ToString());
                ExtintorInspeccionDetalle.Nueve = Boolean.Parse(reader["Nueve"].ToString());
                ExtintorInspeccionDetalle.Diez = Boolean.Parse(reader["Diez"].ToString());
                ExtintorInspeccionDetalle.Once = Boolean.Parse(reader["Once"].ToString());
                ExtintorInspeccionDetalle.Doce = Boolean.Parse(reader["Doce"].ToString());
                ExtintorInspeccionDetalle.Trece = Boolean.Parse(reader["Trece"].ToString());
                ExtintorInspeccionDetalle.Quince = Boolean.Parse(reader["Quince"].ToString());
                ExtintorInspeccionDetalle.Diecisies = Boolean.Parse(reader["Diecisies"].ToString());
                ExtintorInspeccionDetalle.Diecisiete = Boolean.Parse(reader["Diecisiete"].ToString());
                ExtintorInspeccionDetalle.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                ExtintorInspeccionDetalle.RecargadoPor = reader["RecargadoPor"].ToString();
                ExtintorInspeccionDetalle.Observacion = reader["Observacion"].ToString();
                ExtintorInspeccionDetalle.FechaVencimientoPruebaHidrostatica = DateTime.Parse(reader["FechaVencimientoPruebaHidrostatica"].ToString());
                ExtintorInspeccionDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return ExtintorInspeccionDetalle;
        }

        public List<ExtintorInspeccionDetalleBE> ListaTodosActivo(int IdExtintorInspeccion)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_ExtintorInspeccionDetalle_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdExtintorInspeccion", DbType.Int32, IdExtintorInspeccion);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<ExtintorInspeccionDetalleBE> ExtintorInspeccionDetallelist = new List<ExtintorInspeccionDetalleBE>();
            ExtintorInspeccionDetalleBE ExtintorInspeccionDetalle;
            while (reader.Read())
            {
                ExtintorInspeccionDetalle = new ExtintorInspeccionDetalleBE();
                ExtintorInspeccionDetalle.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                ExtintorInspeccionDetalle.IdExtintorInspeccion = Int32.Parse(reader["IdExtintorInspeccion"].ToString());
                ExtintorInspeccionDetalle.IdExtintorInspeccionDetalle = Int32.Parse(reader["idExtintorInspeccionDetalle"].ToString());
                ExtintorInspeccionDetalle.IdExtintor = Int32.Parse(reader["idExtintor"].ToString());
                ExtintorInspeccionDetalle.Codigo = reader["Codigo"].ToString();
                ExtintorInspeccionDetalle.Serie = reader["Serie"].ToString();
                ExtintorInspeccionDetalle.Abreviatura = reader["Abreviatura"].ToString();
                ExtintorInspeccionDetalle.Capacidad = reader["Capacidad"].ToString();
                ExtintorInspeccionDetalle.Ubicacion = reader["Ubicacion"].ToString();
                ExtintorInspeccionDetalle.Marca = reader["Marca"].ToString();
                ExtintorInspeccionDetalle.Uno = Boolean.Parse(reader["Uno"].ToString());
                ExtintorInspeccionDetalle.Dos = Boolean.Parse(reader["Dos"].ToString());
                ExtintorInspeccionDetalle.Tres = Boolean.Parse(reader["Tres"].ToString());
                ExtintorInspeccionDetalle.Cuatro = Boolean.Parse(reader["Cuatro"].ToString());
                ExtintorInspeccionDetalle.Cinco = Boolean.Parse(reader["Cinco"].ToString());
                ExtintorInspeccionDetalle.Seis = Boolean.Parse(reader["Seis"].ToString());
                ExtintorInspeccionDetalle.Siete = Boolean.Parse(reader["Siete"].ToString());
                ExtintorInspeccionDetalle.Ocho = Boolean.Parse(reader["Ocho"].ToString());
                ExtintorInspeccionDetalle.Nueve = Boolean.Parse(reader["Nueve"].ToString());
                ExtintorInspeccionDetalle.Diez = Boolean.Parse(reader["Diez"].ToString());
                ExtintorInspeccionDetalle.Once = Boolean.Parse(reader["Once"].ToString());
                ExtintorInspeccionDetalle.Doce = Boolean.Parse(reader["Doce"].ToString());
                ExtintorInspeccionDetalle.Trece = Boolean.Parse(reader["Trece"].ToString());
                ExtintorInspeccionDetalle.Quince = Boolean.Parse(reader["Quince"].ToString());
                ExtintorInspeccionDetalle.Diecisies = Boolean.Parse(reader["Diecisies"].ToString());
                ExtintorInspeccionDetalle.Diecisiete = Boolean.Parse(reader["Diecisiete"].ToString());
                ExtintorInspeccionDetalle.FechaVencimiento = DateTime.Parse(reader["FechaVencimiento"].ToString());
                ExtintorInspeccionDetalle.RecargadoPor = reader["RecargadoPor"].ToString();
                ExtintorInspeccionDetalle.Observacion = reader["Observacion"].ToString();
                ExtintorInspeccionDetalle.FechaVencimientoPruebaHidrostatica = DateTime.Parse(reader["FechaVencimientoPruebaHidrostatica"].ToString());
                ExtintorInspeccionDetalle.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                ExtintorInspeccionDetalle.TipoOper = 4; //CONSULTAR
                ExtintorInspeccionDetallelist.Add(ExtintorInspeccionDetalle);
            }
            reader.Close();
            reader.Dispose();
            return ExtintorInspeccionDetallelist;
        }
    }
}
