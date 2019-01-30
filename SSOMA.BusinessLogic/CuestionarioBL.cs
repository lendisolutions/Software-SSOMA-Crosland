using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class CuestionarioBL
    {
        public enum Operacion
        {
            Nuevo = 1,
            Modificar = 2,
            Eliminar = 3,
            Consultar = 4
        }
        public List<CuestionarioBE> ListaTodosActivo(int IdEmpresa, int IdTema)
        {
            try
            {
                CuestionarioDL Cuestionario = new CuestionarioDL();
                return Cuestionario.ListaTodosActivo(IdEmpresa, IdTema);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public List<CuestionarioBE> ListaCombo(int IdEmpresa, int Periodo)
        {
            try
            {
                CuestionarioDL Cuestionario = new CuestionarioDL();
                return Cuestionario.ListaCombo(IdEmpresa, Periodo);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public CuestionarioBE Selecciona(int IdEmpresa, int IdCuestionario)
        {
            try
            {
                CuestionarioDL Cuestionario = new CuestionarioDL();
                CuestionarioBE objEmp = Cuestionario.Selecciona(IdEmpresa, IdCuestionario);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }



        public void Inserta(CuestionarioBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CuestionarioDL Cuestionario = new CuestionarioDL();
                    Cuestionario.Inserta(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(CuestionarioBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CuestionarioDL Cuestionario = new CuestionarioDL();
                    Cuestionario.Actualiza(pItem);

                    ts.Complete();
                }
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void ActualizaSituacion(int IdCuestionario, int IdSituacion)
        {
            try
            {
                CuestionarioDL Cuestionario = new CuestionarioDL();
                Cuestionario.ActualizaSituacion(IdCuestionario, IdSituacion);
            }
            catch (Exception ex)
            { throw ex; }
        }
        public void Elimina(CuestionarioBE pItem)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    CuestionarioDL Cuestionario = new CuestionarioDL();
                    Cuestionario.Elimina(pItem);

                    ts.Complete();
                }

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
