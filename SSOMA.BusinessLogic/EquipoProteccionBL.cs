using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;


namespace SSOMA.BusinessLogic
{
    public class EquipoProteccionBL
    {
        public List<EquipoProteccionBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                EquipoProteccionDL EquipoProteccion = new EquipoProteccionDL();
                return EquipoProteccion.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<EquipoProteccionBE> ListaCombo(int IdEmpresa)
        {
            try
            {
                EquipoProteccionDL EquipoProteccion = new EquipoProteccionDL();
                return EquipoProteccion.ListaCombo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EquipoProteccionBE Selecciona(int IdEquipoProteccion)
        {
            try
            {
                EquipoProteccionDL EquipoProteccion = new EquipoProteccionDL();
                EquipoProteccionBE objEmp = EquipoProteccion.Selecciona(IdEquipoProteccion);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(EquipoProteccionBE pItem)
        {
            try
            {
                EquipoProteccionDL EquipoProteccion = new EquipoProteccionDL();
                EquipoProteccion.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(EquipoProteccionBE pItem)
        {
            try
            {
                EquipoProteccionDL EquipoProteccion = new EquipoProteccionDL();
                EquipoProteccion.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(EquipoProteccionBE pItem)
        {
            try
            {
                EquipoProteccionDL EquipoProteccion = new EquipoProteccionDL();
                EquipoProteccion.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
