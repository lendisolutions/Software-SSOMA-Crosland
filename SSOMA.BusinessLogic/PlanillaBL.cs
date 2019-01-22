using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class PlanillaBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        public List<PlanillaBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera, int IdArea, int IdSector, int IdActividad)
        {
            try
            {
                PlanillaDL Planilla = new PlanillaDL();
                return Planilla.ListaTodosActivo(IdEmpresa, IdUnidadMinera, IdArea, IdSector, IdActividad);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PlanillaBE> ListaActividad(int IdEmpresa, int IdUnidadMinera, int IdArea, int IdSector, string DescActividad)
        {
            try
            {
                PlanillaDL Planilla = new PlanillaDL();
                return Planilla.ListaActividad(IdEmpresa, IdUnidadMinera, IdArea, IdSector, DescActividad);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PlanillaBE> ListaFecha(int IdEmpresa, int IdUnidadMinera, int IdArea, int IdSector, int IdActividad, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                PlanillaDL Planilla = new PlanillaDL();
                return Planilla.ListaFecha(IdEmpresa, IdUnidadMinera, IdArea, IdSector, IdActividad, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PlanillaBE Selecciona(int IdPlanilla)
        {
            try
            {
                PlanillaDL Planilla = new PlanillaDL();
                PlanillaBE objEmp = Planilla.Selecciona(IdPlanilla);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Inserta(List<PlanillaBE> pListaPlanilla)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PlanillaDL Planilla = new PlanillaDL();

                    foreach (PlanillaBE item in pListaPlanilla)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            Planilla.Inserta(item);
                        }
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(List<PlanillaBE> pListaPlanilla)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PlanillaDL Planilla = new PlanillaDL();
                    foreach (PlanillaBE item in pListaPlanilla)
                    {
                        if (item.TipoOper != Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            Planilla.Actualiza(item);
                        }

                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(PlanillaBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PlanillaDL Planilla = new PlanillaDL();
                    Planilla.Elimina(pItem);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
