using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class FuenteLesionBL
    {
        public List<FuenteLesionBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                FuenteLesionDL FuenteLesion = new FuenteLesionDL();
                return FuenteLesion.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<FuenteLesionBE> ListaCombo(int IdEmpresa)
        {
            try
            {
                FuenteLesionDL FuenteLesion = new FuenteLesionDL();
                return FuenteLesion.ListaCombo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public FuenteLesionBE Selecciona(int IdFuenteLesion)
        {
            try
            {
                FuenteLesionDL FuenteLesion = new FuenteLesionDL();
                FuenteLesionBE objEmp = FuenteLesion.Selecciona(IdFuenteLesion);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(FuenteLesionBE pItem)
        {
            try
            {
                FuenteLesionDL FuenteLesion = new FuenteLesionDL();
                FuenteLesion.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(FuenteLesionBE pItem)
        {
            try
            {
                FuenteLesionDL FuenteLesion = new FuenteLesionDL();
                FuenteLesion.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(FuenteLesionBE pItem)
        {
            try
            {
                FuenteLesionDL FuenteLesion = new FuenteLesionDL();
                FuenteLesion.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
