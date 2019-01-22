using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class ReporteCapacitacionBL
    {
        public List<ReporteCapacitacionBE> Listado(int IdCapacitacion)
        {
            try
            {
                ReporteCapacitacionDL Capacitacion = new ReporteCapacitacionDL();
                return Capacitacion.Listado(IdCapacitacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteCapacitacionBE> ListadoPersonaFecha(int IdPersona, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteCapacitacionDL Capacitacion = new ReporteCapacitacionDL();
                return Capacitacion.ListadoPersonaFecha(IdPersona,FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteCapacitacionBE> ListadoProveedorFecha(int IdProveedor, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteCapacitacionDL Capacitacion = new ReporteCapacitacionDL();
                return Capacitacion.ListadoProveedorFecha(IdProveedor, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteCapacitacionBE> ListadoExpositorFecha(int IdExpositor, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteCapacitacionDL Capacitacion = new ReporteCapacitacionDL();
                return Capacitacion.ListadoExpositorFecha(IdExpositor, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteCapacitacionBE> ListadoTemaFecha(int IdTema, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteCapacitacionDL Capacitacion = new ReporteCapacitacionDL();
                return Capacitacion.ListadoTemaFecha(IdTema, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteCapacitacionBE> ListadoTipoFecha(int IdEmpresa, int IdTipo, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteCapacitacionDL Capacitacion = new ReporteCapacitacionDL();
                return Capacitacion.ListadoTipoFecha(IdEmpresa,IdTipo, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteCapacitacionBE> ListadoClasificacionFecha(int IdClasificacion, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteCapacitacionDL Capacitacion = new ReporteCapacitacionDL();
                return Capacitacion.ListadoClasificacionFecha(IdClasificacion, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteCapacitacionBE> ListadoAprobadaFecha(int IdEmpresa, int IdTema, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteCapacitacionDL Capacitacion = new ReporteCapacitacionDL();
                return Capacitacion.ListadoAprobadaFecha(IdEmpresa,IdTema, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteCapacitacionBE> ListadoDesaprobadaFecha(int IdEmpresa, int IdTema, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteCapacitacionDL Capacitacion = new ReporteCapacitacionDL();
                return Capacitacion.ListadoDesaprobadaFecha(IdEmpresa, IdTema, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteCapacitacionBE> ListadoHorasAnualEmpresaResponsable()
        {
            try
            {
                List<EmpresaBE> lstEmpresa;
                List<ReporteCapacitacionBE> lstHorasAnualEmpresa;

                lstEmpresa = new EmpresaDL().ListaCombo(Parametros.intTECorporativo);
                lstHorasAnualEmpresa = new ReporteCapacitacionDL().ListadoHorasAnualEmpresaResponsable();

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
                            ReporteCapacitacionBE objE_ReporteCapacitacion = new ReporteCapacitacionBE();
                            objE_ReporteCapacitacion.Periodo = strPeriodo;
                            objE_ReporteCapacitacion.EmpresaResponsable = ItemEmpresa.RazonSocial;
                            objE_ReporteCapacitacion.Horas = 0;
                            lstHorasAnualEmpresa.Add(objE_ReporteCapacitacion);
                        }
                    }
                }

                return lstHorasAnualEmpresa;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteCapacitacionBE> ListadoHorasAnualUnidadMineraResponsable(int IdEmpresaResponsable)
        {
            try
            {
                ReporteCapacitacionDL Capacitacion = new ReporteCapacitacionDL();
                return Capacitacion.ListadoHorasAnualUnidadMineraResponsable(IdEmpresaResponsable);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteCapacitacionBE> ListadoHorasAnualNegocio(int IdEmpresaResponsable)
        {
            try
            {
                ReporteCapacitacionDL Capacitacion = new ReporteCapacitacionDL();
                return Capacitacion.ListadoHorasAnualNegocio(IdEmpresaResponsable);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteCapacitacionBE> ListadoHorasAnualAreaResponsable(int IdEmpresaResponsable, int IdUnidadMineraResponsable)
        {
            try
            {
                ReporteCapacitacionDL Capacitacion = new ReporteCapacitacionDL();
                return Capacitacion.ListadoHorasAnualAreaResponsable(IdEmpresaResponsable, IdUnidadMineraResponsable);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteCapacitacionBE> ListadoHorasAnualTipo(int IdEmpresaResponsable)
        {
            try
            {
                List<TipoCapacitacionBE> lstTipoCapacitacion;
                List<ReporteCapacitacionBE> lstHorasAnualTipo;

                lstTipoCapacitacion = new TipoCapacitacionDL().ListaCombo(0);
                lstHorasAnualTipo = new ReporteCapacitacionDL().ListadoHorasAnualTipo(IdEmpresaResponsable);

                List<string> lstPeriodo = new List<string>();
                foreach (var item in lstHorasAnualTipo)
                { 
                    var Buscar = lstPeriodo.Where(x => x.Contains(item.Periodo)).ToList();
                    if (Buscar.Count == 0)
                    {
                        lstPeriodo.Add(item.Periodo);
                    }
                }

                foreach (string strPeriodo in lstPeriodo)
                {
                    foreach (var ItemTipo in lstTipoCapacitacion)
                    {
                        var Buscar = lstHorasAnualTipo.Where(oB => oB.Periodo == strPeriodo && oB.DescTipoCapacitacion == ItemTipo.DescTipoCapacitacion).ToList();
                        if (Buscar.Count == 0)
                        {
                            ReporteCapacitacionBE objE_ReporteCapacitacion = new ReporteCapacitacionBE();
                            objE_ReporteCapacitacion.Periodo = strPeriodo;
                            objE_ReporteCapacitacion.DescTipoCapacitacion = ItemTipo.DescTipoCapacitacion;
                            objE_ReporteCapacitacion.Horas = 0;
                            lstHorasAnualTipo.Add(objE_ReporteCapacitacion);
                        }
                    }
                }

                return lstHorasAnualTipo;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteCapacitacionBE> ListadoHorasAnualClasificacion(int IdEmpresaResponsable)
        {
            try
            {
                List<TablaElementoBE> lstClasificacionCapacitacion;
                List<ReporteCapacitacionBE> lstHorasAnualClasificacion;

                lstClasificacionCapacitacion = new TablaElementoDL().ListaTodosActivo(0, Parametros.intTblClasificacionCapacitacion);
                lstHorasAnualClasificacion = new ReporteCapacitacionDL().ListadoHorasAnualClasificacion(IdEmpresaResponsable);

                List<string> lstPeriodo = new List<string>();
                foreach (var item in lstHorasAnualClasificacion)
                {
                    var Buscar = lstPeriodo.Where(x => x.Contains(item.Periodo)).ToList();
                    if (Buscar.Count == 0)
                    {
                        lstPeriodo.Add(item.Periodo);
                    }
                }

                foreach (string strPeriodo in lstPeriodo)
                {
                    foreach (var ItemClasificacion in lstClasificacionCapacitacion)
                    {
                        var Buscar = lstHorasAnualClasificacion.Where(oB => oB.Periodo == strPeriodo && oB.DescClasificacionCapacitacion == ItemClasificacion.DescTablaElemento).ToList();
                        if (Buscar.Count == 0)
                        {
                            ReporteCapacitacionBE objE_ReporteCapacitacion = new ReporteCapacitacionBE();
                            objE_ReporteCapacitacion.Periodo = strPeriodo;
                            objE_ReporteCapacitacion.DescClasificacionCapacitacion = ItemClasificacion.DescTablaElemento;
                            objE_ReporteCapacitacion.Horas = 0;
                            lstHorasAnualClasificacion.Add(objE_ReporteCapacitacion);
                        }
                    }
                }

                return lstHorasAnualClasificacion;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteCapacitacionBE> ListadoHorasMensualEmpresaResponsable(int Periodo)
        {
            try
            {
                List<EmpresaBE> lstEmpresa;
                List<ReporteCapacitacionBE> lstHorasMensualEmpresa;

                lstEmpresa = new EmpresaDL().ListaCombo(Parametros.intTECorporativo);
                lstHorasMensualEmpresa = new ReporteCapacitacionDL().ListadoHorasMensualEmpresaResponsable(Periodo);

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
                            ReporteCapacitacionBE objE_ReporteCapacitacion = new ReporteCapacitacionBE();
                            objE_ReporteCapacitacion.Periodo = Periodo.ToString();
                            objE_ReporteCapacitacion.Mes = strMes;
                            objE_ReporteCapacitacion.EmpresaResponsable = ItemEmpresa.RazonSocial;
                            objE_ReporteCapacitacion.Horas = 0;
                            lstHorasMensualEmpresa.Add(objE_ReporteCapacitacion);
                        }
                    }
                }

                return lstHorasMensualEmpresa;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteCapacitacionBE> ListadoHorasMensualUnidadMineraResponsable(int Periodo, int IdEmpresaResponsable)
        {
            try
            {
                ReporteCapacitacionDL Capacitacion = new ReporteCapacitacionDL();
                return Capacitacion.ListadoHorasMensualUnidadMineraResponsable(Periodo, IdEmpresaResponsable);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteCapacitacionBE> ListadoHorasMensualNegocio(int Periodo, int IdEmpresaResponsable)
        {
            try
            {
                ReporteCapacitacionDL Capacitacion = new ReporteCapacitacionDL();
                return Capacitacion.ListadoHorasMensualNegocio(Periodo, IdEmpresaResponsable);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteCapacitacionBE> ListadoHorasMensualAreaResponsable(int Periodo, int IdEmpresaResponsable, int IdUnidadMineraResponsable)
        {
            try
            {
                ReporteCapacitacionDL Capacitacion = new ReporteCapacitacionDL();
                return Capacitacion.ListadoHorasMensualAreaResponsable(Periodo, IdEmpresaResponsable, IdUnidadMineraResponsable);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteCapacitacionBE> ListadoHorasMensualTipo(int Periodo, int IdEmpresaResponsable)
        {
            try
            {
                List<TipoCapacitacionBE> lstTipoCapacitacion;
                List<ReporteCapacitacionBE> lstHorasMensualTipo;

                lstTipoCapacitacion = new TipoCapacitacionDL().ListaCombo(0);
                lstHorasMensualTipo = new ReporteCapacitacionDL().ListadoHorasMensualTipo(Periodo,IdEmpresaResponsable);

                List<string> lstMes = new List<string>();
                foreach (var item in lstHorasMensualTipo)
                {
                    var Buscar = lstMes.Where(x => x.Contains(item.Mes)).ToList();
                    if (Buscar.Count == 0)
                    {
                        lstMes.Add(item.Mes);
                    }
                }

                foreach (string strMes in lstMes)
                {
                    foreach (var ItemTipo in lstTipoCapacitacion)
                    {
                        var Buscar = lstHorasMensualTipo.Where(oB => oB.Mes== strMes && oB.DescTipoCapacitacion == ItemTipo.DescTipoCapacitacion).ToList();
                        if (Buscar.Count == 0)
                        {
                            ReporteCapacitacionBE objE_ReporteCapacitacion = new ReporteCapacitacionBE();
                            objE_ReporteCapacitacion.Periodo = Periodo.ToString();
                            objE_ReporteCapacitacion.Mes = strMes;
                            objE_ReporteCapacitacion.DescTipoCapacitacion = ItemTipo.DescTipoCapacitacion;
                            objE_ReporteCapacitacion.Horas = 0;
                            lstHorasMensualTipo.Add(objE_ReporteCapacitacion);
                        }
                    }
                }

                return lstHorasMensualTipo;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteCapacitacionBE> ListadoHorasMensualClasificacion(int Periodo, int IdEmpresaResponsable)
        {
            try
            {
                List<TablaElementoBE> lstClasificacionCapacitacion;
                List<ReporteCapacitacionBE> lstHorasMensualClasificacion;

                lstClasificacionCapacitacion = new TablaElementoDL().ListaTodosActivo(0, Parametros.intTblClasificacionCapacitacion);
                lstHorasMensualClasificacion = new ReporteCapacitacionDL().ListadoHorasMensualClasificacion(Periodo, IdEmpresaResponsable);

                List<string> lstMes = new List<string>();
                foreach (var item in lstHorasMensualClasificacion)
                {
                    var Buscar = lstMes.Where(x => x.Contains(item.Mes)).ToList();
                    if (Buscar.Count == 0)
                    {
                        lstMes.Add(item.Mes);
                    }
                }

                foreach (string strMes in lstMes)
                {
                    foreach (var ItemClasificacion in lstClasificacionCapacitacion)
                    {
                        var Buscar = lstHorasMensualClasificacion.Where(oB => oB.Mes == strMes && oB.DescClasificacionCapacitacion == ItemClasificacion.DescTablaElemento).ToList();
                        if (Buscar.Count == 0)
                        {
                            ReporteCapacitacionBE objE_ReporteCapacitacion = new ReporteCapacitacionBE();
                            objE_ReporteCapacitacion.Periodo = Periodo.ToString();
                            objE_ReporteCapacitacion.Mes = strMes;
                            objE_ReporteCapacitacion.DescClasificacionCapacitacion = ItemClasificacion.DescTablaElemento;
                            objE_ReporteCapacitacion.Horas = 0;
                            lstHorasMensualClasificacion.Add(objE_ReporteCapacitacion);
                        }
                    }
                }

                return lstHorasMensualClasificacion;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteCapacitacionBE> ListadoInasistencia(int IdEmpresa, int Periodo, int IdTipoCapacitacion, int IdClasificacionCapacitacion)
        {
            try
            {
                ReporteCapacitacionDL Capacitacion = new ReporteCapacitacionDL();
                return Capacitacion.ListadoInasistencia(IdEmpresa, Periodo, IdTipoCapacitacion, IdClasificacionCapacitacion);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
