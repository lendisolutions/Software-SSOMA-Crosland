using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class ExtintorDetalleBL
    {
        public List<ExtintorDetalleBE> ListaTodosActivo(int IdExtintor)
        {
            try
            {
                ExtintorDetalleDL ExtintorDetalle = new ExtintorDetalleDL();
                return ExtintorDetalle.ListaTodosActivo(IdExtintor);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ExtintorDetalleBE Selecciona(int IdExtintorDetalle)
        {
            try
            {
                ExtintorDetalleDL ExtintorDetalle = new ExtintorDetalleDL();
                ExtintorDetalleBE objEmp = ExtintorDetalle.Selecciona(IdExtintorDetalle);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ExtintorDetalleBE pItem)
        {
            try
            {
                ExtintorDetalleDL ExtintorDetalle = new ExtintorDetalleDL();
                ExtintorDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void InsertaMasivo(List<ExtintorDetalleBE> pListaExtintorDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ExtintorDetalleDL objExtintorDetalle = new ExtintorDetalleDL();

                    foreach (ExtintorDetalleBE item in pListaExtintorDetalle)
                    {
                        objExtintorDetalle.Inserta(item);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Actualiza(ExtintorDetalleBE pItem)
        {
            try
            {
                ExtintorDetalleDL ExtintorDetalle = new ExtintorDetalleDL();
                ExtintorDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ExtintorDetalleBE pItem)
        {
            try
            {
                ExtintorDetalleDL ExtintorDetalle = new ExtintorDetalleDL();
                ExtintorDetalle.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
