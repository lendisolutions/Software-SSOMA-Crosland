using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class ReporteEppBL
    {
        public List<ReporteEppBE> Listado(int IdEpp)
        {
            try
            {
                ReporteEppDL Epp = new ReporteEppDL();
                return Epp.Listado(IdEpp);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteEppBE> ListadoPorPersona(int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdPersona, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteEppDL Epp = new ReporteEppDL();
                return Epp.ListadoPorPersona(IdEmpresaResponsable, IdUnidadMineraResponsable, IdAreaResponsable, IdPersona, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteEppBE> ListadoPersonaConsumo(int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteEppDL Epp = new ReporteEppDL();
                return Epp.ListadoPersonaConsumo(IdEmpresaResponsable, IdUnidadMineraResponsable, IdAreaResponsable, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteEppBE> ListadoPorTipoEntrega(int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdTipoEntrega, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteEppDL Epp = new ReporteEppDL();
                return Epp.ListadoPorTipoEntrega(IdEmpresaResponsable, IdUnidadMineraResponsable, IdAreaResponsable, IdTipoEntrega, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteEppBE> ListadoEmpresaResponsable(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteEppDL Epp = new ReporteEppDL();
                return Epp.ListadoEmpresaResponsable(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteEppBE> ListadoUnidadMineraResponsable(int IdEmpresaResponsable, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteEppDL Epp = new ReporteEppDL();
                return Epp.ListadoUnidadMineraResponsable(IdEmpresaResponsable, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteEppBE> ListadoAreaResponsable(int IdEmpresaResponsable, int IdUnidadMineraResponsable, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteEppDL Epp = new ReporteEppDL();
                return Epp.ListadoAreaResponsable(IdEmpresaResponsable, IdUnidadMineraResponsable, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteEppBE> ListadoEquipo(int IdEmpresaResponsable, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteEppDL Epp = new ReporteEppDL();
                return Epp.ListadoEquipo(IdEmpresaResponsable,FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteEppBE> ListadoRegistroEntrega(int IdEmpresaResponsable, int IdUnidadMineraResponsable, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteEppDL Epp = new ReporteEppDL();
                return Epp.ListadoRegistroEntrega(IdEmpresaResponsable, IdUnidadMineraResponsable, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteEppBE> ListadoConsumoAnualEmpresaResponsable()
        {
            try
            {
                List<EmpresaBE> lstEmpresa;
                List<ReporteEppBE> lstConsumoAnualEmpresa;

                lstEmpresa = new EmpresaDL().ListaCombo(Parametros.intTECorporativo);
                lstConsumoAnualEmpresa = new ReporteEppDL().ListadoConsumoAnualEmpresaResponsable();

                List<string> lstPeriodo = new List<string>();
                foreach (var item in lstConsumoAnualEmpresa)
                {
                    var Buscar = lstPeriodo.Where(x => x.Contains(item.Periodo)).ToList();
                    if (Buscar.Count == 0)
                    {
                        lstPeriodo.Add(item.Periodo);
                    }
                }

                foreach (string strPeriodo in lstPeriodo)
                {
                    foreach (var ItemEmpresa in lstEmpresa)
                    {
                        var Buscar = lstConsumoAnualEmpresa.Where(oB => oB.Periodo == strPeriodo && oB.EmpresaResponsable== ItemEmpresa.RazonSocial).ToList();
                        if (Buscar.Count == 0)
                        {
                            ReporteEppBE objE_ReporteEpp = new ReporteEppBE();
                            objE_ReporteEpp.Periodo = strPeriodo;
                            objE_ReporteEpp.EmpresaResponsable = ItemEmpresa.RazonSocial;
                            objE_ReporteEpp.Total = 0;
                            lstConsumoAnualEmpresa.Add(objE_ReporteEpp);
                        }
                    }
                }

                return lstConsumoAnualEmpresa;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteEppBE> ListadoConsumoAnualUnidadMineraResponsable(int IdEmpresaResponsable)
        {
            try
            {
                ReporteEppDL Epp = new ReporteEppDL();
                return Epp.ListadoConsumoAnualUnidadMineraResponsable(IdEmpresaResponsable);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteEppBE> ListadoConsumoAnualNegocio(int IdEmpresaResponsable)
        {
            try
            {
                ReporteEppDL Epp = new ReporteEppDL();
                return Epp.ListadoConsumoAnualNegocio(IdEmpresaResponsable);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteEppBE> ListadoConsumoAnualAreaResponsable(int IdEmpresaResponsable, int IdUnidadMineraResponsable)
        {
            try
            {
                ReporteEppDL Epp = new ReporteEppDL();
                return Epp.ListadoConsumoAnualAreaResponsable(IdEmpresaResponsable, IdUnidadMineraResponsable);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteEppBE> ListadoConsumoAnualSectorResponsable(int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable)
        {
            try
            {
                ReporteEppDL Epp = new ReporteEppDL();
                return Epp.ListadoConsumoAnualSectorResponsable(IdEmpresaResponsable, IdUnidadMineraResponsable, IdAreaResponsable);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteEppBE> ListadoConsumoMensualEmpresaResponsable(int Periodo)
        {
            try
            {
                List<EmpresaBE> lstEmpresa;
                List<ReporteEppBE> lstConsumoMensualEmpresa;

                lstEmpresa = new EmpresaDL().ListaCombo(Parametros.intTECorporativo);
                lstConsumoMensualEmpresa = new ReporteEppDL().ListadoConsumoMensualEmpresaResponsable(Periodo);

                List<string> lstMes = new List<string>();
                foreach (var item in lstConsumoMensualEmpresa)
                {
                    var Buscar = lstMes.Where(x => x.Contains(item.Mes)).ToList();
                    if (Buscar.Count == 0)
                    {
                        lstMes.Add(item.Mes);
                    }
                }

                foreach (string strMes in lstMes)
                {
                    foreach (var ItemEmpresa in lstEmpresa)
                    {
                        var Buscar = lstConsumoMensualEmpresa.Where(oB => oB.Mes == strMes && oB.EmpresaResponsable == ItemEmpresa.RazonSocial).ToList();
                        if (Buscar.Count == 0)
                        {
                            ReporteEppBE objE_ReporteEpp = new ReporteEppBE();
                            objE_ReporteEpp.Periodo = Periodo.ToString();
                            objE_ReporteEpp.Mes = strMes;
                            objE_ReporteEpp.EmpresaResponsable = ItemEmpresa.RazonSocial;
                            objE_ReporteEpp.Total = 0;
                            lstConsumoMensualEmpresa.Add(objE_ReporteEpp);
                        }
                    }
                }

                return lstConsumoMensualEmpresa;
            }

            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteEppBE> ListadoConsumoMensualUnidadMineraResponsable(int Periodo, int IdEmpresaResponsable)
        {
            try
            {
                ReporteEppDL Epp = new ReporteEppDL();
                return Epp.ListadoConsumoMensualUnidadMineraResponsable(Periodo, IdEmpresaResponsable);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteEppBE> ListadoConsumoMensualNegocio(int Periodo, int IdEmpresaResponsable)
        {
            try
            {
                ReporteEppDL Epp = new ReporteEppDL();
                return Epp.ListadoConsumoMensualNegocio(Periodo, IdEmpresaResponsable);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteEppBE> ListadoConsumoMensualAreaResponsable(int Periodo, int IdEmpresaResponsable, int IdUnidadMineraResponsable)
        {
            try
            {
                ReporteEppDL Epp = new ReporteEppDL();
                return Epp.ListadoConsumoMensualAreaResponsable(Periodo, IdEmpresaResponsable, IdUnidadMineraResponsable);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteEppBE> ListadoConsumoMensualSectorResponsable(int Periodo, int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable)
        {
            try
            {
                ReporteEppDL Epp = new ReporteEppDL();
                return Epp.ListadoConsumoMensualSectorResponsable(Periodo, IdEmpresaResponsable, IdUnidadMineraResponsable, IdAreaResponsable);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteEppBE> ListadoConsumoResumen(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteEppDL Epp = new ReporteEppDL();
                return Epp.ListadoConsumoResumen(FechaDesde,FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
