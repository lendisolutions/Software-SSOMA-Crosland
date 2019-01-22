using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class EppBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        public List<EppBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            try
            {
                EppDL Epp = new EppDL();
                return Epp.ListaTodosActivo(IdEmpresa, IdUnidadMinera, IdArea);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<EppBE> ListaFecha(int IdEmpresa, int IdUnidadMinera, int IdArea, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                EppDL Epp = new EppDL();
                return Epp.ListaFecha(IdEmpresa, IdUnidadMinera, IdArea, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<EppBE> ListaResponsable(int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdResponsable)
        {
            try
            {
                EppDL Epp = new EppDL();
                return Epp.ListaResponsable(IdEmpresaResponsable, IdUnidadMineraResponsable, IdAreaResponsable, IdResponsable);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<EppBE> ListaFechaResponsable(int IdEmpresaResponsable, int IdUnidadMineraResponsable, int IdAreaResponsable, int IdResponsable, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                EppDL Epp = new EppDL();
                return Epp.ListaFechaResponsable(IdEmpresaResponsable, IdUnidadMineraResponsable, IdAreaResponsable, IdResponsable, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<EppBE> ListaNumero(int Numero)
        {
            try
            {
                EppDL Epp = new EppDL();
                return Epp.ListaNumero(Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<EppBE> ListaPorVencer(int IdEmpresa, int IdUnidadMinera, int IdArea, int Dias)
        {
            try
            {
                EppDL Epp = new EppDL();
                return Epp.ListaPorVencer(IdEmpresa, IdUnidadMinera, IdArea, Dias);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<EppBE> ListaVencido(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            try
            {
                EppDL Epp = new EppDL();
                return Epp.ListaVencido(IdEmpresa, IdUnidadMinera, IdArea);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public EppBE Selecciona(int IdEpp)
        {
            try
            {
                EppDL Epp = new EppDL();
                EppBE objEmp = Epp.Selecciona(IdEpp);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public EppBE SeleccionaNumero(int Numero)
        {
            try
            {
                EppDL Epp = new EppDL();
                EppBE objEmp = Epp.SeleccionaNumero(Numero);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 Inserta(EppBE pItem, List<EppDetalleBE> pListaEppDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    EppDL Epp = new EppDL();
                    EppDetalleDL EppDetalle = new EppDetalleDL();

                    int IdEpp = 0;
                    IdEpp = Epp.Inserta(pItem);

                    string strNumero = "";
                    strNumero = AgregarCaracter(IdEpp.ToString(), "0", 7);

                    foreach (var item in pListaEppDetalle)
                    {
                        int IdKardex = 0;
                        //INSERTAR KARDEX
                        KardexBE objE_Kardex = new KardexBE();
                        objE_Kardex.IdKardex = 0;
                        objE_Kardex.IdEmpresa = pItem.IdEmpresaResponsable;
                        objE_Kardex.IdUnidadMinera = pItem.IdUnidadMineraResponsable;
                        objE_Kardex.DescOrdenInterna = pItem.DescOrdenInterna;
                        objE_Kardex.IdEquipo = item.IdEquipo;
                        objE_Kardex.Periodo = pItem.Fecha.Year;
                        objE_Kardex.FechaMovimiento = Convert.ToDateTime(pItem.Fecha);
                        objE_Kardex.Cantidad = item.Cantidad;
                        objE_Kardex.NumeroDocumento = strNumero;
                        objE_Kardex.Observacion = "SALIDA POR ENTREGA DE EPP";
                        objE_Kardex.TipoMovimiento = "S";
                        objE_Kardex.FlagEstado = true;
                        objE_Kardex.Usuario = pItem.Usuario;
                        objE_Kardex.Maquina = pItem.Maquina;

                        KardexDL objDL_Kardex = new KardexDL();
                        IdKardex = objDL_Kardex.Inserta(objE_Kardex);


                        item.IdEpp = IdEpp;
                        item.IdKardex = IdKardex;
                        EppDetalle.Inserta(item);
                    }

                    //Actualizamos la solicitud del EPP
                    SolicitudEppDL objDL_SolicitudEPP = new SolicitudEppDL();
                    objDL_SolicitudEPP.ActualizaSituacion(pItem.IdSolicitudEpp, Parametros.intSLCAtendido);

                    
                    ts.Complete();

                    return IdEpp;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(EppBE pItem, List<EppDetalleBE> pListaEppDetalle)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    EppDL Epp = new EppDL();
                    EppDetalleDL EppDetalle = new EppDetalleDL();

                    foreach (EppDetalleBE item in pListaEppDetalle)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {

                            item.IdEpp = pItem.IdEpp;
                            EppDetalle.Inserta(item);
                        }
                        else
                        {

                            EppDetalle.Actualiza(item);
                        }
                    }

                    Epp.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaNumero(int IdEpp, string Numero)
        {
            try
            {
                EppDL Epp = new EppDL();
                Epp.ActualizaNumero(IdEpp, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(EppBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    EppDL Epp = new EppDL();
                    EppDetalleDL EppDetalle = new EppDetalleDL();

                    EppBE objE_Epp = new EppBE();
                    objE_Epp = Epp.Selecciona(pItem.IdEpp);

                    List<EppDetalleBE> lstEppDetalle = null;
                    lstEppDetalle = new EppDetalleDL().ListaTodosActivo(pItem.IdEpp);

                    foreach (EppDetalleBE item in lstEppDetalle)
                    {
                        int IdKardex = 0;
                        //Insertar Kardex
                        KardexBE objE_Kardex = new KardexBE();
                        objE_Kardex.IdKardex = 0;
                        objE_Kardex.IdEmpresa = objE_Epp.IdEmpresaResponsable;
                        objE_Kardex.IdUnidadMinera = objE_Epp.IdUnidadMineraResponsable;
                        objE_Kardex.DescOrdenInterna = objE_Epp.DescOrdenInterna;
                        objE_Kardex.IdEquipo = item.IdEquipo;
                        objE_Kardex.Periodo = objE_Epp.Fecha.Year;
                        objE_Kardex.FechaMovimiento = Convert.ToDateTime(objE_Epp.Fecha);
                        objE_Kardex.Cantidad = item.Cantidad;
                        objE_Kardex.NumeroDocumento = objE_Epp.Numero;
                        objE_Kardex.Observacion = "INGRESO POR ANULACIÓN DE ENTREGA DE EPP";
                        objE_Kardex.TipoMovimiento = "I";
                        objE_Kardex.FlagEstado = true;
                        objE_Kardex.Usuario = pItem.Usuario;
                        objE_Kardex.Maquina = pItem.Maquina;

                        KardexDL objDL_Kardex = new KardexDL();
                        IdKardex = objDL_Kardex.Inserta(objE_Kardex);

                        EppDetalle.Elimina(item);
                    }

                    Epp.Elimina(pItem);

                    //Actualizamos la solicitud del EPP
                    SolicitudEppDL objDL_SolicitudEPP = new SolicitudEppDL();
                    objDL_SolicitudEPP.ActualizaSituacion(pItem.IdSolicitudEpp, Parametros.intSLCPendiente);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }

        public static string AgregarCaracter(string cadena, string caracter, int digitos)
        {
            string nuevo = "";
            for (int i = 0; i < digitos; i++)
            {
                if (i == 0)
                    nuevo = caracter + cadena;
                else
                    nuevo = caracter + nuevo;
            }
            return nuevo.Substring(nuevo.Length - digitos, digitos);
        }
    }
}
