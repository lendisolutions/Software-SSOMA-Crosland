using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class TemaDetallePersonaBL
    {
        public List<TemaDetallePersonaBE> ListaTodosActivo(int IdTema, int IdPersona)
        {
            try
            {
                TemaDetallePersonaDL TemaDetallePersona = new TemaDetallePersonaDL();
                return TemaDetallePersona.ListaTodosActivo(IdTema,IdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TemaDetallePersonaBE Selecciona(int IdTemaDetallePersona)
        {
            try
            {
                TemaDetallePersonaDL TemaDetallePersona = new TemaDetallePersonaDL();
                TemaDetallePersonaBE objEmp = TemaDetallePersona.Selecciona(IdTemaDetallePersona);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(TemaDetallePersonaBE pItem)
        {
            try
            {
                TemaDetallePersonaDL TemaDetallePersona = new TemaDetallePersonaDL();
                TemaDetallePersona.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TemaDetallePersonaBE pItem)
        {
            try
            {
                TemaDetallePersonaDL TemaDetallePersona = new TemaDetallePersonaDL();
                TemaDetallePersona.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaSituacion(TemaDetallePersonaBE pItem)
        {
            try
            {
                TemaDetallePersonaDL TemaDetallePersona = new TemaDetallePersonaDL();
                TemaDetallePersona.ActualizaSituacion(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TemaDetallePersonaBE pItem)
        {
            try
            {
                TemaDetallePersonaDL TemaDetallePersona = new TemaDetallePersonaDL();
                TemaDetallePersona.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
