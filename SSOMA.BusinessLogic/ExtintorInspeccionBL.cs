using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class ExtintorInspeccionBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        public List<ExtintorInspeccionBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera)
        {
            try
            {
                ExtintorInspeccionDL ExtintorInspeccion = new ExtintorInspeccionDL();
                return ExtintorInspeccion.ListaTodosActivo(IdEmpresa, IdUnidadMinera);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ExtintorInspeccionBE> ListaFecha(int IdEmpresa, int IdUnidadMinera, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ExtintorInspeccionDL ExtintorInspeccion = new ExtintorInspeccionDL();
                return ExtintorInspeccion.ListaFecha(IdEmpresa, IdUnidadMinera, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ExtintorInspeccionBE> ListaReporte(int IdExtintorInspeccion)
        {
            try
            {
                ExtintorInspeccionDL ExtintorInspeccion = new ExtintorInspeccionDL();
                return ExtintorInspeccion.ListaReporte(IdExtintorInspeccion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ExtintorInspeccionBE Selecciona(int IdExtintorInspeccion)
        {
            try
            {
                ExtintorInspeccionDL ExtintorInspeccion = new ExtintorInspeccionDL();
                ExtintorInspeccionBE objEmp = ExtintorInspeccion.Selecciona(IdExtintorInspeccion);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 Inserta(ExtintorInspeccionBE pItem, List<ExtintorInspeccionDetalleBE> pListaExtintorInspeccionDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ExtintorInspeccionDL ExtintorInspeccion = new ExtintorInspeccionDL();
                    ExtintorInspeccionDetalleDL ExtintorInspeccionDetalle = new ExtintorInspeccionDetalleDL();

                    int IdExtintorInspeccion = 0;
                    IdExtintorInspeccion = ExtintorInspeccion.Inserta(pItem);

                    foreach (var item in pListaExtintorInspeccionDetalle)
                    {
                        item.IdExtintorInspeccion = IdExtintorInspeccion;
                        ExtintorInspeccionDetalle.Inserta(item);
                    }

                    ts.Complete();

                    return IdExtintorInspeccion;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ExtintorInspeccionBE pItem, List<ExtintorInspeccionDetalleBE> pListaExtintorInspeccionDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ExtintorInspeccionDL ExtintorInspeccion = new ExtintorInspeccionDL();
                    ExtintorInspeccionDetalleDL ExtintorInspeccionDetalle = new ExtintorInspeccionDetalleDL();

                    foreach (ExtintorInspeccionDetalleBE item in pListaExtintorInspeccionDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {

                            item.IdExtintorInspeccion = pItem.IdExtintorInspeccion;
                            ExtintorInspeccionDetalle.Inserta(item);
                        }
                        else
                        {

                            ExtintorInspeccionDetalle.Actualiza(item);
                        }
                    }

                    ExtintorInspeccion.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ExtintorInspeccionBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ExtintorInspeccionDL ExtintorInspeccion = new ExtintorInspeccionDL();
                    ExtintorInspeccionDetalleDL ExtintorInspeccionDetalle = new ExtintorInspeccionDetalleDL();

                    List<ExtintorInspeccionDetalleBE> lstExtintorInspeccionDetalle = null;
                    lstExtintorInspeccionDetalle = new ExtintorInspeccionDetalleDL().ListaTodosActivo(pItem.IdExtintorInspeccion);

                    foreach (ExtintorInspeccionDetalleBE item in lstExtintorInspeccionDetalle)
                    {
                        ExtintorInspeccionDetalle.Elimina(item);
                    }

                    ExtintorInspeccion.Elimina(pItem);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
