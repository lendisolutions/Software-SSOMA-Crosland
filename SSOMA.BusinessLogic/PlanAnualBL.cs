using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class PlanAnualBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        public List<PlanAnualBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera, int Periodo)
        {
            try
            {
                PlanAnualDL PlanAnual = new PlanAnualDL();
                return PlanAnual.ListaTodosActivo(IdEmpresa,IdUnidadMinera,Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PlanAnualBE> ListaPeriodo(int IdEmpresa, int IdUnidadMinera, int Periodo)
        {
            try
            {
                PlanAnualDL PlanAnual = new PlanAnualDL();
                return PlanAnual.ListaPeriodo(IdEmpresa, IdUnidadMinera, Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PlanAnualBE> ListaTema(int IdEmpresa, int IdUnidadMinera, int Periodo)
        {
            try
            {
                PlanAnualDL PlanAnual = new PlanAnualDL();
                return PlanAnual.ListaTema(IdEmpresa, IdUnidadMinera, Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public PlanAnualBE Selecciona(int IdPlanAnual)
        {
            try
            {
                PlanAnualDL PlanAnual = new PlanAnualDL();
                return PlanAnual.Selecciona(IdPlanAnual);
            }
            catch (Exception ex)
            { throw ex; }
        }



        public void Inserta(PlanAnualBE pItem, List<PlanAnualDetalleBE> pListaPlanAnualDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PlanAnualDL PlanAnual = new PlanAnualDL();
                    PlanAnualDetalleDL PlanAnualDetalle = new PlanAnualDetalleDL();

                    int IdPlanAnual = 0;
                    IdPlanAnual = PlanAnual.Inserta(pItem);

                    foreach (var item in pListaPlanAnualDetalle)
                    {
                        item.IdPlanAnual = IdPlanAnual;
                        PlanAnualDetalle.Inserta(item);

                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(PlanAnualBE pItem, List<PlanAnualDetalleBE> pListaPlanAnualDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PlanAnualDL PlanAnual = new PlanAnualDL();
                    PlanAnualDetalleDL PlanAnualDetalle = new PlanAnualDetalleDL();

                    foreach (PlanAnualDetalleBE item in pListaPlanAnualDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {

                            item.IdPlanAnual = pItem.IdPlanAnual;
                            PlanAnualDetalle.Inserta(item);
                        }
                        else
                        {

                            PlanAnualDetalle.Actualiza(item);
                        }
                    }

                    PlanAnual.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(PlanAnualBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PlanAnualDL PlanAnual = new PlanAnualDL();
                    PlanAnualDetalleDL PlanAnualDetalle = new PlanAnualDetalleDL();

                    List<PlanAnualDetalleBE> lstPlanAnualDetalle = null;
                    lstPlanAnualDetalle = new PlanAnualDetalleDL().ListaTodosActivo(pItem.IdPlanAnual);

                    foreach (PlanAnualDetalleBE item in lstPlanAnualDetalle)
                    {
                        PlanAnualDetalle.Elimina(item);
                    }

                    PlanAnual.Elimina(pItem);

                    

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
