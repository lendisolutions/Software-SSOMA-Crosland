using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class TemaDetalleBL
    {
        public List<TemaDetalleBE> ListaTodosActivo(int IdTema)
        {
            try
            {
                TemaDetalleDL TemaDetalle = new TemaDetalleDL();
                return TemaDetalle.ListaTodosActivo(IdTema);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TemaDetalleBE Selecciona(int IdTemaDetalle)
        {
            try
            {
                TemaDetalleDL TemaDetalle = new TemaDetalleDL();
                TemaDetalleBE objEmp = TemaDetalle.Selecciona(IdTemaDetalle);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(TemaDetalleBE pItem)
        {
            try
            {
                TemaDetalleDL TemaDetalle = new TemaDetalleDL();
                TemaDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(TemaDetalleBE pItem)
        {
            try
            {
                TemaDetalleDL TemaDetalle = new TemaDetalleDL();
                TemaDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TemaDetalleBE pItem)
        {
            try
            {
                TemaDetalleDL TemaDetalle = new TemaDetalleDL();
                TemaDetalle.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
