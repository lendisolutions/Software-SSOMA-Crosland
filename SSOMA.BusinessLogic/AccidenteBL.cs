using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class AccidenteBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        public List<AccidenteBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            try
            {
                AccidenteDL Accidente = new AccidenteDL();
                return Accidente.ListaTodosActivo(IdEmpresa, IdUnidadMinera, IdArea);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<AccidenteBE> ListaFecha(int IdEmpresa, int IdUnidadMinera, int IdArea, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                AccidenteDL Accidente = new AccidenteDL();
                return Accidente.ListaFecha(IdEmpresa, IdUnidadMinera, IdArea, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<AccidenteBE> ListaResponsable(int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdResponsable)
        {
            try
            {
                AccidenteDL Accidente = new AccidenteDL();
                return Accidente.ListaResponsable(IdEmpresaResponsable, IdUnidadMineraResponsable, IdAreaResponsable, IdResponsable);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<AccidenteBE> ListaFechaResponsable(int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdResponsable, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                AccidenteDL Accidente = new AccidenteDL();
                return Accidente.ListaFechaResponsable(IdEmpresaResponsable, IdUnidadMineraResponsable, IdAreaResponsable, IdResponsable, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<AccidenteBE> ListaTipo(int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdTipo, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                AccidenteDL Accidente = new AccidenteDL();
                return Accidente.ListaTipo(IdEmpresaResponsable, IdUnidadMineraResponsable, IdAreaResponsable, IdTipo, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<AccidenteBE> ListaPotencialDanio(int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdPotenciaDanio, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                AccidenteDL Accidente = new AccidenteDL();
                return Accidente.ListaPotencialDanio(IdEmpresaResponsable, IdUnidadMineraResponsable, IdAreaResponsable, IdPotenciaDanio, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<AccidenteBE> ListaEmpresaContratista(int IdEmpresaContratista, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                AccidenteDL Accidente = new AccidenteDL();
                return Accidente.ListaEmpresaContratista(IdEmpresaContratista, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<AccidenteBE> ListaSeguimiento(int IdEmpresaResponsable, int IdUnidadMineraResponsable, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                AccidenteDL Accidente = new AccidenteDL();
                return Accidente.ListaSeguimiento(IdEmpresaResponsable, IdUnidadMineraResponsable, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public int SeleccionaTipoNumeroMensual(int IdEmpresa, int IdTipo, int Periodo, int Mes)
        {
            try
            {
                AccidenteDL Accidente = new AccidenteDL();
                return Accidente.SeleccionaTipoNumeroMensual(IdEmpresa, IdTipo, Periodo, Mes);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public int SeleccionaTipoNumeroAnual(int IdEmpresa, int IdTipo, int Periodo)
        {
            try
            {
                AccidenteDL Accidente = new AccidenteDL();
                return Accidente.SeleccionaTipoNumeroAnual(IdEmpresa, IdTipo, Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<AccidenteBE> ListaUnidadMineraMensual(int IdEmpresa, int IdTipo, int Periodo, int Mes)
        {
            try
            {
                AccidenteDL Accidente = new AccidenteDL();
                return Accidente.ListaUnidadMineraMensual(IdEmpresa, IdTipo, Periodo, Mes);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<AccidenteBE> ListaSectorMensual(int IdEmpresa, int IdTipo, int Periodo, int Mes)
        {
            try
            {
                AccidenteDL Accidente = new AccidenteDL();
                return Accidente.ListaSectorMensual(IdEmpresa, IdTipo, Periodo, Mes);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public int SeleccionaDiasPerdidosMensual(int IdEmpresa, int IdTipo, int Periodo, int Mes)
        {
            try
            {
                AccidenteDL Accidente = new AccidenteDL();
                return Accidente.SeleccionaDiasPerdidosMensual(IdEmpresa, IdTipo, Periodo, Mes);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public int SeleccionaDiasPerdidosAnual(int IdEmpresa, int IdTipo, int Periodo)
        {
            try
            {
                AccidenteDL Accidente = new AccidenteDL();
                return Accidente.SeleccionaDiasPerdidosAnual(IdEmpresa, IdTipo, Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<AccidenteBE> ListaNumero(int Numero)
        {
            try
            {
                AccidenteDL Accidente = new AccidenteDL();
                return Accidente.ListaNumero(Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        
        public AccidenteBE Selecciona(int IdAccidente)
        {
            try
            {
                AccidenteDL Accidente = new AccidenteDL();
                AccidenteBE objEmp = Accidente.Selecciona(IdAccidente);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public AccidenteBE SeleccionaNumero(int Numero)
        {
            try
            {
                AccidenteDL Accidente = new AccidenteDL();
                AccidenteBE objEmp = Accidente.SeleccionaNumero(Numero);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public AccidenteBE SeleccionaReporte(int IdAccidente)
        {
            try
            {
                AccidenteDL Accidente = new AccidenteDL();
                AccidenteBE objEmp = Accidente.SeleccionaReporte(IdAccidente);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 Inserta(AccidenteBE pItem, AccidenteCostoBE pAccidenteCosto, List<AccidenteFotoBE> pListaAccidenteFoto, List<AccidenteActoSubEstandarBE> pListaAccidenteActoSubEstandar, List<AccidenteCondicionSubEstandarBE> pListaAccidenteCondicionSubEstandar, List<AccidenteFactorPersonalBE> pListaAccidenteFactorPersonal, List<AccidenteFactorTrabajoBE> pListaAccidenteFactorTrabajo, List<AccidenteMedidaPrevencionBE> pListaAccidenteMedidaPrevencion, List<AccidenteAccionCorrectivaBE> pListaAccidenteAccionCorrectiva, List<AccidenteTestigoBE> pListaAccidenteTestigo, List<AccidenteEntrevistadoBE> pListaAccidenteEntrevistado, List<AccidenteDocumentoBE> pListaAccidenteDocumento)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    AccidenteDL Accidente = new AccidenteDL();
                    AccidenteCostoDL AccidenteCosto = new AccidenteCostoDL();
                    AccidenteFotoDL AccidenteFoto = new AccidenteFotoDL();
                    AccidenteActoSubEstandarDL AccidenteActoSubEstandar = new AccidenteActoSubEstandarDL();
                    AccidenteCondicionSubEstandarDL AccidenteCondicionSubEstandar = new AccidenteCondicionSubEstandarDL();
                    AccidenteFactorPersonalDL AccidenteFactorPersonal = new AccidenteFactorPersonalDL();
                    AccidenteFactorTrabajoDL AccidenteFactorTrabajo = new AccidenteFactorTrabajoDL();
                    AccidenteMedidaPrevencionDL AccidenteMedidaPrevencion = new AccidenteMedidaPrevencionDL();
                    AccidenteAccionCorrectivaDL AccidenteAccionCorrectiva = new AccidenteAccionCorrectivaDL();
                    AccidenteTestigoDL AccidenteTestigo = new AccidenteTestigoDL();
                    AccidenteEntrevistadoDL AccidenteEntrevistado = new AccidenteEntrevistadoDL();
                    AccidenteDocumentoDL AccidenteDocumento = new AccidenteDocumentoDL();
                   
                    int IdAccidente = 0;
                    IdAccidente = Accidente.Inserta(pItem);

                    pAccidenteCosto.IdAccidente = IdAccidente;
                    AccidenteCosto.Inserta(pAccidenteCosto);

                    foreach (var item in pListaAccidenteFoto)
                    {
                        item.IdAccidente = IdAccidente;
                        AccidenteFoto.Inserta(item);
                    }

                    foreach (var item in pListaAccidenteActoSubEstandar)
                    {
                        item.IdAccidente = IdAccidente;
                        AccidenteActoSubEstandar.Inserta(item);
                    }

                    foreach (var item in pListaAccidenteCondicionSubEstandar)
                    {
                        item.IdAccidente = IdAccidente;
                        AccidenteCondicionSubEstandar.Inserta(item);
                    }

                    foreach (var item in pListaAccidenteFactorPersonal)
                    {
                        item.IdAccidente = IdAccidente;
                        AccidenteFactorPersonal.Inserta(item);
                    }

                    foreach (var item in pListaAccidenteFactorTrabajo)
                    {
                        item.IdAccidente = IdAccidente;
                        AccidenteFactorTrabajo.Inserta(item);
                    }

                    foreach (var item in pListaAccidenteMedidaPrevencion)
                    {
                        item.IdAccidente = IdAccidente;
                        AccidenteMedidaPrevencion.Inserta(item);
                    }

                    foreach (var item in pListaAccidenteAccionCorrectiva)
                    {
                        item.IdAccidente = IdAccidente;
                        AccidenteAccionCorrectiva.Inserta(item);
                    }

                    foreach (var item in pListaAccidenteTestigo)
                    {
                        item.IdAccidente = IdAccidente;
                        AccidenteTestigo.Inserta(item);
                    }

                    foreach (var item in pListaAccidenteEntrevistado)
                    {
                        item.IdAccidente = IdAccidente;
                        AccidenteEntrevistado.Inserta(item);
                    }

                    foreach (var item in pListaAccidenteDocumento)
                    {
                        item.IdAccidente = IdAccidente;
                        AccidenteDocumento.Inserta(item);
                    }

                    ts.Complete();

                    return IdAccidente;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(AccidenteBE pItem, AccidenteCostoBE pAccidenteCosto, List<AccidenteFotoBE> pListaAccidenteFoto, List<AccidenteActoSubEstandarBE> pListaAccidenteActoSubEstandar, List<AccidenteCondicionSubEstandarBE> pListaAccidenteCondicionSubEstandar, List<AccidenteFactorPersonalBE> pListaAccidenteFactorPersonal, List<AccidenteFactorTrabajoBE> pListaAccidenteFactorTrabajo, List<AccidenteMedidaPrevencionBE> pListaAccidenteMedidaPrevencion, List<AccidenteAccionCorrectivaBE> pListaAccidenteAccionCorrectiva, List<AccidenteTestigoBE> pListaAccidenteTestigo, List<AccidenteEntrevistadoBE> pListaAccidenteEntrevistado, List<AccidenteDocumentoBE> pListaAccidenteDocumento)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    AccidenteDL Accidente = new AccidenteDL();
                    AccidenteCostoDL AccidenteCosto = new AccidenteCostoDL();
                    AccidenteFotoDL AccidenteFoto = new AccidenteFotoDL();
                    AccidenteActoSubEstandarDL AccidenteActoSubEstandar = new AccidenteActoSubEstandarDL();
                    AccidenteCondicionSubEstandarDL AccidenteCondicionSubEstandar = new AccidenteCondicionSubEstandarDL();
                    AccidenteFactorPersonalDL AccidenteFactorPersonal = new AccidenteFactorPersonalDL();
                    AccidenteFactorTrabajoDL AccidenteFactorTrabajo = new AccidenteFactorTrabajoDL();
                    AccidenteMedidaPrevencionDL AccidenteMedidaPrevencion = new AccidenteMedidaPrevencionDL();
                    AccidenteAccionCorrectivaDL AccidenteAccionCorrectiva = new AccidenteAccionCorrectivaDL();
                    AccidenteTestigoDL AccidenteTestigo = new AccidenteTestigoDL();
                    AccidenteEntrevistadoDL AccidenteEntrevistado = new AccidenteEntrevistadoDL();
                    AccidenteDocumentoDL AccidenteDocumento = new AccidenteDocumentoDL();


                    AccidenteCosto.Actualiza(pAccidenteCosto);

                    foreach (AccidenteFotoBE item in pListaAccidenteFoto)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {

                            item.IdAccidente = pItem.IdAccidente;
                            AccidenteFoto.Inserta(item);
                        }
                        else
                        {

                            AccidenteFoto.Actualiza(item);
                        }
                    }

                    foreach (AccidenteActoSubEstandarBE item in pListaAccidenteActoSubEstandar)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {

                            item.IdAccidente = pItem.IdAccidente;
                            AccidenteActoSubEstandar.Inserta(item);
                        }
                        else
                        {

                            AccidenteActoSubEstandar.Actualiza(item);
                        }
                    }

                    foreach (AccidenteCondicionSubEstandarBE item in pListaAccidenteCondicionSubEstandar)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {

                            item.IdAccidente = pItem.IdAccidente;
                            AccidenteCondicionSubEstandar.Inserta(item);
                        }
                        else
                        {

                            AccidenteCondicionSubEstandar.Actualiza(item);
                        }
                    }

                    foreach (AccidenteFactorPersonalBE item in pListaAccidenteFactorPersonal)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {

                            item.IdAccidente = pItem.IdAccidente;
                            AccidenteFactorPersonal.Inserta(item);
                        }
                        else
                        {

                            AccidenteFactorPersonal.Actualiza(item);
                        }
                    }

                    foreach (AccidenteFactorTrabajoBE item in pListaAccidenteFactorTrabajo)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {

                            item.IdAccidente = pItem.IdAccidente;
                            AccidenteFactorTrabajo.Inserta(item);
                        }
                        else
                        {

                            AccidenteFactorTrabajo.Actualiza(item);
                        }
                    }

                    foreach (AccidenteMedidaPrevencionBE item in pListaAccidenteMedidaPrevencion)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {

                            item.IdAccidente = pItem.IdAccidente;
                            AccidenteMedidaPrevencion.Inserta(item);
                        }
                        else
                        {

                            AccidenteMedidaPrevencion.Actualiza(item);
                        }
                    }

                    foreach (AccidenteAccionCorrectivaBE item in pListaAccidenteAccionCorrectiva)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {

                            item.IdAccidente = pItem.IdAccidente;
                            AccidenteAccionCorrectiva.Inserta(item);
                        }
                        else
                        {

                            AccidenteAccionCorrectiva.Actualiza(item);
                        }
                    }

                    foreach (AccidenteTestigoBE item in pListaAccidenteTestigo)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {

                            item.IdAccidente = pItem.IdAccidente;
                            AccidenteTestigo.Inserta(item);
                        }
                        else
                        {

                            AccidenteTestigo.Actualiza(item);
                        }
                    }

                    foreach (AccidenteEntrevistadoBE item in pListaAccidenteEntrevistado)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {

                            item.IdAccidente = pItem.IdAccidente;
                            AccidenteEntrevistado.Inserta(item);
                        }
                        else
                        {

                            AccidenteEntrevistado.Actualiza(item);
                        }
                    }

                    foreach (AccidenteDocumentoBE item in pListaAccidenteDocumento)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {

                            item.IdAccidente = pItem.IdAccidente;
                            AccidenteDocumento.Inserta(item);
                        }
                        else
                        {

                            AccidenteDocumento.Actualiza(item);
                        }
                    }

                    Accidente.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaNumero(int IdAccidente, string Numero)
        {
            try
            {
                AccidenteDL Accidente = new AccidenteDL();
                Accidente.ActualizaNumero(IdAccidente, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(AccidenteBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    AccidenteDL Accidente = new AccidenteDL();
                    AccidenteCostoDL AccidenteCosto = new AccidenteCostoDL();
                    AccidenteFotoDL AccidenteFoto = new AccidenteFotoDL();
                    AccidenteActoSubEstandarDL AccidenteActoSubEstandar = new AccidenteActoSubEstandarDL();
                    AccidenteCondicionSubEstandarDL AccidenteCondicionSubEstandar = new AccidenteCondicionSubEstandarDL();
                    AccidenteFactorPersonalDL AccidenteFactorPersonal = new AccidenteFactorPersonalDL();
                    AccidenteFactorTrabajoDL AccidenteFactorTrabajo = new AccidenteFactorTrabajoDL();
                    AccidenteMedidaPrevencionDL AccidenteMedidaPrevencion = new AccidenteMedidaPrevencionDL();
                    AccidenteAccionCorrectivaDL AccidenteAccionCorrectiva = new AccidenteAccionCorrectivaDL();
                    AccidenteTestigoDL AccidenteTestigo = new AccidenteTestigoDL();
                    AccidenteEntrevistadoDL AccidenteEntrevistado = new AccidenteEntrevistadoDL();
                    AccidenteDocumentoDL AccidenteDocumento = new AccidenteDocumentoDL();


                    List<AccidenteFotoBE> lstAccidenteFoto = null;
                    lstAccidenteFoto = new AccidenteFotoDL().ListaTodosActivo(pItem.IdAccidente);

                    foreach (AccidenteFotoBE item in lstAccidenteFoto)
                    {
                        AccidenteFoto.Elimina(item);
                    }

                    List<AccidenteActoSubEstandarBE> lstAccidenteActoSubEstandar = null;
                    lstAccidenteActoSubEstandar = new AccidenteActoSubEstandarDL().ListaTodosActivo(pItem.IdAccidente);

                    foreach (AccidenteActoSubEstandarBE item in lstAccidenteActoSubEstandar)
                    {
                        AccidenteActoSubEstandar.Elimina(item);
                    }

                    List<AccidenteCondicionSubEstandarBE> lstAccidenteCondicionSubEstandar = null;
                    lstAccidenteCondicionSubEstandar = new AccidenteCondicionSubEstandarDL().ListaTodosActivo(pItem.IdAccidente);

                    foreach (AccidenteCondicionSubEstandarBE item in lstAccidenteCondicionSubEstandar)
                    {
                        AccidenteCondicionSubEstandar.Elimina(item);
                    }

                    List<AccidenteFactorPersonalBE> lstAccidenteFactorPersonal = null;
                    lstAccidenteFactorPersonal = new AccidenteFactorPersonalDL().ListaTodosActivo(pItem.IdAccidente);

                    foreach (AccidenteFactorPersonalBE item in lstAccidenteFactorPersonal)
                    {
                        AccidenteFactorPersonal.Elimina(item);
                    }

                    List<AccidenteFactorTrabajoBE> lstAccidenteFactorTrabajo = null;
                    lstAccidenteFactorTrabajo = new AccidenteFactorTrabajoDL().ListaTodosActivo(pItem.IdAccidente);

                    foreach (AccidenteFactorTrabajoBE item in lstAccidenteFactorTrabajo)
                    {
                        AccidenteFactorTrabajo.Elimina(item);
                    }

                    List<AccidenteMedidaPrevencionBE> lstAccidenteMedidaPrevencion = null;
                    lstAccidenteMedidaPrevencion = new AccidenteMedidaPrevencionDL().ListaTodosActivo(pItem.IdAccidente);

                    foreach (AccidenteMedidaPrevencionBE item in lstAccidenteMedidaPrevencion)
                    {
                        AccidenteMedidaPrevencion.Elimina(item);
                    }

                    List<AccidenteAccionCorrectivaBE> lstAccidenteAccionCorrectiva = null;
                    lstAccidenteAccionCorrectiva = new AccidenteAccionCorrectivaDL().ListaTodosActivo(pItem.IdAccidente);

                    foreach (AccidenteAccionCorrectivaBE item in lstAccidenteAccionCorrectiva)
                    {
                        AccidenteAccionCorrectiva.Elimina(item);
                    }

                    List<AccidenteTestigoBE> lstAccidenteTestigo = null;
                    lstAccidenteTestigo = new AccidenteTestigoDL().ListaTodosActivo(pItem.IdAccidente);

                    foreach (AccidenteTestigoBE item in lstAccidenteTestigo)
                    {
                        AccidenteTestigo.Elimina(item);
                    }

                    List<AccidenteEntrevistadoBE> lstAccidenteEntrevistado = null;
                    lstAccidenteEntrevistado = new AccidenteEntrevistadoDL().ListaTodosActivo(pItem.IdAccidente);

                    foreach (AccidenteEntrevistadoBE item in lstAccidenteEntrevistado)
                    {
                        AccidenteEntrevistado.Elimina(item);
                    }

                    List<AccidenteDocumentoBE> lstAccidenteDocumento = null;
                    lstAccidenteDocumento = new AccidenteDocumentoDL().ListaTodosActivo(pItem.IdAccidente);

                    foreach (AccidenteDocumentoBE item in lstAccidenteDocumento)
                    {
                        AccidenteDocumento.Elimina(item);
                    }

                    Accidente.Elimina(pItem);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
