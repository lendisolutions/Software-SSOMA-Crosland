using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class CarpetaBL
    {
        public List<CarpetaBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                CarpetaDL Carpeta = new CarpetaDL();
                return Carpeta.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CarpetaBE> ListaCombo(int IdEmpresa)
        {
            try
            {
                CarpetaDL Carpeta = new CarpetaDL();
                return Carpeta.ListaCombo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CarpetaBE Selecciona(int IdCarpeta)
        {
            try
            {
                CarpetaDL Carpeta = new CarpetaDL();
                CarpetaBE objEmp = Carpeta.Selecciona(IdCarpeta);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(CarpetaBE pItem)
        {
            try
            {
                CarpetaDL Carpeta = new CarpetaDL();
                Carpeta.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(CarpetaBE pItem)
        {
            try
            {
                CarpetaDL Carpeta = new CarpetaDL();
                Carpeta.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(CarpetaBE pItem)
        {
            try
            {
                CarpetaDL Carpeta = new CarpetaDL();
                Carpeta.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
