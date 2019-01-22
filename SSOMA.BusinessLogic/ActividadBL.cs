using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class ActividadBL
    {
        public List<ActividadBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera, int IdArea, int IdSector)
        {
            try
            {
                ActividadDL Actividad = new ActividadDL();
                return Actividad.ListaTodosActivo(IdEmpresa, IdUnidadMinera, IdArea, IdSector);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ActividadBE Selecciona(int IdActividad)
        {
            try
            {
                ActividadDL Actividad = new ActividadDL();
                ActividadBE objEmp = Actividad.Selecciona(IdActividad);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        
        public void Inserta(ActividadBE pItem)
        {
            try
            {
                ActividadDL Actividad = new ActividadDL();
                Actividad.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ActividadBE pItem)
        {
            try
            {
                ActividadDL Actividad = new ActividadDL();
                Actividad.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ActividadBE pItem)
        {
            try
            {
                ActividadDL Actividad = new ActividadDL();
                Actividad.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
