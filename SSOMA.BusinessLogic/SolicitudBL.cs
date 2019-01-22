using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;


namespace SSOMA.BusinessLogic
{
    public class SolicitudBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        public List<SolicitudBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            try
            {
                SolicitudDL Solicitud = new SolicitudDL();
                return Solicitud.ListaTodosActivo(IdEmpresa, IdUnidadMinera, IdArea);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<SolicitudBE> ListaFecha(int IdEmpresa, int IdUnidadMinera, int IdArea, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                SolicitudDL Solicitud = new SolicitudDL();
                return Solicitud.ListaFecha(IdEmpresa, IdUnidadMinera, IdArea, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        
        public List<SolicitudBE> ListaNumero(int Numero)
        {
            try
            {
                SolicitudDL Solicitud = new SolicitudDL();
                return Solicitud.ListaNumero(Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        
        public SolicitudBE Selecciona(int IdSolicitud)
        {
            try
            {
                SolicitudDL Solicitud = new SolicitudDL();
                SolicitudBE objEmp = Solicitud.Selecciona(IdSolicitud);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public SolicitudBE SeleccionaNumero(int Numero)
        {
            try
            {
                SolicitudDL Solicitud = new SolicitudDL();
                SolicitudBE objEmp = Solicitud.SeleccionaNumero(Numero);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 Inserta(SolicitudBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SolicitudDL Solicitud = new SolicitudDL();
                  
                    int IdSolicitud = 0;
                    IdSolicitud = Solicitud.Inserta(pItem);

                    ts.Complete();

                    return IdSolicitud;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(SolicitudBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SolicitudDL Solicitud = new SolicitudDL();
                    Solicitud.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaNumero(int IdSolicitud, string Numero)
        {
            try
            {
                SolicitudDL Solicitud = new SolicitudDL();
                Solicitud.ActualizaNumero(IdSolicitud, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaSituacion(int IdSolicitud, int IdSituacion)
        {
            try
            {
                SolicitudDL Solicitud = new SolicitudDL();
                Solicitud.ActualizaSituacion(IdSolicitud, IdSituacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(SolicitudBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SolicitudDL Solicitud = new SolicitudDL();
                    Solicitud.Elimina(pItem);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
