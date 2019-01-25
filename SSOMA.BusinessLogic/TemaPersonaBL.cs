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

        public void Actualiza(List<TemaPersonaBE> pListaTemaPersona, int IdTema, string Usuario, string Maquina)
        {
            try
            {
                TemaPersonaDL TemaPersona = new TemaPersonaDL();

                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (TemaPersonaBE item in pListaTemaPersona)
                    {
                        if (item.IdTemaPersona == 0 && item.FlagMatricula == true) //INSERTAR Tema PERSONA
                        {
                            TemaPersonaBE objE_TemaPersona = new TemaPersonaBE();
                            objE_TemaPersona.IdEmpresa = item.IdEmpresa;
                            objE_TemaPersona.IdTemaPersona = item.IdTemaPersona;
                            objE_TemaPersona.IdPersona = item.IdPersona;
                            objE_TemaPersona.IdTema = IdTema;
                            objE_TemaPersona.FlagMatricula = item.FlagMatricula;
                            objE_TemaPersona.FlagEstado = true;
                            objE_TemaPersona.Usuario = Usuario;
                            objE_TemaPersona.Maquina = Maquina;

                            TemaPersona.Inserta(objE_TemaPersona);

                        }

                        if (item.IdTemaPersona > 0 && item.FlagMatricula == true) //ACTUALIZAR Tema PERSONA
                        {
                            TemaPersonaBE objE_TemaPersona = new TemaPersonaBE();
                            objE_TemaPersona.IdEmpresa = item.IdEmpresa;
                            objE_TemaPersona.IdTemaPersona = item.IdTemaPersona;
                            objE_TemaPersona.IdPersona = item.IdPersona;
                            objE_TemaPersona.IdTema = IdTema;
                            objE_TemaPersona.FlagMatricula = item.FlagMatricula;
                            objE_TemaPersona.FlagEstado = true;
                            objE_TemaPersona.Usuario = Usuario;
                            objE_TemaPersona.Maquina = Maquina;

                            TemaPersona.Actualiza(objE_TemaPersona);

                        }

                        if (item.IdTemaPersona > 0 && item.FlagMatricula == false) //ELIMINAR Tema PERSONA
                        {
                            TemaPersonaBE objE_TemaPersona = new TemaPersonaBE();
                            objE_TemaPersona.IdEmpresa = item.IdEmpresa;
                            objE_TemaPersona.IdTemaPersona = item.IdTemaPersona;
                            objE_TemaPersona.Usuario = Usuario;
                            objE_TemaPersona.Maquina = Maquina;

                            TemaPersona.Elimina(objE_TemaPersona);

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
