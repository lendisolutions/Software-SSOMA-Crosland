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
    public class ReporteResumenPersonaBL
    {
        public List<ReporteResumenPersonaBE> Listado(int IdEmpresa, int IdTema, int IdPersona)
        {
            try
            {
                ReporteResumenPersonaDL ReporteResumenPersona = new ReporteResumenPersonaDL();
                return ReporteResumenPersona.Listado(IdEmpresa,IdTema,IdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteResumenPersonaBE> ListadoHorasAnualEmpresaResponsable()
        {
            try
            {
                List<EmpresaBE> lstEmpresa;
                List<ReporteResumenPersonaBE> lstHorasAnualEmpresa;

                lstEmpresa = new EmpresaDL().ListaCombo(Parametros.intTECorporativo);
                lstHorasAnualEmpresa = new ReporteResumenPersonaDL().ListadoHorasAnualEmpresaResponsable();

                List<string> lstPeriodo = new List<string>();
                foreach (var item in lstHorasAnualEmpresa)
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
                        var Buscar = lstHorasAnualEmpresa.Where(oB => oB.Periodo == strPeriodo && oB.EmpresaResponsable == ItemEmpresa.RazonSocial).ToList();
                        if (Buscar.Count == 0)
                        {
                            ReporteResumenPersonaBE objE_ReporteResumenPersona = new ReporteResumenPersonaBE();
                            objE_ReporteResumenPersona.Periodo = strPeriodo;
                            objE_ReporteResumenPersona.EmpresaResponsable = ItemEmpresa.RazonSocial;
                            objE_ReporteResumenPersona.Horas = 0;
                            lstHorasAnualEmpresa.Add(objE_ReporteResumenPersona);
                        }
                    }
                }

                return lstHorasAnualEmpresa;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteResumenPersonaBE> ListadoHorasAnualUnidadMineraResponsable(int IdEmpresaResponsable)
        {
            try
            {
                ReporteResumenPersonaDL ResumenPersona = new ReporteResumenPersonaDL();
                return ResumenPersona.ListadoHorasAnualUnidadMineraResponsable(IdEmpresaResponsable);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteResumenPersonaBE> ListadoHorasMensualEmpresaResponsable(int Periodo)
        {
            try
            {
                List<EmpresaBE> lstEmpresa;
                List<ReporteResumenPersonaBE> lstHorasMensualEmpresa;

                lstEmpresa = new EmpresaDL().ListaCombo(Parametros.intTECorporativo);
                lstHorasMensualEmpresa = new ReporteResumenPersonaDL().ListadoHorasMensualEmpresaResponsable(Periodo);

                List<string> lstMes = new List<string>();
                foreach (var item in lstHorasMensualEmpresa)
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
                        var Buscar = lstHorasMensualEmpresa.Where(oB => oB.Mes == strMes && oB.EmpresaResponsable == ItemEmpresa.RazonSocial).ToList();
                        if (Buscar.Count == 0)
                        {
                            ReporteResumenPersonaBE objE_ReporteResumenPersona = new ReporteResumenPersonaBE();
                            objE_ReporteResumenPersona.Periodo = Periodo.ToString();
                            objE_ReporteResumenPersona.Mes = strMes;
                            objE_ReporteResumenPersona.EmpresaResponsable = ItemEmpresa.RazonSocial;
                            objE_ReporteResumenPersona.Horas = 0;
                            lstHorasMensualEmpresa.Add(objE_ReporteResumenPersona);
                        }
                    }
                }

                return lstHorasMensualEmpresa;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteResumenPersonaBE> ListadoHorasMensualUnidadMineraResponsable(int Periodo, int IdEmpresaResponsable)
        {
            try
            {
                ReporteResumenPersonaDL ResumenPersona = new ReporteResumenPersonaDL();
                return ResumenPersona.ListadoHorasMensualUnidadMineraResponsable(Periodo, IdEmpresaResponsable);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
