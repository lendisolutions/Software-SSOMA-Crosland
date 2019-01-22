using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using SSOMA.BusinessEntity;
using System.Collections.Generic;

namespace SSOMA.DataLogic
{
    public class AccidenteCostoDL
    {
        public AccidenteCostoDL() { }

        public void Inserta(AccidenteCostoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteCosto_Inserta");

            db.AddInParameter(dbCommand, "pIdAccidenteCosto", DbType.Int32, pItem.IdAccidenteCosto);
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, pItem.IdAccidente);
            db.AddInParameter(dbCommand, "pDiasPerdido", DbType.Int32, pItem.DiasPerdido);
            db.AddInParameter(dbCommand, "pCostoDia", DbType.Decimal, pItem.CostoDia);
            db.AddInParameter(dbCommand, "pTotalCostoDia", DbType.Decimal, pItem.TotalCostoDia);
            db.AddInParameter(dbCommand, "pHorasExtra", DbType.Int32, pItem.HorasExtra);
            db.AddInParameter(dbCommand, "pCostoHorasExtra", DbType.Decimal, pItem.CostoHorasExtra);
            db.AddInParameter(dbCommand, "pTotalCostoHorasExtra", DbType.Decimal, pItem.TotalCostoHorasExtra);
            db.AddInParameter(dbCommand, "pCostoEnergia", DbType.Decimal, pItem.CostoEnergia);
            db.AddInParameter(dbCommand, "pTiempoTrabajado", DbType.Int32, pItem.TiempoTrabajado);
            db.AddInParameter(dbCommand, "pSalario", DbType.Decimal, pItem.Salario);
            db.AddInParameter(dbCommand, "pSubTotalReemplazo", DbType.Decimal, pItem.SubTotalReemplazo);
            db.AddInParameter(dbCommand, "pReadaptacionTrabajo", DbType.Decimal, pItem.ReadaptacionTrabajo);
            db.AddInParameter(dbCommand, "pReingresoAccidentado", DbType.Decimal, pItem.ReingresoAccidentado);
            db.AddInParameter(dbCommand, "pParalizacionMaquina", DbType.Decimal, pItem.ParalizacionMaquina);
            db.AddInParameter(dbCommand, "pManoObra", DbType.Decimal, pItem.ManoObra);
            db.AddInParameter(dbCommand, "pRepuestos", DbType.Decimal, pItem.Repuestos);
            db.AddInParameter(dbCommand, "pTiempoPerdidoTotal", DbType.Decimal, pItem.TiempoPerdidoTotal);
            db.AddInParameter(dbCommand, "pNumeroTrabajadores", DbType.Int32, pItem.NumeroTrabajadores);
            db.AddInParameter(dbCommand, "pSalarioPromedio", DbType.Decimal, pItem.SalarioPromedio);
            db.AddInParameter(dbCommand, "pSubTotalSalario", DbType.Decimal, pItem.SubTotalSalario);
            db.AddInParameter(dbCommand, "pTiempoPerdidoSupervisor", DbType.Int32, pItem.TiempoPerdidoSupervisor);
            db.AddInParameter(dbCommand, "pCostoHoraSupervisor", DbType.Decimal, pItem.CostoHoraSupervisor);
            db.AddInParameter(dbCommand, "pCostoTotalSupervisor", DbType.Decimal, pItem.CostoTotalSupervisor);
            db.AddInParameter(dbCommand, "pCostoTotalAccidentado", DbType.Decimal, pItem.CostoTotalAccidentado);
            db.AddInParameter(dbCommand, "pCostoAdministrativo", DbType.Decimal, pItem.CostoAdministrativo);
            db.AddInParameter(dbCommand, "pCostoTraslado", DbType.Decimal, pItem.CostoTraslado);
            db.AddInParameter(dbCommand, "pCostoEnfermo", DbType.Decimal, pItem.CostoEnfermo);
            db.AddInParameter(dbCommand, "pCostoMaterial", DbType.Decimal, pItem.CostoMaterial);
            db.AddInParameter(dbCommand, "pCostoParamedico", DbType.Decimal, pItem.CostoParamedico);
            db.AddInParameter(dbCommand, "pCostoDiverso", DbType.Decimal, pItem.CostoDiverso);
            db.AddInParameter(dbCommand, "pCostoTotal", DbType.Decimal, pItem.CostoTotal);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

