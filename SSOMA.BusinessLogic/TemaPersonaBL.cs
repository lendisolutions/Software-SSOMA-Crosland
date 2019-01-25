using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class TemaPersonaBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        public List<TemaPersonaBE> ListaTodosActivo(int IdEmpresa, int IdTema, int IdPersona)
        {
            try
            {
                TemaPersonaDL TemaPersona = new TemaPersonaDL();
                return TemaPersona.ListaTodosActivo(IdEmpresa, IdTema, IdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public TemaPersonaBE Selecciona(int IdTemaPersona)
        {
            try
            {
                TemaPersonaDL TemaPersona = new TemaPersonaDL();
                TemaPersonaBE objEmp = TemaPersona.Selecciona(IdTemaPersona);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(List<TemaPersonaBE> pListaTemaPersona)
        {
            try
            {
                TemaPersonaDL TemaPersona = new TemaPersonaDL();

                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (TemaPersonaBE item in pListaTemaPersona)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            TemaPersona.Inserta(item);
                        }
                        else
                        {
                            TemaPersona.Actualiza(item);
                        }
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(List<TemaPersonaBE> pListaTemaPersona, int IdPersona, string Usuario, string Maquina)
        {
            try
            {
                TemaPersonaDL TemaPersona = new TemaPersonaDL();

                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (TemaPersonaBE item in pListaTemaPersona)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            TemaPersona.Inserta(item);
                        }
                        else
                        {
                            TemaPersona.Actualiza(item);
                        }
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(TemaPersonaBE pItem)
        {
            try
            {
                TemaPersonaDL TemaPersona = new TemaPersonaDL();
                TemaPersona.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
