using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class TipoAccidenteBL
    {
        public List<TipoAccidenteBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                TipoAccidenteDL TipoAccidente = new TipoAccidenteDL();
                return TipoAccidente.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<TipoAccidenteBE> ListaCombo(int IdEmpresa)
        {
            try
            {
                TipoAccidenteDL TipoAccidente = new TipoAccidenteDL();
                return TipoAccidente.ListaCombo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TipoAccidenteBE Selecciona(int IdTipoAccidente)
        {
            try
            {
                TipoAccidenteDL TipoAccidente = new TipoAccidenteDL();
                TipoAccidenteBE objEmp = TipoAccidente.Selecciona(IdTipoAccidente);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(TipoAccidenteBE pItem)
        {
            try
            {
                TipoAccidenteDL TipoAccidente = new TipoAccidenteDL();
                TipoAccidente.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TipoAccidenteBE pItem)
        {
            try
            {
                TipoAccidenteDL TipoAccidente = new TipoAccidenteDL();
                TipoAccidente.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TipoAccidenteBE pItem)
        {
            try
            {
                TipoAccidenteDL TipoAccidente = new TipoAccidenteDL();
                TipoAccidente.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
