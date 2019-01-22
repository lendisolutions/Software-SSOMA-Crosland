using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class TipoCapacitacionBL
    {
        public List<TipoCapacitacionBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                TipoCapacitacionDL TipoCapacitacion = new TipoCapacitacionDL();
                return TipoCapacitacion.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<TipoCapacitacionBE> ListaCombo(int IdEmpresa)
        {
            try
            {
                TipoCapacitacionDL TipoCapacitacion = new TipoCapacitacionDL();
                return TipoCapacitacion.ListaCombo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TipoCapacitacionBE Selecciona(int IdEmpresa, int IdTipoCapacitacion)
        {
            try
            {
                TipoCapacitacionDL TipoCapacitacion = new TipoCapacitacionDL();
                TipoCapacitacionBE objEmp = TipoCapacitacion.Selecciona(IdEmpresa, IdTipoCapacitacion);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(TipoCapacitacionBE pItem)
        {
            try
            {
                TipoCapacitacionDL TipoCapacitacion = new TipoCapacitacionDL();
                TipoCapacitacion.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TipoCapacitacionBE pItem)
        {
            try
            {
                TipoCapacitacionDL TipoCapacitacion = new TipoCapacitacionDL();
                TipoCapacitacion.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TipoCapacitacionBE pItem)
        {
            try
            {
                TipoCapacitacionDL TipoCapacitacion = new TipoCapacitacionDL();
                TipoCapacitacion.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
