using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class TratamientoBL
    {
        public List<TratamientoBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                TratamientoDL Tratamiento = new TratamientoDL();
                return Tratamiento.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<TratamientoBE> ListaCombo(int IdEmpresa)
        {
            try
            {
                TratamientoDL Tratamiento = new TratamientoDL();
                return Tratamiento.ListaCombo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TratamientoBE Selecciona(int IdTratamiento)
        {
            try
            {
                TratamientoDL Tratamiento = new TratamientoDL();
                TratamientoBE objEmp = Tratamiento.Selecciona(IdTratamiento);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(TratamientoBE pItem)
        {
            try
            {
                TratamientoDL Tratamiento = new TratamientoDL();
                Tratamiento.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TratamientoBE pItem)
        {
            try
            {
                TratamientoDL Tratamiento = new TratamientoDL();
                Tratamiento.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TratamientoBE pItem)
        {
            try
            {
                TratamientoDL Tratamiento = new TratamientoDL();
                Tratamiento.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
