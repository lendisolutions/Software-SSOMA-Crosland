using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class PlanAnualDetalleBL
    {
        public List<PlanAnualDetalleBE> ListaTodosActivo(int IdPlanAnual)
        {
            try
            {
                PlanAnualDetalleDL PlanAnualDetalle = new PlanAnualDetalleDL();
                return PlanAnualDetalle.ListaTodosActivo(IdPlanAnual);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PlanAnualDetalleBE Selecciona(int IdPlanAnualDetalle)
        {
            try
            {
                PlanAnualDetalleDL PlanAnualDetalle = new PlanAnualDetalleDL();
                PlanAnualDetalleBE objEmp = PlanAnualDetalle.Selecciona(IdPlanAnualDetalle);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(PlanAnualDetalleBE pItem)
        {
            try
            {
                PlanAnualDetalleDL PlanAnualDetalle = new PlanAnualDetalleDL();
                PlanAnualDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(PlanAnualDetalleBE pItem)
        {
            try
            {
                PlanAnualDetalleDL PlanAnualDetalle = new PlanAnualDetalleDL();
                PlanAnualDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(PlanAnualDetalleBE pItem)
        {
            try
            {
                PlanAnualDetalleDL PlanAnualDetalle = new PlanAnualDetalleDL();
                PlanAnualDetalle.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
