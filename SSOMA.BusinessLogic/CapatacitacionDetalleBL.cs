using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class CapatacitacionDetalleBL
    {
        public List<CapacitacionDetalleBE> ListaTodosActivo(int IdIncidente)
        {
            try
            {
                CapacitacionDetalleDL CapacitacionDetalle = new CapacitacionDetalleDL();
                return CapacitacionDetalle.ListaTodosActivo(IdIncidente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CapacitacionDetalleBE Selecciona(int IdCapacitacionDetalle)
        {
            try
            {
                CapacitacionDetalleDL CapacitacionDetalle = new CapacitacionDetalleDL();
                CapacitacionDetalleBE objEmp = CapacitacionDetalle.Selecciona(IdCapacitacionDetalle);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(CapacitacionDetalleBE pItem)
        {
            try
            {
                CapacitacionDetalleDL CapacitacionDetalle = new CapacitacionDetalleDL();
                CapacitacionDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(CapacitacionDetalleBE pItem)
        {
            try
            {
                CapacitacionDetalleDL CapacitacionDetalle = new CapacitacionDetalleDL();
                CapacitacionDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(CapacitacionDetalleBE pItem)
        {
            try
            {
                CapacitacionDetalleDL CapacitacionDetalle = new CapacitacionDetalleDL();
                CapacitacionDetalle.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
