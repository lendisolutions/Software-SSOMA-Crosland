using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class AccidenteFactorTrabajoBL
    {
        public List<AccidenteFactorTrabajoBE> ListaTodosActivo(int IdAccidente)
        {
            try
            {
                AccidenteFactorTrabajoDL AccidenteFactorTrabajo = new AccidenteFactorTrabajoDL();
                return AccidenteFactorTrabajo.ListaTodosActivo(IdAccidente);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public AccidenteFactorTrabajoBE Selecciona(int IdAccidenteFactorTrabajo)
        {
            try
            {
                AccidenteFactorTrabajoDL AccidenteFactorTrabajo = new AccidenteFactorTrabajoDL();
                AccidenteFactorTrabajoBE objEmp = AccidenteFactorTrabajo.Selecciona(IdAccidenteFactorTrabajo);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(AccidenteFactorTrabajoBE pItem)
        {
            try
            {
                AccidenteFactorTrabajoDL AccidenteFactorTrabajo = new AccidenteFactorTrabajoDL();
                AccidenteFactorTrabajo.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(AccidenteFactorTrabajoBE pItem)
        {
            try
            {
                AccidenteFactorTrabajoDL AccidenteFactorTrabajo = new AccidenteFactorTrabajoDL();
                AccidenteFactorTrabajo.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(AccidenteFactorTrabajoBE pItem)
        {
            try
            {
                AccidenteFactorTrabajoDL AccidenteFactorTrabajo = new AccidenteFactorTrabajoDL();
                AccidenteFactorTrabajo.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }

    }
}
