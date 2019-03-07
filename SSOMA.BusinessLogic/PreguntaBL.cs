using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class PreguntaBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        public List<PreguntaBE> ListaTodosActivo(int IdEmpresa, int IdTema, int IdCuestionario)
        {
            try
            {
                PreguntaDL Pregunta = new PreguntaDL();
                return Pregunta.ListaTodosActivo(IdEmpresa, IdTema, IdCuestionario);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<PreguntaBE> ListaEvaluacion(int IdEmpresa, int IdTema, int IdCuestionario)
        {
            try
            {
                PreguntaDL Pregunta = new PreguntaDL();
                return Pregunta.ListaEvaluacion(IdEmpresa, IdTema, IdCuestionario);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public PreguntaBE Selecciona(int IdEmpresa, int IdPregunta)
        {
            try
            {
                PreguntaDL Pregunta = new PreguntaDL();
                PreguntaBE objEmp = Pregunta.Selecciona(IdEmpresa, IdPregunta);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(PreguntaBE pItem, List<RespuestaBE> pListaRespuesta)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PreguntaDL Pregunta = new PreguntaDL();
                    RespuestaDL Respuesta = new RespuestaDL();

                    int intIdPregunta = 0;
                    intIdPregunta = Pregunta.Inserta(pItem);

                    foreach (var item in pListaRespuesta)
                    {
                        item.IdPregunta = intIdPregunta;
                        Respuesta.Inserta(item);
                    }

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(PreguntaBE pItem, List<RespuestaBE> pListaRespuesta)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PreguntaDL Pregunta = new PreguntaDL();
                    RespuestaDL Respuesta = new RespuestaDL();

                    foreach (RespuestaBE item in pListaRespuesta)
                    {
                        if (item.TipoOper == Convert.ToInt32(Operacion.Nuevo)) //Nuevo
                        {
                            item.IdPregunta = pItem.IdPregunta;
                            Respuesta.Inserta(item);
                        }
                        else
                        {
                            Respuesta.Actualiza(item);
                        }
                    }

                    Pregunta.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        
        public void Elimina(PreguntaBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    PreguntaDL Pregunta = new PreguntaDL();
                    RespuestaDL Respuesta = new RespuestaDL();

                    List<RespuestaBE> lstRespuesta = null;
                    lstRespuesta = new RespuestaDL().ListaTodosActivo(pItem.IdPregunta);

                    foreach (RespuestaBE item in lstRespuesta)
                    {
                        Respuesta.Elimina(item);
                    }

                    Pregunta.Elimina(pItem);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
