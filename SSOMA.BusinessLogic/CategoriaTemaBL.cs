using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class CategoriaTemaBL
    {
        public List<CategoriaTemaBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                CategoriaTemaDL CategoriaTema = new CategoriaTemaDL();
                return CategoriaTema.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CategoriaTemaBE> ListaCombo(int IdEmpresa)
        {
            try
            {
                CategoriaTemaDL CategoriaTema = new CategoriaTemaDL();
                return CategoriaTema.ListaCombo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CategoriaTemaBE Selecciona(int IdCategoriaTema)
        {
            try
            {
                CategoriaTemaDL CategoriaTema = new CategoriaTemaDL();
                CategoriaTemaBE objEmp = CategoriaTema.Selecciona(IdCategoriaTema);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(CategoriaTemaBE pItem)
        {
            try
            {
                CategoriaTemaDL CategoriaTema = new CategoriaTemaDL();
                CategoriaTema.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(CategoriaTemaBE pItem)
        {
            try
            {
                CategoriaTemaDL CategoriaTema = new CategoriaTemaDL();
                CategoriaTema.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(CategoriaTemaBE pItem)
        {
            try
            {
                CategoriaTemaDL CategoriaTema = new CategoriaTemaDL();
                CategoriaTema.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