        public void Actualiza(AccidenteCostoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteCosto_Actualiza");

            db.AddInParameter(dbCommand, "pIdAccidenteCosto", DbType.Int32, pItem.IdAccidenteCosto);
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, pItem.IdAccidente);
            db.AddInParameter(dbCommand, "pDiasPerdido", DbType.Int32, pItem.DiasPerdido);
            db.AddInParameter(dbCommand, "pCostoDia", DbType.Decimal, pItem.CostoDia);
            db.AddInParameter(dbCommand, "pTotalCostoDia", DbType.Decimal, pItem.TotalCostoDia);
            db.AddInParameter(dbCommand, "pHorasExtra", DbType.Int32, pItem.HorasExtra);
            db.AddInParameter(dbCommand, "pCostoHorasExtra", DbType.Decimal, pItem.CostoHorasExtra);
            db.AddInParameter(dbCommand, "pTotalCostoHorasExtra", DbType.Decimal, pItem.TotalCostoHorasExtra);
            db.AddInParameter(dbCommand, "pCostoEnergia", DbType.Decimal, pItem.CostoEnergia);
            db.AddInParameter(dbCommand, "pTiempoTrabajado", DbType.Int32, pItem.TiempoTrabajado);
            db.AddInParameter(dbCommand, "pSalario", DbType.Decimal, pItem.Salario);
            db.AddInParameter(dbCommand, "pSubTotalReemplazo", DbType.Decimal, pItem.SubTotalReemplazo);
            db.AddInParameter(dbCommand, "pReadaptacionTrabajo", DbType.Decimal, pItem.ReadaptacionTrabajo);
            db.AddInParameter(dbCommand, "pReingresoAccidentado", DbType.Decimal, pItem.ReingresoAccidentado);
            db.AddInParameter(dbCommand, "pParalizacionMaquina", DbType.Decimal, pItem.ParalizacionMaquina);
            db.AddInParameter(dbCommand, "pManoObra", DbType.Decimal, pItem.ManoObra);
            db.AddInParameter(dbCommand, "pRepuestos", DbType.Decimal, pItem.Repuestos);
            db.AddInParameter(dbCommand, "pTiempoPerdidoTotal", DbType.Decimal, pItem.TiempoPerdidoTotal);
            db.AddInParameter(dbCommand, "pNumeroTrabajadores", DbType.Int32, pItem.NumeroTrabajadores);
            db.AddInParameter(dbCommand, "pSalarioPromedio", DbType.Decimal, pItem.SalarioPromedio);
            db.AddInParameter(dbCommand, "pSubTotalSalario", DbType.Decimal, pItem.SubTotalSalario);
            db.AddInParameter(dbCommand, "pTiempoPerdidoSupervisor", DbType.Int32, pItem.TiempoPerdidoSupervisor);
            db.AddInParameter(dbCommand, "pCostoHoraSupervisor", DbType.Decimal, pItem.CostoHoraSupervisor);
            db.AddInParameter(dbCommand, "pCostoTotalSupervisor", DbType.Decimal, pItem.CostoTotalSupervisor);
            db.AddInParameter(dbCommand, "pCostoTotalAccidentado", DbType.Decimal, pItem.CostoTotalAccidentado);
            db.AddInParameter(dbCommand, "pCostoAdministrativo", DbType.Decimal, pItem.CostoAdministrativo);
            db.AddInParameter(dbCommand, "pCostoTraslado", DbType.Decimal, pItem.CostoTraslado);
            db.AddInParameter(dbCommand, "pCostoEnfermo", DbType.Decimal, pItem.CostoEnfermo);
            db.AddInParameter(dbCommand, "pCostoMaterial", DbType.Decimal, pItem.CostoMaterial);
            db.AddInParameter(dbCommand, "pCostoParamedico", DbType.Decimal, pItem.CostoParamedico);
            db.AddInParameter(dbCommand, "pCostoDiverso", DbType.Decimal, pItem.CostoDiverso);
            db.AddInParameter(dbCommand, "pCostoTotal", DbType.Decimal, pItem.CostoTotal);
            db.AddInParameter(dbCommand, "pFlagEstado", DbType.Boolean, pItem.FlagEstado);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.ExecuteNonQuery(dbCommand);

        }

       
        public void Elimina(AccidenteCostoBE pItem)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteCosto_Elimina");

            db.AddInParameter(dbCommand, "pIdAccidenteCosto", DbType.Int32, pItem.IdAccidenteCosto);
            db.AddInParameter(dbCommand, "pIdEmpresa", DbType.Int32, pItem.IdEmpresa);
            db.AddInParameter(dbCommand, "pUsuario", DbType.String, pItem.Usuario);
            db.AddInParameter(dbCommand, "pMaquina", DbType.String, pItem.Maquina);

