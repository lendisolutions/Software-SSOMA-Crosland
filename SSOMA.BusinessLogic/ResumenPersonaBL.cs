using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class ResumenPersonaBL
    {
        public List<ResumenPersonaBE> ListaTodosActivo(int IdEmpresa, int IdTema, int IdPersona)
        {
            try
            {
                ResumenPersonaDL ResumenPersona = new ResumenPersonaDL();
                return ResumenPersona.ListaTodosActivo(IdEmpresa, IdTema, IdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<ResumenPersonaBE> ListaCursoVirtual(int IdEmpresa, int Periodo, int Idtema)
        {
            try
            {
                ResumenPersonaDL ResumenPersona = new ResumenPersonaDL();
                return ResumenPersona.ListaCursoVirtual(IdEmpresa, Periodo, Idtema);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ResumenPersonaBE Selecciona(int IdResumenPersona)
        {
            try
            {
                ResumenPersonaDL ResumenPersona = new ResumenPersonaDL();
                ResumenPersonaBE objEmp = ResumenPersona.Selecciona(IdResumenPersona);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public int CuentaDesaprobado(int IdEmpresa, int IdPersona, int IdTema)
        {
            try
            {
                ResumenPersonaDL ResumenPersona = new ResumenPersonaDL();
                return ResumenPersona.CuentaDesaprobado(IdEmpresa, IdPersona, IdTema);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ResumenPersonaBE pItem, List<RespuestaPersonaBE> pListaRespuestaPersona)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ResumenPersonaDL ResumenPersona = new ResumenPersonaDL();
                    RespuestaPersonaDL RespuestaPersona = new RespuestaPersonaDL();

                    ResumenPersona.Inserta(pItem);

                    foreach (var item in pListaRespuestaPersona)
                    {
                        RespuestaPersona.Inserta(item);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ResumenPersonaBE pItem, List<RespuestaPersonaBE> pListaRespuestaPersona)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ResumenPersonaDL ResumenPersona = new ResumenPersonaDL();
                    RespuestaPersonaDL RespuestaPersona = new RespuestaPersonaDL();

                    foreach (var item in pListaRespuestaPersona)
                    {
                        RespuestaPersona.Actualiza(item);
                    }

                    ResumenPersona.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }


        public void Elimina(ResumenPersonaBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    ResumenPersonaDL ResumenPersona = new ResumenPersonaDL();
                    RespuestaPersonaDL RespuestaPersona = new RespuestaPersonaDL();

                    List<RespuestaPersonaBE> lstRespuestaPersona = null;
                    lstRespuestaPersona = new RespuestaPersonaDL().ListaTodosActivo(pItem.IdEmpresa,pItem.IdTema, 0,0,0, pItem.IdPersona);

                    foreach (RespuestaPersonaBE item in lstRespuestaPersona)
                    {
                        RespuestaPersona.Elimina(item);
                    }

                    ResumenPersona.Elimina(pItem);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
