using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;


namespace SSOMA.BusinessLogic
{
    public class CapacitacionBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        public List<CapacitacionBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                CapacitacionDL Capacitacion = new CapacitacionDL();
                return Capacitacion.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<CapacitacionBE> ListaFecha(int IdEmpresa, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                CapacitacionDL Capacitacion = new CapacitacionDL();
                return Capacitacion.ListaFecha(IdEmpresa,  FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CapacitacionBE> ListaPersonaFecha(int IdPersona, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                CapacitacionDL Capacitacion = new CapacitacionDL();
                return Capacitacion.ListaPersonaFecha(IdPersona, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CapacitacionBE> ListaAprobado(int IdEmpresa, int IdTema)
        {
            try
            {
                CapacitacionDL Capacitacion = new CapacitacionDL();
                return Capacitacion.ListaAprobado(IdEmpresa, IdTema);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CapacitacionBE> ListaDesaprobado(int IdEmpresa, int IdTema)
        {
            try
            {
                CapacitacionDL Capacitacion = new CapacitacionDL();
                return Capacitacion.ListaDesaprobado(IdEmpresa, IdTema);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CapacitacionBE> ListaNumero(int Numero)
        {
            try
            {
                CapacitacionDL Capacitacion = new CapacitacionDL();
                return Capacitacion.ListaNumero(Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CapacitacionBE Selecciona(int IdCapacitacion)
        {
            try
            {
                CapacitacionDL Capacitacion = new CapacitacionDL();
                CapacitacionBE objEmp = Capacitacion.Selecciona(IdCapacitacion);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CapacitacionBE SeleccionaNumero(int Numero)
        {
            try
            {
                CapacitacionDL Capacitacion = new CapacitacionDL();
                CapacitacionBE objEmp = Capacitacion.SeleccionaNumero(Numero);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 Inserta(CapacitacionBE pItem, List<CapacitacionDetalleBE> pListaCapacitacionDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CapacitacionDL Capacitacion = new CapacitacionDL();
                    CapacitacionDetalleDL CapacitacionDetalle = new CapacitacionDetalleDL();

                    int IdCapacitacion = 0;
                    IdCapacitacion = Capacitacion.Inserta(pItem);

                    foreach (var item in pListaCapacitacionDetalle)
                    {
                        item.IdCapacitacion = IdCapacitacion;
                        CapacitacionDetalle.Inserta(item);
                    }

                    ts.Complete();

                    return IdCapacitacion;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(CapacitacionBE pItem, List<CapacitacionDetalleBE> pListaCapacitacionDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CapacitacionDL Capacitacion = new CapacitacionDL();
                    CapacitacionDetalleDL CapacitacionDetalle = new CapacitacionDetalleDL();

                    foreach (CapacitacionDetalleBE item in pListaCapacitacionDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {

                            item.IdCapacitacion = pItem.IdCapacitacion;
                            CapacitacionDetalle.Inserta(item);
                        }
                        else
                        {

                            CapacitacionDetalle.Actualiza(item);
                        }
                    }

                    Capacitacion.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaNumero(int IdCapacitacion, string Numero)
        {
            try
            {
                CapacitacionDL Capacitacion = new CapacitacionDL();
                Capacitacion.ActualizaNumero(IdCapacitacion, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(CapacitacionBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CapacitacionDL Capacitacion = new CapacitacionDL();
                    CapacitacionDetalleDL CapacitacionDetalle = new CapacitacionDetalleDL();

                    List<CapacitacionDetalleBE> lstCapacitacionDetalle = null;
                    lstCapacitacionDetalle = new CapacitacionDetalleDL().ListaTodosActivo(pItem.IdCapacitacion);

                    foreach (CapacitacionDetalleBE item in lstCapacitacionDetalle)
                    {
                        CapacitacionDetalle.Elimina(item);
                    }

                    Capacitacion.Elimina(pItem);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