            db.ExecuteNonQuery(dbCommand);

        }

        public AccidenteCostoBE Selecciona(int IdAccidenteCosto)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteCosto_Selecciona");
            db.AddInParameter(dbCommand, "pidAccidenteCosto", DbType.Int32, IdAccidenteCosto);

            IDataReader reader = db.ExecuteReader(dbCommand);
            AccidenteCostoBE AccidenteCosto = null;
            while (reader.Read())
            {
                AccidenteCosto = new AccidenteCostoBE();
                AccidenteCosto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                AccidenteCosto.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                AccidenteCosto.IdAccidenteCosto = Int32.Parse(reader["idAccidenteCosto"].ToString());
                AccidenteCosto.DiasPerdido = Int32.Parse(reader["DiasPerdido"].ToString());
                AccidenteCosto.CostoDia = Decimal.Parse(reader["CostoDia"].ToString());
                AccidenteCosto.TotalCostoDia = Decimal.Parse(reader["TotalCostoDia"].ToString());
                AccidenteCosto.HorasExtra = Int32.Parse(reader["HorasExtra"].ToString());
                AccidenteCosto.CostoHorasExtra = Decimal.Parse(reader["CostoHorasExtra"].ToString());
                AccidenteCosto.TotalCostoHorasExtra = Decimal.Parse(reader["TotalCostoHorasExtra"].ToString());
                AccidenteCosto.CostoEnergia = Decimal.Parse(reader["CostoEnergia"].ToString());
                AccidenteCosto.TiempoTrabajado = Int32.Parse(reader["TiempoTrabajado"].ToString());
                AccidenteCosto.Salario = Decimal.Parse(reader["Salario"].ToString());
                AccidenteCosto.SubTotalReemplazo = Decimal.Parse(reader["SubTotalReemplazo"].ToString());
                AccidenteCosto.ReadaptacionTrabajo = Decimal.Parse(reader["ReadaptacionTrabajo"].ToString());
                AccidenteCosto.ReingresoAccidentado = Decimal.Parse(reader["ReingresoAccidentado"].ToString());
                AccidenteCosto.ParalizacionMaquina = Decimal.Parse(reader["ParalizacionMaquina"].ToString());
                AccidenteCosto.ManoObra = Decimal.Parse(reader["ManoObra"].ToString());
                AccidenteCosto.Repuestos = Decimal.Parse(reader["Repuestos"].ToString());
                AccidenteCosto.TiempoPerdidoTotal = Decimal.Parse(reader["TiempoPerdidoTotal"].ToString());
                AccidenteCosto.NumeroTrabajadores = Int32.Parse(reader["NumeroTrabajadores"].ToString());
                AccidenteCosto.SalarioPromedio = Decimal.Parse(reader["SalarioPromedio"].ToString());
                AccidenteCosto.SubTotalSalario = Decimal.Parse(reader["SubTotalSalario"].ToString());
                AccidenteCosto.TiempoPerdidoSupervisor = Int32.Parse(reader["TiempoPerdidoSupervisor"].ToString());
                AccidenteCosto.CostoHoraSupervisor = Decimal.Parse(reader["CostoHoraSupervisor"].ToString());
                AccidenteCosto.CostoTotalSupervisor = Decimal.Parse(reader["CostoTotalSupervisor"].ToString());
                AccidenteCosto.CostoTotalAccidentado = Decimal.Parse(reader["CostoTotalAccidentado"].ToString());
                AccidenteCosto.CostoAdministrativo = Decimal.Parse(reader["CostoAdministrativo"].ToString());
                AccidenteCosto.CostoTraslado = Decimal.Parse(reader["CostoTraslado"].ToString());
                AccidenteCosto.CostoEnfermo = Decimal.Parse(reader["CostoEnfermo"].ToString());
                AccidenteCosto.CostoMaterial = Decimal.Parse(reader["CostoMaterial"].ToString());
                AccidenteCosto.CostoParamedico = Decimal.Parse(reader["CostoParamedico"].ToString());
                AccidenteCosto.CostoDiverso = Decimal.Parse(reader["CostoDiverso"].ToString());
                AccidenteCosto.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                AccidenteCosto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
            }
            reader.Close();
            reader.Dispose();
            return AccidenteCosto;
        }

        public List<AccidenteCostoBE> ListaTodosActivo(int IdAccidente)
        {
            Database db = DatabaseFactory.CreateDatabase("cnSSOMABD");
            DbCommand dbCommand = db.GetStoredProcCommand("usp_AccidenteCosto_ListaTodosActivo");
            db.AddInParameter(dbCommand, "pIdAccidente", DbType.Int32, IdAccidente);

            IDataReader reader = db.ExecuteReader(dbCommand);
            List<AccidenteCostoBE> AccidenteCostolist = new List<AccidenteCostoBE>();
            AccidenteCostoBE AccidenteCosto;
            while (reader.Read())
            {
                AccidenteCosto = new AccidenteCostoBE();
                AccidenteCosto.IdEmpresa = Int32.Parse(reader["IdEmpresa"].ToString());
                AccidenteCosto.IdAccidente = Int32.Parse(reader["idAccidente"].ToString());
                AccidenteCosto.IdAccidenteCosto = Int32.Parse(reader["idAccidenteCosto"].ToString());
                AccidenteCosto.DiasPerdido = Int32.Parse(reader["DiasPerdido"].ToString());
                AccidenteCosto.CostoDia = Decimal.Parse(reader["CostoDia"].ToString());
                AccidenteCosto.TotalCostoDia = Decimal.Parse(reader["TotalCostoDia"].ToString());
                AccidenteCosto.HorasExtra = Int32.Parse(reader["HorasExtra"].ToString());
                AccidenteCosto.CostoHorasExtra = Decimal.Parse(reader["CostoHorasExtra"].ToString());
                AccidenteCosto.TotalCostoHorasExtra = Decimal.Parse(reader["TotalCostoHorasExtra"].ToString());
                AccidenteCosto.CostoEnergia = Decimal.Parse(reader["CostoEnergia"].ToString());
                AccidenteCosto.TiempoTrabajado = Int32.Parse(reader["TiempoTrabajado"].ToString());
                AccidenteCosto.Salario = Decimal.Parse(reader["Salario"].ToString());
                AccidenteCosto.SubTotalReemplazo = Decimal.Parse(reader["SubTotalReemplazo"].ToString());
                AccidenteCosto.ReadaptacionTrabajo = Decimal.Parse(reader["ReadaptacionTrabajo"].ToString());
                AccidenteCosto.ReingresoAccidentado = Decimal.Parse(reader["ReingresoAccidentado"].ToString());
                AccidenteCosto.ParalizacionMaquina = Decimal.Parse(reader["ParalizacionMaquina"].ToString());
                AccidenteCosto.ManoObra = Decimal.Parse(reader["ManoObra"].ToString());
                AccidenteCosto.Repuestos = Decimal.Parse(reader["Repuestos"].ToString());
                AccidenteCosto.TiempoPerdidoTotal = Decimal.Parse(reader["TiempoPerdidoTotal"].ToString());
                AccidenteCosto.NumeroTrabajadores = Int32.Parse(reader["NumeroTrabajadores"].ToString());
                AccidenteCosto.SalarioPromedio = Decimal.Parse(reader["SalarioPromedio"].ToString());
                AccidenteCosto.SubTotalSalario = Decimal.Parse(reader["SubTotalSalario"].ToString());
                AccidenteCosto.TiempoPerdidoSupervisor = Int32.Parse(reader["TiempoPerdidoSupervisor"].ToString());
                AccidenteCosto.CostoHoraSupervisor = Decimal.Parse(reader["CostoHoraSupervisor"].ToString());
                AccidenteCosto.CostoTotalSupervisor = Decimal.Parse(reader["CostoTotalSupervisor"].ToString());
                AccidenteCosto.CostoTotalAccidentado = Decimal.Parse(reader["CostoTotalAccidentado"].ToString());
                AccidenteCosto.CostoAdministrativo = Decimal.Parse(reader["CostoAdministrativo"].ToString());
                AccidenteCosto.CostoTraslado = Decimal.Parse(reader["CostoTraslado"].ToString());
                AccidenteCosto.CostoEnfermo = Decimal.Parse(reader["CostoEnfermo"].ToString());
                AccidenteCosto.CostoMaterial = Decimal.Parse(reader["CostoMaterial"].ToString());
                AccidenteCosto.CostoParamedico = Decimal.Parse(reader["CostoParamedico"].ToString());
                AccidenteCosto.CostoDiverso = Decimal.Parse(reader["CostoDiverso"].ToString());
                AccidenteCosto.CostoTotal = Decimal.Parse(reader["CostoTotal"].ToString());
                AccidenteCosto.FlagEstado = Boolean.Parse(reader["flagestado"].ToString());
                AccidenteCosto.TipoOper = 4; //CONSULTAR
                AccidenteCostolist.Add(AccidenteCosto);
            }
            reader.Close();
            reader.Dispose();
            return AccidenteCostolist;
        }
    }
}
