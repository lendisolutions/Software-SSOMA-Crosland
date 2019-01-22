using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class ExtintorInspeccionDetalleBL
    {
        public List<ExtintorInspeccionDetalleBE> ListaTodosActivo(int IdExtintor)
        {
            try
            {
                ExtintorInspeccionDetalleDL ExtintorInspeccionDetalle = new ExtintorInspeccionDetalleDL();
                return ExtintorInspeccionDetalle.ListaTodosActivo(IdExtintor);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ExtintorInspeccionDetalleBE Selecciona(int IdExtintorInspeccionDetalle)
        {
            try
            {
                ExtintorInspeccionDetalleDL ExtintorInspeccionDetalle = new ExtintorInspeccionDetalleDL();
                ExtintorInspeccionDetalleBE objEmp = ExtintorInspeccionDetalle.Selecciona(IdExtintorInspeccionDetalle);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ExtintorInspeccionDetalleBE pItem)
        {
            try
            {
                ExtintorInspeccionDetalleDL ExtintorInspeccionDetalle = new ExtintorInspeccionDetalleDL();
                ExtintorInspeccionDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void InsertaMasivo(List<ExtintorInspeccionDetalleBE> pListaExtintorInspeccionDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ExtintorInspeccionDetalleDL objExtintorInspeccionDetalle = new ExtintorInspeccionDetalleDL();

                    foreach (ExtintorInspeccionDetalleBE item in pListaExtintorInspeccionDetalle)
                    {
                        objExtintorInspeccionDetalle.Inserta(item);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Actualiza(ExtintorInspeccionDetalleBE pItem)
        {
            try
            {
                ExtintorInspeccionDetalleDL ExtintorInspeccionDetalle = new ExtintorInspeccionDetalleDL();
                ExtintorInspeccionDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ExtintorInspeccionDetalleBE pItem)
        {
            try
            {
                ExtintorInspeccionDetalleDL ExtintorInspeccionDetalle = new ExtintorInspeccionDetalleDL();
                ExtintorInspeccionDetalle.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
