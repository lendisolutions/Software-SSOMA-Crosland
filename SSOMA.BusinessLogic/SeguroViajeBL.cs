using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;


namespace SSOMA.BusinessLogic
{
    public class SeguroViajeBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        public List<SeguroViajeBE> ListaTodosActivo(int IdEmpresa, int IdPersona)
        {
            try
            {
                SeguroViajeDL SeguroViaje = new SeguroViajeDL();
                return SeguroViaje.ListaTodosActivo(IdEmpresa, IdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<SeguroViajeBE> ListaFecha(int IdEmpresa, int IdPersona, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                SeguroViajeDL SeguroViaje = new SeguroViajeDL();
                return SeguroViaje.ListaFecha(IdEmpresa, IdPersona, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public List<SeguroViajeBE> ListaNumero(int Numero)
        {
            try
            {
                SeguroViajeDL SeguroViaje = new SeguroViajeDL();
                return SeguroViaje.ListaNumero(Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public SeguroViajeBE Selecciona(int IdSeguroViaje)
        {
            try
            {
                SeguroViajeDL SeguroViaje = new SeguroViajeDL();
                SeguroViajeBE objEmp = SeguroViaje.Selecciona(IdSeguroViaje);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public SeguroViajeBE SeleccionaNumero(int Numero)
        {
            try
            {
                SeguroViajeDL SeguroViaje = new SeguroViajeDL();
                SeguroViajeBE objEmp = SeguroViaje.SeleccionaNumero(Numero);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 Inserta(SeguroViajeBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SeguroViajeDL SeguroViaje = new SeguroViajeDL();

                    int IdSeguroViaje = 0;
                    IdSeguroViaje = SeguroViaje.Inserta(pItem);

                    ts.Complete();

                    return IdSeguroViaje;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(SeguroViajeBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SeguroViajeDL SeguroViaje = new SeguroViajeDL();
                    SeguroViaje.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaNumero(int IdSeguroViaje, string Numero)
        {
            try
            {
                SeguroViajeDL SeguroViaje = new SeguroViajeDL();
                SeguroViaje.ActualizaNumero(IdSeguroViaje, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaSituacion(int IdSeguroViaje, int IdSituacion)
        {
            try
            {
                SeguroViajeDL SeguroViaje = new SeguroViajeDL();
                SeguroViaje.ActualizaSituacion(IdSeguroViaje, IdSituacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(SeguroViajeBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SeguroViajeDL SeguroViaje = new SeguroViajeDL();
                    SeguroViaje.Elimina(pItem);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
