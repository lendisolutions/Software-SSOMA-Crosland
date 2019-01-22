using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class SctrBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        public List<SctrBE> ListaTodosActivo(int IdEmpresa, int IdPersona)
        {
            try
            {
                SctrDL Sctr = new SctrDL();
                return Sctr.ListaTodosActivo(IdEmpresa, IdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public List<SctrBE> ListaFecha(int IdEmpresa, int IdPersona, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                SctrDL Sctr = new SctrDL();
                return Sctr.ListaFecha(IdEmpresa, IdPersona, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public List<SctrBE> ListaNumero(int Numero)
        {
            try
            {
                SctrDL Sctr = new SctrDL();
                return Sctr.ListaNumero(Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public SctrBE Selecciona(int IdSctr)
        {
            try
            {
                SctrDL Sctr = new SctrDL();
                SctrBE objEmp = Sctr.Selecciona(IdSctr);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public SctrBE SeleccionaNumero(int Numero)
        {
            try
            {
                SctrDL Sctr = new SctrDL();
                SctrBE objEmp = Sctr.SeleccionaNumero(Numero);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 Inserta(SctrBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SctrDL Sctr = new SctrDL();

                    int IdSctr = 0;
                    IdSctr = Sctr.Inserta(pItem);

                    ts.Complete();

                    return IdSctr;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(SctrBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SctrDL Sctr = new SctrDL();
                    Sctr.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaNumero(int IdSctr, string Numero)
        {
            try
            {
                SctrDL Sctr = new SctrDL();
                Sctr.ActualizaNumero(IdSctr, Numero);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaSituacion(int IdSctr, int IdSituacion)
        {
            try
            {
                SctrDL Sctr = new SctrDL();
                Sctr.ActualizaSituacion(IdSctr, IdSituacion);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(SctrBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    SctrDL Sctr = new SctrDL();
                    Sctr.Elimina(pItem);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
