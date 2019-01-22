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
    public class ReporteAccidenteBL
    {
        public List<ReporteAccidenteBE> ListadoResponsable(int IdTipo, int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdResponsable, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteAccidenteDL Accidente = new ReporteAccidenteDL();
                return Accidente.ListadoResponsable(IdTipo, IdEmpresaResponsable, IdUnidadMineraResponsable, IdAreaResponsable, IdResponsable, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAccidenteBE> ListadoPotencialDanio(int IdTipo, int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdPotencialDanio, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteAccidenteDL Accidente = new ReporteAccidenteDL();
                return Accidente.ListadoPotencialDanio(IdTipo, IdEmpresaResponsable, IdUnidadMineraResponsable, IdAreaResponsable, IdPotencialDanio, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAccidenteBE> ListadoTipoAccidente(int IdTipo, int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdTipoAccidente, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteAccidenteDL Accidente = new ReporteAccidenteDL();
                return Accidente.ListadoTipoAccidente(IdTipo, IdEmpresaResponsable, IdUnidadMineraResponsable, IdAreaResponsable, IdTipoAccidente, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAccidenteBE> ListadoParteLesionada(int IdTipo, int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdParteLesionada, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteAccidenteDL Accidente = new ReporteAccidenteDL();
                return Accidente.ListadoParteLesionada(IdTipo, IdEmpresaResponsable, IdUnidadMineraResponsable, IdAreaResponsable, IdParteLesionada, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAccidenteBE> ListadoTipoLesion(int IdTipo, int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdTipoLesion, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteAccidenteDL Accidente = new ReporteAccidenteDL();
                return Accidente.ListadoTipoLesion(IdTipo, IdEmpresaResponsable, IdUnidadMineraResponsable, IdAreaResponsable, IdTipoLesion, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAccidenteBE> ListadoFuenteLesion(int IdTipo, int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdFuenteLesion, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteAccidenteDL Accidente = new ReporteAccidenteDL();
                return Accidente.ListadoFuenteLesion(IdTipo, IdEmpresaResponsable, IdUnidadMineraResponsable, IdAreaResponsable, IdFuenteLesion, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAccidenteBE> ListadoActoSubEstandar(int IdTipo, int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdActoSubEstandar, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteAccidenteDL Accidente = new ReporteAccidenteDL();
                return Accidente.ListadoActoSubEstandar(IdTipo, IdEmpresaResponsable, IdUnidadMineraResponsable, IdAreaResponsable, IdActoSubEstandar, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAccidenteBE> ListadoCondicionSubEstandar(int IdTipo, int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdCondicionSubEstandar, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteAccidenteDL Accidente = new ReporteAccidenteDL();
                return Accidente.ListadoCondicionSubEstandar(IdTipo, IdEmpresaResponsable, IdUnidadMineraResponsable, IdAreaResponsable, IdCondicionSubEstandar, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAccidenteBE> ListadoFactorPersonal(int IdTipo, int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdFactorPersonal, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteAccidenteDL Accidente = new ReporteAccidenteDL();
                return Accidente.ListadoFactorPersonal(IdTipo, IdEmpresaResponsable, IdUnidadMineraResponsable, IdAreaResponsable, IdFactorPersonal, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAccidenteBE> ListadoFactorTrabajo(int IdTipo, int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdFactorTrabajo, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteAccidenteDL Accidente = new ReporteAccidenteDL();
                return Accidente.ListadoFactorTrabajo(IdTipo, IdEmpresaResponsable, IdUnidadMineraResponsable, IdAreaResponsable, IdFactorTrabajo, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAccidenteBE> ListadoAccionCorrectiva(int IdTipo, int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteAccidenteDL Accidente = new ReporteAccidenteDL();
                return Accidente.ListadoAccionCorrectiva(IdTipo, IdEmpresaResponsable, IdUnidadMineraResponsable, IdAreaResponsable, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAccidenteBE> ListadoAccionCorrectivaVencida()
        {
            try
            {
                ReporteAccidenteDL Accidente = new ReporteAccidenteDL();
                return Accidente.ListadoAccionCorrectivaVencida();
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAccidenteBE> ListadoAccionCorrectivaVencidaResponsable(string Dni)
        {
            try
            {
                ReporteAccidenteDL Accidente = new ReporteAccidenteDL();
                return Accidente.ListadoAccionCorrectivaVencidaResponsable(Dni);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAccidenteBE> ListadoCostoAnualNegocio(int IdTipo, int IdEmpresaResponsable)
        {
            try
            {
                ReporteAccidenteDL Accidente = new ReporteAccidenteDL();
                return Accidente.ListadoCostoAnualNegocio(IdTipo, IdEmpresaResponsable);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAccidenteBE> ListadoCostoAnualEmpresaResponsable(int IdTipo)
        {
            try
            {
                ReporteAccidenteDL Accidente = new ReporteAccidenteDL();
                return Accidente.ListadoCostoAnualEmpresaResponsable(IdTipo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAccidenteBE> ListadoCostoAnualUnidadMineraResponsable(int IdTipo, int IdEmpresaResponsable)
        {
            try
            {
                ReporteAccidenteDL Accidente = new ReporteAccidenteDL();
                return Accidente.ListadoCostoAnualUnidadMineraResponsable(IdTipo, IdEmpresaResponsable);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAccidenteBE> ListadoCantidadAnualNegocio(int IdTipo, int IdEmpresaResponsable)
        {
            try
            {
                ReporteAccidenteDL Accidente = new ReporteAccidenteDL();
                return Accidente.ListadoCantidadAnualNegocio(IdTipo, IdEmpresaResponsable);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAccidenteBE> ListadoCantidadAnualEmpresaResponsable(int IdTipo)
        {
            try
            {
                ReporteAccidenteDL Accidente = new ReporteAccidenteDL();
                return Accidente.ListadoCantidadAnualEmpresaResponsable(IdTipo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAccidenteBE> ListadoCantidadAnualUnidadMineraResponsable(int IdTipo, int IdEmpresaResponsable)
        {
            try
            {
                ReporteAccidenteDL Accidente = new ReporteAccidenteDL();
                return Accidente.ListadoCantidadAnualUnidadMineraResponsable(IdTipo, IdEmpresaResponsable);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAccidenteBE> ListadoCostoMensualNegocio(int Periodo, int IdTipo, int IdEmpresaResponsable)
        {
            try
            {
                ReporteAccidenteDL Accidente = new ReporteAccidenteDL();
                return Accidente.ListadoCostoMensualNegocio(Periodo,IdTipo, IdEmpresaResponsable);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAccidenteBE> ListadoCostoMensualEmpresaResponsable(int Periodo, int IdTipo)
        {
            try
            {
                ReporteAccidenteDL Accidente = new ReporteAccidenteDL();
                return Accidente.ListadoCostoMensualEmpresaResponsable(Periodo,IdTipo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAccidenteBE> ListadoCostoMensualUnidadMineraResponsable(int Periodo, int IdTipo, int IdEmpresaResponsable)
        {
            try
            {
                ReporteAccidenteDL Accidente = new ReporteAccidenteDL();
                return Accidente.ListadoCostoMensualUnidadMineraResponsable(Periodo,IdTipo, IdEmpresaResponsable);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAccidenteBE> ListadoCantidadMensualNegocio(int Periodo, int IdTipo, int IdEmpresaResponsable)
        {
            try
            {
                ReporteAccidenteDL Accidente = new ReporteAccidenteDL();
                return Accidente.ListadoCantidadMensualNegocio(Periodo,IdTipo, IdEmpresaResponsable);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAccidenteBE> ListadoCantidadMensualEmpresaResponsable(int Periodo, int IdTipo)
        {
            try
            {
                ReporteAccidenteDL Accidente = new ReporteAccidenteDL();
                return Accidente.ListadoCantidadMensualEmpresaResponsable(Periodo, IdTipo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAccidenteBE> ListadoCantidadMensualUnidadMineraResponsable(int Periodo, int IdTipo, int IdEmpresaResponsable)
        {
            try
            {
                ReporteAccidenteDL Accidente = new ReporteAccidenteDL();
                return Accidente.ListadoCantidadMensualUnidadMineraResponsable(Periodo,IdTipo, IdEmpresaResponsable);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAccidenteBE> ListadoEmpresaContratista(int IdTipo, int IdEmpresaContratista, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ReporteAccidenteDL Accidente = new ReporteAccidenteDL();
                return Accidente.ListadoEmpresaContratista(IdTipo, IdEmpresaContratista, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAccidenteBE> ListadoCostoAnualEmpresaContratista(int IdTipo)
        {
            try
            {
                ReporteAccidenteDL Accidente = new ReporteAccidenteDL();
                return Accidente.ListadoCostoAnualEmpresaContratista(IdTipo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ReporteAccidenteBE> ListadoCantidadAnualEmpresaContratista(int IdTipo)
        {
            try
            {
                ReporteAccidenteDL Accidente = new ReporteAccidenteDL();
                return Accidente.ListadoCantidadAnualEmpresaContratista(IdTipo);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
