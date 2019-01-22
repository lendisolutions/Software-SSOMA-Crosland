using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class EppDetalleBL
    {
        public List<EppDetalleBE> ListaTodosActivo(int IdEpp)
        {
            try
            {
                EppDetalleDL EppDetalle = new EppDetalleDL();
                return EppDetalle.ListaTodosActivo(IdEpp);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EppDetalleBE Selecciona(int IdEppDetalle)
        {
            try
            {
                EppDetalleDL EppDetalle = new EppDetalleDL();
                EppDetalleBE objEmp = EppDetalle.Selecciona(IdEppDetalle);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(EppDetalleBE pItem)
        {
            try
            {
                EppDetalleDL EppDetalle = new EppDetalleDL();
                EppDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(EppDetalleBE pItem)
        {
            try
            {
                EppDetalleDL EppDetalle = new EppDetalleDL();
                EppDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(EppDetalleBE pItem)
        {
            try
            {
                EppDetalleDL EppDetalle = new EppDetalleDL();
                EppDetalle.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
