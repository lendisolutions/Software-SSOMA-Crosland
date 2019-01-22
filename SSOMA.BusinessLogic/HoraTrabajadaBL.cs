using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class HoraTrabajadaBL
    {
        public List<HoraTrabajadaBE> ListaTodosActivo(int Periodo)
        {
            try
            {
                HoraTrabajadaDL HoraTrabajada = new HoraTrabajadaDL();
                return HoraTrabajada.ListaTodosActivo(Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(List<HoraTrabajadaBE> pListaHoraTrabajada)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    HoraTrabajadaDL objHoraTrabajada = new HoraTrabajadaDL();

                    foreach (HoraTrabajadaBE item in pListaHoraTrabajada)
                    {
                        objHoraTrabajada.Actualiza(item);

                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int SeleccionaHora(int IdEmpresa, int Periodo, int Mes)
        {
            try
            {
                HoraTrabajadaDL HoraTrabajada = new HoraTrabajadaDL();
                return HoraTrabajada.SeleccionaHora(IdEmpresa, Periodo, Mes);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(int Periodo, int Mes)
        {
            try
            {
                HoraTrabajadaDL HoraTrabajada = new HoraTrabajadaDL();
                HoraTrabajada.Elimina(Periodo,Mes);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
