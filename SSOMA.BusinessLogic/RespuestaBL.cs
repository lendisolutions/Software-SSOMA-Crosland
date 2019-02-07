using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class RespuestaBL
    {
        public List<RespuestaBE> ListaTodosActivo(int IdPregunta)
        {
            try
            {
                RespuestaDL Respuesta = new RespuestaDL();
                return Respuesta.ListaTodosActivo(IdPregunta);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public RespuestaBE Selecciona(int IdRespuesta)
        {
            try
            {
                RespuestaDL Respuesta = new RespuestaDL();
                RespuestaBE objEmp = Respuesta.Selecciona(IdRespuesta);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(RespuestaBE pItem)
        {
            try
            {
                RespuestaDL Respuesta = new RespuestaDL();
                Respuesta.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(RespuestaBE pItem)
        {
            try
            {
                RespuestaDL Respuesta = new RespuestaDL();
                Respuesta.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(RespuestaBE pItem)
        {
            try
            {
                RespuestaDL Respuesta = new RespuestaDL();
                Respuesta.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
