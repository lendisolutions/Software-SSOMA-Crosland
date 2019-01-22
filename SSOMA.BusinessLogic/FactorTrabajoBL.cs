using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;


namespace SSOMA.BusinessLogic
{
    public class FactorTrabajoBL
    {
        public List<FactorTrabajoBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                FactorTrabajoDL FactorTrabajo = new FactorTrabajoDL();
                return FactorTrabajo.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<FactorTrabajoBE> ListaCombo(int IdEmpresa)
        {
            try
            {
                FactorTrabajoDL FactorTrabajo = new FactorTrabajoDL();
                return FactorTrabajo.ListaCombo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public FactorTrabajoBE Selecciona(int IdFactorTrabajo)
        {
            try
            {
                FactorTrabajoDL FactorTrabajo = new FactorTrabajoDL();
                FactorTrabajoBE objEmp = FactorTrabajo.Selecciona(IdFactorTrabajo);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(FactorTrabajoBE pItem)
        {
            try
            {
                FactorTrabajoDL FactorTrabajo = new FactorTrabajoDL();
                FactorTrabajo.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(FactorTrabajoBE pItem)
        {
            try
            {
                FactorTrabajoDL FactorTrabajo = new FactorTrabajoDL();
                FactorTrabajo.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(FactorTrabajoBE pItem)
        {
            try
            {
                FactorTrabajoDL FactorTrabajo = new FactorTrabajoDL();
                FactorTrabajo.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
