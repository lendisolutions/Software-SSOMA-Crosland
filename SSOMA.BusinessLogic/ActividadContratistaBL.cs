using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class ActividadContratistaBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        public List<ActividadContratistaBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                ActividadContratistaDL ActividadContratista = new ActividadContratistaDL();
                return ActividadContratista.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ActividadContratistaBE Selecciona(int IdActividadContratista)
        {
            try
            {
                ActividadContratistaDL ActividadContratista = new ActividadContratistaDL();
                ActividadContratistaBE objEmp = ActividadContratista.Selecciona(IdActividadContratista);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ActividadContratistaBE SeleccionaEmpresa(int IdEmpresa)
        {
            try
            {
                ActividadContratistaDL ActividadContratista = new ActividadContratistaDL();
                ActividadContratistaBE objEmp = ActividadContratista.SeleccionaEmpresa(IdEmpresa);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ActividadContratistaBE pItem, List<ActividadContratistaDetalleBE> pListaActividadContratistaDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ActividadContratistaDL ActividadContratista = new ActividadContratistaDL();
                    ActividadContratistaDetalleDL ActividadContratistaDetalle = new ActividadContratistaDetalleDL();

                    int intIdActividadContratista = 0;
                    intIdActividadContratista = ActividadContratista.Inserta(pItem);

                    foreach (var item in pListaActividadContratistaDetalle)
                    {
                        item.IdActividadContratista = intIdActividadContratista;
                        ActividadContratistaDetalle.Inserta(item);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ActividadContratistaBE pItem, List<ActividadContratistaDetalleBE> pListaActividadContratistaDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ActividadContratistaDL ActividadContratista = new ActividadContratistaDL();
                    ActividadContratistaDetalleDL ActividadContratistaDetalle = new ActividadContratistaDetalleDL();

                    foreach (ActividadContratistaDetalleBE item in pListaActividadContratistaDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            item.IdActividadContratista = pItem.IdActividadContratista;
                            ActividadContratistaDetalle.Inserta(item);
                        }
                        else
                        {
                            ActividadContratistaDetalle.Actualiza(item);
                        }
                    }

                    ActividadContratista.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ActividadContratistaBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ActividadContratistaDL ActividadContratista = new ActividadContratistaDL();
                    ActividadContratistaDetalleDL ActividadContratistaDetalle = new ActividadContratistaDetalleDL();

                    List<ActividadContratistaDetalleBE> lstActividadContratistaDetalle = null;
                    lstActividadContratistaDetalle = new ActividadContratistaDetalleDL().ListaTodosActivo(pItem.IdActividadContratista);

                    foreach (ActividadContratistaDetalleBE item in lstActividadContratistaDetalle)
                    {
                        ActividadContratistaDetalle.Elimina(item);
                    }

                    ActividadContratista.Elimina(pItem);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
