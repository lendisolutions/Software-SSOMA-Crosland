using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class ExtintorBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        public List<ExtintorBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera)
        {
            try
            {
                ExtintorDL Extintor = new ExtintorDL();
                return Extintor.ListaTodosActivo(IdEmpresa, IdUnidadMinera);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ExtintorBE> ListaCombo(int IdEmpresa, int IdUnidadMinera)
        {
            try
            {
                ExtintorDL Extintor = new ExtintorDL();
                return Extintor.ListaCombo(IdEmpresa, IdUnidadMinera);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ExtintorBE> ListaFecha(int IdEmpresa, int IdUnidadMinera, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                ExtintorDL Extintor = new ExtintorDL();
                return Extintor.ListaFecha(IdEmpresa, IdUnidadMinera, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public List<ExtintorBE> ListaCodigo(string Codigo)
        {
            try
            {
                ExtintorDL Extintor = new ExtintorDL();
                return Extintor.ListaCodigo(Codigo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ExtintorBE> ListaPorVencer(int IdEmpresa, int IdUnidadMinera, int Dias)
        {
            try
            {
                ExtintorDL Extintor = new ExtintorDL();
                return Extintor.ListaPorVencer(IdEmpresa, IdUnidadMinera, Dias);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ExtintorBE> ListaVencido(int IdEmpresa, int IdUnidadMinera)
        {
            try
            {
                ExtintorDL Extintor = new ExtintorDL();
                return Extintor.ListaVencido(IdEmpresa, IdUnidadMinera);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ExtintorBE> ListaTipoServicio(int IdEmpresa, int IdUnidadMinera)
        {
            try
            {
                ExtintorDL Extintor = new ExtintorDL();
                return Extintor.ListaTipoServicio(IdEmpresa, IdUnidadMinera);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ExtintorBE> ListaInspeccionDetalle(int IdEmpresa, int IdUnidadMinera)
        {
            try
            {
                ExtintorDL Extintor = new ExtintorDL();
                return Extintor.ListaInspeccionDetalle(IdEmpresa, IdUnidadMinera);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public ExtintorBE Selecciona(int IdExtintor)
        {
            try
            {
                ExtintorDL Extintor = new ExtintorDL();
                ExtintorBE objEmp = Extintor.Selecciona(IdExtintor);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ExtintorBE SeleccionaCodigo(string Codigo)
        {
            try
            {
                ExtintorDL Extintor = new ExtintorDL();
                ExtintorBE objEmp = Extintor.SeleccionaCodigo(Codigo);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 Inserta(ExtintorBE pItem, List<ExtintorDetalleBE> pListaExtintorDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ExtintorDL Extintor = new ExtintorDL();
                    ExtintorDetalleDL ExtintorDetalle = new ExtintorDetalleDL();

                    int IdExtintor = 0;
                    IdExtintor = Extintor.Inserta(pItem);

                    foreach (var item in pListaExtintorDetalle)
                    {
                        item.IdExtintor = IdExtintor;
                        ExtintorDetalle.Inserta(item);
                    }

                    ts.Complete();

                    return IdExtintor;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ExtintorBE pItem, List<ExtintorDetalleBE> pListaExtintorDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ExtintorDL Extintor = new ExtintorDL();
                    ExtintorDetalleDL ExtintorDetalle = new ExtintorDetalleDL();

                    foreach (ExtintorDetalleBE item in pListaExtintorDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {

                            item.IdExtintor = pItem.IdExtintor;
                            ExtintorDetalle.Inserta(item);
                        }
                        else
                        {

                            ExtintorDetalle.Actualiza(item);
                        }
                    }

                    Extintor.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ExtintorBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ExtintorDL Extintor = new ExtintorDL();
                    ExtintorDetalleDL ExtintorDetalle = new ExtintorDetalleDL();

                    List<ExtintorDetalleBE> lstExtintorDetalle = null;
                    lstExtintorDetalle = new ExtintorDetalleDL().ListaTodosActivo(pItem.IdExtintor);

                    foreach (ExtintorDetalleBE item in lstExtintorDetalle)
                    {
                        ExtintorDetalle.Elimina(item);
                    }

                    Extintor.Elimina(pItem);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
