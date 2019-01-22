using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class MovimientoExtintorBL
    {
        public List<MovimientoExtintorBE> ListaTodosActivo(int IdEmpresa, int IdUnidadMinera)
        {
            try
            {
                MovimientoExtintorDL MovimientoExtintor = new MovimientoExtintorDL();
                return MovimientoExtintor.ListaTodosActivo(IdEmpresa, IdUnidadMinera);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public List<MovimientoExtintorBE> ListaFecha(int IdEmpresa, int IdUnidadMinera, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                MovimientoExtintorDL MovimientoExtintor = new MovimientoExtintorDL();
                return MovimientoExtintor.ListaFecha(IdEmpresa, IdUnidadMinera, FechaDesde, FechaHasta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<MovimientoExtintorBE> ListaArea(int IdEmpresa, int IdUnidadMinera, int IdArea)
        {
            try
            {
                MovimientoExtintorDL MovimientoExtintor = new MovimientoExtintorDL();
                return MovimientoExtintor.ListaArea(IdEmpresa, IdUnidadMinera, IdArea);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<MovimientoExtintorBE> ListaCodigo(string Codigo)
        {
            try
            {
                MovimientoExtintorDL MovimientoExtintor = new MovimientoExtintorDL();
                return MovimientoExtintor.ListaCodigo(Codigo);
            }
            catch (Exception ex)
            { throw ex; }
        }


        public MovimientoExtintorBE Selecciona(int IdMovimientoExtintor)
        {
            try
            {
                MovimientoExtintorDL MovimientoExtintor = new MovimientoExtintorDL();
                MovimientoExtintorBE objEmp = MovimientoExtintor.Selecciona(IdMovimientoExtintor);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public MovimientoExtintorBE SeleccionaCodigo(string Codigo)
        {
            try
            {
                MovimientoExtintorDL MovimientoExtintor = new MovimientoExtintorDL();
                MovimientoExtintorBE objEmp = MovimientoExtintor.SeleccionaCodigo(Codigo);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public Int32 Inserta(MovimientoExtintorBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    MovimientoExtintorDL MovimientoExtintor = new MovimientoExtintorDL();


                    int IdMovimientoExtintor = 0;
                    IdMovimientoExtintor = MovimientoExtintor.Inserta(pItem);


                    ts.Complete();

                    return IdMovimientoExtintor;
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(MovimientoExtintorBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    MovimientoExtintorDL MovimientoExtintor = new MovimientoExtintorDL();
                    MovimientoExtintor.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(MovimientoExtintorBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    MovimientoExtintorDL MovimientoExtintor = new MovimientoExtintorDL();
                    MovimientoExtintor.Elimina(pItem);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
