using System;
using System.Collections.Generic;
using System.Text;
using SSOMA.BusinessEntity;
using SSOMA.DataLogic;
using System.Data;
using System.Transactions;

namespace SSOMA.BusinessLogic
{
    public class ProbabilidadBL
    {
        public List<ProbabilidadBE> ListaTodosActivo(int IdEmpresa)
        {
            try
            {
                ProbabilidadDL Probabilidad = new ProbabilidadDL();
                return Probabilidad.ListaTodosActivo(IdEmpresa);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public ProbabilidadBE Selecciona(int IdProbabilidad)
        {
            try
            {
                ProbabilidadDL Probabilidad = new ProbabilidadDL();
                ProbabilidadBE objEmp = Probabilidad.Selecciona(IdProbabilidad);
                return objEmp;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Inserta(ProbabilidadBE pItem)
        {
            try
            {
                ProbabilidadDL Probabilidad = new ProbabilidadDL();
                Probabilidad.Inserta(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Actualiza(ProbabilidadBE pItem)
        {
            try
            {
                ProbabilidadDL Probabilidad = new ProbabilidadDL();
                Probabilidad.Actualiza(pItem);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public void Elimina(ProbabilidadBE pItem)
        {
            try
            {
                ProbabilidadDL Probabilidad = new ProbabilidadDL();
                Probabilidad.Elimina(pItem);

            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
