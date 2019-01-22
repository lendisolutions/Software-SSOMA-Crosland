using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class InspeccionTrabajoDetalleBL
    {
        public List<InspeccionTrabajoDetalleBE> ListaTodosActivo(int IdTrabajoInspeccion)
        {
            try
            {
                InspeccionTrabajoDetalleDL InspeccionTrabajoDetalle = new InspeccionTrabajoDetalleDL();
                return InspeccionTrabajoDetalle.ListaTodosActivo(IdTrabajoInspeccion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<InspeccionTrabajoDetalleBE> ListaTipo(int IdEmpresa, int IdUnidadMinera, int IdArea, int IdTipoInspeccion, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                InspeccionTrabajoDetalleDL InspeccionTrabajoDetalle = new InspeccionTrabajoDetalleDL();
                return InspeccionTrabajoDetalle.ListaTipo(IdEmpresa, IdUnidadMinera, IdArea, IdTipoInspeccion, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<InspeccionTrabajoDetalleBE> ListaEmpresaContratista(DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                InspeccionTrabajoDetalleDL InspeccionTrabajoDetalle = new InspeccionTrabajoDetalleDL();
                return InspeccionTrabajoDetalle.ListaEmpresaContratista(FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<InspeccionTrabajoDetalleBE> ListaSituacion(int IdTrabajoInspeccion, int IdSituacion)
        {
            try
            {
                InspeccionTrabajoDetalleDL InspeccionTrabajoDetalle = new InspeccionTrabajoDetalleDL();
                return InspeccionTrabajoDetalle.ListaSituacion(IdTrabajoInspeccion, IdSituacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public InspeccionTrabajoDetalleBE Selecciona(int IdInspeccionTrabajoDetalle)
        {
            try
            {
                InspeccionTrabajoDetalleDL InspeccionTrabajoDetalle = new InspeccionTrabajoDetalleDL();
                InspeccionTrabajoDetalleBE objEmp = InspeccionTrabajoDetalle.Selecciona(IdInspeccionTrabajoDetalle);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(InspeccionTrabajoDetalleBE pItem)
        {
            try
            {
                InspeccionTrabajoDetalleDL InspeccionTrabajoDetalle = new InspeccionTrabajoDetalleDL();
                InspeccionTrabajoDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(InspeccionTrabajoDetalleBE pItem)
        {
            try
            {
                InspeccionTrabajoDetalleDL InspeccionTrabajoDetalle = new InspeccionTrabajoDetalleDL();
                InspeccionTrabajoDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaSituacion(int IdInspeccionTrabajoDetalle, int IdSituacion)
        {
            try
            {
                InspeccionTrabajoDetalleDL InspeccionTrabajoDetalle = new InspeccionTrabajoDetalleDL();
                InspeccionTrabajoDetalle.ActualizaSituacion(IdInspeccionTrabajoDetalle, IdSituacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(InspeccionTrabajoDetalleBE pItem)
        {
            try
            {
                InspeccionTrabajoDetalleDL InspeccionTrabajoDetalle = new InspeccionTrabajoDetalleDL();
                InspeccionTrabajoDetalle.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
