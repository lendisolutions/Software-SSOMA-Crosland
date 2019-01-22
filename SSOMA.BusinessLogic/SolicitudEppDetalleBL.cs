using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class SolicitudEppDetalleBL
    {
        public List<SolicitudEppDetalleBE> ListaTodosActivo(int IdEpp)
        {
            try
            {
                SolicitudEppDetalleDL SolicitudEppDetalle = new SolicitudEppDetalleDL();
                return SolicitudEppDetalle.ListaTodosActivo(IdEpp);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public SolicitudEppDetalleBE Selecciona(int IdSolicitudEppDetalle)
        {
            try
            {
                SolicitudEppDetalleDL SolicitudEppDetalle = new SolicitudEppDetalleDL();
                SolicitudEppDetalleBE objEmp = SolicitudEppDetalle.Selecciona(IdSolicitudEppDetalle);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(SolicitudEppDetalleBE pItem)
        {
            try
            {
                SolicitudEppDetalleDL SolicitudEppDetalle = new SolicitudEppDetalleDL();
                SolicitudEppDetalle.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(SolicitudEppDetalleBE pItem)
        {
            try
            {
                SolicitudEppDetalleDL SolicitudEppDetalle = new SolicitudEppDetalleDL();
                SolicitudEppDetalle.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(SolicitudEppDetalleBE pItem)
        {
            try
            {
                SolicitudEppDetalleDL SolicitudEppDetalle = new SolicitudEppDetalleDL();
                SolicitudEppDetalle.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
