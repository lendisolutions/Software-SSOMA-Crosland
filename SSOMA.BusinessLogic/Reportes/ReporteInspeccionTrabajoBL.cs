using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class ReporteInspeccionTrabajoBL
    {
        public List<ReporteInspeccionTrabajoBE> Listado(int IdInspeccionTrabajo)
        {
            try
            {
                ReporteInspeccionTrabajoDL ReporteInspeccionTrabajo = new ReporteInspeccionTrabajoDL();
                return ReporteInspeccionTrabajo.Listado(IdInspeccionTrabajo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteInspeccionTrabajoBE> ListadoPendiente(int IdInspeccionTrabajo)
        {
            try
            {
                ReporteInspeccionTrabajoDL ReporteInspeccionTrabajo = new ReporteInspeccionTrabajoDL();
                return ReporteInspeccionTrabajo.ListadoPendiente(IdInspeccionTrabajo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteInspeccionTrabajoBE> ListadoSituacion(int IdEmpresa, int IdSituacion, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteInspeccionTrabajoDL ReporteInspeccionTrabajo = new ReporteInspeccionTrabajoDL();
                return ReporteInspeccionTrabajo.ListadoSituacion(IdEmpresa,IdSituacion,FechaDesde,FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteInspeccionTrabajoBE> ListadoSituacionAnualEmpresa(int IdEmpresa)
        {
            try
            {
                ReporteInspeccionTrabajoDL ReporteInspeccionTrabajo = new ReporteInspeccionTrabajoDL();
                return ReporteInspeccionTrabajo.ListadoSituacionAnualEmpresa(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteInspeccionTrabajoBE> ListadoSituacionMesualEmpresa(int IdEmpresa, int Periodo)
        {
            try
            {
                ReporteInspeccionTrabajoDL ReporteInspeccionTrabajo = new ReporteInspeccionTrabajoDL();
                return ReporteInspeccionTrabajo.ListadoSituacionMesualEmpresa(IdEmpresa, Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteInspeccionTrabajoBE> ListadoSituacionAnualSede(int IdEmpresa)
        {
            try
            {
                ReporteInspeccionTrabajoDL ReporteInspeccionTrabajo = new ReporteInspeccionTrabajoDL();
                return ReporteInspeccionTrabajo.ListadoSituacionAnualSede(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteInspeccionTrabajoBE> ListadoSituacionMesualSede(int IdEmpresa, int Periodo)
        {
            try
            {
                ReporteInspeccionTrabajoDL ReporteInspeccionTrabajo = new ReporteInspeccionTrabajoDL();
                return ReporteInspeccionTrabajo.ListadoSituacionMesualSede(IdEmpresa,Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteInspeccionTrabajoBE> ListadoTipoFecha(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteInspeccionTrabajoDL ReporteInspeccionTrabajo = new ReporteInspeccionTrabajoDL();
                return ReporteInspeccionTrabajo.ListadoTipoFecha(IdEmpresa, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteInspeccionTrabajoBE> ListadoSituacionSede(int IdEmpresa, int IdUnidadMinera, int IdSituacion, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteInspeccionTrabajoDL ReporteInspeccionTrabajo = new ReporteInspeccionTrabajoDL();
                return ReporteInspeccionTrabajo.ListadoSituacionSede(IdEmpresa, IdUnidadMinera, IdSituacion, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteInspeccionTrabajoBE> ListadoConsolidado(int Periodo)
        {
            try
            {
                ReporteInspeccionTrabajoDL ReporteInspeccionTrabajo = new ReporteInspeccionTrabajoDL();
                return ReporteInspeccionTrabajo.ListadoConsolidado(Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteInspeccionTrabajoBE> ListadoSituacionAnualEmpresaContratista(int IdEmpresaContratista)
        {
            try
            {
                ReporteInspeccionTrabajoDL ReporteInspeccionTrabajo = new ReporteInspeccionTrabajoDL();
                return ReporteInspeccionTrabajo.ListadoSituacionAnualEmpresaContratista(IdEmpresaContratista);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteInspeccionTrabajoBE> ListadoTipoFechaEmpresaContratista(int IdEmpresaContratista, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteInspeccionTrabajoDL ReporteInspeccionTrabajo = new ReporteInspeccionTrabajoDL();
                return ReporteInspeccionTrabajo.ListadoTipoFechaEmpresaContratista(IdEmpresaContratista, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteInspeccionTrabajoBE> ListadoSituacionEmpresaContratista(int IdEmpresaContratista, int IdSituacion, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteInspeccionTrabajoDL ReporteInspeccionTrabajo = new ReporteInspeccionTrabajoDL();
                return ReporteInspeccionTrabajo.ListadoSituacionEmpresaContratista(IdEmpresaContratista, IdSituacion, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
