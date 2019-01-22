using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class InspeccionTrabajoBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        public List<InspeccionTrabajoBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            try
            {
                InspeccionTrabajoDL InspeccionTrabajo = new InspeccionTrabajoDL();
                return InspeccionTrabajo.ListaTodosActivo(IdEmpresa, IdUnidadMinera, IdArea);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<InspeccionTrabajoBE> ListaFecha(int IdEmpresa, int IdUnidadMinera, int IdArea, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                InspeccionTrabajoDL InspeccionTrabajo = new InspeccionTrabajoDL();
                return InspeccionTrabajo.ListaFecha(IdEmpresa, IdUnidadMinera, IdArea, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<InspeccionTrabajoBE> ListaTipo(int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdTipoInspeccion, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                InspeccionTrabajoDL InspeccionTrabajo = new InspeccionTrabajoDL();
                return InspeccionTrabajo.ListaTipo(IdEmpresaResponsable, IdUnidadMineraResponsable, IdAreaResponsable, IdTipoInspeccion,FechaDesde,FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        

        public List<InspeccionTrabajoBE> ListaNumero(int Numero)
        {
            try
            {
                InspeccionTrabajoDL InspeccionTrabajo = new InspeccionTrabajoDL();
                return InspeccionTrabajo.ListaNumero(Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        
        public InspeccionTrabajoBE Selecciona(int IdInspeccionTrabajo)
        {
            try
            {
                InspeccionTrabajoDL InspeccionTrabajo = new InspeccionTrabajoDL();
                InspeccionTrabajoBE objEmp = InspeccionTrabajo.Selecciona(IdInspeccionTrabajo);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public InspeccionTrabajoBE SeleccionaNumero(int Numero)
        {
            try
            {
                InspeccionTrabajoDL InspeccionTrabajo = new InspeccionTrabajoDL();
                InspeccionTrabajoBE objEmp = InspeccionTrabajo.SeleccionaNumero(Numero);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 Inserta(InspeccionTrabajoBE pItem, List<InspeccionTrabajoDetalleBE> pListaInspeccionTrabajoDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    InspeccionTrabajoDL InspeccionTrabajo = new InspeccionTrabajoDL();
                    InspeccionTrabajoDetalleDL InspeccionTrabajoDetalle = new InspeccionTrabajoDetalleDL();

                    
                    int IdInspeccionTrabajo = 0;
                    IdInspeccionTrabajo = InspeccionTrabajo.Inserta(pItem);

                    foreach (var item in pListaInspeccionTrabajoDetalle)
                    {
                        item.IdInspeccionTrabajo = IdInspeccionTrabajo;
                        InspeccionTrabajoDetalle.Inserta(item);
                        
                    }

                    
                    ts.Complete();

                    return IdInspeccionTrabajo;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(InspeccionTrabajoBE pItem, List<InspeccionTrabajoDetalleBE> pListaInspeccionTrabajoDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    InspeccionTrabajoDL InspeccionTrabajo = new InspeccionTrabajoDL();
                    InspeccionTrabajoDetalleDL InspeccionTrabajoDetalle = new InspeccionTrabajoDetalleDL();

                    foreach (InspeccionTrabajoDetalleBE item in pListaInspeccionTrabajoDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {

                            item.IdInspeccionTrabajo = pItem.IdInspeccionTrabajo;
                            InspeccionTrabajoDetalle.Inserta(item);
                        }
                        else
                        {

                            InspeccionTrabajoDetalle.Actualiza(item);
                        }
                    }

                    InspeccionTrabajo.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaNumero(int IdInspeccionTrabajo, string Numero)
        {
            try
            {
                InspeccionTrabajoDL InspeccionTrabajo = new InspeccionTrabajoDL();
                InspeccionTrabajo.ActualizaNumero(IdInspeccionTrabajo, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(InspeccionTrabajoBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    InspeccionTrabajoDL InspeccionTrabajo = new InspeccionTrabajoDL();
                    InspeccionTrabajoDetalleDL InspeccionTrabajoDetalle = new InspeccionTrabajoDetalleDL();

                    List<InspeccionTrabajoDetalleBE> lstInspeccionTrabajoDetalle = null;
                    lstInspeccionTrabajoDetalle = new InspeccionTrabajoDetalleDL().ListaTodosActivo(pItem.IdInspeccionTrabajo);

                    foreach (InspeccionTrabajoDetalleBE item in lstInspeccionTrabajoDetalle)
                    {
                        InspeccionTrabajoDetalle.Elimina(item);
                    }

                    InspeccionTrabajo.Elimina(pItem);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
