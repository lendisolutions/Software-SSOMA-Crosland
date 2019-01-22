using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;


namespace SSOMA.BusinessLogic
{
    public class TemaBL
    {
        public List<TemaBE> ListaTodosActivo(int IdEmpresa, int Periodo)
        {
            try
            {
                TemaDL Tema = new TemaDL();
                return Tema.ListaTodosActivo(IdEmpresa,Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<TemaBE> ListaCombo(int IdEmpresa, int Periodo)
        {
            try
            {
                TemaDL Tema = new TemaDL();
                return Tema.ListaCombo(IdEmpresa,Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TemaBE Selecciona(int IdEmpresa, int IdTema)
        {
            try
            {
                TemaDL Tema = new TemaDL();
                TemaBE objEmp = Tema.Selecciona(IdEmpresa, IdTema);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TemaBE SeleccionaParametros(string CODUNIDADP, string CODCENTROP)
        {
            try
            {
                TemaDL Tema = new TemaDL();
                TemaBE objEmp = Tema.SeleccionaParametros(CODUNIDADP, CODCENTROP);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(TemaBE pItem)
        {
            try
            {
                TemaDL Tema = new TemaDL();
                Tema.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TemaBE pItem)
        {
            try
            {
                TemaDL Tema = new TemaDL();
                Tema.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TemaBE pItem)
        {
            try
            {
                TemaDL Tema = new TemaDL();
                Tema.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
