using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class RespuestaPersonaBL
    {
        public List<RespuestaPersonaBE> ListaTodosActivo(int IdEmpresa, int IdTema, int IdCuestionario, int IdPregunta, int IdRespuesta, int IdPersona)
        {
            try
            {
                RespuestaPersonaDL RespuestaPersona = new RespuestaPersonaDL();
                return RespuestaPersona.ListaTodosActivo(IdEmpresa, IdTema, IdCuestionario, IdPregunta, IdRespuesta,IdPersona);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public RespuestaPersonaBE Selecciona(int IdRespuestaPersona)
        {
            try
            {
                RespuestaPersonaDL RespuestaPersona = new RespuestaPersonaDL();
                RespuestaPersonaBE objEmp = RespuestaPersona.Selecciona(IdRespuestaPersona);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(RespuestaPersonaBE pItem)
        {
            try
            {
                RespuestaPersonaDL RespuestaPersona = new RespuestaPersonaDL();
                RespuestaPersona.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(RespuestaPersonaBE pItem)
        {
            try
            {
                RespuestaPersonaDL RespuestaPersona = new RespuestaPersonaDL();
                RespuestaPersona.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(RespuestaPersonaBE pItem)
        {
            try
            {
                RespuestaPersonaDL RespuestaPersona = new RespuestaPersonaDL();
                RespuestaPersona.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
