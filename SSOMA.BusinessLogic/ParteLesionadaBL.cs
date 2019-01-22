using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class ParteLesionadaBL
    {
        public List<ParteLesionadaBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                ParteLesionadaDL ParteLesionada = new ParteLesionadaDL();
                return ParteLesionada.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ParteLesionadaBE> ListaCombo(int IdEmpresa)
        {
            try
            {
                ParteLesionadaDL ParteLesionada = new ParteLesionadaDL();
                return ParteLesionada.ListaCombo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ParteLesionadaBE Selecciona(int IdParteLesionada)
        {
            try
            {
                ParteLesionadaDL ParteLesionada = new ParteLesionadaDL();
                ParteLesionadaBE objEmp = ParteLesionada.Selecciona(IdParteLesionada);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ParteLesionadaBE pItem)
        {
            try
            {
                ParteLesionadaDL ParteLesionada = new ParteLesionadaDL();
                ParteLesionada.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ParteLesionadaBE pItem)
        {
            try
            {
                ParteLesionadaDL ParteLesionada = new ParteLesionadaDL();
                ParteLesionada.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ParteLesionadaBE pItem)
        {
            try
            {
                ParteLesionadaDL ParteLesionada = new ParteLesionadaDL();
                ParteLesionada.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
