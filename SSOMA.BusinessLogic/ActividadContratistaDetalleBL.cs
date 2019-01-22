using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class ActividadContratistaDetalleBL
    {
        public List<ActividadContratistaDetalleBE> ListaTodosActivo(int IdPersona)
        {
            try
            {
                ActividadContratistaDetalleDL ActividadContratistaDetalle = new ActividadContratistaDetalleDL();
                return ActividadContratistaDetalle.ListaTodosActivo(IdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ActividadContratistaDetalleBE Selecciona(int IdActividadContratistaDetalle)
        {
            try
            {
                ActividadContratistaDetalleDL ActividadContratistaDetalle = new ActividadContratistaDetalleDL();
                ActividadContratistaDetalleBE objEmp = ActividadContratistaDetalle.Selecciona(IdActividadContratistaDetalle);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ActividadContratistaDetalleBE pItem)
        {
            try
            {
                ActividadContratistaDetalleDL ActividadContratistaDetalle = new ActividadContratistaDetalleDL();
                ActividadContratistaDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ActividadContratistaDetalleBE pItem)
        {
            try
            {
                ActividadContratistaDetalleDL ActividadContratistaDetalle = new ActividadContratistaDetalleDL();
                ActividadContratistaDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ActividadContratistaDetalleBE pItem)
        {
            try
            {
                ActividadContratistaDetalleDL ActividadContratistaDetalle = new ActividadContratistaDetalleDL();
                ActividadContratistaDetalle.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
