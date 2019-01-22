using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class SolicitudEppBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        public List<SolicitudEppBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            try
            {
                SolicitudEppDL SolicitudEpp = new SolicitudEppDL();
                return SolicitudEpp.ListaTodosActivo(IdEmpresa, IdUnidadMinera,IdArea);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<SolicitudEppBE> ListaFecha(int IdEmpresa, int IdUnidadMinera, int IdArea, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                SolicitudEppDL SolicitudEpp = new SolicitudEppDL();
                return SolicitudEpp.ListaFecha(IdEmpresa, IdUnidadMinera, IdArea, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<SolicitudEppBE> ListaResponsable(int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdResponsable)
        {
            try
            {
                SolicitudEppDL SolicitudEpp = new SolicitudEppDL();
                return SolicitudEpp.ListaResponsable(IdEmpresaResponsable, IdUnidadMineraResponsable, IdAreaResponsable, IdResponsable);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<SolicitudEppBE> ListaFechaResponsable(int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdResponsable, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                SolicitudEppDL SolicitudEpp = new SolicitudEppDL();
                return SolicitudEpp.ListaFechaResponsable(IdEmpresaResponsable, IdUnidadMineraResponsable,  IdAreaResponsable, IdResponsable, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<SolicitudEppBE> ListaNumero(int Numero)
        {
            try
            {
                SolicitudEppDL SolicitudEpp = new SolicitudEppDL();
                return SolicitudEpp.ListaNumero(Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<SolicitudEppBE> ListaPorVencer(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            try
            {
                SolicitudEppDL SolicitudEpp = new SolicitudEppDL();
                return SolicitudEpp.ListaPorVencer(IdEmpresa, IdUnidadMinera, IdArea);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<SolicitudEppBE> ListaVencido(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            try
            {
                SolicitudEppDL SolicitudEpp = new SolicitudEppDL();
                return SolicitudEpp.ListaVencido(IdEmpresa, IdUnidadMinera, IdArea);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public SolicitudEppBE Selecciona(int IdSolicitudEpp)
        {
            try
            {
                SolicitudEppDL SolicitudEpp = new SolicitudEppDL();
                SolicitudEppBE objEmp = SolicitudEpp.Selecciona(IdSolicitudEpp);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public SolicitudEppBE SeleccionaNumero(int Numero)
        {
            try
            {
                SolicitudEppDL SolicitudEpp = new SolicitudEppDL();
                SolicitudEppBE objEmp = SolicitudEpp.SeleccionaNumero(Numero);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 Inserta(SolicitudEppBE pItem, List<SolicitudEppDetalleBE> pListaSolicitudEppDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SolicitudEppDL SolicitudEpp = new SolicitudEppDL();
                    SolicitudEppDetalleDL SolicitudEppDetalle = new SolicitudEppDetalleDL();

                    int IdSolicitudEpp = 0;
                    IdSolicitudEpp = SolicitudEpp.Inserta(pItem);

                    foreach (var item in pListaSolicitudEppDetalle)
                    {
                        item.IdSolicitudEpp = IdSolicitudEpp;
                        SolicitudEppDetalle.Inserta(item);                        
                    }

                    ts.Complete();

                    return IdSolicitudEpp;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(SolicitudEppBE pItem, List<SolicitudEppDetalleBE> pListaSolicitudEppDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SolicitudEppDL SolicitudEpp = new SolicitudEppDL();
                    SolicitudEppDetalleDL SolicitudEppDetalle = new SolicitudEppDetalleDL();

                    foreach (SolicitudEppDetalleBE item in pListaSolicitudEppDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {

                            item.IdSolicitudEpp = pItem.IdSolicitudEpp;
                            SolicitudEppDetalle.Inserta(item);
                        }
                        else
                        {

                            SolicitudEppDetalle.Actualiza(item);
                        }
                    }

                    SolicitudEpp.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaNumero(int IdSolicitudEpp, string Numero)
        {
            try
            {
                SolicitudEppDL SolicitudEpp = new SolicitudEppDL();
                SolicitudEpp.ActualizaNumero(IdSolicitudEpp, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaSituacion(int IdSolicitudEpp, int IdSituacion)
        {
            try
            {
                SolicitudEppDL SolicitudEpp = new SolicitudEppDL();
                SolicitudEpp.ActualizaSituacion(IdSolicitudEpp, IdSituacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(SolicitudEppBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SolicitudEppDL SolicitudEpp = new SolicitudEppDL();
                    SolicitudEppDetalleDL SolicitudEppDetalle = new SolicitudEppDetalleDL();

                    List<SolicitudEppDetalleBE> lstSolicitudEppDetalle = null;
                    lstSolicitudEppDetalle = new SolicitudEppDetalleDL().ListaTodosActivo(pItem.IdSolicitudEpp);

                    foreach (SolicitudEppDetalleBE item in lstSolicitudEppDetalle)
                    {
                        SolicitudEppDetalle.Elimina(item);
                    }

                    SolicitudEpp.Elimina(pItem);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }

       
    }
}
